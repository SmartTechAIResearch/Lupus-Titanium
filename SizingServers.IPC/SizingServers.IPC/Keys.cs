/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using System.Text;

namespace SizingServers.IPC {
    /// <summary>
    /// To help handling acknowledgement of message lengths. More keys can be added here if need be.
    /// </summary>
    internal static class Keys {
        public const string ACK = "ACK{8B20C7BD-634B-408D-B337-732644177389}";
        public static byte[] ACK_bytes = Encoding.UTF8.GetBytes(ACK);

        public static bool Equals(byte[] x, string y) {
            try {
                return Encoding.UTF8.GetString(x).Trim('\0') == y;
            } catch {
                return false;
            }
        }
    }
}
