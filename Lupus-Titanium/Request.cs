/*
 * 2015 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Http;

namespace Lupus_Titanium {
    public class Request
    {

        #region Fields
        private Titanium.Web.Proxy.Http.Request _request;
        private Titanium.Web.Proxy.Http.Response _response;

        private int _parentUserActionIndex = -1, _result = -1, _destinationPort = -1;
        private string _parentUserActionLabel, _requestMethod, _protocol, _destinationHost, _relativeUrl, _getData,
            _requestBodyUtf8, _requestBodyHex, _accept, _referer,
            _httpVersion, _requestContentType, _responseBodyUtf8, _responseBodyHex;
        #endregion

        #region Properties

        public Guid RequestId { get; private set; }

        public int ParentUserActionIndex
        {
            get
            {
                if (ParentUserAction != null) _parentUserActionIndex = ParentUserAction.Index;
                return _parentUserActionIndex;
            }
        }

        public string ParentUserActionLabel
        {
            get
            {
                if (ParentUserAction != null) _parentUserActionLabel = ParentUserAction.Label;
                return _parentUserActionLabel;
            }
        }

        public string RequestMethod
        {
            get
            {
                return _requestMethod ?? (_requestMethod = _request.Method.ToUpperInvariant());
            }
        }

        public int Result
        {
            get
            {
                if (_result == -1 && HasResponse)
                    try
                    {
                        _result = (int)_response.ResponseStatusCode;
                    }
                    catch (NullReferenceException)
                    {
                        //Titanium bug.
                    }
                return _result;
            }
        }

        public string Protocol
        {
            get
            {
                return _protocol;
            }
        }

        public string DestinationHost
        {
            get
            {
                return _destinationHost;
            }
        }

        public int DestinationPort
        {
            get
            {
                return _destinationPort;
            }
        }

        public string RelativeUrl
        {
            get
            {
                return _relativeUrl;
            }
        }

        public string GetData
        {
            get
            {
                return _getData;
            }
        }

        public KeyValuePair<string, string>[] RequestHeaders
        {
            get; private set;
        }

        public string RequestBodyUtf8
        {
            get { return _requestBodyUtf8 ?? (_requestBodyUtf8 = (RequestBody == null ? string.Empty : Encoding.UTF8.GetString(RequestBody))); }
        }

        public string RequestBodyHex
        {
            get
            {
                return _requestBodyHex ?? (_requestBodyHex = (RequestBody == null ? string.Empty : BytesToHex(RequestBody)));
            }
        }

        public KeyValuePair<string, string>[] ResponseHeaders
        {
            get; private set;
        }

        public string ResponseContentType
        {
            get; private set;
        }

        public string Accept
        {
            get
            {
                if (_accept == null)
                    foreach (var header in RequestHeaders)
                        if (header.Key.ToLowerInvariant() == "accept")
                        {
                            _accept = header.Value;
                            break;
                        }
                return _accept;
            }
        }

        public string Referer
        {
            get
            {
                if (_referer == null)
                    foreach (var header in RequestHeaders)
                        if (header.Key.ToLowerInvariant() == "referer")
                        {
                            _referer = header.Value;
                            break;
                        }
                return _referer;
            }
        }

        public string HttpVersion
        {
            get
            {
                if (_httpVersion == null)
                {
                    _httpVersion = string.Format("{0}.{1}", _request.HttpVersion.Major, _request.HttpVersion.Minor);
                }
                return _httpVersion;
            }
        }

        /// <summary>
        /// The request body can only be read on BeforeRequest. THis behaviour is defined by Titanium Proxy.
        /// </summary>
        public byte[] RequestBody { get; private set; }

        public string RequestContentType
        {
            get
            {
                if (_requestContentType == null)
                    foreach (var header in RequestHeaders)
                        if (header.Key.Equals("content-type", StringComparison.InvariantCultureIgnoreCase))
                        {
                            _requestContentType = header.Value;
                            break;
                        }

                return _requestContentType;
            }
        }

        public byte[] ResponseBody { get; private set; }

        public string ResponseBodyUtf8
        {
            get { return _responseBodyUtf8 ?? (_responseBodyUtf8 = (ResponseBody == null ? string.Empty : Encoding.UTF8.GetString(ResponseBody))); }
        }

        public string ResponseBodyHex
        {
            get
            {
                return _responseBodyHex ?? (_responseBodyHex = (ResponseBody == null ? string.Empty : BytesToHex(ResponseBody)));
            }
        }

        public bool HasResponse
        {
            get { return ResponseBody != null; }
        }

        internal UserAction ParentUserAction { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public Request(SessionEventArgs session, byte[] bodyBytes)
        {
            RequestId = session.WebSession.RequestId;
            DetermineUrlParts(session);
            _request = session.WebSession.Request;
            _response = session.WebSession.Response;

            RequestHeaders = _request.RequestHeaders == null ? null : ConvertHttpHeaders(_request.RequestHeaders);
            RequestBody = bodyBytes;

        }
        /// <summary>
        /// Make a new request out of a given json string. Such a string would be created using ConvertToJson().
        /// </summary>
        /// <param name="json"></param>
        public Request(string json)
        {
            dynamic jObject = JObject.Parse(json);
            _parentUserActionIndex = jObject.parentUserActionIndex;
            _parentUserActionLabel = jObject.parentUserActionLabel;
            _requestMethod = jObject.requestMethod;
            _result = jObject.result;
            _protocol = jObject.protocol;
            _httpVersion = jObject.httpVersion;
            _destinationHost = jObject.destinationHost;
            _destinationPort = jObject.destinationPort;
            _relativeUrl = jObject.relativeUrl;
            _getData = jObject.getData;
            if (jObject.requestHeaders != null)
                RequestHeaders = ((JArray)jObject.requestHeaders).Select(token => JsonConvert.DeserializeObject<KeyValuePair<string, string>>(token.ToString())).ToArray();
            RequestBody = jObject.requestBody;
            if (jObject.responseHeaders != null)
                ResponseHeaders = ((JArray)jObject.responseHeaders).Select(token => JsonConvert.DeserializeObject<KeyValuePair<string, string>>(token.ToString())).ToArray();
            ResponseContentType = jObject.responseContentType;
            ResponseBody = jObject.responseBody;
        }

        /// <summary>
        /// Find a string in url, request / response headers and bodies.
        /// </summary>
        /// <param name="find"></param>
        /// <returns></returns>
        public bool Contains(string find)
        {
            string result = Result == -1 ? "pending..." : Result + " " + ((System.Net.HttpStatusCode)Result);
            string protocol = Protocol;
            if (!string.IsNullOrEmpty(HttpVersion))
                protocol += " (" + HttpVersion + ")";
            string host = DestinationHost;
            if (DestinationPort != 80) host += ":" + DestinationPort;
            string relativeUrl = RelativeUrl;
            if (!string.IsNullOrEmpty(GetData)) relativeUrl += "?" + GetData;

            if (IgnoreCaseContains(RequestMethod + " " + result + " " + protocol + " " + Protocol + "://" + host + relativeUrl, find)) return true;

            if (IgnoreCaseContains(RequestBodyUtf8, find)) return true;
            foreach (var header in _request.RequestHeaders)
            {
                if (IgnoreCaseContains(header.Name, find)) return true;
                if (IgnoreCaseContains(header.Value, find)) return true;
            }

            if (HasResponse)
            {
                if (IgnoreCaseContains(ResponseBodyUtf8, find)) return true;
                foreach (var header in _response.ResponseHeaders)
                {
                    if (IgnoreCaseContains(header.Name, find)) return true;
                    if (IgnoreCaseContains(header.Value, find)) return true;
                }
            }
            return false;
        }

        private bool IgnoreCaseContains(string from, string value)
        {
            return from.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) != -1;
        }

        internal async Task SetResponse(SessionEventArgs session) {
            ResponseBody = await session.GetResponseBody();
            ResponseHeaders = ConvertHttpHeaders(session.WebSession.Response.ResponseHeaders);
            ResponseContentType = session.WebSession.Response.ContentType;
        }

        internal bool EqualsSession(SessionEventArgs session) { return session.WebSession.RequestId == RequestId; }

        private void DetermineUrlParts(SessionEventArgs session)
        {
            if (_protocol == null)
            {
                string fullUrl = session.WebSession.Request.Url;
                string[] split = fullUrl.Split('?');
                string url = split[0];
                _protocol = "http";
                if (url.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
                {
                    url = url.Substring(7);
                }
                else if (url.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
                {
                    url = url.Substring(8);
                    _protocol = "https";
                }
                _relativeUrl = "/";
                int slashIndex = url.IndexOf('/');
                if (slashIndex != -1) _relativeUrl = url.Substring(slashIndex);
                _getData = split.Length == 1 ? string.Empty : split[1];

                if (url.Contains(":"))
                    int.TryParse(url.Split(':')[1].Split('?')[0].Split('/')[0], out _destinationPort);

                if (_destinationPort == -1)
                    _destinationPort = _protocol == "http" ? 80 : 443;

                _destinationHost = session.WebSession.Request.Host.ToLowerInvariant();
            }
        }

        private KeyValuePair<string, string>[] ConvertHttpHeaders(HeaderCollection httpHeaders)
        {
            var arr = new KeyValuePair<string, string>[httpHeaders.Count()];

            for (int i = 0; i != httpHeaders.Count(); i++)
            {
                var httpHeader = httpHeaders.ElementAt(i);
                arr[i] = new KeyValuePair<string, string>(httpHeader.Name, httpHeader.Value);
            }
            return arr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            dynamic jObject = new JObject();
            jObject.parentUserActionIndex = ParentUserActionIndex;
            jObject.parentUserActionLabel = ParentUserActionLabel;
            jObject.requestMethod = RequestMethod;
            jObject.result = Result;
            jObject.protocol = Protocol;
            jObject.httpVersion = HttpVersion;
            jObject.destinationHost = DestinationHost;
            jObject.destinationPort = DestinationPort;
            jObject.relativeUrl = RelativeUrl;
            jObject.getData = GetData;
            if (RequestHeaders != null) jObject.requestHeaders = JArray.FromObject(RequestHeaders);
            if (RequestBody != null) jObject.requestBody = RequestBody;
            if (HasResponse)
            {
                jObject.responseHeaders = JArray.FromObject(ResponseHeaders);
                jObject.responseContentType = ResponseContentType;
                jObject.responseBody = ResponseBody;
            }
            return jObject.ToString(Formatting.None);
        }

        /// <summary>
        /// Only data needed to make a correct http web request is added. One request per line.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="newLine"></param>
        /// <param name="cariageReturn"></param>
        /// <returns> 
        /// <para>Request method<![CDATA[<16 0C 02 12 $>]]>Protocol<![CDATA[<16 0C 02 12 $>]]>Destination host<![CDATA[<16 0C 02 12 $>]]>Destination port<![CDATA[<16 0C 02 12 $>]]>Relative url<![CDATA[<16 0C 02 12 $>]]></para> 
        /// <para> Get data (&-delimited KVPs)<![CDATA[<16 0C 02 12 $>]]>Post data (UTF8)<![CDATA[<16 0C 02 12 $>]]>Post data (bytes as hex)<![CDATA[<16 0C 02 12 $>]]>Content type<![CDATA[<16 0C 02 12 $>]]>Accept</para> 
        /// <para><![CDATA[<16 0C 02 12 $>]]>Offset<![CDATA[<16 0C 02 12 $>]]>Redirects<![CDATA[<16 0C 02 12 $>]]>Request headers</para> 
        /// </returns>
        public string ConvertToFlat(string delimiter = "<16 0C 02 12$>", string newLine = "<16 0C 02 12n>", string carriageReturn = "<16 0C 02 12r>")
        {
            var sb = new StringBuilder();
            sb.Append(RequestMethod);
            sb.Append(delimiter);

            sb.Append(Protocol);
            sb.Append(delimiter);

            sb.Append(DestinationHost);
            sb.Append(delimiter);

            sb.Append(DestinationPort);
            sb.Append(delimiter);

            sb.Append(RelativeUrl);
            sb.Append(delimiter);

            sb.Append(GetData);
            sb.Append(delimiter);

            sb.Append(RequestBodyUtf8.Replace("\n", newLine).Replace("\r", carriageReturn));
            sb.Append(delimiter);

            sb.Append(RequestBodyHex);
            sb.Append(delimiter);

            sb.Append(RequestContentType);
            sb.Append(delimiter);

            sb.Append(Accept);
            sb.Append(delimiter);

            sb.Append(Referer);
            sb.Append(delimiter);

            //Offset can not be automatically determined.
            sb.Append(0);
            sb.Append(delimiter);

            //To correctly parallize
            sb.Append(Result > 299 && Result < 400);

            sb.Append(delimiter);
            if (RequestHeaders.Length != 0)
            {
                KeyValuePair<string, string> kvp;
                for (int i = 0; i != RequestHeaders.Length - 1; i++)
                {
                    kvp = RequestHeaders[i];
                    sb.AppendFormat("{0}: {1}<16 0C 02 13$>", kvp.Key, kvp.Value);
                }
                kvp = RequestHeaders.Last();
                sb.AppendFormat("{0}: {1}", kvp.Key, kvp.Value);
            }

            return sb.ToString();

        }

        /// <summary>
        /// Converts a byte array to a hex using the given separator.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        private string BytesToHex(byte[] arr, string separator = "")
        {
            if (separator == ",") return BitConverter.ToString(arr);
            return BitConverter.ToString(arr).Replace(",", separator);
        }
    }
}
