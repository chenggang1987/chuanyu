using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChuanYu.TA.Domain.Common;

namespace ChuanYu.TA.MvcApp.Common
{
    public static class CommonMethod
    {
        public static void SetMenuChecked(string menuId)
        {
            var menu = UserContext.Menu.CurrentMenu;
            menu.ForEach(f =>
            {
                if (!f.CurrentNavMenu.IsChecked) return;
                foreach (var item in f.CurrentSideMenu)
                {
                    item.IsChecked = item.MenuId == menuId;
                }
            });
        }
    }
}