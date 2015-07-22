/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Enums
 * 文件名：  Gender
 * 版本号：  V1.0.0.0
 * 唯一标识：8f15ef95-56f2-4c63-8021-c402d287976c
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:12:34
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
    public enum Gender : byte
    {
        /// <summary>
        /// 0男
        /// </summary>
        [Description("男")]
        Male = 0,

        /// <summary>
        /// 1女
        /// </summary>
        [Description("女")]
        Female = 1
    }
}
