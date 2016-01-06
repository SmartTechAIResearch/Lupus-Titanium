/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lupus_Titanium {
    public partial class FilterRequestsPanel : UserControl {
        public event EventHandler UseFilterChanged;

        [Category("FilterRequestsControl")]
        public bool UseFilter {
            get { return chkUseFilter.Checked; }
            set {
                chkUseFilter.CheckedChanged -= chkUseFilter_CheckedChanged;
                chkUseFilter.Checked = value;
                VisualizeFilter();
                if (UseFilterChanged != null)
                    UseFilterChanged(this, new EventArgs());
                chkUseFilter.CheckedChanged += chkUseFilter_CheckedChanged;
            }
        }

        [Category("FilterRequestsControl")]
        public string[] Filter {
            get { return Split(rtxtFilter.Text); }
            set { rtxtFilter.Text = Combine(value); }
        }

        /// <summary>
        /// I still want to have the focused property when this is disabled.
        /// </summary>
        [Category("FilterRequestsControl")]
        public new bool Enabled {
            get { return chkUseFilter.Enabled; }
            set { foreach (Control ctrl in Controls) ctrl.Enabled = value; }
        }

        public FilterRequestsPanel() { InitializeComponent(); }

        private string[] Split(string s) {
            var l = new List<string>();
            string[] arr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i != arr.Length; i++) {
                string part = arr[i].Trim().ToLowerInvariant();
                if (part.Length != 0 && !l.Contains(part)) l.Add(part);
            }
            l.Sort();
            return l.ToArray();
        }
        private string Combine(string[] arr) {
            var sb = new StringBuilder();

            var l = new List<string>();
            for (int i = 0; i != arr.Length; i++) {
                string part = arr[i].Trim().ToLowerInvariant();
                if (part.Length != 0 && !l.Contains(part)) l.Add(part);
            }
            l.Sort();

            if (l.Count != 0)
                for (int i = 0; i != l.Count; i++) {
                    sb.Append(l[i]);
                    sb.Append("  ");
                }

            return sb.ToString();
        }

        private void chkUseFilter_CheckedChanged(object sender, EventArgs e) {
            Filter = Split(rtxtFilter.Text);
            VisualizeFilter();
            if (UseFilterChanged != null)
                UseFilterChanged(this, new EventArgs());
        }
        private void VisualizeFilter() {
            if (UseFilter) {
                chkUseFilter.ForeColor = pnlFilterBorder.BackColor = Color.LimeGreen;
                chkUseFilter.Text = "YEP - Start typing to change the filter";

                if (this.Visible) rtxtFilter.Focus();
            } else {
                chkUseFilter.ForeColor = Color.DarkOrange;
                chkUseFilter.Text = "NOPE";

                pnlFilterBorder.BackColor = SystemColors.Control;
            }
            if (rtxtFilter.Focused) rtxtFilter.Select(rtxtFilter.Text.Length, 0);
        }

        private void rtxtFilter_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                Filter = Split(rtxtFilter.Text);
                VisualizeFilter();
            }
        }

        private void FilterRequestsPanel_EnabledChanged(object sender, EventArgs e) {
            Filter = Split(rtxtFilter.Text);
            VisualizeFilter();
        }

        private void FilterRequestsPanel_VisibleChanged(object sender, EventArgs e) {
            if (this.Visible) this.Focus();
            VisualizeFilter();
        }
    }
}
