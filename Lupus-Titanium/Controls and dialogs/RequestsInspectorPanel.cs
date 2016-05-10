/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lupus_Titanium.Controls_and_dialogs {
    public partial class RequestsInspectorPanel : UserControl {
        #region Fields
        private readonly object _lock = new object();

        private Scenario _scenario;
        private object _clickedObject;

        private List<Request> _requests = new List<Request>();
        private List<object[]> _requestRows = new List<object[]>();

        private bool _keepAtEnd;
        private int _selectedRow, _selectedColumn;
        private List<int> _extendedSelectedRows = new List<int>();

        private ScrollBar _verticalScrollBar;
        #endregion

        #region Properties
        private ScrollBar VerticalScrollBar {
            get {
                return _verticalScrollBar ??
                    (_verticalScrollBar = dgvRequests.GetType().GetProperty("VerticalScrollBar", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(dgvRequests) as ScrollBar);
            }
        }

        public Scenario Scenario {
            get { return _scenario; }
            set {
                _scenario = value;
                if (_scenario != null) {
                    _scenario.OnRequestsChanged += _scenario_OnRequestsChanged;
                    _scenario.OnClick += _scenario_OnClick;
                }
            }
        }
        #endregion

        public RequestsInspectorPanel() {
            InitializeComponent();
            this.HandleCreated += _HandleCreated;
        }

        #region Functions
        public void Find(string find, Request request) {
            if (_scenario.AllRequests.Contains(request)) {
                request.ParentUserAction.UserActionControl.PerformClick();

                dgvRequests.ClearSelection();

                _selectedRow = _requests.IndexOf(request);


                _selectedColumn = 0;
                object[] row = _requestRows[_selectedRow];
                for (int column = 0; column != row.Length; column++)
                    if (IgnoreCaseContains(row[column].ToString(), find)) {
                        _selectedColumn = column;
                        break;
                    }

                dgvRequests.CurrentCell = dgvRequests.Rows[_selectedRow].Cells[_selectedColumn];
                dgvRequests.CurrentCell.Selected = true;

                dgvRequests.FirstDisplayedScrollingRowIndex = _selectedRow;

                HandleCellEntered(_requests.IndexOf(request), _selectedColumn);

                SelectInFCTB(find, fctbRequest);
                SelectInFCTB(find, fctbRequestBody);
                SelectInFCTB(find, fctbResponse);
                SelectInFCTB(find, fctbResponseBody);
            }
        }
        private bool IgnoreCaseContains(string from, string value) {
            return from.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) != -1;
        }
        private void SelectInFCTB(string find, FastColoredTextBoxNS.FastColoredTextBox fctb) {
            if (fctb.Visible) {
                int index = fctb.Text.IndexOf(find, StringComparison.InvariantCultureIgnoreCase);
                if (index != -1) {
                    fctb.SelectionStart = fctb.Text.IndexOf(find, StringComparison.InvariantCultureIgnoreCase);
                    fctb.SelectionLength = find.Length;
                    fctb.DoSelectionVisible();
                }
            }
        }

        private void _HandleCreated(object sender, EventArgs e) {
            this.HandleCreated -= _HandleCreated;
            try {
                //Stupid workaround.
                dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font(dgvRequests.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                var parentForm = this.FindForm();
                if (parentForm != null) {
                    if (parentForm.IsHandleCreated)
                        ParentForm_HandleCreated(ParentForm, null);
                    else
                        parentForm.HandleCreated += ParentForm_HandleCreated;
                }
            }
            catch {
            }
        }
        private void ParentForm_HandleCreated(object sender, EventArgs e) {
            (sender as Form).HandleCreated -= ParentForm_HandleCreated;
            SynchronizationContextWrapper.SynchronizationContext = SynchronizationContext.Current;
        }

        private void _scenario_OnRequestsChanged(object sender, EventArgs e) {
            SynchronizationContextWrapper.SynchronizationContext.Send((state) => {
                UpdateClickedObject();
            }, null);
        }

        private void _scenario_OnClick(object sender, Scenario.OnClickEventArgs e) {
            _keepAtEnd = false;
            _selectedRow = _selectedColumn = 0;
            _extendedSelectedRows.Clear();
            _clickedObject = e.ClickedObject;
            UpdateClickedObject();

            if (dgvRequests.RowCount != 0)
                try {
                    dgvRequests.FirstDisplayedScrollingRowIndex = 0;
                }
                catch {
                }
        }

        private void UpdateClickedObject() {
            if (_clickedObject == null) return;

            rtxtLabel.TextChanged -= rtxtLabel_TextChanged;
            if (_clickedObject is Scenario)
                UpdateClickedObject(_clickedObject as Scenario);
            else
                UpdateClickedObject(_clickedObject as UserAction);
            rtxtLabel.TextChanged += rtxtLabel_TextChanged;

           FillRequests();
        }

        private void UpdateClickedObject(Scenario scenario) {
            _clickedObject = _scenario;
            rtxtLabel.Text = "All requests";
            rtxtLabel.ReadOnly = true;
            rtxtLabel.ForeColor = SystemColors.ControlDarkDark;
            rtxtLabel.BackColor = Color.White;

            btnClearDelete.Text = "Clear";
            btnClearDelete.Enabled = scenario.AllRequests.Count != 0;

            btnGroupIntoUserAction.Enabled = false;
        }

        private void UpdateClickedObject(UserAction userAction) {
            _clickedObject = userAction;
            if (userAction.Label.Length == 0) {
                rtxtLabel.Text = "Ungrouped requests";
                rtxtLabel.ReadOnly = true;
                rtxtLabel.ForeColor = SystemColors.ControlDarkDark;

                btnClearDelete.Text = "Clear";
                btnGroupIntoUserAction.Enabled = userAction.Requests.Count != 0;
            }
            else {
                rtxtLabel.Text = userAction.Label;
                rtxtLabel.ReadOnly = false;
                rtxtLabel.ForeColor = SystemColors.ControlText;

                btnClearDelete.Text = "Delete";
                btnGroupIntoUserAction.Enabled = false;
            }
            rtxtLabel.BackColor = Color.White;
            btnClearDelete.Enabled = userAction.Requests.Count != 0;
        }

        private void rtxtLabel_TextChanged(object sender, EventArgs e) {
            if (rtxtLabel.Text.Length != 0) {
                var ua = _clickedObject as UserAction;
                if (ua != null) ua.Label = rtxtLabel.Text;
            }
        }

        private void FillRequests() {
            lock (_lock) {
                try {
                    if (_clickedObject == null) return;
                    _requests = _clickedObject is UserAction ? (_clickedObject as UserAction).Requests : _scenario.AllRequests;

                    dgvRequests.CellEnter -= dgvRequests_CellEnter;

                    int firstDisplayedScrollingRowIndex = dgvRequests.FirstDisplayedScrollingRowIndex;
                    if (firstDisplayedScrollingRowIndex == -1)
                        firstDisplayedScrollingRowIndex = 0;

                    _requestRows.Clear();
                    dgvRequests.RowCount = 0;


                    foreach (Request request in _requests) {
                        string result = request.Result == -1 ? "pending..." : request.Result + " " + ((System.Net.HttpStatusCode)request.Result);
                        string protocol = request.Protocol;
                        if (!string.IsNullOrEmpty(request.HttpVersion))
                            protocol += " (" + request.HttpVersion + ")";
                        string host = request.DestinationHost;
                        if (request.DestinationPort != 80) host += ":" + request.DestinationPort;
                        string relativeUrl = request.RelativeUrl;
                        if (!string.IsNullOrEmpty(request.GetData)) relativeUrl += "?" + request.GetData;

                        _requestRows.Add(new object[] { request.RequestMethod, result, protocol, host, relativeUrl });
                    }

                    int count = _requestRows.Count;
                    dgvRequests.RowCount = count;


                    if (_selectedRow < count) {
                        dgvRequests.ClearSelection();

                        dgvRequests.CurrentCell = dgvRequests.Rows[_selectedRow].Cells[_selectedColumn];
                        dgvRequests.CurrentCell.Selected = true;

                        foreach (int r in _extendedSelectedRows)
                            if (r != _selectedRow)
                                dgvRequests.Rows[r].Selected = true;

                    }
                    else {
                        _selectedRow = _selectedColumn = 0;
                        _extendedSelectedRows.Clear();
                    }

                    if (count != 0) {
                        Scroll -= dgvRequests_Scroll;
                        if (_keepAtEnd) {
                            dgvRequests.FirstDisplayedScrollingRowIndex = count - 1;
                        }
                        else {
                            if (firstDisplayedScrollingRowIndex < count)
                                dgvRequests.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                        }
                        Scroll += dgvRequests_Scroll;
                    }

                    FillViews();

                    dgvRequests.CellEnter += dgvRequests_CellEnter;
                }
                catch (Exception ex) {
                    //Most likely because of disposing.
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        private void btnGroupIntoUserAction_Click(object sender, EventArgs e) {
            var inputDialog = new InputDialog("Give the name of the user action you want to put the last captured requests in.", "Add User Action");
            inputDialog.SetInputLength(1);
            if (inputDialog.ShowDialog() == DialogResult.OK)
                _scenario.PushFromUngroupedToNew(inputDialog.Input);
        }

        private void btnClearDelete_Click(object sender, EventArgs e) {
            if (_clickedObject == _scenario) {
                if (MessageBox.Show("Are you sure you want to clear all requests?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    _scenario.Clear();
            }
            else {
                var ua = _clickedObject as UserAction;
                if (ua.Label.Length == 0) {
                    if (MessageBox.Show("Are you sure you want to clear these requests?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        ua.Clear();
                }
                else if (MessageBox.Show("Are you sure you want to delete this user action?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    _scenario.Delete(ua);
                }
            }
        }

        private void dgvRequests_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex < _requestRows.Count) {
                    object[] row = _requestRows[e.RowIndex];
                    if (e.ColumnIndex < row.Length)
                        e.Value = row[e.ColumnIndex];
                }
            }
            catch {
                //Row not available anymore.
            }
        }

        //Draw the row index
        private void dgvRequests_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
            var dgv = sender as DataGridView;
            int rowIndex = e.RowIndex + 1;
            if (rowIndex <= dgv.Rows.Count) {
                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIndex.ToString(), this.Font, SystemBrushes.ControlText, headerBounds, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
        }

        private void dgvRequests_CellEnter(object sender, DataGridViewCellEventArgs e) {
            HandleCellEntered(e.RowIndex, e.ColumnIndex);
        }

        private void HandleCellEntered(int row, int column) {
            _selectedRow = row;
            _selectedColumn = column;
            _extendedSelectedRows.Clear();
            foreach (DataGridViewCell cell in dgvRequests.SelectedCells) {
                int r = cell.RowIndex;
                if (!_extendedSelectedRows.Contains(r))
                    _extendedSelectedRows.Add(r);
            }
            FillViews();
        }


        private void dgvRequests_Scroll(object sender, ScrollEventArgs e) {
            _keepAtEnd = (VerticalScrollBar.Value + VerticalScrollBar.LargeChange + 1) >= VerticalScrollBar.Maximum;
        }

        private void FillViews() {
            try {
                if (_selectedRow >= _requests.Count) {
                    TextualContentFormatter.Format(fctbRequest, string.Empty);
                    splitContainerRequest.Panel2Collapsed = true;
                    TextualContentFormatter.Format(fctbResponse, string.Empty);
                    splitContainerResponse.Panel2Collapsed = true;

                    return;
                }

                Request request = _requests[_selectedRow];

                if (fctbRequest.Tag as KeyValuePair<string, string>[] != request.RequestHeaders) {
                    fctbRequest.Tag = request.RequestHeaders;

                    var sb = new StringBuilder();

                    foreach (var header in request.RequestHeaders)
                        sb.AppendLine(header.Key + ": " + header.Value);

                    TextualContentFormatter.Format(fctbRequest, sb.ToString().Trim());
                }

                if (fctbRequestBody.Tag as byte[] != request.RequestBody) {
                    fctbRequestBody.Tag = request.RequestBody;

                    if (request.RequestBody == null || request.RequestBody.LongLength == 0L) {
                        splitContainerRequest.Panel2Collapsed = true;
                        browserRequest.Render(string.Empty);
                    }
                    else {
                        splitContainerRequest.Panel2Collapsed = false;

                        TextualContentFormatter.Format(fctbRequestBody, request.RequestBodyUtf8, request.RequestContentType);
                        hexBoxRequest.ByteProvider = new Be.Windows.Forms.DynamicByteProvider(request.RequestBody);

                        if (!string.IsNullOrEmpty(request.RequestContentType) && request.RequestContentType.Contains("image")) {
                            browserRequest.Visible = false;
                            picRequest.Visible = true;
                            picRequest.Image = Image.FromStream(new MemoryStream(request.RequestBody));
                        }
                        else if (request.RequestBodyUtf8.Contains("</svg>")) {
                            browserRequest.Visible = false;
                            picRequest.Visible = true;
                            var svg = Svg.SvgDocument.FromSvg<Svg.SvgDocument>(request.RequestBodyUtf8);
                            picRequest.Image = svg.Draw();
                        }
                        else {
                            browserRequest.Visible = true;
                            picRequest.Visible = false;
                            browserRequest.Render(request.RequestBodyUtf8);
                        }
                    }
                }

                if (fctbResponse.Tag as KeyValuePair<string, string>[] != request.ResponseHeaders) {
                    fctbResponse.Tag = request.ResponseHeaders;

                    if (request.HasResponse) {
                        var sb = new StringBuilder();

                        foreach (var header in request.ResponseHeaders)
                            sb.AppendLine(header.Key + ": " + header.Value);

                        TextualContentFormatter.Format(fctbResponse, sb.ToString().Trim());

                        if (fctbResponseBody.Tag as byte[] != request.ResponseBody) {
                            fctbResponseBody.Tag = request.ResponseBody;

                            if (request.ResponseBody == null || request.ResponseBody.LongLength == 0L) {
                                splitContainerResponse.Panel2Collapsed = true;
                                browserResponse.Render(string.Empty);
                            }
                            else {
                                splitContainerResponse.Panel2Collapsed = false;

                                TextualContentFormatter.Format(fctbResponseBody, request.ResponseBodyUtf8, request.ResponseContentType);

                                hexBoxResponse.ByteProvider = new Be.Windows.Forms.DynamicByteProvider(request.ResponseBody);

                                if (!string.IsNullOrEmpty(request.ResponseContentType) && request.ResponseContentType.Contains("image")) {
                                    browserResponse.Visible = false;
                                    picResponse.Visible = true;
                                    picResponse.Image = Image.FromStream(new MemoryStream(request.ResponseBody));
                                }
                                else if (request.ResponseBodyUtf8.Contains("</svg>")) {
                                    browserResponse.Visible = false;
                                    picResponse.Visible = true;
                                    var svg = Svg.SvgDocument.FromSvg<Svg.SvgDocument>(request.ResponseBodyUtf8);
                                    picResponse.Image = svg.Draw();
                                }
                                else {
                                    browserResponse.Visible = true;
                                    picResponse.Visible = false;
                                    browserResponse.Render(request.ResponseBodyUtf8);
                                }
                            }

                        }
                    }
                    else {
                        splitContainerResponse.Panel2Collapsed = true;
                        TextualContentFormatter.Format(fctbResponse, string.Empty);
                        browserResponse.Render(string.Empty);
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine("FillViews " + ex);
            }
        }

        private void tsmFind_Click(object sender, EventArgs e) {
            var ctrl = contextMenuStripHeadersAndBodies.SourceControl as FastColoredTextBoxNS.FastColoredTextBox;
            ctrl.ShowFindDialog();
        }

        private void tsmCopy_Click(object sender, EventArgs e) {
            var ctrl = contextMenuStripHeadersAndBodies.SourceControl as FastColoredTextBoxNS.FastColoredTextBox;
            ctrl.Copy();
        }

        private void tsmSelectAll_Click(object sender, EventArgs e) {
            var ctrl = contextMenuStripHeadersAndBodies.SourceControl as FastColoredTextBoxNS.FastColoredTextBox;
            ctrl.SelectAll();
        }

        private void contextMenuStripBodies_Opening(object sender, CancelEventArgs e) {
            var ctrl = contextMenuStripHeadersAndBodies.SourceControl as FastColoredTextBoxNS.FastColoredTextBox;
            tsmCopy.Enabled = ctrl.SelectedText.Length != 0;
            tsmSelectAll.Enabled = ctrl.Text.Length != 0;
        }

        private void dgvRequests_Enter(object sender, EventArgs e) {
            dgvRequests.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvRequests.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
        }
        private void dgvRequests_Leave(object sender, EventArgs e) {
            dgvRequests.DefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            dgvRequests.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
        }

        private void dgvRequests_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Delete || _extendedSelectedRows.Count == 0) return;

            if (CanDeleteRequests()) DeleteSelectedRequests();

        }

        private void contextMenuStripRequests_Opening(object sender, CancelEventArgs e) {
            if (_requestRows.Count == 0 || _extendedSelectedRows.Count == 0) e.Cancel = true;

            if (CanDeleteRequests()) {
                foreach (int r in _extendedSelectedRows)
                    if (r != _selectedRow)
                        dgvRequests.Rows[r].Selected = true;

                tsmDeleteRequests.Text = "Delete";
                tsmDeleteRequests.Enabled = true;
            }
            else {
                tsmDeleteRequests.Text = "Deleting selections not possible from 'All' and 'Ungrouped' requests while capturing";
                tsmDeleteRequests.Enabled = false;
            }
        }
        private bool CanDeleteRequests() {
            if (_clickedObject == _scenario) {
                if (_scenario.IsCapturing) return false;
            }
            else {
                var userAction = _clickedObject as UserAction;
                if (_scenario.IsCapturing && userAction.Label.Length == 0) return false;
            }
            return true;
        }
        private void DeleteSelectedRequests() {
            if (CanDeleteRequests() && MessageBox.Show("Are you sure you want to delete the selected request(s)?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                var range = new List<int>(_extendedSelectedRows);
                _extendedSelectedRows.Clear();
                _selectedRow = _selectedColumn = 0;
                if (_clickedObject == _scenario) {
                    _scenario.RemoveRange(range);
                }
                else {
                    var userAction = _clickedObject as UserAction;
                    userAction.RemoveRange(range);
                }
            }
        }

        private void tsmDeleteRequests_Click(object sender, EventArgs e) {
            DeleteSelectedRequests();
        }

        private void tsmCopyRequests_Click(object sender, EventArgs e) {
            if (_extendedSelectedRows.Count == 1) {
                Clipboard.SetText(_requestRows[_selectedRow][_selectedColumn].ToString());
            }
            else {
                var sb = new StringBuilder();

                foreach (int r in _extendedSelectedRows) {
                    dgvRequests.Rows[r].Selected = true;

                    object[] row = _requestRows[r];
                    for (int i = 0; i < row.Length - 1; i++) {
                        sb.Append(row[i]);
                        sb.Append("\t");
                    }
                    sb.AppendLine(row[row.Length - 1].ToString());
                }
                Clipboard.SetText(sb.ToString().Trim());
            }
        }

        private void pnlLabelBorder_Enter(object sender, EventArgs e) {
            rtxtLabel.Focus();
        }
        #endregion
    }
}
