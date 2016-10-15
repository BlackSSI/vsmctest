using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SKE48PlusViewer1
{
    public partial class App : Application
    {

        public static GoogleOAuth2Settings OAuth2Settings;

        public App()
        {
            InitializeComponent();

            OAuth2Settings = new GoogleOAuth2Settings(
                "796232685434-lnfb9e3mv9isgtu7v6avlvpt1ee47oqd.apps.googleusercontent.com",
                "RgujmMrmqYaY8zCtReG6Er0I",
                "https://www.googleapis.com/auth/plus.login",
                "https://accounts.google.com/o/oauth2/auth",
                "http://localhost",
                "https://accounts.google.com/o/oauth2/token"
                );

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
