/*
 * 2015 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Drawing;

namespace Lupus_Titanium {
    public class CaptureUserActionKVPControl : CaptureKeyValuePairControl {
        public UserAction UserAction { get; private set; }
        public CaptureUserActionKVPControl(UserAction userAction) {
            UserAction = userAction;
            UserAction.OnLabelChanged += UserAction_OnLabelChanged;
            UserAction.OnRequestCountChanged += UserAction_OnRequestCountChanged;

            BackColor = Color.FromArgb(192, 192, 255);
            SetKey();
            SetValue();
        }

        private void UserAction_OnLabelChanged(object sender, EventArgs e) { SetKey(); }
        private void UserAction_OnRequestCountChanged(object sender, EventArgs e) {
            if (SynchronizationContextWrapper.SynchronizationContext != null)
                SynchronizationContextWrapper.SynchronizationContext.Send((state) => SetValue(), null);
        }

        private void SetKey() { Key = (UserAction.Label == string.Empty) ? "Ungrouped requests" : UserAction.Label; }
        private void SetValue() { Value = UserAction.Requests.Count.ToString(); }
    }
}
