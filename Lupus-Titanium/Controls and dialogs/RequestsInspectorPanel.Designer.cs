namespace Lupus_Titanium.Controls_and_dialogs {
    partial class RequestsInspectorPanel {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestsInspectorPanel));
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.clmMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripRequests = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCopyRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerInspectors = new System.Windows.Forms.SplitContainer();
            this.splitContainerRequest = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.fctbRequest = new FastColoredTextBoxNS.FastColoredTextBox();
            this.contextMenuStripBodies = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerResponse = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.fctbResponse = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnGroupIntoUserAction = new System.Windows.Forms.Button();
            this.btnClearDelete = new System.Windows.Forms.Button();
            this.pnlLabelBorder = new System.Windows.Forms.Panel();
            this.rtxtLabel = new System.Windows.Forms.RichTextBox();
            this.tsmFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tcRequestBody = new Lupus_Titanium.TabControlWithAdjustableBorders();
            this.tpRequestText = new System.Windows.Forms.TabPage();
            this.fctbRequestBody = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpRequestHex = new System.Windows.Forms.TabPage();
            this.hexBoxRequest = new Be.Windows.Forms.HexBox();
            this.tpRequestRender = new System.Windows.Forms.TabPage();
            this.picRequest = new System.Windows.Forms.PictureBox();
            this.browserRequest = new Lupus_Titanium.WebRenderer();
            this.tcResponseBody = new Lupus_Titanium.TabControlWithAdjustableBorders();
            this.tpResponseText = new System.Windows.Forms.TabPage();
            this.fctbResponseBody = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpResponseHex = new System.Windows.Forms.TabPage();
            this.hexBoxResponse = new Be.Windows.Forms.HexBox();
            this.tpResponseRender = new System.Windows.Forms.TabPage();
            this.picResponse = new System.Windows.Forms.PictureBox();
            this.browserResponse = new Lupus_Titanium.WebRenderer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.contextMenuStripRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInspectors)).BeginInit();
            this.splitContainerInspectors.Panel1.SuspendLayout();
            this.splitContainerInspectors.Panel2.SuspendLayout();
            this.splitContainerInspectors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRequest)).BeginInit();
            this.splitContainerRequest.Panel1.SuspendLayout();
            this.splitContainerRequest.Panel2.SuspendLayout();
            this.splitContainerRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbRequest)).BeginInit();
            this.contextMenuStripBodies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerResponse)).BeginInit();
            this.splitContainerResponse.Panel1.SuspendLayout();
            this.splitContainerResponse.Panel2.SuspendLayout();
            this.splitContainerResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbResponse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlLabelBorder.SuspendLayout();
            this.tcRequestBody.SuspendLayout();
            this.tpRequestText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbRequestBody)).BeginInit();
            this.tpRequestHex.SuspendLayout();
            this.tpRequestRender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRequest)).BeginInit();
            this.tcResponseBody.SuspendLayout();
            this.tpResponseText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbResponseBody)).BeginInit();
            this.tpResponseHex.SuspendLayout();
            this.tpResponseRender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResponse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRequests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMethod,
            this.clmResult,
            this.clmProtocol,
            this.clmHost,
            this.clmUrl});
            this.dgvRequests.ContextMenuStrip = this.contextMenuStripRequests;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequests.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequests.EnableHeadersVisualStyles = false;
            this.dgvRequests.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.dgvRequests.Location = new System.Drawing.Point(0, 0);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequests.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRequests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvRequests.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRequests.Size = new System.Drawing.Size(560, 715);
            this.dgvRequests.TabIndex = 33;
            this.dgvRequests.VirtualMode = true;
            this.dgvRequests.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellEnter);
            this.dgvRequests.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvRequests_CellValueNeeded);
            this.dgvRequests.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRequests_RowPostPaint);
            this.dgvRequests.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvRequests_Scroll);
            this.dgvRequests.Enter += new System.EventHandler(this.dgvRequests_Enter);
            this.dgvRequests.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvRequests_KeyUp);
            this.dgvRequests.Leave += new System.EventHandler(this.dgvRequests_Leave);
            // 
            // clmMethod
            // 
            this.clmMethod.HeaderText = "Method";
            this.clmMethod.Name = "clmMethod";
            this.clmMethod.ReadOnly = true;
            this.clmMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMethod.Width = 53;
            // 
            // clmResult
            // 
            this.clmResult.HeaderText = "Result";
            this.clmResult.Name = "clmResult";
            this.clmResult.ReadOnly = true;
            this.clmResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmResult.Width = 53;
            // 
            // clmProtocol
            // 
            this.clmProtocol.HeaderText = "Protocol";
            this.clmProtocol.Name = "clmProtocol";
            this.clmProtocol.ReadOnly = true;
            this.clmProtocol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmProtocol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmProtocol.Width = 67;
            // 
            // clmHost
            // 
            this.clmHost.HeaderText = "Host";
            this.clmHost.Name = "clmHost";
            this.clmHost.ReadOnly = true;
            this.clmHost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmHost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmHost.Width = 39;
            // 
            // clmUrl
            // 
            this.clmUrl.HeaderText = "Relative Url";
            this.clmUrl.Name = "clmUrl";
            this.clmUrl.ReadOnly = true;
            this.clmUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUrl.Width = 95;
            // 
            // contextMenuStripRequests
            // 
            this.contextMenuStripRequests.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCopyRequests,
            this.tsmDeleteRequests});
            this.contextMenuStripRequests.Name = "contextMenuStripBodies";
            this.contextMenuStripRequests.Size = new System.Drawing.Size(108, 48);
            this.contextMenuStripRequests.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripRequests_Opening);
            // 
            // tsmCopyRequests
            // 
            this.tsmCopyRequests.Name = "tsmCopyRequests";
            this.tsmCopyRequests.Size = new System.Drawing.Size(107, 22);
            this.tsmCopyRequests.Text = "Copy";
            this.tsmCopyRequests.Click += new System.EventHandler(this.tsmCopyRequests_Click);
            // 
            // tsmDeleteRequests
            // 
            this.tsmDeleteRequests.Enabled = false;
            this.tsmDeleteRequests.Name = "tsmDeleteRequests";
            this.tsmDeleteRequests.Size = new System.Drawing.Size(107, 22);
            this.tsmDeleteRequests.Text = "Delete";
            this.tsmDeleteRequests.Click += new System.EventHandler(this.tsmDeleteRequests_Click);
            // 
            // splitContainerInspectors
            // 
            this.splitContainerInspectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInspectors.Location = new System.Drawing.Point(0, 0);
            this.splitContainerInspectors.Name = "splitContainerInspectors";
            this.splitContainerInspectors.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerInspectors.Panel1
            // 
            this.splitContainerInspectors.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerInspectors.Panel1.Controls.Add(this.splitContainerRequest);
            // 
            // splitContainerInspectors.Panel2
            // 
            this.splitContainerInspectors.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerInspectors.Panel2.Controls.Add(this.splitContainerResponse);
            this.splitContainerInspectors.Size = new System.Drawing.Size(556, 715);
            this.splitContainerInspectors.SplitterDistance = 250;
            this.splitContainerInspectors.TabIndex = 1;
            // 
            // splitContainerRequest
            // 
            this.splitContainerRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRequest.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerRequest.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRequest.Name = "splitContainerRequest";
            // 
            // splitContainerRequest.Panel1
            // 
            this.splitContainerRequest.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerRequest.Panel1.Controls.Add(this.label1);
            this.splitContainerRequest.Panel1.Controls.Add(this.fctbRequest);
            // 
            // splitContainerRequest.Panel2
            // 
            this.splitContainerRequest.Panel2.Controls.Add(this.tcRequestBody);
            this.splitContainerRequest.Panel2Collapsed = true;
            this.splitContainerRequest.Size = new System.Drawing.Size(556, 250);
            this.splitContainerRequest.SplitterDistance = 400;
            this.splitContainerRequest.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request";
            // 
            // fctbRequest
            // 
            this.fctbRequest.AllowMacroRecording = false;
            this.fctbRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctbRequest.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbRequest.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.fctbRequest.BackBrush = null;
            this.fctbRequest.CharHeight = 15;
            this.fctbRequest.CharWidth = 7;
            this.fctbRequest.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbRequest.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbRequest.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctbRequest.IsReplaceMode = false;
            this.fctbRequest.Location = new System.Drawing.Point(6, 25);
            this.fctbRequest.Name = "fctbRequest";
            this.fctbRequest.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbRequest.ReadOnly = true;
            this.fctbRequest.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbRequest.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbRequest.ServiceColors")));
            this.fctbRequest.ShowLineNumbers = false;
            this.fctbRequest.Size = new System.Drawing.Size(553, 225);
            this.fctbRequest.TabIndex = 0;
            this.fctbRequest.WordWrap = true;
            this.fctbRequest.Zoom = 100;
            // 
            // contextMenuStripBodies
            // 
            this.contextMenuStripBodies.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFind,
            this.tsmCopy,
            this.toolStripSeparator1,
            this.tsmSelectAll});
            this.contextMenuStripBodies.Name = "contextMenuStripBodies";
            this.contextMenuStripBodies.Size = new System.Drawing.Size(121, 76);
            this.contextMenuStripBodies.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripBodies_Opening);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.Size = new System.Drawing.Size(120, 22);
            this.tsmCopy.Text = "Copy";
            this.tsmCopy.Click += new System.EventHandler(this.tsmCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // tsmSelectAll
            // 
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.Size = new System.Drawing.Size(120, 22);
            this.tsmSelectAll.Text = "Select all";
            this.tsmSelectAll.Click += new System.EventHandler(this.tsmSelectAll_Click);
            // 
            // splitContainerResponse
            // 
            this.splitContainerResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerResponse.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerResponse.Location = new System.Drawing.Point(0, 0);
            this.splitContainerResponse.Name = "splitContainerResponse";
            // 
            // splitContainerResponse.Panel1
            // 
            this.splitContainerResponse.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerResponse.Panel1.Controls.Add(this.label2);
            this.splitContainerResponse.Panel1.Controls.Add(this.fctbResponse);
            // 
            // splitContainerResponse.Panel2
            // 
            this.splitContainerResponse.Panel2.Controls.Add(this.tcResponseBody);
            this.splitContainerResponse.Panel2Collapsed = true;
            this.splitContainerResponse.Size = new System.Drawing.Size(556, 461);
            this.splitContainerResponse.SplitterDistance = 400;
            this.splitContainerResponse.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Response";
            // 
            // fctbResponse
            // 
            this.fctbResponse.AllowMacroRecording = false;
            this.fctbResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctbResponse.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbResponse.AutoIndentCharsPatterns = "";
            this.fctbResponse.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.fctbResponse.BackBrush = null;
            this.fctbResponse.CharHeight = 15;
            this.fctbResponse.CharWidth = 7;
            this.fctbResponse.CommentPrefix = null;
            this.fctbResponse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbResponse.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbResponse.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctbResponse.IsReplaceMode = false;
            this.fctbResponse.LeftBracket = '<';
            this.fctbResponse.LeftBracket2 = '(';
            this.fctbResponse.Location = new System.Drawing.Point(6, 25);
            this.fctbResponse.Name = "fctbResponse";
            this.fctbResponse.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbResponse.ReadOnly = true;
            this.fctbResponse.RightBracket = '>';
            this.fctbResponse.RightBracket2 = ')';
            this.fctbResponse.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbResponse.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbResponse.ServiceColors")));
            this.fctbResponse.ShowLineNumbers = false;
            this.fctbResponse.Size = new System.Drawing.Size(553, 436);
            this.fctbResponse.TabIndex = 2;
            this.fctbResponse.WordWrap = true;
            this.fctbResponse.Zoom = 100;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(3, 44);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvRequests);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainerInspectors);
            this.splitContainer.Size = new System.Drawing.Size(1120, 715);
            this.splitContainer.SplitterDistance = 560;
            this.splitContainer.TabIndex = 41;
            // 
            // btnGroupIntoUserAction
            // 
            this.btnGroupIntoUserAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupIntoUserAction.AutoSize = true;
            this.btnGroupIntoUserAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGroupIntoUserAction.BackColor = System.Drawing.Color.White;
            this.btnGroupIntoUserAction.Enabled = false;
            this.btnGroupIntoUserAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupIntoUserAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupIntoUserAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGroupIntoUserAction.Location = new System.Drawing.Point(1071, 6);
            this.btnGroupIntoUserAction.MaximumSize = new System.Drawing.Size(9999, 24);
            this.btnGroupIntoUserAction.Name = "btnGroupIntoUserAction";
            this.btnGroupIntoUserAction.Size = new System.Drawing.Size(53, 24);
            this.btnGroupIntoUserAction.TabIndex = 42;
            this.btnGroupIntoUserAction.Text = "Group";
            this.btnGroupIntoUserAction.UseVisualStyleBackColor = false;
            this.btnGroupIntoUserAction.Click += new System.EventHandler(this.btnGroupIntoUserAction_Click);
            // 
            // btnClearDelete
            // 
            this.btnClearDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearDelete.AutoSize = true;
            this.btnClearDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearDelete.BackColor = System.Drawing.Color.White;
            this.btnClearDelete.Enabled = false;
            this.btnClearDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearDelete.Location = new System.Drawing.Point(1009, 6);
            this.btnClearDelete.MaximumSize = new System.Drawing.Size(9999, 24);
            this.btnClearDelete.Name = "btnClearDelete";
            this.btnClearDelete.Size = new System.Drawing.Size(56, 24);
            this.btnClearDelete.TabIndex = 43;
            this.btnClearDelete.Text = "Delete";
            this.btnClearDelete.UseVisualStyleBackColor = false;
            this.btnClearDelete.Click += new System.EventHandler(this.btnClearDelete_Click);
            // 
            // pnlLabelBorder
            // 
            this.pnlLabelBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLabelBorder.BackColor = System.Drawing.Color.White;
            this.pnlLabelBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLabelBorder.Controls.Add(this.rtxtLabel);
            this.pnlLabelBorder.Location = new System.Drawing.Point(3, 6);
            this.pnlLabelBorder.Name = "pnlLabelBorder";
            this.pnlLabelBorder.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLabelBorder.Size = new System.Drawing.Size(1000, 24);
            this.pnlLabelBorder.TabIndex = 44;
            this.pnlLabelBorder.Enter += new System.EventHandler(this.pnlLabelBorder_Enter);
            // 
            // rtxtLabel
            // 
            this.rtxtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtLabel.Location = new System.Drawing.Point(4, 4);
            this.rtxtLabel.Multiline = false;
            this.rtxtLabel.Name = "rtxtLabel";
            this.rtxtLabel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtLabel.Size = new System.Drawing.Size(993, 15);
            this.rtxtLabel.TabIndex = 31;
            this.rtxtLabel.Text = "";
            this.rtxtLabel.WordWrap = false;
            this.rtxtLabel.TextChanged += new System.EventHandler(this.rtxtLabel_TextChanged);
            // 
            // tsmFind
            // 
            this.tsmFind.Name = "tsmFind";
            this.tsmFind.Size = new System.Drawing.Size(120, 22);
            this.tsmFind.Text = "Find";
            this.tsmFind.Click += new System.EventHandler(this.tsmFind_Click);
            // 
            // tcRequestBody
            // 
            this.tcRequestBody.BottomVisible = false;
            this.tcRequestBody.Controls.Add(this.tpRequestText);
            this.tcRequestBody.Controls.Add(this.tpRequestHex);
            this.tcRequestBody.Controls.Add(this.tpRequestRender);
            this.tcRequestBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRequestBody.LeftVisible = true;
            this.tcRequestBody.Location = new System.Drawing.Point(0, 0);
            this.tcRequestBody.Name = "tcRequestBody";
            this.tcRequestBody.RightVisible = false;
            this.tcRequestBody.SelectedIndex = 0;
            this.tcRequestBody.Size = new System.Drawing.Size(96, 100);
            this.tcRequestBody.TabIndex = 1;
            this.tcRequestBody.TopVisible = true;
            // 
            // tpRequestText
            // 
            this.tpRequestText.Controls.Add(this.fctbRequestBody);
            this.tpRequestText.Location = new System.Drawing.Point(4, 22);
            this.tpRequestText.Name = "tpRequestText";
            this.tpRequestText.Padding = new System.Windows.Forms.Padding(3);
            this.tpRequestText.Size = new System.Drawing.Size(91, 77);
            this.tpRequestText.TabIndex = 0;
            this.tpRequestText.Text = "Text";
            this.tpRequestText.UseVisualStyleBackColor = true;
            // 
            // fctbRequestBody
            // 
            this.fctbRequestBody.AllowMacroRecording = false;
            this.fctbRequestBody.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbRequestBody.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.fctbRequestBody.BackBrush = null;
            this.fctbRequestBody.CharHeight = 15;
            this.fctbRequestBody.CharWidth = 7;
            this.fctbRequestBody.ContextMenuStrip = this.contextMenuStripBodies;
            this.fctbRequestBody.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbRequestBody.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbRequestBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbRequestBody.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctbRequestBody.IsReplaceMode = false;
            this.fctbRequestBody.Location = new System.Drawing.Point(3, 3);
            this.fctbRequestBody.Name = "fctbRequestBody";
            this.fctbRequestBody.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbRequestBody.ReadOnly = true;
            this.fctbRequestBody.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbRequestBody.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbRequestBody.ServiceColors")));
            this.fctbRequestBody.Size = new System.Drawing.Size(85, 71);
            this.fctbRequestBody.TabIndex = 0;
            this.fctbRequestBody.WordWrap = true;
            this.fctbRequestBody.Zoom = 100;
            // 
            // tpRequestHex
            // 
            this.tpRequestHex.Controls.Add(this.hexBoxRequest);
            this.tpRequestHex.Location = new System.Drawing.Point(4, 22);
            this.tpRequestHex.Name = "tpRequestHex";
            this.tpRequestHex.Padding = new System.Windows.Forms.Padding(3);
            this.tpRequestHex.Size = new System.Drawing.Size(91, 77);
            this.tpRequestHex.TabIndex = 3;
            this.tpRequestHex.Text = "Hex";
            this.tpRequestHex.UseVisualStyleBackColor = true;
            // 
            // hexBoxRequest
            // 
            this.hexBoxRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBoxRequest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBoxRequest.LineInfoVisible = true;
            this.hexBoxRequest.Location = new System.Drawing.Point(3, 3);
            this.hexBoxRequest.Name = "hexBoxRequest";
            this.hexBoxRequest.ReadOnly = true;
            this.hexBoxRequest.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxRequest.Size = new System.Drawing.Size(85, 71);
            this.hexBoxRequest.StringViewVisible = true;
            this.hexBoxRequest.TabIndex = 0;
            this.hexBoxRequest.UseFixedBytesPerLine = true;
            this.hexBoxRequest.VScrollBarVisible = true;
            // 
            // tpRequestRender
            // 
            this.tpRequestRender.AutoScroll = true;
            this.tpRequestRender.BackColor = System.Drawing.Color.White;
            this.tpRequestRender.Controls.Add(this.picRequest);
            this.tpRequestRender.Controls.Add(this.browserRequest);
            this.tpRequestRender.Location = new System.Drawing.Point(4, 22);
            this.tpRequestRender.Name = "tpRequestRender";
            this.tpRequestRender.Padding = new System.Windows.Forms.Padding(3);
            this.tpRequestRender.Size = new System.Drawing.Size(91, 77);
            this.tpRequestRender.TabIndex = 1;
            this.tpRequestRender.Text = "Render";
            // 
            // picRequest
            // 
            this.picRequest.Location = new System.Drawing.Point(3, 3);
            this.picRequest.Name = "picRequest";
            this.picRequest.Size = new System.Drawing.Size(201, 271);
            this.picRequest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRequest.TabIndex = 1;
            this.picRequest.TabStop = false;
            // 
            // browserRequest
            // 
            this.browserRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserRequest.Location = new System.Drawing.Point(3, 3);
            this.browserRequest.Name = "browserRequest";
            this.browserRequest.Size = new System.Drawing.Size(198, 268);
            this.browserRequest.TabIndex = 0;
            // 
            // tcResponseBody
            // 
            this.tcResponseBody.BottomVisible = false;
            this.tcResponseBody.Controls.Add(this.tpResponseText);
            this.tcResponseBody.Controls.Add(this.tpResponseHex);
            this.tcResponseBody.Controls.Add(this.tpResponseRender);
            this.tcResponseBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcResponseBody.LeftVisible = true;
            this.tcResponseBody.Location = new System.Drawing.Point(0, 0);
            this.tcResponseBody.Name = "tcResponseBody";
            this.tcResponseBody.RightVisible = false;
            this.tcResponseBody.SelectedIndex = 0;
            this.tcResponseBody.Size = new System.Drawing.Size(96, 100);
            this.tcResponseBody.TabIndex = 3;
            this.tcResponseBody.TopVisible = true;
            // 
            // tpResponseText
            // 
            this.tpResponseText.Controls.Add(this.fctbResponseBody);
            this.tpResponseText.Location = new System.Drawing.Point(4, 22);
            this.tpResponseText.Name = "tpResponseText";
            this.tpResponseText.Padding = new System.Windows.Forms.Padding(3);
            this.tpResponseText.Size = new System.Drawing.Size(91, 77);
            this.tpResponseText.TabIndex = 0;
            this.tpResponseText.Text = "Text";
            this.tpResponseText.UseVisualStyleBackColor = true;
            // 
            // fctbResponseBody
            // 
            this.fctbResponseBody.AllowMacroRecording = false;
            this.fctbResponseBody.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbResponseBody.AutoIndentCharsPatterns = "";
            this.fctbResponseBody.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.fctbResponseBody.BackBrush = null;
            this.fctbResponseBody.CharHeight = 15;
            this.fctbResponseBody.CharWidth = 7;
            this.fctbResponseBody.CommentPrefix = null;
            this.fctbResponseBody.ContextMenuStrip = this.contextMenuStripBodies;
            this.fctbResponseBody.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbResponseBody.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbResponseBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbResponseBody.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctbResponseBody.IsReplaceMode = false;
            this.fctbResponseBody.LeftBracket = '<';
            this.fctbResponseBody.LeftBracket2 = '(';
            this.fctbResponseBody.Location = new System.Drawing.Point(3, 3);
            this.fctbResponseBody.Name = "fctbResponseBody";
            this.fctbResponseBody.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbResponseBody.ReadOnly = true;
            this.fctbResponseBody.RightBracket = '>';
            this.fctbResponseBody.RightBracket2 = ')';
            this.fctbResponseBody.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbResponseBody.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbResponseBody.ServiceColors")));
            this.fctbResponseBody.Size = new System.Drawing.Size(85, 71);
            this.fctbResponseBody.TabIndex = 2;
            this.fctbResponseBody.WordWrap = true;
            this.fctbResponseBody.Zoom = 100;
            // 
            // tpResponseHex
            // 
            this.tpResponseHex.Controls.Add(this.hexBoxResponse);
            this.tpResponseHex.Location = new System.Drawing.Point(4, 22);
            this.tpResponseHex.Name = "tpResponseHex";
            this.tpResponseHex.Padding = new System.Windows.Forms.Padding(3);
            this.tpResponseHex.Size = new System.Drawing.Size(91, 77);
            this.tpResponseHex.TabIndex = 3;
            this.tpResponseHex.Text = "Hex";
            this.tpResponseHex.UseVisualStyleBackColor = true;
            // 
            // hexBoxResponse
            // 
            this.hexBoxResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBoxResponse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBoxResponse.LineInfoVisible = true;
            this.hexBoxResponse.Location = new System.Drawing.Point(3, 3);
            this.hexBoxResponse.Name = "hexBoxResponse";
            this.hexBoxResponse.ReadOnly = true;
            this.hexBoxResponse.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxResponse.Size = new System.Drawing.Size(85, 71);
            this.hexBoxResponse.StringViewVisible = true;
            this.hexBoxResponse.TabIndex = 1;
            this.hexBoxResponse.UseFixedBytesPerLine = true;
            this.hexBoxResponse.VScrollBarVisible = true;
            // 
            // tpResponseRender
            // 
            this.tpResponseRender.AutoScroll = true;
            this.tpResponseRender.BackColor = System.Drawing.Color.White;
            this.tpResponseRender.Controls.Add(this.picResponse);
            this.tpResponseRender.Controls.Add(this.browserResponse);
            this.tpResponseRender.Location = new System.Drawing.Point(4, 22);
            this.tpResponseRender.Name = "tpResponseRender";
            this.tpResponseRender.Padding = new System.Windows.Forms.Padding(3);
            this.tpResponseRender.Size = new System.Drawing.Size(91, 77);
            this.tpResponseRender.TabIndex = 1;
            this.tpResponseRender.Text = "Render";
            // 
            // picResponse
            // 
            this.picResponse.Location = new System.Drawing.Point(3, 3);
            this.picResponse.Name = "picResponse";
            this.picResponse.Size = new System.Drawing.Size(201, 382);
            this.picResponse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResponse.TabIndex = 1;
            this.picResponse.TabStop = false;
            // 
            // browserResponse
            // 
            this.browserResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserResponse.Location = new System.Drawing.Point(3, 3);
            this.browserResponse.Name = "browserResponse";
            this.browserResponse.Size = new System.Drawing.Size(198, 379);
            this.browserResponse.TabIndex = 0;
            // 
            // RequestsInspectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLabelBorder);
            this.Controls.Add(this.btnGroupIntoUserAction);
            this.Controls.Add(this.btnClearDelete);
            this.Controls.Add(this.splitContainer);
            this.DoubleBuffered = true;
            this.Name = "RequestsInspectorPanel";
            this.Size = new System.Drawing.Size(1127, 762);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.contextMenuStripRequests.ResumeLayout(false);
            this.splitContainerInspectors.Panel1.ResumeLayout(false);
            this.splitContainerInspectors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInspectors)).EndInit();
            this.splitContainerInspectors.ResumeLayout(false);
            this.splitContainerRequest.Panel1.ResumeLayout(false);
            this.splitContainerRequest.Panel1.PerformLayout();
            this.splitContainerRequest.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRequest)).EndInit();
            this.splitContainerRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbRequest)).EndInit();
            this.contextMenuStripBodies.ResumeLayout(false);
            this.splitContainerResponse.Panel1.ResumeLayout(false);
            this.splitContainerResponse.Panel1.PerformLayout();
            this.splitContainerResponse.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerResponse)).EndInit();
            this.splitContainerResponse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbResponse)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlLabelBorder.ResumeLayout(false);
            this.tcRequestBody.ResumeLayout(false);
            this.tpRequestText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbRequestBody)).EndInit();
            this.tpRequestHex.ResumeLayout(false);
            this.tpRequestRender.ResumeLayout(false);
            this.tpRequestRender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRequest)).EndInit();
            this.tcResponseBody.ResumeLayout(false);
            this.tpResponseText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbResponseBody)).EndInit();
            this.tpResponseHex.ResumeLayout(false);
            this.tpResponseRender.ResumeLayout(false);
            this.tpResponseRender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResponse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvRequests;
        private FastColoredTextBoxNS.FastColoredTextBox fctbRequestBody;
        private FastColoredTextBoxNS.FastColoredTextBox fctbResponseBody;
        private TabControlWithAdjustableBorders tcRequestBody;
        private System.Windows.Forms.TabPage tpRequestText;
        private System.Windows.Forms.TabPage tpRequestRender;
        private System.Windows.Forms.SplitContainer splitContainerInspectors;
        private FastColoredTextBoxNS.FastColoredTextBox fctbRequest;
        private FastColoredTextBoxNS.FastColoredTextBox fctbResponse;
        private WebRenderer browserRequest;
        private System.Windows.Forms.PictureBox picRequest;
        private System.Windows.Forms.TabPage tpRequestHex;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitContainerRequest;
        private System.Windows.Forms.SplitContainer splitContainerResponse;
        private TabControlWithAdjustableBorders tcResponseBody;
        private System.Windows.Forms.TabPage tpResponseRender;
        private System.Windows.Forms.PictureBox picResponse;
        private WebRenderer browserResponse;
        private System.Windows.Forms.TabPage tpResponseText;
        private System.Windows.Forms.TabPage tpResponseHex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGroupIntoUserAction;
        private Be.Windows.Forms.HexBox hexBoxRequest;
        private Be.Windows.Forms.HexBox hexBoxResponse;
        private System.Windows.Forms.Button btnClearDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMethod;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBodies;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRequests;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteRequests;
        private System.Windows.Forms.Panel pnlLabelBorder;
        private System.Windows.Forms.RichTextBox rtxtLabel;
        private System.Windows.Forms.ToolStripMenuItem tsmCopyRequests;
        private System.Windows.Forms.ToolStripMenuItem tsmFind;
    }
}
