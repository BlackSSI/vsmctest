using SKE48PlusViewer1.Model;
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
        public static AppStatus AppStatus = new AppStatus();

        public App()
        {
            InitializeComponent();

        }
    }
}
