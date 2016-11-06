using System;

using Xamarin.Forms;
using Xamarin.Auth;


namespace SKE48PlusViewer1.Resources.Pages
{
    public partial class Page11 : ContentPage
    {
        public Page11()
        {
            InitializeComponent();

        }
        public void Button_StartAuth_Clicked(object sender, EventArgs e)
        {
            //var detailPage = new Resources.Pages.Login();
            //this.Navigation.PushAsync(detailPage);
            App.AppStatus._NavPage.PushAsync(new Login());
            //Navigation.PushModalAsync(new Login());
        }
    }
}