/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34209
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Domain.Services
 * 文件名：  CyCommonService
 * 版本号：  V1.0.0.0
 * 唯一标识：79dbe3ca-0755-4e4b-b3ad-f358fb9ea57a
 * 创建人：  成刚
 * 创建时间：2015/8/9 1:30:44
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChuanYu.TA.Data;
using ChuanYu.TA.Data.User;
using ChuanYu.TA.Domain.Common;
using ChuanYu.TA.Entity.Common.Menu;
using Sys.Common;

namespace ChuanYu.TA.Domain.Services
{
    public class CyCommonService
    {
        #region 实例化对象
        private readonly Lazy<CyCommonProvider> _cyCommonProvider = new Lazy<CyCommonProvider>();
        public CyCommonProvider CyCommonProvider
        {
            get
            {
                return _cyCommonProvider.Value;
            }
        }
        #endregion

        public List<MenuItem> GetMenuList()
        {
            var list = new List<MenuItem>();
            var cacheModel =
                System.Web.HttpContext.Current.Cache.Get(CacheKey.ResourcePrefix + UserContext.CurrentUser.UserNo) as List<MenuItem>;
            if (cacheModel != null)
            {
                return cacheModel;
            }
            var resource = CyCommonProvider.GetCyResourceList().ResultObjList;
            resource.ForEach(f =>
            {
                var menuitem = new MenuItem();
                if (!string.IsNullOrWhiteSpace(f.MenuCode))
                {
                    var parentNo = f.MenuCode.Substring(0, 3);
                    menuitem.Name = f.ResourceName;
                    menuitem.Url = f.RequestPath;
                    menuitem.MenuId = f.MenuId;
                    menuitem.MenuCode = f.MenuCode;
                    menuitem.ParentNo = f.MenuCode.Length == 3 ? "root" : parentNo;
                    if (f.MenuCode.Length == 3)
                    {
                        menuitem.IsMain = true;
                        menuitem.SortValue = string.Empty;
                    }
                    else
                    {
                        menuitem.IsMain = false;
                        menuitem.SortValue = f.MenuCode.Substring(4, 2);
                    }
                    list.Add(menuitem);
                }
            });
            System.Web.HttpContext.Current.Cache.Insert(CacheKey.ResourcePrefix + UserContext.CurrentUser.UserNo, list, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
            return list;
        }

        public List<MenuItem> GetMenuItem(string parentNo)
        {
            var menuList = GetMenuList();
            return menuList.Where(w => w.ParentNo == parentNo).OrderBy(o => o.SortValue).ToList();
        }
    }
}
