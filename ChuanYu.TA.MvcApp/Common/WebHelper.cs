using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sys.Common;

namespace ChuanYu.TA.MvcApp.Common
{
    public static class WebHelper
    {
        /// <summary>
        ///  把枚举的描述和值绑定到DropDownList
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            var selectList = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "", Selected = true } };

            selectList.AddRange(from object e in Enum.GetValues(enumType) select new SelectListItem { Text = EnumHelper.GetDescription(e), Value = ((byte)e).ToString(CultureInfo.InvariantCulture) });

            return selectList;
        }
    }
}