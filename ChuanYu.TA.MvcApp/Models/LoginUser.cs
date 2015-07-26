using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChuanYu.TA.MvcApp.Models
{
    public class LoginUser
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string ValideCode { get; set; }
        public string IsRember { get; set; }
    }
}