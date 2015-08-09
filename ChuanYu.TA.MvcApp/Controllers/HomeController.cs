using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChuanYu.TA.Domain.Common;
using ChuanYu.TA.Domain.Services;
using ChuanYu.TA.Entity.Common.Menu;
using ChuanYu.TA.MvcApp.Common;

namespace ChuanYu.TA.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        #region 实例化对象
        private readonly Lazy<CyCommonService> _cyCommonService = new Lazy<CyCommonService>();
        public CyCommonService CyCommonService
        {
            get
            {
                return _cyCommonService.Value;
            }
        }
        #endregion

        public ActionResult Index()
        {
            var menuList = CyCommonService.GetMenuList();
            var navMenu = menuList.Where(w => w.MenuCode.Length == 3).ToList();
            var currentMenuList = new List<CurrentMenu>();
            navMenu.ForEach(f =>
            {
                var currentMenu = new CurrentMenu();
                f.IsChecked = f.MenuId == "navHome";
                var menuItem = CyCommonService.GetMenuItem(f.MenuCode);
                currentMenu.CurrentNavMenu = f;
                currentMenu.CurrentSideMenu = menuItem;
                currentMenuList.Add(currentMenu);
            });
            var menu = new Menu { CurrentMenu = currentMenuList };
            UserContext.Menu = menu;

            return View();
        }

        public JsonResult LoginInfo()
        {
            var user = UserContext.GetAuthUser();
            if (string.IsNullOrEmpty(user.UserName))
            {
                user.UserName = string.Empty;
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NavMenuSwitch(string navId)
        {
            var menu = UserContext.Menu;
            menu.CurrentMenu.ForEach(f =>
            {
                f.CurrentNavMenu.IsChecked = f.CurrentNavMenu.MenuId == navId;
            });
            return Json(new { Success = true });
        }

        public JsonResult SideMenuSwitch(string sideId)
        {
            CommonMethod.SetMenuChecked(sideId);
            return Json(new { Success = true });
        }
    }
}
