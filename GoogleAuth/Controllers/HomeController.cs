using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthLib.Transformation;
using System.Web.AuthLib;
using System.Net.Http;

namespace GoogleAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpMethod method = new HttpMethod("GET");
            var auth = OpenIDAuth.CreateModel<OpenIDAuth>("client_secrets.json");
            var uri = auth.GetUri("https", "accounts.google.com", "/o/oauth2/v2/auth");
            return Redirect(uri.GetUriString());
        }
    }
}
