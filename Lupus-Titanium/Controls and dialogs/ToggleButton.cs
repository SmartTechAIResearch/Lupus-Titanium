using System.Drawing;
using System.Windows.Forms;

namespace Lupus_Titanium {
    public class ToggleButton : CheckBox {
        public ToggleButton() {
            Appearance = Appearance.Button;
            TextAlign = ContentAlignment.MiddleCenter;
            FlatStyle = FlatStyle.Flat;

            this.CheckedChanged += ToggleButton_CheckedChanged;
        }

        private void ToggleButton_CheckedChanged(object sender, System.EventArgs e) {
            FlatStyle = Checked ? FlatStyle.System : FlatStyle.Flat;
        }
    }
}
