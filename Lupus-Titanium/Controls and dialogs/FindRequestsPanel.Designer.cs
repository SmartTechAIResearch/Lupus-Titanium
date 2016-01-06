namespace Lupus_Titanium {
    partial class FindRequestsPanel {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFindBorder = new System.Windows.Forms.Panel();
            this.rtxtFind = new System.Windows.Forms.RichTextBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.dgvFindResults = new System.Windows.Forms.DataGridView();
            this.clmResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFound = new System.Windows.Forms.Label();
            this.pnlFindBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindResults)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFindBorder
            // 
            this.pnlFindBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFindBorder.BackColor = System.Drawing.Color.White;
            this.pnlFindBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFindBorder.Controls.Add(this.rtxtFind);
            this.pnlFindBorder.Location = new System.Drawing.Point(6, 4);
            this.pnlFindBorder.Name = "pnlFindBorder";
            this.pnlFindBorder.Padding = new System.Windows.Forms.Padding(1);
            this.pnlFindBorder.Size = new System.Drawing.Size(437, 24);
            this.pnlFindBorder.TabIndex = 36;
            this.pnlFindBorder.Enter += new System.EventHandler(this.pnlFindBorder_Enter);
            // 
            // rtxtFind
            // 
            this.rtxtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtFind.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtFind.Location = new System.Drawing.Point(4, 4);
            this.rtxtFind.Multiline = false;
            this.rtxtFind.Name = "rtxtFind";
            this.rtxtFind.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtFind.Size = new System.Drawing.Size(430, 15);
            this.rtxtFind.TabIndex = 31;
            this.rtxtFind.Text = "";
            this.rtxtFind.WordWrap = false;
            this.rtxtFind.TextChanged += new System.EventHandler(this.rtxtFind_TextChanged);
            this.rtxtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtxtFind_KeyUp);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindNext.AutoSize = true;
            this.btnFindNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFindNext.BackColor = System.Drawing.Color.White;
            this.btnFindNext.Enabled = false;
            this.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindNext.Location = new System.Drawing.Point(449, 4);
            this.btnFindNext.MaximumSize = new System.Drawing.Size(9999, 24);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(45, 24);
            this.btnFindNext.TabIndex = 38;
            this.btnFindNext.Text = "Next";
            this.btnFindNext.UseVisualStyleBackColor = false;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // dgvFindResults
            // 
            this.dgvFindResults.AllowUserToAddRows = false;
            this.dgvFindResults.AllowUserToDeleteRows = false;
            this.dgvFindResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dgvFindResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFindResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFindResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFindResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvFindResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFindResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFindResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFindResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFindResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFindResults.ColumnHeadersVisible = false;
            this.dgvFindResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmResult});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 9.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFindResults.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFindResults.EnableHeadersVisualStyles = false;
            this.dgvFindResults.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.dgvFindResults.Location = new System.Drawing.Point(6, 53);
            this.dgvFindResults.MultiSelect = false;
            this.dgvFindResults.Name = "dgvFindResults";
            this.dgvFindResults.ReadOnly = true;
            this.dgvFindResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Consolas", 9.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFindResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFindResults.RowHeadersVisible = false;
            this.dgvFindResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvFindResults.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvFindResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindResults.Size = new System.Drawing.Size(488, 80);
            this.dgvFindResults.TabIndex = 39;
            this.dgvFindResults.VirtualMode = true;
            this.dgvFindResults.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvFindResults_CellValueNeeded);
            this.dgvFindResults.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFindResults_RowEnter);
            this.dgvFindResults.SelectionChanged += new System.EventHandler(this.dgvFindResults_SelectionChanged);
            this.dgvFindResults.Enter += new System.EventHandler(this.dgvFindResults_Enter);
            this.dgvFindResults.Leave += new System.EventHandler(this.dgvFindResults_Leave);
            // 
            // clmResult
            // 
            this.clmResult.HeaderText = "Result";
            this.clmResult.Name = "clmResult";
            this.clmResult.ReadOnly = true;
            this.clmResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmResult.Width = 5;
            // 
            // lblFound
            // 
            this.lblFound.AutoSize = true;
            this.lblFound.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFound.Location = new System.Drawing.Point(6, 37);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(43, 13);
            this.lblFound.TabIndex = 40;
            this.lblFound.Text = "0 found";
            // 
            // FindRequestsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.dgvFindResults);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.pnlFindBorder);
            this.DoubleBuffered = true;
            this.Name = "FindRequestsPanel";
            this.Size = new System.Drawing.Size(500, 35);
            this.VisibleChanged += new System.EventHandler(this.FindRequestsPanel_VisibleChanged);
            this.pnlFindBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlFindBorder;
        private System.Windows.Forms.RichTextBox rtxtFind;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.DataGridView dgvFindResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmResult;
        private System.Windows.Forms.Label lblFound;
    }
}
