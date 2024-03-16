using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSend.Models.SitecoreSend
{
    public class SitecoreSendResult
    {
        public int Code { get; set; }
        public string Error { get; set; }
        public string Context { get; set; }
    }
}