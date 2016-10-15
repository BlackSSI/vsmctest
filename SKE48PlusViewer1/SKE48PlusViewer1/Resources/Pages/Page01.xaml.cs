using System.Collections.ObjectModel;

using Xamarin.Forms;
using SKE48PlusViewer1.Model;
using SKE48PlusViewer1.ViewModel;
using SKE48PlusViewer1.Data;

namespace SKE48PlusViewer1.Resources.Pages
{
    public partial class Page01 : ContentPage
    {
        MemberListViewModel _vm;
        Member _member;

        ObservableCollection<Member> _members;
        public Page01()
        {
            InitializeComponent();

            var list = new MemberList();
            _members = list.CreateList();

            _vm = new MemberListViewModel(_members);
            this.BindingContext = _vm;
        }

        void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            _member = (Member)e.SelectedItem;
            //DisplayAlert("Item Selected", member.UserId, "Ok");
            var detailPage = new Resources.Pages.Page02(_member);
            this.Navigation.PushAsync(detailPage);
        }

        void ShowMessage()
        {
            MessagingCenter.Send(this, "Push!");
        }
    }
}
