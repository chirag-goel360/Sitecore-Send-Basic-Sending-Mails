using Newtonsoft.Json;
using SitecoreSend.Constants;
using SitecoreSend.Helpers;
using SitecoreSend.Models;
using SitecoreSend.Models.SitecoreSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecoreSend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactForm contactForm)
        {
            List<string> mailList = new List<string>();
            if (!string.IsNullOrEmpty(contactForm.EmailList))
            {
                mailList = CheckMailingList.CheckMailList(contactForm.EmailList);
            }
            string mailingListName = MailingListNameFormatter.NameFormating(contactForm.Subject);
            SitecoreSendResult createMailList = SitecoreSendHelpers.CreateMailingList(mailingListName);
            if (createMailList.Code == 0)
            {
                var mailListID = createMailList.Context;
                AddMultipleSubscribersResult addMultipleUsers = SitecoreSendHelpers.AddMultipleUsers(mailList, mailListID);
                if (addMultipleUsers.Code == 0)
                {
                    CreateCampaign.MailingList mailing = new CreateCampaign.MailingList();
                    mailing.MailingListID = mailListID;
                    List<CreateCampaign.MailingList> mailings = new List<CreateCampaign.MailingList> { mailing };
                    CreateCampaign.Campaign campaign = new CreateCampaign.Campaign(mailingListName, contactForm.Subject, SitecoreSendConstants.SenderEmail, SitecoreSendConstants.ReplyToEmail, SitecoreSendConstants.ConfirmationToEmail, contactForm.Message, mailings, SitecoreSendConstants.IsAB);
                    string jsonData = JsonConvert.SerializeObject(campaign);
                    SitecoreSendResult createDraftCampaign = SitecoreSendHelpers.CreateDraftCampaign(jsonData);
                    if (createDraftCampaign.Code == 0)
                    {
                        SitecoreSendResult sendMails = SitecoreSendHelpers.SendCampaign(createDraftCampaign.Context);
                        if (sendMails.Code == 0)
                        {
                            ViewBag.SuccessMessage = "success";
                            Console.WriteLine("Sending Mails Successful");
                        }
                        else
                        {
                            ViewBag.SuccessMessage = "fail";
                            Console.WriteLine(string.Format("Sitecore Send : Encountered an Error while sending a Campaign - {0}", sendMails.Error), this);
                        }
                    }
                    else
                    {
                        ViewBag.SuccessMessage = "fail";
                        Console.WriteLine(string.Format("Sitecore Send : Encountered an Error while creating a Draft Campaign - {0}", createDraftCampaign.Error), this);
                    }
                }
                else
                {
                    ViewBag.SuccessMessage = "fail";
                    Console.WriteLine(string.Format("Sitecore Send : Encountered an Error while adding Multiple Users - {0}", addMultipleUsers.Error), this);
                }
            }
            else
            {
                ViewBag.SuccessMessage = "fail";
                Console.WriteLine(string.Format("Sitecore Send : Encountered an Error while creating a Mailing List - {0}", createMailList.Error), this);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}