using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChuanYu.TA.Domain.Common;

namespace ChuanYu.TA.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
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
    }
}
