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

[assembly: ExportRenderer(typeof(Login), typeof(LoginRenderer))]

namespace SKE48PlusViewer1.Droid.Renderers
{
    public class LoginRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

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
            if (e.IsAuthenticated)
            {
                //App.Instance.SuccessfulLoginAction.Invoke();
                // Use eventArgs.Account to do wonderful things
                App.OAuth2Settings.SaveToken(e.Account.Properties["access_token"]);
            }
            else
            {
                // The user cancelled
            }
        }
    }
}