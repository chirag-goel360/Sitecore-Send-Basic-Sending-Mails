using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSend.Models.SitecoreSend
{
    public class CreateCampaign
    {
        public class Campaign
        {
            public string Name { get; set; }
            public string Subject { get; set; }
            public string SenderEmail { get; set; }
            public string ReplyToEmail { get; set; }
            public string ConfirmationToEmail { get; set; }
            public string HTMLContent { get; set; }
            public List<MailingList> MailingLists { get; set; }
            public string IsAB { get; set; }

            public Campaign(string name, string subject, string senderEmail, string replyToEmail, string confirmationToEmail, string htmlContent, List<MailingList> mailingLists, string isAB)
            {
                Name = name;
                Subject = subject;
                SenderEmail = senderEmail;
                ReplyToEmail = replyToEmail;
                ConfirmationToEmail = confirmationToEmail;
                HTMLContent = htmlContent;
                MailingLists = mailingLists;
                IsAB = isAB;
            }
        }

        public class MailingList
        {
            public string MailingListID { get; set; }
            public string SegmentID { get; set; }
        }
    }
}