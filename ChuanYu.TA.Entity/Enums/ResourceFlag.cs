/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34209
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Enums
 * 文件名：  ResourceFlag
 * 版本号：  V1.0.0.0
 * 唯一标识：31bd77d8-4b0e-45b4-858a-c7895a0b7cab
 * 创建人：  成刚
 * 创建时间：2015/8/9 1:35:47
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
    public enum ResourceFlag : byte
    {
        /// <summary>
        /// 前端
        /// </summary>
        [Description("前端")]
        Front = 1,

        /// <summary>
        /// 后端
        /// </summary>
        [Description("后端")]
        Back = 2
    }
}
