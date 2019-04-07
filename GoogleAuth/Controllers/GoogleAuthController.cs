using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AuthLib.Transformation;

//MVC
using Microsoft.AspNetCore.Mvc;


//Google apis
using Google.Apis.Auth.OAuth2;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleAuth.Controllers
{
    public class GoogleAuthController : Controller
    {
        //[Route("authorize")]
        /* public bool Authorize()
        {
            return true;
        } */
        [Route("activate")]
        public bool Activate()
        {
            var auth = OpenIDAuth.CreateModel<OpenIDAuth>("client_secrets.json");
            var uri = auth.GetUri("https", "accounts.google.com", "/o/oauth2/v2/auth");
            return true;
        }
    }

    
}
