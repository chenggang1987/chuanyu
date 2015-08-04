using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChuanYu.TA.Entity.Enums;

namespace ChuanYu.TA.MvcApp.Models
{
    public class CyCompany
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        public Industry Industry { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyTel { get; set; }

        /// <summary>
        /// 公司传真
        /// </summary>
        public string CompanyFax { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司网址
        /// </summary>
        public string CompanyWebsite { get; set; }

        /// <summary>
        /// 公司介绍
        /// </summary>
        public string CompanyProfile { get; set; }
    }
}