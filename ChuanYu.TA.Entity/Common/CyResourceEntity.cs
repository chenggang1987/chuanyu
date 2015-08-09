/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34209
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Common
 * 文件名：  CyResourceEntity
 * 版本号：  V1.0.0.0
 * 唯一标识：11ee786b-5c04-4b89-b5ad-f9da4900c934
 * 创建人：  成刚
 * 创建时间：2015/8/9 1:18:16
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
using ChuanYu.TA.Entity.Enums;

namespace ChuanYu.TA.Entity.Common
{
    public class CyResourceEntity
    {
        /// <summary>
        /// 自增Id
        /// </summary>
        public long ResourceId { set; get; }
        /// <summary>
        /// 资源编码
        /// </summary>
        public string ResourceCode { set; get; }
        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { set; get; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string MenuCode { set; get; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        public string MenuId { set; get; }
        /// <summary>
        /// 请求路径
        /// </summary>
        public string RequestPath { set; get; }
        /// <summary>
        /// 资源标示
        /// </summary>
        public ResourceFlag ResourceFlag { set; get; }
        /// <summary>
        /// 说明信息
        /// </summary>
        public string Memo { set; get; }
    }
}
