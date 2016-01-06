/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SizingServers.IPC {
    /// <summary>
    /// <para>Add a new Receiver in the code of the process you want to receive messages. Make sure the handles matches the one of the Sender.</para>
    /// <para>This inter process communication only works on the same machine and in the same Windows session.</para>
    /// </summary>
    public class Receiver : IDisposable {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;

        private BinaryFormatter _bf;
        private TcpListener _receiver;

        /// <summary>
        /// 
        /// </summary>
        public bool IsDisposed { get; private set; }
        /// <summary>
        /// <para>The handle is a value shared by a Sender and its Receivers.</para>
        /// <para>It links both parties so messages from a Sender get to the right Receivers.</para>
        /// <para>Make sure this is a unique value: use a GUID for instance:</para>
        /// <para>There is absolutely no checking to see if this handle is used in another Sender - Receivers relation.</para>
        /// </summary>
        public string Handle { get; private set; }

        /// <summary>
        /// Receives messages of a Sender having the same handle.
        /// </summary>
        /// <param name="handle">
        /// <para>The handle is a value shared by a Sender and its Receivers.</para>
        /// <para>It links both parties so messages from a Sender get to the right Receivers.</para>
        /// <para>Make sure this is a unique value: use a GUID for instance:</para>
        /// <para>There is absolutely no checking to see if this handle is used in another Sender - Receivers relation.</para>
        /// </param>
        public Receiver(string handle) {
            Handle = handle;

            for (int i = 0; ; i++) //Try 3 times.
                try {
                    _receiver = new TcpListener(EndPointManager.RegisterReceiver(Handle));
                    _receiver.Start(1);
                    break;
                } catch {
                    if (i == 2) throw;
                }

            _bf = new BinaryFormatter();

            BeginReceive();
        }

        private void BeginReceive() {
            ThreadPool.QueueUserWorkItem((state) => {
                while (!IsDisposed)
                    if (MessageReceived != null) {
                        try {
                            HandleReceive(_receiver.AcceptTcpClient());
                        } catch {
                            if (!IsDisposed) throw;
                        }
                    } else {
                        Thread.Sleep(1);
                    }
            }, null);
        }
        private void HandleReceive(TcpClient client) {
            ThreadPool.QueueUserWorkItem((state) => {
                try {
                    while (!IsDisposed) {
                        var chunk = new byte[client.ReceiveBufferSize];

                        //Get the length of the message that follows.
                        client.GetStream().Read(chunk, 0, chunk.Length);

                        int messageLength = BitConverter.ToInt32(chunk, 0);
                        var message = new byte[messageLength];
                        int totalRead = 0;

                        //Send Ack
                        client.GetStream().Write(Keys.ACK_bytes, 0, Keys.ACK_bytes.Length);
                        client.GetStream().Flush();

                        //Read all bytes of the message.
                        while (totalRead != messageLength) {
                            int chunkLength = client.ReceiveBufferSize;
                            if (chunkLength > messageLength - totalRead) chunkLength = messageLength - totalRead;

                            chunk = new byte[chunkLength];
                            int chunkRead = client.GetStream().Read(chunk, 0, chunkLength);
                            if (chunkRead <= 0) break;
                            chunk.CopyTo(message, totalRead);
                            totalRead += chunkRead;
                        }

                        using (var ms = new MemoryStream(message)) {
                            var e = (MessageWrapper)_bf.Deserialize(ms);
                            if (Handle == null || e.Handle == Handle)
                                MessageReceived(this, new MessageEventArgs() { Message = e.Message });
                        }
                    }
                } catch {
                    //Not important. If it doesn't work the other sender does not exist anymore or the sender will handle it.
                }
            }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            if (!IsDisposed) {
                IsDisposed = true;

                if (_receiver != null) {
                    _receiver.Stop();
                    _receiver = null;
                }
                _bf = null;

                Handle = null;
            }
        }
    }
}
