/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Domain.Common
 * 文件名：  UserContext
 * 版本号：  V1.0.0.0
 * 唯一标识：d380c518-789d-45b8-bcce-a23682201750
 * 创建人：  成刚
 * 创建时间：2015/7/26 23:58:42
 * 描述：
 *
 *=====================================================================
 * 修改标记
 * 修改时间：
 * 修改人： 
 * 版本号： 
 * 描述：
 *
/*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChuanYu.TA.Entity.Common;
using System.Web;
using System.Web.Security;

namespace ChuanYu.TA.Domain.Common
{
    public class UserContext
    {
        private static readonly int CookieExpires = int.Parse(ConfigurationManager.AppSettings["CookieExpires"] ?? "1");

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public static UserModel CurrentUser
        {
            get
            {
                UserModel userModel;
                try
                {
                    userModel = GetAuthUser();
                }
                catch (Exception ex)
                {
                    throw;
                }

                return userModel;
            }
        }

        /// <summary>
        /// 设置客户端口验证票据
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="createPersistentCookie"></param>
        /// <param name="strCookiePath"></param>
        public static void SetAuthCookie(UserModel userModel, bool createPersistentCookie, string strCookiePath = "/")
        {
            string userName = userModel.UserName;

            // 获得Cookie
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userName, createPersistentCookie, strCookiePath);
            //authCookie.Name = "SopAuthCookie_" + accountName;
            string userData = userModel.SerializeToString();


            // 根据之前的ticket凭据创建新ticket凭据，然后加入自定义信息
            var newTicket = new FormsAuthenticationTicket(2, userModel.UserName, DateTime.Now, DateTime.Now.AddDays(CookieExpires), createPersistentCookie, userData, strCookiePath);

            // 将新的Ticke转变为Cookie值，然后添加到Cookies集合中
            authCookie.Value = FormsAuthentication.Encrypt(newTicket);

            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null)
            {
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
            else
            {
                HttpContext.Current.Response.Cookies.Set(authCookie);
            }
        }

        public static UserModel GetAuthUser()
        {
            if (HttpContext.Current == null)
            {
                return new UserModel();
            }

            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket authTicket = null;
            UserModel model = null;
            try
            {
                //解密
                if (authCookie != null) authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null) model = authTicket.UserData.DesrializeToObject<UserModel>();
            }
            catch (Exception ex)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            return model ?? new UserModel();
        }
    }
}
