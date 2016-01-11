namespace Lupus_Titanium {
    partial class CaptureControl {
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
            _initWaitHandle.Set();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnPauseContinue = new System.Windows.Forms.Button();
            this.flpScenario = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnTutorial = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.requestsInspectorPanel = new Lupus_Titanium.Controls_and_dialogs.RequestsInspectorPanel();
            this.findRequestsPanel = new Lupus_Titanium.FindRequestsPanel();
            this.tbFind = new Lupus_Titanium.ToggleButton();
            this.filterRequestsPanel = new Lupus_Titanium.FilterRequestsPanel();
            this.tbShowFilter = new Lupus_Titanium.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.AutoSize = true;
            this.btnStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartStop.BackColor = System.Drawing.Color.White;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartStop.Location = new System.Drawing.Point(3, 3);
            this.btnStartStop.MaximumSize = new System.Drawing.Size(9999, 24);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(115, 24);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Capture requests";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnPauseContinue
            // 
            this.btnPauseContinue.AutoSize = true;
            this.btnPauseContinue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPauseContinue.BackColor = System.Drawing.Color.White;
            this.btnPauseContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPauseContinue.Location = new System.Drawing.Point(257, 3);
            this.btnPauseContinue.MaximumSize = new System.Drawing.Size(9999, 24);
            this.btnPauseContinue.Name = "btnPauseContinue";
            this.btnPauseContinue.Size = new System.Drawing.Size(54, 24);
            this.btnPauseContinue.TabIndex = 4;
            this.btnPauseContinue.Text = "Pause";
            this.btnPauseContinue.UseVisualStyleBackColor = false;
            this.btnPauseContinue.Visible = false;
            this.btnPauseContinue.Click += new System.EventHandler(this.btnPauseContinue_Click);
            // 
            // flpScenario
            // 
            this.flpScenario.BackColor = System.Drawing.Color.White;
            this.flpScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpScenario.Location = new System.Drawing.Point(3, 3);
            this.flpScenario.Name = "flpScenario";
            this.flpScenario.Size = new System.Drawing.Size(794, 44);
            this.flpScenario.TabIndex = 1;
            // 
            // btnTutorial
            // 
            this.btnTutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTutorial.AutoSize = true;
            this.btnTutorial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTutorial.BackColor = System.Drawing.Color.White;
            this.btnTutorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTutorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTutorial.Location = new System.Drawing.Point(735, 3);
            this.btnTutorial.MaximumSize = new System.Drawing.Size(9999, 24);
            this.btnTutorial.Name = "btnTutorial";
            this.btnTutorial.Size = new System.Drawing.Size(62, 24);
            this.btnTutorial.TabIndex = 6;
            this.btnTutorial.Text = "Tutorial";
            this.btnTutorial.UseVisualStyleBackColor = false;
            this.btnTutorial.Click += new System.EventHandler(this.btnTutorial_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 30);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.flpScenario);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.requestsInspectorPanel);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(800, 570);
            this.splitContainer.TabIndex = 41;
            // 
            // requestsInspectorPanel
            // 
            this.requestsInspectorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestsInspectorPanel.Location = new System.Drawing.Point(0, 0);
            this.requestsInspectorPanel.Name = "requestsInspectorPanel";
            this.requestsInspectorPanel.Scenario = null;
            this.requestsInspectorPanel.Size = new System.Drawing.Size(800, 516);
            this.requestsInspectorPanel.TabIndex = 40;
            // 
            // findRequestsPanel
            // 
            this.findRequestsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findRequestsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.findRequestsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findRequestsPanel.Location = new System.Drawing.Point(537, 33);
            this.findRequestsPanel.Name = "findRequestsPanel";
            this.findRequestsPanel.Size = new System.Drawing.Size(260, 35);
            this.findRequestsPanel.TabIndex = 43;
            this.findRequestsPanel.Visible = false;
            this.findRequestsPanel.Leave += new System.EventHandler(this.findRequestsPanel_Leave);
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Appearance = System.Windows.Forms.Appearance.Button;
            this.tbFind.AutoSize = true;
            this.tbFind.BackColor = System.Drawing.Color.White;
            this.tbFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(636, 3);
            this.tbFind.MinimumSize = new System.Drawing.Size(75, 24);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(93, 24);
            this.tbFind.TabIndex = 42;
            this.tbFind.Text = "Find requests";
            this.tbFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbFind.UseVisualStyleBackColor = false;
            this.tbFind.Visible = false;
            this.tbFind.CheckedChanged += new System.EventHandler(this.tbFind_CheckedChanged);
            // 
            // filterRequestsPanel
            // 
            this.filterRequestsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.filterRequestsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterRequestsPanel.Filter = new string[0];
            this.filterRequestsPanel.Location = new System.Drawing.Point(3, 33);
            this.filterRequestsPanel.Name = "filterRequestsPanel";
            this.filterRequestsPanel.Size = new System.Drawing.Size(494, 140);
            this.filterRequestsPanel.TabIndex = 39;
            this.filterRequestsPanel.UseFilter = false;
            this.filterRequestsPanel.Visible = false;
            this.filterRequestsPanel.UseFilterChanged += new System.EventHandler(this.filterRequestsControl_UseFilterChanged);
            this.filterRequestsPanel.Leave += new System.EventHandler(this.filterRequestsPanel_Leave);
            // 
            // tbShowFilter
            // 
            this.tbShowFilter.Appearance = System.Windows.Forms.Appearance.Button;
            this.tbShowFilter.AutoSize = true;
            this.tbShowFilter.BackColor = System.Drawing.Color.White;
            this.tbShowFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbShowFilter.Location = new System.Drawing.Point(124, 3);
            this.tbShowFilter.MinimumSize = new System.Drawing.Size(75, 24);
            this.tbShowFilter.Name = "tbShowFilter";
            this.tbShowFilter.Size = new System.Drawing.Size(127, 24);
            this.tbShowFilter.TabIndex = 2;
            this.tbShowFilter.Text = "Filter requests: disabled";
            this.tbShowFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbShowFilter.UseVisualStyleBackColor = false;
            this.tbShowFilter.CheckedChanged += new System.EventHandler(this.tbShowFilter_CheckedChanged);
            // 
            // CaptureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.findRequestsPanel);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.filterRequestsPanel);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnTutorial);
            this.Controls.Add(this.tbShowFilter);
            this.Controls.Add(this.btnPauseContinue);
            this.Controls.Add(this.btnStartStop);
            this.Name = "CaptureControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnPauseContinue;
        private System.Windows.Forms.FlowLayoutPanel flpScenario;
        private ToggleButton tbShowFilter;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnTutorial;
        private FilterRequestsPanel filterRequestsPanel;
        private Controls_and_dialogs.RequestsInspectorPanel requestsInspectorPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private ToggleButton tbFind;
        private FindRequestsPanel findRequestsPanel;
    }
}