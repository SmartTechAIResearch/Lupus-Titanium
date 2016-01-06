/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Lupus_Titanium {
    public static class RequestsSerializer {
        /// <summary>
        /// Converts each request to a json string. These are combined in one string with new line for a delimiter.
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static string ToJSON(IEnumerable<Request> requests) {
            var sb = new StringBuilder();

            foreach (var request in requests)
                sb.AppendLine(request.ConvertToJson());

            return sb.ToString().Trim();
        }
        /// <summary>
        /// <para>Only data needed to make a correct http web request is added to the string. One request per line.</para>
        /// <para>Relative url<![CDATA[<16 0C 02 12 $>]]>Request method<![CDATA[<16 0C 02 12 $>]]>Get data (&-delimited KVPs)<![CDATA[<16 0C 02 12 $>]]>Post data (UTF8)<![CDATA[<16 0C 02 12 $>]]>Post data (bytes as hex)</para> 
        /// <para><![CDATA[<16 0C 02 12 $>]]>Content type<![CDATA[<16 0C 02 12 $>]]>Accept<![CDATA[<16 0C 02 12 $>]]>Protocol<![CDATA[<16 0C 02 12 $>]]>Destination host<![CDATA[<16 0C 02 12 $>]]>Destination port</para> 
        /// <para><![CDATA[<16 0C 02 12 $>]]>Offset<![CDATA[<16 0C 02 12 $>]]>Redirects</para> 
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static string ToFlat(IEnumerable<Request> requests) {
            var sb = new StringBuilder();

            UserAction ua = null;

            foreach (var request in requests) {
                if (request.ParentUserAction != ua) {
                    sb.Append("<!--");
                    sb.Append(request.ParentUserActionLabel);
                    sb.AppendLine("-->");
                    ua = request.ParentUserAction;
                }

                sb.AppendLine(request.ConvertToFlat());
            }

            return sb.ToString().Trim();
        }
        /// <summary>
        /// Converts json to requests. The json must be new line delimited in the given string. One json for one request.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Request[] FromJSON(string json) {
            string[] split = json.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var arr = new Request[split.Length];
            for (int i = 0; i != split.Length; i++)
                arr[i] = new Request(split[i]);

            return arr;
        }
    }
}
