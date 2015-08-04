/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.User
 * 文件名：  CyCompanyEntity
 * 版本号：  V1.0.0.0
 * 唯一标识：ec1604d8-1756-4f8d-8a7c-77556f38a666
 * 创建人：  成刚
 * 创建时间：2015/8/5 1:06:30
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
using ChuanYu.TA.Entity.Base;

namespace ChuanYu.TA.Entity.User
{
    public class CyCompanyEntity : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public long CompanyId { get; set; }

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
        public string Industry { get; set; }

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
