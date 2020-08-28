using System.Text;
using System.IO;
using System.Net;
using DogYun.Model;
using System.Collections.Specialized;

namespace DogYun.Net
{
    internal class Http
    {
        private static string HttpHelper(string method, string url, string headerKey, string headerValue, NameValueCollection data, int timeout = 10000, string userAgent = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            byte[] buffer = { };

            request.Method = method.ToUpper();
            request.UserAgent = userAgent;
            request.Timeout = timeout;

            if (!string.IsNullOrEmpty(headerKey) && !string.IsNullOrEmpty(headerValue))
            {
                request.Headers.Add(headerKey + ":" + headerValue);
            }
            if (method.ToUpper() != "GET")
            {
                request.ContentType = "application/x-www-form-urlencoded";
                if (data != null)
                {
                    var sb = new StringBuilder();
                    foreach (string k in data.Keys)
                    {
                        sb.AppendFormat("&{0}={1}", k, data.Get(k));
                    }
                    buffer = Encoding.UTF8.GetBytes(sb.ToString().Trim('&'));
                }

            }
            if (method.ToUpper() == "GET")
            {
                var resp = (HttpWebResponse)request.GetResponse();
                var rs = resp.GetResponseStream();
                var sr = new StreamReader(rs, Encoding.GetEncoding("utf-8"));
                string retString = sr.ReadToEnd();

                sr.Close();
                rs.Close();

                return retString;
            }
            else
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Close();

                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var s = reader.ReadToEnd();
                reader.Close();
                return s;
            }
        }

        internal static string Get(string url, string headerKey, string headerValue, int timeout = 10000, string userAgent = null)
            => HttpHelper("GET", url, headerKey, headerValue, null, timeout, userAgent);

        internal static string Get(string url, int timeout = 10000, string userAgent = null) => Get(url, "API-KEY", Configuration.ApiKey, timeout, userAgent);

        internal static string Post(string url, string headerKey, string headerValue, int timeout = 10000, string userAgent = null)
            => HttpHelper("POST", url, headerKey, headerValue, null, timeout, userAgent);

        internal static string Post(string url, int timeout = 10000, string userAgent = null) => Post(url, "API-KEY", Configuration.ApiKey, timeout, userAgent);

        internal static string Put(string url, string headerKey, string headerValue, int timeout = 10000, string userAgent = null)
            => HttpHelper("PUT", url, headerKey, headerValue, null, timeout, userAgent);

        internal static string Put(string url, int timeout = 10000, string userAgent = null) => Put(url, "API-KEY", Configuration.ApiKey, timeout, userAgent);

        internal static string Put(string url, NameValueCollection data, int timeout = 10000, string userAgent = null)
            => HttpHelper("PUT", url, "API-KEY", Configuration.ApiKey, data, timeout, userAgent);

        internal static string Post(string url, NameValueCollection data, int timeout = 10000, string userAgent = null)
            => HttpHelper("POST", url, "API-KEY", Configuration.ApiKey, data, timeout, userAgent);

    }
}
