/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using System;

namespace SizingServers.IPC {
    /// <summary>
    /// Sends the message together with the handle (extra safety check). If the handle matches at the receiving end the message will be processed; Otherwise it will be dropped.
    /// </summary>
    [Serializable]
    internal struct MessageWrapper {
        public string Handle { get; internal set; }
        public object Message { get; internal set; }
    }
}
