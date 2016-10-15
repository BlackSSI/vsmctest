using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SKE48PlusViewer1.Model;

namespace SKE48PlusViewer1.ViewModel
{
    class MemberContentsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<UserActivity> Contents { private set; get; }

        public MemberContentsViewModel(ObservableCollection<UserActivity> contents)
        {
            Contents = contents;
        }
    }
}
