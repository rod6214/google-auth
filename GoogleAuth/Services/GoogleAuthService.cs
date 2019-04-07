using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


//Google apis
using Google.Apis.Auth.OAuth2;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleAuth.Services
{
    public class GoogleAuthService
    {
        public async Task<HttpResponseMessage> Send(Task<HttpResponseMessage> res)
        {
            var val = await res;
            var content = await val.Content.ReadAsStringAsync();
            return val;
        }
        public async Task Run()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { BooksService.Scope.Books },
                    "user", CancellationToken.None, new FileDataStore("Books.ListMyLibrary"));
            }

            // Create the service.
            var service = new BooksService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Books API Sample",
                });

            var bookshelves = await service.Mylibrary.Bookshelves.List().ExecuteAsync();
        }
    }
}
