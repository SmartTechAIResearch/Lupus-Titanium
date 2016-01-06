/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Generic;

namespace Lupus_Titanium {
    public class UserAction {
        internal event EventHandler OnLabelChanged;
        internal event EventHandler OnRequestCountChanged;

        private readonly object _lock = new object();

        private List<Request> _requests = new List<Request>();

        private string _label = string.Empty;
        private CaptureUserActionKVPControl _userActionControl;

        public List<Request> Requests { get { lock (_lock) return _requests; } }

        public int Index {
            get {
                if (Scenario == null) return -1;
                return Scenario.UserActions.IndexOf(this);
            }
        }

        public Scenario Scenario { get; private set; }

        public string Label {
            get { return _label; }
            set {
                _label = value;
                if (OnLabelChanged != null) OnLabelChanged(this, null);
            }
        }

        internal CaptureUserActionKVPControl UserActionControl {
            get {
                if (_userActionControl == null) _userActionControl = new CaptureUserActionKVPControl(this);
                return _userActionControl;
            }
        }


        public UserAction(string label, Scenario scenario) {
            Label = label;
            Scenario = scenario;
        }

        public void Add(Request request) {
            Requests.Add(request);
            InvokeRequestCountChanged();
        }

        public void Clear() {
            if (Requests.Count != 0) {
                Requests.Clear();
                InvokeRequestCountChanged();
            }
        }
        /// <summary>
        /// Do not do this while capturing to this user action!
        /// </summary>
        /// <param name="range"></param>
        public void RemoveRange(List<int> range) {
            range.Sort();
            range.Reverse();
            foreach (int index in range)
                Requests.RemoveAt(index);

            InvokeRequestCountChanged();
        }

        internal void InvokeRequestCountChanged() {
            if (OnRequestCountChanged != null) OnRequestCountChanged(this, null);
        }
    }
}
