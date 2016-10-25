using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SKE48PlusViewer1.Resources.Pages;
using SKE48PlusViewer1.Droid.Renderers;

using System.Net;
using System.Net.Sockets;

[assembly: ExportRenderer(typeof(Login), typeof(LoginRenderer))]

namespace SKE48PlusViewer1.Droid.Renderers
{
    public class LoginRenderer : PageRenderer
    {
        private HttpListener _http;
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();

            App.OAuth2Settings.SetRedirectUrl(string.Format("http://{0}:{1}/", IPAddress.Loopback, port));

            _http = new HttpListener();
            _http.Prefixes.Add(App.OAuth2Settings.RedirectUrl.ToString());
            _http.Start();

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                App.OAuth2Settings.ClientId,
                App.OAuth2Settings.ClientSecret,
                App.OAuth2Settings.Scope,
                App.OAuth2Settings.AuthorizeUrl,
                App.OAuth2Settings.RedirectUrl,
                App.OAuth2Settings.AccessTokenUrl);
            auth.AllowCancel = false;

            auth.Completed += OnAuthenticationCompleted;

            activity.StartActivity(auth.GetUI(activity));
        }
        void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var alertDialog = new AlertDialog.Builder(this.Context);
            alertDialog.SetTitle("確認");
            if (e.IsAuthenticated)
            {
                //App.Instance.SuccessfulLoginAction.Invoke();
                // Use eventArgs.Account to do wonderful things
                //App.OAuth2Settings.SaveToken(e.Account.Properties["access_token"]);
                alertDialog.SetMessage("認証成功");
                alertDialog.Show();
            }
            else
            {
                // The user cancelled
                alertDialog.SetMessage("認証キャンセル");
                alertDialog.Show();
            }
        }
    }
}