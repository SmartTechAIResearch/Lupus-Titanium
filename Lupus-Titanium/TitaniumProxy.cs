/*
 * Copyright 2013 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;

namespace Lupus_Titanium {
    public class TitaniumProxy {

        #region events
        /// <summary>
        /// 
        /// </summary>
        internal event EventHandler<OnRequestEventArgs> BeforeRequest, BeforeResponse;
        #endregion

        #region Fields
        private static readonly object _lock = new object();

        private bool _isStarted, _isCapturingPaused;
        private HashSet<string> _filter;

        private HashSet<Request> _requests = new HashSet<Request>(); //Workaround fiesta.
        #endregion

        #region Properties
        /// <summary>
        /// Pause and continue capturing using the setter.
        /// </summary>
        public bool IsCapturingPaused {
            get { return _isCapturingPaused; }
            set {
                if (_isCapturingPaused != value) {
                    _isCapturingPaused = value;

                    if (_isCapturingPaused) {
                        ProxyServer.BeforeRequest -= ProxyServer_BeforeRequest;
                        ProxyServer.BeforeResponse -= ProxyServer_BeforeResponse;
                    } else {
                        ProxyServer.BeforeRequest += ProxyServer_BeforeRequest;
                        ProxyServer.BeforeResponse += ProxyServer_BeforeResponse;
                    }
                }
            }
        }
        #endregion

        ~TitaniumProxy() { StopCapturing(); }

        #region Functions
        /// <summary>
        /// Clears WININET cache before capturing.
        /// </summary>
        /// <param name="filter">Filter on host names and ips</param>
        public void StartCapturing(string[] filter = null) {
            if (!_isStarted) {
                //To be safe.
                StopCapturing();

                _requests = new HashSet<Request>();

                ProxyHelper.ClearProxyCache();

                _filter = filter == null || filter.Length == 0 ? null : new HashSet<string>(filter);

                ProxyServer.BeforeRequest += ProxyServer_BeforeRequest;
                ProxyServer.BeforeResponse += ProxyServer_BeforeResponse;

                ProxyServer.EnableSsl = true;
                ProxyServer.SetAsSystemProxy = true;

                //Could be dangerous to accept all server certificates. We do it anyway, we want to capture everything.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((sender, certificate, chain, errors) => true);

                _isStarted = ProxyServer.Start();
            }
        }

        private void ProxyServer_BeforeRequest(object sender, SessionEventArgs session) {
            lock (_lock)
                if (CanCapture(session, _filter)) {
                    var request = new Request(session);
                    _requests.Add(request);
                    if (BeforeRequest != null)
                        BeforeRequest(this, new OnRequestEventArgs(request));
                }
        }

        private void ProxyServer_BeforeResponse(object sender, SessionEventArgs session) {
            lock (_lock)
                if (CanCapture(session, _filter))
                    foreach (Request request in _requests)
                        if (request.EqualsSession(session)) {
                            request.SetResponse();
                            if (BeforeResponse != null)
                                BeforeResponse(this, new OnRequestEventArgs(request));
                            break;
                        }
        }


        /// <summary>
        /// Auto stops capturing when this becomes null.
        /// </summary>
        public void StopCapturing() {
            if (_isStarted)
                for (int i = 0; i != 3; i++) //Try 3 times.
                    try {
                        ProxyServer.BeforeRequest -= ProxyServer_BeforeRequest;
                        ProxyServer.BeforeResponse -= ProxyServer_BeforeResponse;

                        ProxyServer.Stop();
                        break;
                    } catch {
                        // Should not happen. Don't care much if it does.
                    }
            _isStarted = false;

            _filter = null;

            for (int i = 0; i != 3; i++)
                try {
                    ProxyHelper.UnsetProxy();
                    break;
                } catch {
                    // Should not happen. Don't care much if it does.
                }

            _requests = null;
        }

        /// <summary>
        /// Only sessions containing request data and having a destination host that is not filtered can be captured. 
        /// </summary>
        /// <param name="session"></param>
        private bool CanCapture(SessionEventArgs session, HashSet<string> filter) {
            if (!_isStarted  || session == null || string.IsNullOrEmpty(session.RequestUrl) || session.RequestHeaders == null) return false;
            if (filter != null) {
                string destinationHost = session.RequestHostname.ToLowerInvariant();
                foreach (string ipOrHostnamePart in filter)
                    if (destinationHost.Contains(ipOrHostnamePart))
                        return false;
            }
            return true;
        }
        #endregion

        public class OnRequestEventArgs : EventArgs {
            public Request Request { get; private set; }
            public OnRequestEventArgs(Request request) { Request = request; }
        }
    }
}
