using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AuthLib.Web
{
    public class HHeader : Dictionary<string, string>
    {
        public HMethod Method { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        
        public HHeader(HMethod method, string host, string path)
        {
            Method = method;
            Host = host;
            Path = path;
        }
    }
}
