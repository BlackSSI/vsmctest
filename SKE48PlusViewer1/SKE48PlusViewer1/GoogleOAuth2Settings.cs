using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKE48PlusViewer1
{
    public class GoogleOAuth2Settings
    {
        public GoogleOAuth2Settings(string clientId, string clientSecret, string scope,
                                    string authorizeUrl, string redirectUrl, string accessTokenUrl)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scope = scope;
            AuthorizeUrl = new Uri(authorizeUrl);
            RedirectUrl = new Uri(redirectUrl);
            AccessTokenUrl = new Uri(accessTokenUrl);
        }

        public void SaveToken(string token)
        {
            AuthorizeToken = token;
        }

        public string ClientId { private set; get; }
        public string ClientSecret { private set; get; }
        public string Scope { private set; get; }
        public Uri AuthorizeUrl { private set; get; }
        public Uri RedirectUrl { private set; get; }
        public Uri AccessTokenUrl { private set; get; }
        public string AuthorizeToken { private set; get; }
    }
}
