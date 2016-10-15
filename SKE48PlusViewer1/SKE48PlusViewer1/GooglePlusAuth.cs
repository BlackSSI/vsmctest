using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
using Google.Apis.Services;

using Xamarin.Auth;

using System.Security.Principal;


namespace SKE48PlusViewer1
{
    public class GooglePlusAuth
    {
        public void Auth()
        {
            var clientId = "588035480561-9viuq54cpc427jefm8qh4c9d46guhl4d.apps.googleusercontent.com";
            var scope = "profile";
            var authorizeUrl = new Uri("https://accounts.google.com/o/oauth2/auth");
            var redirectUrl = new Uri("http://localhost");

            var auth = new Xamarin.Auth.OAuth2Authenticator(clientId, scope, authorizeUrl, redirectUrl);
            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var requestAddress = authorizeUrl.AbsolutePath + "?client_id=" + clientId + "&redirect_url=" + redirectUrl.AbsolutePath
                                            + "&response_type=code" ;
                    var requestUrl = new Uri(requestAddress);
                    var request = new OAuth2Request("GET", requestUrl, null, eventArgs.Account);
                    request.GetResponseAsync().ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                        {
                            var s = t.Status;
                        }
                        else
                        {
                            var json = t.Result.GetResponseText();
                        }
                    });

                }
                else
                {
                    var s = scope;
                }
            };
            auth.Error += (sender, eventArgs) =>
            {
                var s = sender;
            };
            
        }

    }
}
