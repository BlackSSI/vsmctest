using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SKE48PlusViewer1.Model;

namespace SKE48PlusViewer1.Data
{
    class MemberList
    {
        public ObservableCollection<Member> CreateList()
        {
            var _list = new ObservableCollection<Member>();

            _list.Add(new Member { FullName = "二村春香", UserId = "107238963481347254445", Team="TeamS" });
            _list.Add(new Member { FullName = "東李苑", UserId = "114994550153922257750", Team = "TeamS" });
            _list.Add(new Member { FullName = "犬塚あさな", UserId = "115730192449019105814", Team = "TeamS" });
            _list.Add(new Member { FullName = "大矢真那", UserId = "116324240483798147615", Team = "TeamS" });
            _list.Add(new Member { FullName = "北川綾巴", UserId = "113971612493421284619", Team = "TeamS" });
            _list.Add(new Member { FullName = "鎌田菜月", UserId = "111577742898202735013", Team = "TeamE" });

            _list.Add(new Member { FullName = "高柳明音", UserId = "106926723626971174827", Team = "TeamK2" });

            return _list;
        }
    }
}
