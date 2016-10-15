using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using SKE48PlusViewer1.ViewModel;
using SKE48PlusViewer1.Model;
using Google.Apis.Services;
using Google.Apis.Plus.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;

namespace SKE48PlusViewer1.Resources.Pages
{
    public partial class Page02 : ContentPage
    {
        MemberContentsViewModel _vm;

        public Member TargetMember { set; get; }

        public Page02(Member member)
        {
            InitializeComponent();


            //var contents = new ObservableCollection<MemberContent>();
            //contents.Add(new MemberContent { FullName = member.FullName, UserId=member.UserId });

            var ps = new PlusService();
            
            var uas = new UserActivities(ps, member.UserId);
            var contents = uas.ActivitiesList;

            _vm = new MemberContentsViewModel(contents);
            this.BindingContext = _vm;
        }
    }
}
