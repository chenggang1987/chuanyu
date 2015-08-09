using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ChuanYu.TA.MvcApp.Models;
using ChuanYu.TA.Entity.Common;
using ChuanYu.TA.Entity.User;
using ChuanYu.TA.Domain.Services;
using ChuanYu.TA.Domain.Common;
using ChuanYu.TA.Entity.Enums;
using ChuanYu.TA.MvcApp.Common;
using ChuanYu.TA.MvcApp.Models.User;
using Sys.Common;

namespace ChuanYu.TA.MvcApp.Controllers
{
    [ResourceFilter]
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        #region 实例化对象
        /// <summary>
        /// 用户类对象
        /// </summary>
        private readonly Lazy<CyUserService> _userService = new Lazy<CyUserService>();
        public CyUserService CyUserService
        {
            get
            {
                return _userService.Value;
            }
        }
        #endregion
        public ActionResult Login()
        {
            CommonMethod.SetMenuChecked("sideLogin");

            return View();
        }

        public JsonResult LoginIn(LoginUser loginUser)
        {
            var userResult = new CommonResult<CyUserEntity>();
            try
            {
                var user = new CyUserEntity()
                {
                    UserName = loginUser.UserName,
                    UserPwd = loginUser.UserPwd,
                    ValideCode = loginUser.ValideCode
                };

                //验证用户信息
                userResult = CyUserService.Login(user);
                //验证成功
                if (userResult.Success)
                {
                    var cyUser = userResult.ResultObj;
                    var model = new UserModel()
                    {
                        UserNo = cyUser.UserNo,
                        UserName = cyUser.UserName,
                        NickName = cyUser.NickName,
                        TrueName = cyUser.TrueName,
                        MemberType = cyUser.MemberType,
                        Role = cyUser.Role
                    };
                    UserContext.SetAuthCookie(model, true);
                    var loginLog = new CyUserLoginLogEntity()
                    {
                        UserNo = cyUser.UserNo,
                        LoginIp = IpHelper.GetUserIpAddress(),
                        LoginTime = DateTime.Now
                    };
                    CyUserService.AddCyUserLoginLog(loginLog);
                }
            }
            catch (Exception ex)
            {
                userResult.Success = false;
                userResult.Message = ex.Message;
            }
            return Json(userResult, JsonRequestBehavior.AllowGet);

        }

        public FileResult GetValidateCode()
        {
            VaildCode vc = new VaildCode();
            var img = vc.GetImgByte();
            return File(img, @"image/jpeg");
        }
        public ActionResult LoginOut()
        {
            UserContext.RemoveAuthUser();
            return RedirectToAction("Login");
        }
    }
}
