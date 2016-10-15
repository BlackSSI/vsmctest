using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SKE48PlusViewer1.Resources.Pages
{
    public partial class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Navigation.PushAsync(new Login());
        }
    }
}
