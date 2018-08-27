/*
 * 2010 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Lupus_Titanium {
    public partial class CaptureKeyValuePairControl : UserControl {
        public string Key {
            get { return lblKey.Text; }
            set { lblKey.Text = value; }
        }

        public string Value {
            get { return lblValue.Text; }
            set { lblValue.Text = value; }
        }

        [Editor(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof(UITypeEditor))]
        public string Tooltip {
            set {
                value = value.Replace("\\n", "\n").Replace("\\r", "\r");
                toolTip.SetToolTip(this, value);
                toolTip.SetToolTip(lblKey, value);
                toolTip.SetToolTip(lblValue, value);
            }
            get { return toolTip.GetToolTip(this); }
        }

        public CaptureKeyValuePairControl() { InitializeComponent(); }

        public CaptureKeyValuePairControl(string key, string value)
            : this() {
            lblKey.Text = key;
            lblValue.Text = value;
        }

        private void lbl_SizeChanged(object sender, EventArgs e) {
            lblValue.Left = lblKey.Right;
            Width = lblValue.Right + 3;
        }

        private void KeyValuePairControl_SizeChanged(object sender, EventArgs e) {
            lblValue.SizeChanged -= lbl_SizeChanged;
            if (MaximumSize.Width == 0) {
                lblValue.MaximumSize = new Size(int.MaxValue, lblValue.Height);
            } else {
                int difference = lblValue.Right - Width;
                int newWidth = lblValue.Width - difference;
                lblValue.MaximumSize = new Size(newWidth > 0 ? newWidth : int.MaxValue, lblValue.Height);
            }
            lblValue.SizeChanged += lbl_SizeChanged;
        }

        private void lbl_MouseDown(object sender, MouseEventArgs e) { OnMouseDown(e); }

        private void lbl_Click(object sender, EventArgs e) { OnClick(e); }

        public void PerformClick() { OnClick(new EventArgs()); }
    }
}