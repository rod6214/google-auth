using System;
using Google.Apis.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace AuthTest
{
    public class AuthInitializer : IConfigurableHttpClientInitializer
    {
        private readonly Dictionary<string, string> HEADERS;
        private readonly Dictionary<string, string> PROPERTIES;
        
        public AuthInitializer()
        {
            KeyValuePair<string, string>[] headers = new KeyValuePair<string,string>[]{
                new KeyValuePair<string, string>("",""),
            };

            KeyValuePair<string, string>[] properties = new KeyValuePair<string,string>[]{
                new KeyValuePair<string, string>("client_id",""),
                new KeyValuePair<string, string>("client_secret",""),
                new KeyValuePair<string, string>("redirect_uri",""),
                new KeyValuePair<string, string>("client_id","")
            };

            HEADERS = new Dictionary<string, string>(headers);
            PROPERTIES = new Dictionary<string, string>(properties);
        }

        public void Initialize(ConfigurableHttpClient httpClient)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.SetEmptyContent();
            
            foreach(var header in HEADERS)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            foreach(var property in PROPERTIES)
            {
                request.Properties.Add(property.Key, property.Value);
            }
        }
    }
}
