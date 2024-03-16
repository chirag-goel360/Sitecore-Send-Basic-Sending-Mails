using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SitecoreSend.Helpers
{
    public static class CheckMailingList
    {
        public static List<string> CheckMailList(string emails)
        {
            List<string> emailsForMailingList = new List<string>();
            string[] emailArray = emails.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string email in emailArray)
            {
                string trimmedEmail = email.Trim();
                if (IsValidEmail(trimmedEmail))
                {
                    emailsForMailingList.Add(trimmedEmail);
                }
            }
            return emailsForMailingList;
        }

        public static bool IsValidEmail(string email)
        {
            // Regular Expression for Email Validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            // Check if Email Matches the Pattern
            return Regex.IsMatch(email, pattern);
        }
    }
}