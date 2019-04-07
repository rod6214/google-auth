using System;

namespace GoogleAuth.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string id_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
    }
}
