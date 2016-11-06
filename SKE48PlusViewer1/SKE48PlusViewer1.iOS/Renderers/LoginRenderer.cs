
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SKE48PlusViewer1.Resources.Pages;
using SKE48PlusViewer1.iOS.Renderers;

using System.Net;
using System.Net.Sockets;
using UIKit;

[assembly: ExportRenderer(typeof(Login), typeof(LoginRenderer))]

namespace SKE48PlusViewer1.iOS.Renderers
{
    public class LoginRenderer : PageRenderer
    {
        private HttpListener _http;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();

            App.OAuth2Settings.SetRedirectUrl(string.Format("http://{0}:{1}/", IPAddress.Loopback, port));

            _http = new HttpListener();
            _http.Prefixes.Add(App.OAuth2Settings.RedirectUrl.ToString());
            _http.Start();

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var auth = new OAuth2Authenticator(
                App.OAuth2Settings.ClientId,
                App.OAuth2Settings.ClientSecret,
                App.OAuth2Settings.Scope,
                App.OAuth2Settings.AuthorizeUrl,
                App.OAuth2Settings.RedirectUrl,
                App.OAuth2Settings.AccessTokenUrl);
            auth.AllowCancel = false;

            auth.Completed += OnAuthenticationCompleted;

            PresentViewController(auth.GetUI(), true, null);
        }

        void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            //App.SuccessfulLoginAction.Invoke();
            UIAlertView alert = new UIAlertView()
            {
                Title = "確認"
            };
            alert.AddButton("OK");
            if (e.IsAuthenticated)
            {
                //App.Instance.SuccessfulLoginAction.Invoke();
                // Use eventArgs.Account to do wonderful things
                //App.OAuth2Settings.SaveToken(e.Account.Properties["access_token"]);
                alert.Message = "認証成功";
                alert.Show();
            }
            else
            {
                // The user cancelled
                alert.Message = "認証キャンセル";
                alert.Show();
            }
        }
    }
}
 