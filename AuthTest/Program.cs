using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using AuthLib.Transformation;
using System.Web.AuthLib;
using System.Net.Http;


namespace Books.ListMyLibrary
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var auth = OpenIDAuth.CreateModel<OpenIDAuth>("client_secrets.json");
            var uri = auth.GetUri("https", "accounts.google.com", "/o/oauth2/v2/auth");
            HttpClient client = new HttpClient();
            client.GetAsync(uri).ContinueWith((x)=>{
                var result = x.Result as HttpResponseMessage;
                var rUri = result.RequestMessage.RequestUri;
                var val = HttpUtility.ParseQueryString(rUri.Query);
                Console.WriteLine();
            }).Wait();
            Console.WriteLine();
        }
    }
}