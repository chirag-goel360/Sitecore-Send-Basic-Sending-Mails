using Newtonsoft.Json;
using SitecoreSend.Constants;
using SitecoreSend.Models.SitecoreSend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SitecoreSend.Helpers
{
    public static class SitecoreSendHelpers
    {
        public static SitecoreSendResult CreateMailingList(string mailListName)
        {
            CreateMailingList createMailingList = new CreateMailingList();
            createMailingList.Name = mailListName;
            string jsonData = JsonConvert.SerializeObject(createMailingList);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}?apiKey={2}", SitecoreSendConstants.BaseURL, "lists/create.json", SitecoreSendConstants.APIKey));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = jsonData;
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var sitecoreSendResult = JsonConvert.DeserializeObject<SitecoreSendResult>(result);
                return sitecoreSendResult;
            }
        }

        public static AddMultipleSubscribersResult AddMultipleUsers(List<string> userNames, string mailListID)
        {
            AddMultipleSubscribers.AddMultipleUser addMultipleUser = new AddMultipleSubscribers.AddMultipleUser();
            List<AddMultipleSubscribers.UserInfo> users = new List<AddMultipleSubscribers.UserInfo>();
            List<string> usersEmail = userNames;
            foreach (string user in usersEmail)
            {
                users.Add(new AddMultipleSubscribers.UserInfo { Name = user, Email = user });
            }
            addMultipleUser.Subscribers = users;
            addMultipleUser.HasExternalDoubleOptIn = false;
            string jsonData = JsonConvert.SerializeObject(addMultipleUser);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}/{2}/{3}?apiKey={4}", SitecoreSendConstants.BaseURL, "subscribers", mailListID, "subscribe_many.json", SitecoreSendConstants.APIKey));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = jsonData;
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var sitecoreSendResult = JsonConvert.DeserializeObject<AddMultipleSubscribersResult>(result);
                return sitecoreSendResult;
            }
        }

        public static SitecoreSendResult CreateDraftCampaign(string jsonData)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}?apiKey={2}", SitecoreSendConstants.BaseURL, "campaigns/create.json", SitecoreSendConstants.APIKey));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = jsonData;
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var sitecoreSendResult = JsonConvert.DeserializeObject<SitecoreSendResult>(result);
                return sitecoreSendResult;
            }
        }

        public static SitecoreSendResult SendCampaign(string campaignID)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}/{2}/{3}?apiKey={4}", SitecoreSendConstants.BaseURL, "campaigns", campaignID, "send.json", SitecoreSendConstants.APIKey));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "";
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var sitecoreSendResult = JsonConvert.DeserializeObject<SitecoreSendResult>(result);
                return sitecoreSendResult;
            }
        }
    }
}