using Google.Apis.Plus.v1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKE48PlusViewer1.Model;

using Google.Apis.Plus.v1.Data;

namespace SKE48PlusViewer1
{
    public class UserActivities
    {
        private ObservableCollection<UserActivity> _list;
        private Collection<UserActivity> _actList = new Collection<UserActivity>();
        private PlusService _service;

        public UserActivities(PlusService sv, string id)
        {
            _service = sv;
            GetUserActivities(id);
        }

        public void GetUsersActivities(PlusService sv, List<string> idList)
        {
            _service = sv;
            _actList.Clear();

            foreach (var id in idList)
            {
                GetUserActivities(id);
            }
            _list = new ObservableCollection<UserActivity>(_actList.OrderByDescending(x => x.Updated));
        }

        public void GetUserActivities(string id)
        {
            //var people = _service.People.Get(id).Execute();
            var activities = _service.Activities.List(id, ActivitiesResource.ListRequest.CollectionEnum.Public__);
            activities.MaxResults = 3;
            IList<Activity> activityFeed = new List<Activity>();
            try
            {
                activityFeed = activities.Execute().Items;
            }
            catch
            {

            }
            var preHtml = @"<html><head><meta name='viewport' content='width=device-width; height=device-height; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;'/></head>";
            foreach (var activity in activityFeed)
            {
                var act = new UserActivity();

                act.Id = id;
                act.DisplayName = activity.Actor.DisplayName;
                act.Tagline = "";
                act.Updated = activity.Updated.GetValueOrDefault().AddHours(9);
                act.Content = preHtml + @"<body height=100%>" + activity.Object__.Content + @"</body></html>";
                var urls = new List<string>();
                if (activity.Object__.Attachments != null)
                {
                    foreach (var a in activity.Object__.Attachments)
                    {
                        if (a.Thumbnails == null)
                        {
                            urls.Add(a.Image.Url);
                        }
                        else
                        {
                            foreach (var b in a.Thumbnails)
                            {
                                urls.Add(b.Image.Url);
                            }
                        }
                    }
                    act.ImageUrls.AddRange(urls);
                }

                _actList.Add(act);
            }
        }

        public ObservableCollection<UserActivity> ActivitiesList
        {
            get { return _list; }
        }
    }
}
