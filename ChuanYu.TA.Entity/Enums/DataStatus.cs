/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Enums
 * 文件名：  DataStatus
 * 版本号：  V1.0.0.0
 * 唯一标识：ffac3cc4-e9f3-428a-a3c3-16a10ae6694b
 * 创建人：  成刚
 * 创建时间：2015/7/22 0:47:31
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuanYu.TA.Entity.Enums
{
    public enum DataStatus:byte
    {
        /// <summary>
        /// 0无效
        /// </summary>
        [Description("无效")]
        Invalid = 0,

        /// <summary>
        /// 1有效
        /// </summary>
        [Description("有效")]
        Valid = 1,

        /// <summary>
        /// 2数据归档
        /// </summary>
        [Description("数据归档")]
        DataArchiving = 2,

        /// <summary>
        /// 逻辑删除
        /// </summary>
        [Description("逻辑删除")]
        LogicDeleted = 230,
        /// <summary>
        /// 255删除
        /// </summary>
        [Description("删除")]
        Deleted = 255
    }
}
