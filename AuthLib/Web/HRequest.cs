using System;
using System.Net.Http;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AuthLib.Web
{
    public class HRequest
    {
        private HttpRequestMessage _request;
        public HRequest(HBody body, HttpMethod method, string uri)
        {
            _request = new HttpRequestMessage(method, uri)
            {
                Content = new FormUrlEncodedContent(body)
            };
        }
        async public Task ReadJsonAsync<T>(Action<T> func)
        {
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(_request);
            var body = await response.Content.ReadAsStringAsync();
            body = body.Trim();
            body = body.Replace("\n", "");
            body = body.Replace(" ","");
            body += Environment.NewLine;
            func.Invoke(JsonConvert.DeserializeObject<T>(body));
        }
    }
}
