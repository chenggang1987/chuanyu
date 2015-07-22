/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Common
 * 文件名：  CommonResult
 * 版本号：  V1.0.0.0
 * 唯一标识：1ef1b705-81ad-406a-b7a1-3ba177b758b9
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:35:12
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

namespace ChuanYu.TA.Entity.Common
{
    /// <summary>
    /// 返回结果
    /// Success、IsHappenEx默认值为False
    /// </summary>
    [Serializable]
    public class CommonResult<T>
    {
        /// <summary>
        /// 将是否成功和发生异常标志初始化为false
        /// </summary>
        public CommonResult()
        {
            Success = false;
            IsHappenEx = false;
        }

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { set; get; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// 操作影响行数
        /// </summary>
        public int EffectRows { set; get; }

        /// <summary>
        /// 返回值（泛型）
        /// </summary>
        public T ResultObj { set; get; }

        /// <summary>
        /// 返回值（object数组）
        /// </summary>
        public IList<T> ResultObjList { set; get; }

        /// <summary>
        /// 是否发生过异常
        /// </summary>
        public bool IsHappenEx { set; get; }

        /// <summary>
        /// Try..Catch 中 Exception信息
        /// </summary>
        public string ExMessage { set; get; }

        /// <summary>
        /// Try..Catch 中 Exception信息
        /// </summary>
        public object ExData { get; set; }
    }
}
