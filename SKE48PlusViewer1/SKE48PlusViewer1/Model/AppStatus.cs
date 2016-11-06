using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SKE48PlusViewer1.Model
{
    public class AppStatus
    {
        public NavigationPage _NavPage;

        public Page GetMainPage()
        {
            var mainPage = new MainPage();

            _NavPage = new NavigationPage(mainPage);

            return _NavPage;
        }

        public void SetAuthentification()
        {
            App.OAuth2Settings = new GoogleOAuth2Settings(
                "796232685434-lnfb9e3mv9isgtu7v6avlvpt1ee47oqd.apps.googleusercontent.com",
                "RgujmMrmqYaY8zCtReG6Er0I",
                "https://www.googleapis.com/auth/plus.login",
                "https://accounts.google.com/o/oauth2/auth",
                "http://localhost",
                "https://accounts.google.com/o/oauth2/token"
                );
        }

        public Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => _NavPage.Navigation.PopModalAsync());
            }
        }
    }
}
