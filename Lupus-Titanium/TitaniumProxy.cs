/*
 * Copyright 2013 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Threading.Tasks;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Helpers;
using Titanium.Web.Proxy.Models;

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

        private ConcurrentBag<Request> _requests = new ConcurrentBag<Request>(); //Workaround fiesta.

        private ProxyServer _proxyServer;

        private ExplicitProxyEndPoint _explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true);
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
                        _proxyServer.BeforeRequest -= ProxyServer_BeforeRequest;
                        _proxyServer.BeforeResponse -= ProxyServer_BeforeResponse;
                    }
                    else {
                        _proxyServer.BeforeRequest += ProxyServer_BeforeRequest;
                        _proxyServer.BeforeResponse += ProxyServer_BeforeResponse;
                    }
                }
            }
        }
        #endregion

        public TitaniumProxy() {
            _proxyServer = new ProxyServer();
            _proxyServer.ExceptionFunc = exception => Console.WriteLine(exception.Message);
            _proxyServer.TrustRootCertificate = true;
            _proxyServer.ForwardToUpstreamGateway = true;

            _proxyServer.AddEndPoint(_explicitEndPoint);
        }
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

                _requests = new ConcurrentBag<Request>();

                ProxyHelper.ClearProxyCache();

                _filter = filter == null || filter.Length == 0 ? null : new HashSet<string>(filter);

                _proxyServer.BeforeRequest += ProxyServer_BeforeRequest;
                _proxyServer.BeforeResponse += ProxyServer_BeforeResponse;

                //Could be dangerous to accept all server certificates. We do it anyway, we want to capture everything.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((sender, certificate, chain, errors) => true);

                _proxyServer.Start();
                _proxyServer.SetAsSystemProxy(_explicitEndPoint, ProxyProtocolType.AllHttp);

                _isStarted = true;
            }
        }


        private async Task ProxyServer_BeforeRequest(object sender, SessionEventArgs session) {
            if (CanCapture(session, _filter)) {
                byte[] bodyBytes = new byte[0];

                if (session.WebSession.Request.HasBody)
                    bodyBytes = await session.GetRequestBody();

                var request = new Request(session, bodyBytes);
                _requests.Add(request);
                if (BeforeRequest != null)
                    BeforeRequest(this, new OnRequestEventArgs(request));
            }
        }

        private async Task ProxyServer_BeforeResponse(object sender, SessionEventArgs session) {
            if (CanCapture(session, _filter)) {
                foreach (Request request in _requests)
                    if (request.EqualsSession(session)) {
                        await request.SetResponse(session);
                        if (BeforeResponse != null)
                            BeforeResponse(this, new OnRequestEventArgs(request));
                        break;
                    }
            }
        }


        /// <summary>
        /// Auto stops capturing when this becomes null.
        /// </summary>
        public void StopCapturing() {
            if (_isStarted)
                for (int i = 0; i != 3; i++) //Try 3 times.
                    try {
                        _proxyServer.BeforeRequest -= ProxyServer_BeforeRequest;
                        _proxyServer.BeforeResponse -= ProxyServer_BeforeResponse;

                        _proxyServer.Stop();
                        break;
                    }
                    catch {
                        // Should not happen. Don't care much if it does.
                    }
            _isStarted = false;

            _filter = null;

            for (int i = 0; i != 3; i++)
                try {
                    ProxyHelper.UnsetProxy();
                    break;
                }
                catch {
                    // Should not happen. Don't care much if it does.
                }

            _requests = null;
        }

        /// <summary>
        /// Only sessions containing request data and having a destination host that is not filtered can be captured. 
        /// </summary>
        /// <param name="session"></param>
        private bool CanCapture(SessionEventArgs session, HashSet<string> filter) {
            lock (_lock) {
                if (!_isStarted || session == null || string.IsNullOrEmpty(session.WebSession.Request.Url) || session.WebSession.Request.RequestHeaders == null) return false;
                if (filter != null) {
                    string destinationHost = session.WebSession.Request.Host.ToLowerInvariant();
                    foreach (string ipOrHostnamePart in filter)
                        if (destinationHost.Contains(ipOrHostnamePart))
                            return false;
                }
                return true;
            }
        }
        #endregion

        public class OnRequestEventArgs : EventArgs {
            public Request Request { get; private set; }
            public OnRequestEventArgs(Request request) { Request = request; }
        }
    }
}
