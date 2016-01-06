/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lupus_Titanium {
    public class Scenario {

        #region Events
        internal event EventHandler OnRequestsChanged;
        public event EventHandler<OnClickEventArgs> OnClick;
        #endregion

        #region Fields
        private readonly object _lock = new object();

        private List<UserAction> _userActions = new List<UserAction>();
        private UserAction _ungroupedRequests;
        private TitaniumProxy _proxy;

        private Control _container; //The container to add the scenario control. (Holds user action controls)
        private CaptureScenarioKVPControl _scenarioControl;

        private bool _inited;
        #endregion

        #region Properties
        public int RequestCount {
            get {
                int count = 0;
                if (_userActions != null)
                    foreach (var userAction in _userActions) count += userAction.Requests.Count;
                return count;
            }
        }
        public List<Request> AllRequests {
            get {
                var allRequests = new List<Request>();
                if (_userActions != null)
                    foreach (var userAction in _userActions) allRequests.AddRange(userAction.Requests);
                return allRequests;
            }
        }

        /// <summary>
        /// </summary>
        public bool IsCapturing {
            get { return (_proxy == null ? false : !_proxy.IsCapturingPaused); }
        }

        internal List<UserAction> UserActions { get { return _userActions; } }
        #endregion

        public void PauseCapturing() {
            if (_proxy != null) _proxy.IsCapturingPaused = true;
        }
        public void ContinueCapturing() {
            if (_proxy != null) _proxy.IsCapturingPaused = false;
        }

        /// <summary>
        /// Automatically adds controls for total entry and user action counts to the given container.
        /// </summary>
        /// <param name="container"></param>
        public void Init(Control container) {
            if (!_inited) {
                _inited = true;

                _container = container;

                _scenarioControl = new CaptureScenarioKVPControl(this);
                _scenarioControl.Click += _scenarioControl_Click;

                _userActions = new List<UserAction>();
                _ungroupedRequests = new UserAction(string.Empty, this);
                _ungroupedRequests.OnRequestCountChanged += userAction_OnRequestCountChanged;

                _userActions.Add(_ungroupedRequests);

                _container.Controls.Clear();
                _container.Controls.Add(_scenarioControl);
                foreach (var userAction in _userActions) {
                    _container.Controls.Add(userAction.UserActionControl);
                    userAction.UserActionControl.Click += UserActionControl_Click;
                }

                HandleClickedControl(_scenarioControl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">Filter on ips and host names</param>
        public void StartCapturing(string[] filter = null) {
            _proxy = new TitaniumProxy();
            _proxy.BeforeRequest += _proxy_BeforeRequest;
            _proxy.BeforeResponse += _proxy_BeforeResponse;
            _proxy.StartCapturing(filter);

            HandleClickedControl(_ungroupedRequests.UserActionControl);
        }

        private void userAction_OnRequestCountChanged(object sender, EventArgs e) {
            InvokeRequestsChanged();
        }
        private void _proxy_BeforeRequest(object sender, TitaniumProxy.OnRequestEventArgs e) {
            e.Request.ParentUserAction = _ungroupedRequests;
            _ungroupedRequests.Add(e.Request);
        }
        private void _proxy_BeforeResponse(object sender, TitaniumProxy.OnRequestEventArgs e) {
            InvokeRequestsChanged();
        }

        /// <summary>
        /// Push all the requests from the ungrouped user action to a new one with a given label AKA actionize.
        /// </summary>
        /// <param name="userActionLabel"></param>
        /// <returns></returns>
        public UserAction PushFromUngroupedToNew(string userActionLabel) {
            PauseCapturing();
            var userAction = new UserAction(userActionLabel, this);
            foreach (var request in _ungroupedRequests.Requests) {
                request.ParentUserAction = userAction;
                userAction.Requests.Add(request);
            }
            _ungroupedRequests.Requests.Clear();
            _userActions.Insert(_userActions.Count - 1, userAction);

            _ungroupedRequests.OnRequestCountChanged -= userAction_OnRequestCountChanged;
            _ungroupedRequests.InvokeRequestCountChanged();
            userAction.InvokeRequestCountChanged();

            _ungroupedRequests.OnRequestCountChanged += userAction_OnRequestCountChanged;
            userAction.OnRequestCountChanged += userAction_OnRequestCountChanged;

            _container.Controls.Add(userAction.UserActionControl);
            _container.Controls.SetChildIndex(userAction.UserActionControl, _container.Controls.Count - 2);
            userAction.UserActionControl.Click += UserActionControl_Click;

            HandleClickedControl(_ungroupedRequests.UserActionControl);

            ContinueCapturing();

            return userAction;
        }

        public void Clear() {
            if (AllRequests.Count != 0) {
                if (_container != null)
                    foreach (var userAction in _userActions)
                        if (userAction != _ungroupedRequests)
                            _container.Controls.Remove(userAction.UserActionControl);

                _userActions.Clear();
                _userActions.Add(_ungroupedRequests);

                if (_ungroupedRequests.Requests.Count == 0)
                    InvokeRequestsChanged();
                else
                    _ungroupedRequests.Clear();
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="userAction"></param>
        public void Delete(UserAction userAction) {
            if (userAction != _ungroupedRequests) {
                if (_userActions.Remove(userAction)) {
                    HandleClickedControl(_scenarioControl);

                    if (_container != null) _container.Controls.Remove(userAction.UserActionControl);
                    InvokeRequestsChanged();
                }
            }
        }
        /// <summary>
        /// Do not do this while capturing!
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public void RemoveRange(List<int> range) {
            range.Sort();

            List<int> newRange;

            foreach (UserAction userAction in _userActions) {
                int count = userAction.Requests.Count;
                newRange = new List<int>();
                var userActionRange = new List<int>();
                foreach (int index in range)
                    if (index < count) {
                        userActionRange.Add(index);
                    } else {
                        if (userActionRange.Count == 0) break;
                        newRange.Add(index - count);
                    }

                if (userActionRange.Count == 0) break;

                range = newRange;
                userAction.RemoveRange(userActionRange);
            }
        }

        internal void InvokeRequestsChanged() {
            lock (_lock)
                if (OnRequestsChanged != null) OnRequestsChanged(this, null);
        }

        public void StopCapturing() {
            if (_proxy != null) {
                _proxy.BeforeRequest -= _proxy_BeforeRequest;
                _proxy.BeforeResponse -= _proxy_BeforeResponse;
                _proxy.StopCapturing();
                _proxy = null;
            }
        }


        /// <summary>
        /// Contains all request and response data. Each line in this string represets a request. Suck a line can be used to contruct a new Request(string json). 
        /// </summary>
        public string GetScenarioAsJSON() {
            return RequestsSerializer.ToJSON(AllRequests);
        }

        /// <summary>
        /// <para>Only data needed to make a correct http web request is added to the string. One request per line.</para>
        /// <para>Relative url<![CDATA[<16 0C 02 12 $>]]>Request method<![CDATA[<16 0C 02 12 $>]]>Get data (&-delimited KVPs)<![CDATA[<16 0C 02 12 $>]]>Post data (UTF8)<![CDATA[<16 0C 02 12 $>]]>Post data (bytes as hex)</para> 
        /// <para><![CDATA[<16 0C 02 12 $>]]>Content type<![CDATA[<16 0C 02 12 $>]]>Accept<![CDATA[<16 0C 02 12 $>]]>Protocol<![CDATA[<16 0C 02 12 $>]]>Destination host<![CDATA[<16 0C 02 12 $>]]>Destination port</para> 
        /// <para><![CDATA[<16 0C 02 12 $>]]>Offset<![CDATA[<16 0C 02 12 $>]]>Redirects</para> 
        /// </summary>
        public string GetScenarioFlat() {
            return RequestsSerializer.ToFlat(AllRequests);
        }


        private void _scenarioControl_Click(object sender, EventArgs e) {
            HandleClickedControl(sender as CaptureKeyValuePairControl);
        }
        private void UserActionControl_Click(object sender, EventArgs e) {
            HandleClickedControl(sender as CaptureKeyValuePairControl);
        }

        private void HandleClickedControl(CaptureKeyValuePairControl sender) {
            object clickedObject = null;
            if (sender == _scenarioControl) {
                clickedObject = this;
                foreach (var userAction in _userActions)
                    userAction.UserActionControl.BorderStyle = BorderStyle.None;
            } else {
                _scenarioControl.BorderStyle = BorderStyle.None;
                foreach (var userAction in _userActions) {
                    if (sender == userAction.UserActionControl) clickedObject = userAction;
                    userAction.UserActionControl.BorderStyle = BorderStyle.None;
                }
            }

            sender.BorderStyle = BorderStyle.FixedSingle;

            if (OnClick != null) OnClick(null, new OnClickEventArgs(clickedObject));
        }


        public class OnClickEventArgs : EventArgs {
            /// <summary>
            /// This or user action.
            /// </summary>
            public object ClickedObject { get; private set; }
            public OnClickEventArgs(object clickedObject) {
                ClickedObject = clickedObject;
            }
        }
    }
}
