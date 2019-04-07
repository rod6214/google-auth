using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using AuthLib.Transformation;
using AuthLib.Web;
using System.Collections.Generic;
using GoogleAuth.Models;

namespace GoogleAuth.Controllers
{
    public class AuthorizeController : Controller
    {
        public ActionResult Index()
        {
            
            if(Request.Query.ContainsKey("code"))
            {
                var auth = OpenIDAuth.CreateModel<OpenIDAuth>("client_secrets.json");
                
                string code = Request.Query["code"];
                
                HBody body = new HBody();

                body.Add("code", code);
                body.Add("client_id", auth.client_id);
                body.Add("client_secret", auth.client_secret);
                body.Add("redirect_uri", auth.redirect_uri);
                body.Add("grant_type","authorization_code");

                HRequest req = new HRequest(body, HttpMethod.Post, 
                "https://www.googleapis.com/oauth2/v4/token");

                TokenModel token = null;
                
                req.ReadJsonAsync<TokenModel>( tkn => token = tkn).Wait();

                Console.WriteLine();
             
            }
            
            return View();
        }

        
    }
}
