using System;
using Xamarin.Auth;
using System.Threading.Tasks;

namespace SKE48PlusViewer1
{
    public class GoogleAuth
    {
        //private HttpListener _http;

        public bool Authorized { private set; get; }
        public OAuth2Authenticator Auth;

        public GoogleAuth()
        {
            Authorized = false;
        }

        public void GetAuthorization()
        {
            //var listener = new TcpListener(IPAddress.Loopback, 0);
            //listener.Start();
            //var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            //listener.Stop();

            //var redirectURL = string.Format("http://{0}:{1}/", IPAddress.Loopback, port);

            //_http = new TcpListener();
            //_http.Prefixes.Add(redirectURL);
            //_http.Start();

            Auth = new OAuth2Authenticator(
                "796232685434-lnfb9e3mv9isgtu7v6avlvpt1ee47oqd.apps.googleusercontent.com",
                "RgujmMrmqYaY8zCtReG6Er0I",
                "https://www.googleapis.com/auth/plus.login",
                new Uri("https://accounts.google.com/o/oauth2/auth"),
                new Uri("http://localhost"),
                //new Uri(redirectURL),
                //new Uri(System.Uri.EscapeDataString("pw.oauth2:/oauth2redirect")),
                new Uri("https://accounts.google.com/o/oauth2/token"));
            Auth.AllowCancel = false;

            Auth.Completed += OnAuthenticationCompleted;
        }
        void  OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            //_http.Stop();
            Authorized = e.IsAuthenticated;

            return;
        }
    }
}
