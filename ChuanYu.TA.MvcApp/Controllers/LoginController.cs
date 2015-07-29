﻿using System;
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
using Sys.Common;

namespace ChuanYu.TA.MvcApp.Controllers
{
    public class LoginController : Controller
    {
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

        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult LoginAction(LoginUser loginUser)
        {
            var commonResult = new CommonResult<CyUserEntity>();
            var user = new CyUserEntity()
            {
                UserName = loginUser.UserName,
                UserPwd = loginUser.UserPwd
            };

            //验证用户信息
            var userResult = CyUserService.Login(user);
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

            return Json(commonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View();
        }

        public JsonResult SubmitRegister(CyUser user)
        {
            try
            {
                CyUserEntity cyUserEntity = Mapper.Map<CyUser, CyUserEntity>(user);
                cyUserEntity.MemberType = MemberType.Normal;
                cyUserEntity.Role = Role.Normal;
                cyUserEntity.CreateUserNo = "System";
                cyUserEntity.UpdateUserNo = "System";
                if (string.IsNullOrWhiteSpace(cyUserEntity.Birthday))
                {
                    cyUserEntity.Birthday = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.BirthPlace))
                {
                    cyUserEntity.BirthPlace = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.Residence))
                {
                    cyUserEntity.Residence = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(cyUserEntity.Position))
                {
                    cyUserEntity.Position = string.Empty;
                }

                var addResult = CyUserService.AddCyUser(cyUserEntity);
                if (addResult.Success && addResult.EffectRows > 0)
                {
                    return Json(new { IsSuccess = true });
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorInfo = addResult.ExMessage });
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, ErrorInfo = ex });
            }

        }
    }
}
