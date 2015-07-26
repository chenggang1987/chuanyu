/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity
 * 文件名：  CyUserLoginLogEntity
 * 版本号：  V1.0.0.0
 * 唯一标识：9e4e93db-c36e-4c66-a763-bbefdb392fc0
 * 创建人：  成刚
 * 创建时间：2015/7/7 23:50:07
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

namespace ChuanYu.TA.Entity.User
{
    public class CyUserLoginLogEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long CyUserLoginLogId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIp { get; set; }
    }
}
