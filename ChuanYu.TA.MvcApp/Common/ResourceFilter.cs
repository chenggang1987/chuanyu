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