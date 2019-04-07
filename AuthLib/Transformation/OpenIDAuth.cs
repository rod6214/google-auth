using System;
using System.Web;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AuthLib.Transformation
{
    public class OpenIDAuth : AuthBase
    {
        public string client_id { get; set; }
        public string response_type{ get; set; }
        public string scope{ get; set; }
        public string redirect_uri{ get; set; }
        public string login_hint{ get; set; }
        public string openid_realm{ get; set; }
        public string nonce{ get; set; }
        public string hd{ get; set; }
        public string client_secret { get; set; }
        public string auth { get; set; }
        [JsonIgnore]
        public string state{ get; set; }

        protected override string GetUrlParams(string scheme)
        {
            var auth = GetModel(scheme) as OpenIDAuth;
            return $"?client_id={auth.client_id}&" +
                            $"response_type={auth.response_type}&" +
                            $"scope={auth.scope}&" +
                            $"redirect_uri={auth.redirect_uri}&" +
                            $"state={auth.state}&" +
                            $"login_hint={auth.login_hint}&" +
                            $"openid.realm={auth.openid_realm}&" +
                            $"nonce={auth.nonce}&" +
                            $"hd={auth.hd}";
        }

        protected override AuthBase GetModel(string scheme)
        {

            var encodable = HttpUtility.UrlEncode($"security_token={client_secret}&url="); 
            var state = $"{encodable}{auth}";
            //var regex = new Regex($"{scheme}:");
            //var match = regex.Match(this.state);
            //int index = match.Index;
            //var encodable = this.state.Substring(0, index);
            //var authUrl = this.state.Substring(index, this.state.Length - encodable.Length);
            
            
            return new OpenIDAuth
            {
                client_id = client_id,
                login_hint = login_hint,
                openid_realm = openid_realm,
                nonce = nonce,
                redirect_uri = redirect_uri,
                response_type = response_type,
                scope = scope,
                state = state,
                //state = HttpUtility.UrlEncode(encodable) + authUrl,
                hd = hd
            };
        }
    }
}
