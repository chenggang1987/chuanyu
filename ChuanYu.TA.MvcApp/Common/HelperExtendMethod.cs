using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChuanYu.TA.Entity.Enums;

namespace ChuanYu.TA.MvcApp.Common
{
    public static class HelperExtendMethod
    {
        public static List<SelectListItem> GetIndustryEnum(this HtmlHelper helper, string defaultText = null)
        {
            return WebHelper.GetSelectList(typeof(Industry));
        }
    }
}