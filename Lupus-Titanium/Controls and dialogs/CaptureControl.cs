/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Lupus_Titanium {
    /// <summary>
    /// <para>This control links to TitaniumProxy for capturing. It holds a number of other user controls like RequestsInspectorPanel, FindRequestsPanel and FilterRequestsPanel.</para> 
    /// <para>Put this control on you form and suscribe to StartClicked and StopClicked.</para>
    /// <para>Call GetScenarioAsJSON() or GetScenarioFlat() after StopClicked. Or write 'json' or 'flat'(without the quotes) to a tcp stream on 127.0.0.1:9990.</para>
    /// <para>All the other stuff is taken care or.</para>
    /// </summary>
    public partial class CaptureControl : UserControl {
        public event EventHandler StartClicked, StopClicked;

        #region Fields
        private Scenario _scenario;
        private string[] _defaultFilter = { "addthis.com", "cloudflare.com", "facebook.com", "google.com", "google-analytics.com", "googleapis.com", "linkedin.com",
            "m.addthisedge.com", "microsoft.com", "nedstatbasic.net", "gstatic.com", "localhost", "twimg.com", "twitter.com", "youtube.com" };
        private int _RequestSerializerServerPort = 9990;
        #endregion

        #region Properties
        /// <summary>
        /// If Filter == null or empty. This one will be used instead.
        /// </summary>
        [Browsable(false)]
        public string[] DefaultFilter { get { return _defaultFilter; } }

        [Browsable(false)]
        public bool UseFilter {
            get { return filterRequestsPanel.UseFilter; }
            private set { filterRequestsPanel.UseFilter = value; }
        }
        [Browsable(false)]
        public string[] Filter {
            get { return filterRequestsPanel.Filter; }
            private set { filterRequestsPanel.Filter = value; }
        }

        public int RequestSerializerServerPort {
            get { return _RequestSerializerServerPort; }
            set { _RequestSerializerServerPort = value; }
        }
        #endregion

        #region Constructor
        public CaptureControl() {
            InitializeComponent();
            this.HandleCreated += CaptureControl_HandleCreated;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Contains all request and response data. Each line in this string represets a request. Suck a line can be used to contruct a new Request(string json). 
        /// </summary>
        public string GetScenarioAsJSON() {
            return _scenario.GetScenarioAsJSON();
        }

        /// <summary>
        /// <para>Only data needed to make a correct http web request is added to the string. One request per line.</para>
        /// <para>Relative url<![CDATA[<16 0C 02 12 $>]]>Request method<![CDATA[<16 0C 02 12 $>]]>Get data (&-delimited KVPs)<![CDATA[<16 0C 02 12 $>]]>Post data (UTF8)<![CDATA[<16 0C 02 12 $>]]>Post data (bytes as hex)</para> 
        /// <para><![CDATA[<16 0C 02 12 $>]]>Content type<![CDATA[<16 0C 02 12 $>]]>Accept<![CDATA[<16 0C 02 12 $>]]>Protocol<![CDATA[<16 0C 02 12 $>]]>Destination host<![CDATA[<16 0C 02 12 $>]]>Destination port</para> 
        /// <para><![CDATA[<16 0C 02 12 $>]]>Offset<![CDATA[<16 0C 02 12 $>]]>Redirects</para> 
        /// </summary>
        public string GetScenarioFlat() {
            return _scenario.GetScenarioFlat();
        }

        private void CaptureControl_HandleCreated(object sender, EventArgs e) {
            this.HandleCreated -= CaptureControl_HandleCreated;
            try {
                var parentForm = this.FindForm();
                if (parentForm != null) {
                    if (parentForm.IsHandleCreated)
                        ParentForm_HandleCreated(ParentForm, null);
                    else
                        parentForm.HandleCreated += ParentForm_HandleCreated;
                }
            } catch {
            }

            InitScenario();
            VisualizeFilter();
        }

        private void ParentForm_HandleCreated(object sender, EventArgs e) {
            (sender as Form).HandleCreated -= ParentForm_HandleCreated;
            LoadProperties();
            SynchronizationContextWrapper.SynchronizationContext = SynchronizationContext.Current;
            ParentForm.FormClosing += ParentForm_FormClosing;
        }

        private void InitScenario() {
            _scenario = new Scenario();

            RequestsSerializerServer.Start(_scenario, RequestSerializerServerPort);

            requestsInspectorPanel.Scenario = _scenario;
            _scenario.Init(flpScenario);
            _scenario.OnRequestsChanged += _scenario_OnRequestsChanged;
            findRequestsPanel.Scenario = _scenario;
            findRequestsPanel.OnFindSelectionChanged += FindRequestsPanel_OnFindSelectionChanged;
        }

        private void _scenario_OnRequestsChanged(object sender, EventArgs e) {
            SynchronizationContextWrapper.SynchronizationContext.Send((state) => {
                tbFind.Visible = _scenario.AllRequests.Count != 0;
            }, null);
        }

        private void FindRequestsPanel_OnFindSelectionChanged(object sender, FindRequestsPanel.OnFindSelectionChangedEventArgs e) {
            requestsInspectorPanel.Find(e.Find, e.Request);
        }

        private void VisualizeFilter() {
            if (UseFilter) {
                tbShowFilter.ForeColor = Color.LimeGreen;
                tbShowFilter.Text = "Filter requests: enabled";
            } else {
                tbShowFilter.ForeColor = Color.DarkOrange;
                tbShowFilter.Text = "Filter requests: disabled";
            }
        }

        private void LoadProperties() {
            UseFilter = Properties.Settings.Default.UseFilter;

            var filter = Properties.Settings.Default.Filter;
            if (filter == null || filter.Count == 0) {
                filter = new StringCollection();
                filter.AddRange(_defaultFilter);
            }
            string[] arr = new string[filter.Count];
            filter.CopyTo(arr, 0);
            Filter = arr;
        }
        private void SaveProperties() {
            Properties.Settings.Default.UseFilter = UseFilter;

            Properties.Settings.Default.Filter = new StringCollection();
            Properties.Settings.Default.Filter.AddRange(Filter);

            Properties.Settings.Default.Save();
        }

        private void btnStartStop_Click(object sender, EventArgs e) {
            if (btnStartStop.Text == "Capture requests") {
                btnStartStop.Text = "Stop capturing";

                _scenario.StartCapturing(UseFilter ? Filter : null);

                btnPauseContinue.Text = "Pause";
                btnPauseContinue.Visible = true;
                filterRequestsPanel.Enabled = false;

                if (StartClicked != null) StartClicked(this, null);
            } else {
                _scenario.StopCapturing();

                if (StopClicked != null) StopClicked(this, null);

                btnStartStop.Text = "Capture requests";

                btnPauseContinue.Visible = false;
                filterRequestsPanel.Enabled = true;
            }
            //filterRequestsPanel.Visible = false;
        }

        private void btnPauseContinue_Click(object sender, EventArgs e) {
            if (btnPauseContinue.Text == "Pause") {
                btnPauseContinue.Text = "Continue";
                if (_scenario != null) _scenario.PauseCapturing();
            } else {
                btnPauseContinue.Text = "Pause";
                if (_scenario != null) _scenario.ContinueCapturing();
            }
        }

        private void tbUseFilter_CheckedChanged(object sender, EventArgs e) {
            VisualizeFilter();
        }

        private void btnTutorial_Click(object sender, EventArgs e) {
            string path = Path.Combine(Application.StartupPath, "Tutorial.txt");
            if (File.Exists(path))
                Process.Start(path);
            else
                MessageBox.Show("Tutorial.txt was not found in the application's folder!\nIf you want the tutorial, you'll have to re-install this app.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tbShowFilter_CheckedChanged(object sender, EventArgs e) {
            filterRequestsPanel.Visible = tbShowFilter.Checked;
            VisualizeFilter();
        }

        private void filterRequestsControl_UseFilterChanged(object sender, EventArgs e) {
            VisualizeFilter();
        }

        private void tbFind_CheckedChanged(object sender, EventArgs e) {
            findRequestsPanel.Visible = tbFind.Checked;
        }

        private void filterRequestsPanel_Leave(object sender, EventArgs e) {
            if (!tbShowFilter.Focused)
                tbShowFilter.Checked = false;
        }

        private void findRequestsPanel_Leave(object sender, EventArgs e) {
            if (!tbFind.Focused)
                tbFind.Checked = false;
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (_scenario != null) _scenario.StopCapturing();
            _scenario = null;
            SaveProperties();
        }

        public void CancelStart() {
            if (btnStartStop.Text == "Stop")
                btnStartStop.PerformClick();
        }
        #endregion
    }
}