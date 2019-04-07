using System;
using System.IO;
using Newtonsoft.Json;


namespace AuthLib.Transformation
{
    public abstract class AuthBase
    {
        public static T CreateModel<T>(string jsonFile) where T : AuthBase
        {
            var dirBase = Directory.GetCurrentDirectory();
            return CreateModel<T>(dirBase, jsonFile);
        }
        public static T CreateModel<T>(string parentDir, string jsonName) 
        where T : AuthBase
        {
            var json = File.ReadAllText(Path.Combine(parentDir, jsonName));
            return JsonConvert.DeserializeObject<T>(json);
        }

        public Uri GetUri(string scheme, string host, string path)
        {
            return GetUri(scheme, host, path, -1);
        }

        public virtual Uri GetUri(string scheme, string host, string path, int port)
        {
            var modelParams = GetUrlParams(scheme);
            return new UriBuilder(scheme, host, port, path, modelParams).Uri;
        }
        protected abstract string GetUrlParams(string scheme);
        protected abstract AuthBase GetModel(string scheme);
    }
}
