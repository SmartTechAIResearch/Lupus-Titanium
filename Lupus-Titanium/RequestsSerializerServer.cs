/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lupus_Titanium {
    public static class RequestsSerializerServer {
        public static event EventHandler<ErrorEventArgs> OnException;

        public static bool Running { get; private set; }
        private static TcpListener _listener;

        public static Scenario Scenario { get; private set; }

        /// <summary>
        /// The port the server is listening on.
        /// </summary>
        public static int Port { get; private set; }

        /// <summary>
        /// Starts the server if it was not started before.
        /// </summary>
        /// <param name="scenario"></param>
        /// <param name="port"></param>
        public static void Start(Scenario scenario, int port) {
            if (Running) return;
            Port = port;
            Scenario = scenario;

            _listener = new TcpListener(IPAddress.Loopback, port);
            _listener.Start(int.MaxValue);

            ThreadPool.QueueUserWorkItem((state) => {
                while (Running)
                    try {
                        ProcessClient(_listener.AcceptTcpClient());
                    } catch (Exception ex) {
                        ProcessException(ex);
                        Debug.WriteLine("Start " + ex.ToString(), "Lupus_Titanium.RequestsSerializerServer");
                    }
            }, null);
        }

        public static void Stop() {
            Running = false;
            if (_listener != null)
                _listener.Stop();
        }

        private static void ProcessClient(TcpClient client) {
            ThreadPool.QueueUserWorkItem(ProcessClientAsync, client);
        }
        private static void ProcessClientAsync(object state) {
            try {
                var client = state as TcpClient;
                try {
                    while (Running && client.Connected)
                        WriteResponse(client, ReadRequest(client));
                } catch (Exception ex) {
                    ProcessException(ex);
                    Debug.WriteLine("ProcessClientAsync handle stream " + ex.ToString(), "Lupus_Titanium.RequestsSerializerServer");
                }
                client.Close();
            } catch (Exception e) {
                ProcessException(e);
                Debug.WriteLine("ProcessClientAsync handle client " + e.ToString(), "Lupus_Titanium.RequestsSerializerServer");
            }
        }

        private static string ReadRequest(TcpClient client) {
            var input = new StreamReader(new BufferedStream(client.GetStream()));
            return input.ReadToEnd().Trim().ToLowerInvariant();
        }

        private static void WriteResponse(TcpClient client, string request) {
            var output = new StreamWriter(new BufferedStream(client.GetStream()));
            string response = "Write 'json' or 'flat' (without the quotes) to the tcp stream.";
            switch (request) {
                case "json":
                    response = RequestsSerializer.ToJSON(Scenario.AllRequests);
                    break;
                case "flat":
                    response = RequestsSerializer.ToFlat(Scenario.AllRequests);
                    break;
            }
            output.WriteLine(response);
            output.Flush();
        }

        private static void ProcessException(Exception ex) {
            if (Running && OnException != null)
                foreach (EventHandler<ErrorEventArgs> del in OnException.GetInvocationList())
                    del.BeginInvoke(null, new ErrorEventArgs(ex), null, null);
        }
    }
}
