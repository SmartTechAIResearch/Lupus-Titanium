/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using SizingServers.IPC;
using System;
using System.Windows.Forms;

namespace Lupus_Titanium_GUI {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }

        private void captureControl_StopClicked(object sender, EventArgs e) {
            string json = captureControl.GetScenarioAsJSON();
            if (!string.IsNullOrEmpty(json)) {
                var s = new Sender("Lupus-Titanium");
                s.Send(captureControl.GetScenarioFlat());
                s.Dispose();
            }
        }
    }
}
