namespace Lupus_Titanium {
    partial class FilterRequestsPanel {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.chkUseFilter = new System.Windows.Forms.CheckBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlFilterBorder = new System.Windows.Forms.Panel();
            this.rtxtFilter = new System.Windows.Forms.RichTextBox();
            this.pnlFilterBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkUseFilter
            // 
            this.chkUseFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseFilter.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkUseFilter.Location = new System.Drawing.Point(6, 4);
            this.chkUseFilter.MinimumSize = new System.Drawing.Size(75, 23);
            this.chkUseFilter.Name = "chkUseFilter";
            this.chkUseFilter.Size = new System.Drawing.Size(482, 23);
            this.chkUseFilter.TabIndex = 34;
            this.chkUseFilter.Text = "NOPE";
            this.chkUseFilter.UseVisualStyleBackColor = false;
            this.chkUseFilter.CheckedChanged += new System.EventHandler(this.chkUseFilter_CheckedChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFilter.Location = new System.Drawing.Point(4, 37);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(481, 13);
            this.lblFilter.TabIndex = 35;
            this.lblFilter.Text = "Don\'t capture HTTP requests to the following space-seperated IP addresses and (pa" +
    "rtial) hostnames:";
            // 
            // pnlFilterBorder
            // 
            this.pnlFilterBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilterBorder.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterBorder.Controls.Add(this.rtxtFilter);
            this.pnlFilterBorder.Location = new System.Drawing.Point(6, 53);
            this.pnlFilterBorder.Name = "pnlFilterBorder";
            this.pnlFilterBorder.Padding = new System.Windows.Forms.Padding(1);
            this.pnlFilterBorder.Size = new System.Drawing.Size(482, 80);
            this.pnlFilterBorder.TabIndex = 36;
            // 
            // rtxtFilter
            // 
            this.rtxtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtFilter.Location = new System.Drawing.Point(1, 1);
            this.rtxtFilter.Name = "rtxtFilter";
            this.rtxtFilter.Size = new System.Drawing.Size(480, 78);
            this.rtxtFilter.TabIndex = 31;
            this.rtxtFilter.Text = "";
            this.rtxtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtFilter_KeyDown);
            // 
            // FilterRequestsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlFilterBorder);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.chkUseFilter);
            this.Name = "FilterRequestsPanel";
            this.Size = new System.Drawing.Size(494, 140);
            this.EnabledChanged += new System.EventHandler(this.FilterRequestsPanel_EnabledChanged);
            this.VisibleChanged += new System.EventHandler(this.FilterRequestsPanel_VisibleChanged);
            this.pnlFilterBorder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUseFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlFilterBorder;
        private System.Windows.Forms.RichTextBox rtxtFilter;
    }
}
