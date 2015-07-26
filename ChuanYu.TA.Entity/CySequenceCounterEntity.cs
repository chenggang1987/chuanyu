/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity
 * 文件名：  CySequenceCounterEntity
 * 版本号：  V1.0.0.0
 * 唯一标识：d19428e3-f40d-466b-bb8e-73ac3d516fba
 * 创建人：  成刚
 * 创建时间：2015/7/26 19:13:44
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

namespace ChuanYu.TA.Entity
{
    public class CySequenceCounterEntity
    {
        /// <summary>
        /// 键
        /// </summary>
        public string SequenceKey { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public int CounterId { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
