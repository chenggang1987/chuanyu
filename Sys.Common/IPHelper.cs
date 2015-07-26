/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  IPHelper
 * 版本号：  V1.0.0.0
 * 唯一标识：b6203f15-18d7-4251-9399-3d31a38ef1ac
 * 创建人：  成刚
 * 创建时间：2015/7/27 0:17:11
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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sys.Common
{
   public class IpHelper
    {

       /// <summary>
       /// 获取用户IP地址
       /// </summary>
       /// <returns></returns>
       public static string GetUserIpAddress()
       {
           try
           {
               if (HttpContext.Current == null)
               {
                   return Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(p => p.AddressFamily ==AddressFamily.InterNetwork).ToString();
               }
               return HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null ? System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
           }
           catch (Exception)
           {
               return string.Empty;
           }
       }
    }
}
