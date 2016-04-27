/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using SizingServers.IPC;
using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace Lupus_Titanium_GUI {
    public partial class Main : Form {
        private string _handle;
        /// <summary>
        /// </summary>
        /// <param name="handle">
        /// The handle for communication with a parent process via SizingServers.IPC.
        /// </param>
        public Main(string[] args) {
            InitializeComponent();

            if (args.Length != 0) {
                if (args[0].StartsWith("ipc"))
                    _handle = args[0];
                if (args.Contains("autocapture"))
                    captureControl.StartStopCapturing();
            }
        }

        private void captureControl_StopClicked(object sender, EventArgs e) {
            string flat = captureControl.GetScenarioFlat();
            if (!string.IsNullOrEmpty(flat))
                if (string.IsNullOrEmpty(_handle)) {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK) 
                        using (var sw = new StreamWriter(saveFileDialog.FileName, false)) {
                            sw.Write(flat);
                            sw.Flush();
                        }
                } else {
                    var s = new Sender(_handle);
                    s.Send(flat);
                    s.Dispose();
                }
        }
    }
}
