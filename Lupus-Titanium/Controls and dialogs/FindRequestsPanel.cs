/*
 * 2015 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lupus_Titanium {
    public partial class FindRequestsPanel : UserControl {
        /// <summary>
        /// Suscribe to this to do the find in RequestsInspectorPanel.
        /// </summary>
        public event EventHandler<OnFindSelectionChangedEventArgs> OnFindSelectionChanged;

        #region Fields
        private readonly object _lock = new object();

        private System.Timers.Timer _tmrFind;
        private bool _cancelFind;
        private string _find, _previousFind;
        private int _selectedRow = -1;

        private List<Request> _foundRequests = new List<Request>();
        #endregion

        public Scenario Scenario { set; private get; }

        public FindRequestsPanel() {
            InitializeComponent();
        }

        private void pnlFindBorder_Enter(object sender, EventArgs e) {
            rtxtFind.Focus();
        }

        private void FindRequestsPanel_VisibleChanged(object sender, EventArgs e) {
            if (Visible) {
                VisualizeFind(false);

                rtxtFind.Focus();
                rtxtFind.SelectAll();
            }
        }

        private void rtxtFind_TextChanged(object sender, EventArgs e) {
            _cancelFind = true;
            if (_tmrFind != null) _tmrFind.Stop();
            _tmrFind = new System.Timers.Timer();
            _tmrFind.Interval = 500;
            _tmrFind.Elapsed += _tmrFind_Elapsed;
            _find = rtxtFind.Text;
            _cancelFind = false;
            _tmrFind.Start();
        }

        private void _tmrFind_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            if (_tmrFind == null || _cancelFind) return;
            Find(_find);
        }

        private void Find(string find) {
            lock (_lock)
                try {
                    if (_tmrFind != null) {
                        _tmrFind.Stop();
                        _tmrFind = null;
                    }

                    _find = find;
                    if (_find != _previousFind) {
                        _selectedRow = -1;
                        _foundRequests = new List<Request>();

                        if (_find.Length != 0)
                            foreach (Request request in Scenario.AllRequests) {
                                if (_cancelFind) return;

                                if (request.Contains(_find)) _foundRequests.Add(request);
                            }
                    }
                    SynchronizationContextWrapper.SynchronizationContext.Send((state) => {
                        VisualizeFind();
                    }, null);
                    _previousFind = _find;

                }
                catch {
                    //Ignore.
                }
        }

        private void VisualizeFind(bool selectNext = true) {
            dgvFindResults.SelectionChanged -= dgvFindResults_SelectionChanged;
            dgvFindResults.RowEnter -= dgvFindResults_RowEnter;

            if (CleanupDeletedFoundRequests()) {
                _selectedRow = -1;
                selectNext = true;

                dgvFindResults.RowCount = 0;
            }

            int count = _foundRequests.Count;
            if (count == 0) {
                this.Height = 35;
                btnFindNext.Enabled = false;
            }
            else {
                if (selectNext && ++_selectedRow >= count) _selectedRow = 0;

                if (_find != _previousFind)
                    dgvFindResults.RowCount = 0;
                dgvFindResults.RowCount = count;

                try {
                    dgvFindResults.Rows[_selectedRow].Selected = true;
                    dgvFindResults.FirstDisplayedScrollingRowIndex = _selectedRow;
                }
                catch (ArgumentOutOfRangeException) { //Try again.
                    count = _foundRequests.Count;
                    if (_selectedRow >= count) _selectedRow = 0;

                    dgvFindResults.Rows[_selectedRow].Selected = true;
                    dgvFindResults.FirstDisplayedScrollingRowIndex = _selectedRow;
                }

                if (OnFindSelectionChanged != null)
                    OnFindSelectionChanged(this, new OnFindSelectionChangedEventArgs(_find, _foundRequests[_selectedRow]));

                btnFindNext.Enabled = true;
                lblFound.Text = count + " found";
                this.Height = 140;
            }

            dgvFindResults.RowEnter += dgvFindResults_RowEnter;
            dgvFindResults.SelectionChanged += dgvFindResults_SelectionChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True on cleanup done.</returns>
        private bool CleanupDeletedFoundRequests() {
            var foundRequests = new List<Request>();
            if (_foundRequests != null)
                foreach (Request request in _foundRequests) {
                    UserAction parent = request.ParentUserAction;
                    if (parent != null && parent.Requests.Contains(request))
                        foundRequests.Add(request);
                }

            bool cleanup = _foundRequests.Count != foundRequests.Count;
            _foundRequests = foundRequests;
            return cleanup;
        }

        private void btnFindNext_Click(object sender, EventArgs e) { Find(rtxtFind.Text); }
        private void rtxtFind_KeyUp(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) Find(rtxtFind.Text); }

        private void dgvFindResults_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            if (e.RowIndex < _foundRequests.Count) {
                Request request = _foundRequests[e.RowIndex];

                UserAction parent = request.ParentUserAction;
                string parentLabel = parent.Label;
                if (parent.Label.Length == 0) parentLabel = "Ungrouped requests";

                e.Value = parentLabel + " #" + (parent.Requests.IndexOf(request) + 1);
            }
        }

        private void dgvFindResults_RowEnter(object sender, DataGridViewCellEventArgs e) { _selectedRow = e.RowIndex; }
        private void dgvFindResults_SelectionChanged(object sender, EventArgs e) {
            if (OnFindSelectionChanged != null)
                OnFindSelectionChanged(this, new OnFindSelectionChangedEventArgs(_find, _foundRequests[_selectedRow]));
        }

        private void dgvFindResults_Enter(object sender, EventArgs e) {
            dgvFindResults.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvFindResults.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
        }
        private void dgvFindResults_Leave(object sender, EventArgs e) {
            dgvFindResults.DefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            dgvFindResults.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
        }

        public class OnFindSelectionChangedEventArgs : EventArgs {
            public string Find { get; private set; }
            public Request Request { get; private set; }

            public OnFindSelectionChangedEventArgs(string find, Request request) {
                Find = find;
                Request = request;
            }
        }
    }
}
