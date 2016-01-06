/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SizingServers.IPC {
    /// <summary>
    /// <para>Add a new Sender in the code of the process you want to send messages. Make sure the handles matches the one of the Receivers.</para>
    /// <para>This inter process communication only works on the same machine and in the same Windows session.</para>
    /// <para>Suscribe to OnSendFailed for error handeling. Please not Sending will always fail when a Receiver disappears.</para>
    /// </summary>
    public class Sender : IDisposable {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> BeforeMessageSent;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MessageEventArgs> AfterMessageSent;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<ErrorEventArgs> OnSendFailed;

        private BinaryFormatter _bf;
        private Dictionary<TcpClient, IPEndPoint> _senders;

        /// <summary>
        /// 
        /// </summary>
        public bool IsDisposed { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string Handle { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle">A unique identifier to match the right sender with the right receivers.</param>
        public Sender(string handle) {
            if (string.IsNullOrWhiteSpace(handle)) throw new ArgumentNullException(handle);

            Handle = handle;

            _senders = new Dictionary<TcpClient, IPEndPoint>();
            _bf = new BinaryFormatter();
        }
        /// <summary>
        /// Send a message to the Receivers. It must be serializable.
        /// </summary>
        /// <param name="message"></param>
        public void Send(object message) {
            try {
                if (!IsDisposed) {
                    if (BeforeMessageSent != null) BeforeMessageSent(this, new MessageEventArgs() { Message = message });

                    byte[] messageBytes = null;
                    using (var ms = new MemoryStream()) {
                        _bf.Serialize(ms, new MessageWrapper() { Handle = Handle, Message = message });
                        messageBytes = ms.GetBuffer();
                    }

                    SetSenders();
                    Parallel.ForEach(_senders, (kvp) => {
                        Send(kvp.Key, kvp.Value, messageBytes);
                    });


                    if (AfterMessageSent != null) AfterMessageSent(this, new MessageEventArgs() { Message = message });
                }
            } catch (Exception ex) {
                if (!IsDisposed && OnSendFailed != null) OnSendFailed(this, new ErrorEventArgs(ex));
            }
        }

        /// <summary>
        /// Clean up the stored tcp clients (_senders) and add new ones if need be.
        /// </summary>
        private void SetSenders() {
            var newSenders = new Dictionary<TcpClient, IPEndPoint>();
            foreach (IPEndPoint endPoint in EndPointManager.GetReceiverEndPoints(Handle)) {
                bool senderFound = false;
                foreach (TcpClient sender in _senders.Keys)
                    if (_senders[sender].Port == endPoint.Port) {
                        newSenders.Add(sender, endPoint);
                        senderFound = true;
                        break;
                    }

                if (!senderFound)
                    newSenders.Add(new TcpClient(), endPoint);
            }
            foreach (TcpClient oldSender in _senders.Keys) {
                bool equals = false;
                foreach (TcpClient sender in newSenders.Keys)
                    if (_senders[oldSender].Port == newSenders[sender].Port) {
                        equals = true;
                        break;
                    }
                if (!equals)
                    oldSender.Dispose();
            }

            _senders = newSenders;
        }

        private void Send(TcpClient _sender, IPEndPoint endPoint, byte[] messageBytes) {
            try {
                if (!_sender.Connected)
                    try {
                        _sender.Connect(endPoint);
                    } catch {
                        return;
                    }

                //Write the message length
                byte[] messageLength = BitConverter.GetBytes(messageBytes.Length);
                _sender.GetStream().Write(messageLength, 0, messageLength.Length);
                _sender.GetStream().Flush();

                //Ack
                byte[] ack = new byte[_sender.ReceiveBufferSize];
                _sender.GetStream().Read(ack, 0, _sender.ReceiveBufferSize);

                if (!Keys.Equals(ack, Keys.ACK)) throw new Exception("Ack expected but not received!");


                //Write the message.
                int offset = 0;
                while (offset != messageBytes.Length) {
                    int length = _sender.SendBufferSize;
                    if (offset + length > messageBytes.Length)
                        length = messageBytes.Length - offset;

                    _sender.GetStream().Write(messageBytes, offset, length);

                    offset += length;
                }

                _sender.GetStream().Flush();
            } catch (Exception ex) {
                if (!IsDisposed && OnSendFailed != null) OnSendFailed(this, new ErrorEventArgs(ex));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            if (!IsDisposed) {
                IsDisposed = true;
                if (_senders != null) {
                    foreach (TcpClient sender in _senders.Keys)
                        sender.Dispose();
                    _senders = null;
                }

                _bf = null;
                Handle = null;
            }
        }
    }
}
