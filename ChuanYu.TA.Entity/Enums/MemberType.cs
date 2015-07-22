/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Enums
 * 文件名：  MemberType
 * 版本号：  V1.0.0.0
 * 唯一标识：0e8e25a1-78db-47d5-8bff-c79c85ce5355
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:19:20
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
    public enum MemberType:byte
    {
        /// <summary>
        /// 0普通会员
        /// </summary>
        [Description("普通会员")]
        Normal = 0,

        /// <summary>
        /// 1认证会员
        /// </summary>
        [Description("认证会员")]
        Authent = 1
    }
}
