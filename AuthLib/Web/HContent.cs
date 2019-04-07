using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthLib.Web
{
    public class HContent : HttpContent
    {
        private HBody _body;
        private HHeader _header;
        
        public string _http
        {
            get
            {
                string tag = "";
                switch(_header.Method)
                {
                    case HMethod.GET:
                    tag += $"GET ";
                    break;
                    case HMethod.POST:
                    tag += $"POST ";
                    break;
                    case HMethod.PUT:
                    tag += $"PUT ";
                    break;
                    case HMethod.DELETE:
                    tag += $"DELETE ";
                    break;
                }
                //Set header
                tag += $"{_header.Path} HTTP/1.1" + Environment.NewLine;
                tag += $"Host: {_header.Host}" + Environment.NewLine;
                tag += $"Content-Type: {_header.ContentType}";
                tag += Environment.NewLine;
                tag += Environment.NewLine;
                //Set body
                foreach(var b in _body)
                {
                    tag += $"{b.Key}={b.Value}" + Environment.NewLine;
                }
                tag += Environment.NewLine;
                tag += Environment.NewLine;
                return tag;
            }
        }
        public HContent(HBody body, HHeader header)
        {
            _body = body;
            _header = header;
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            byte[] data = Encoding.UTF8.GetBytes(_http);
            byte[] buffer = new byte[data.Length + 1];
            for(int i = 0; i < data.Length; i++)
            {
                buffer[i] = data[i];
            }
            return stream.WriteAsync(buffer, 0, data.Length);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _http.Length;
            return length > 0;
        }
    }
}
