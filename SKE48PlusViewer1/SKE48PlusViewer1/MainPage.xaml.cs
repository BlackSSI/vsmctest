using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using SKE48PlusViewer1.Model;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace SKE48PlusViewer1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void Button_Page11_Clicked(object sender, EventArgs e)
        {

            var detailPage = new Resources.Pages.Page11();
            this.Navigation.PushAsync(detailPage);
        }

        public void Button_Page01_Clicked(object sender, EventArgs e)
        {

            var detailPage = new Resources.Pages.Page01();
            this.Navigation.PushAsync(detailPage);
        }
    }
}
