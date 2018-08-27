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
    public class CaptureScenarioKVPControl : CaptureKeyValuePairControl {
        public Scenario Scenario { get; private set; }
        public CaptureScenarioKVPControl(Scenario scenario) {
            Scenario = scenario;
            Scenario.OnRequestsChanged += Scenario_OnRequestsChanged;

            BackColor = Color.FromArgb(192, 192, 255);
            Key = "All requests";
            SetValue();
        }

        private void Scenario_OnRequestsChanged(object sender, EventArgs e) {
            if (SynchronizationContextWrapper.SynchronizationContext != null)
                SynchronizationContextWrapper.SynchronizationContext.Send((state) => SetValue(), null);
        }

        private void SetValue() { Value = Scenario.RequestCount.ToString(); }
    }
}
