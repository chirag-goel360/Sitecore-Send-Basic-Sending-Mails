using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSend.Models.SitecoreSend
{
    public class AddMultipleSubscribers
    {
        public class AddMultipleUser
        {
            public bool HasExternalDoubleOptIn { get; set; }
            public List<UserInfo> Subscribers { get; set; }
        }

        public class UserInfo
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}