using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChuanYu.TA.Domain.Common;
using ChuanYu.TA.Domain.Services;
using ChuanYu.TA.Entity.Common.Menu;

namespace ChuanYu.TA.MvcApp.Common
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ResourceFilter : FilterAttribute, IActionFilter
    {
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

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {

                //获取用户请求的路径
                var requestPath = HttpContext.Current.Request.Url.AbsolutePath;
                var query = HttpContext.Current.Request.Url.Query;

                var parentNo = string.Empty;
                if (!string.IsNullOrEmpty(query) && query.Length > 10)
                {
                    if (query.Substring(1, 8) == "ParentNo")
                    {
                        parentNo = query.Substring(10, 3);
                    }
                }

                if (string.IsNullOrEmpty(parentNo))
                {
                    switch (requestPath)
                    {
                        case "/User/RegistInfo":
                        case "/Login/Login":
                        case "/User/UserDetail":
                            parentNo = "M02";
                            break;
                    }
                }
                if (string.IsNullOrEmpty(parentNo)) return;
                var menuItem = CyCommonService.GetMenuItem(parentNo);
                UserContext.CurrentMenu = new Menu()
                {
                    MenuTitle = menuItem[0].Name,
                    MenuItems = menuItem
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}