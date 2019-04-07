using System;
using Google.Apis.Http;
using System.Net.Http;

namespace AuthTest
{
    public class TestFactory : IHttpClientFactory
    {
        private ConfigurableHttpClient _client;
        public TestFactory(ConfigurableHttpClient client)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            _client = client;
        }
        public ConfigurableHttpClient CreateHttpClient(CreateHttpClientArgs args)
        {
            foreach(var initializer in args.Initializers)
            {
                initializer.Initialize(_client);
            }

            return _client;
        }
    }
}
