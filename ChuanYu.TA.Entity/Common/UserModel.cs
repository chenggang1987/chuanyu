/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Common
 * 文件名：  UserModel
 * 版本号：  V1.0.0.0
 * 唯一标识：b8be6d37-3701-4bd0-b0d7-7abdce03ac1d
 * 创建人：  成刚
 * 创建时间：2015/7/27 0:01:19
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
    public class UserModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }


        /// <summary>
        /// 会员类型
        /// </summary>
        public MemberType MemberType { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public Role Role { get; set; }
    }
}
