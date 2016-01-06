namespace Lupus_Titanium_GUI {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.captureControl = new Lupus_Titanium.CaptureControl();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "TXT files|*.txt";
            this.saveFileDialog.Title = "Select where to export the scenario to a file that vApus can import...";
            // 
            // captureControl
            // 
            this.captureControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.captureControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.captureControl.Location = new System.Drawing.Point(0, 0);
            this.captureControl.Name = "captureControl";
            this.captureControl.Size = new System.Drawing.Size(784, 561);
            this.captureControl.TabIndex = 0;
            this.captureControl.StopClicked += new System.EventHandler(this.captureControl_StopClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.captureControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lupus-Titanium HTTP(s) proxy";
            this.ResumeLayout(false);

        }

        #endregion

        private Lupus_Titanium.CaptureControl captureControl;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

    }
}