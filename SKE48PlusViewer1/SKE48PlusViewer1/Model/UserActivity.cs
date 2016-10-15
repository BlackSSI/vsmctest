using System;
using System.Collections.Generic;

namespace SKE48PlusViewer1.Model
{
    public class UserActivity
    {
        public string Id { set; get; }
        public string DisplayName { set; get; }
        public string Tagline { set; get; }
        public DateTime Updated { set; get; }
        public string Content { set; get; }

        public List<string> ImageUrls = new List<string>();


        public string ImageUrl1
        {
            get
            {
                return ImageUrls.Count == 0 ? "" : ImageUrls[0];
            }
        }
    }
}
