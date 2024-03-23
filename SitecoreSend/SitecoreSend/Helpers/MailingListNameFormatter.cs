using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSend.Helpers
{
    public static class MailingListNameFormatter
    {
        public static string NameFormating(string name)
        {
            List<char> charsToRemove = new List<char>() { '<', '>', '%', '&', '+', '?', '\"', ':' };
            foreach (char c in charsToRemove)
            {
                name = name.Replace(c.ToString(), string.Empty);
            }
            return name;
        }
    }
}