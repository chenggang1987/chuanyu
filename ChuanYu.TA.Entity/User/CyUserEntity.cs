/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity
 * 文件名：  CyUserEntity
 * 版本号：  V1.0.0.0
 * 唯一标识：f019fa6c-9c28-4ca7-a835-460086cbb0a8
 * 创建人：  成刚
 * 创建时间：2015/7/7 23:50:54
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

using ChuanYu.TA.Entity.Base;
using ChuanYu.TA.Entity.Enums;

namespace ChuanYu.TA.Entity.User
{
    public class CyUserEntity : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNo { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// QQ号
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// 居住地
        /// </summary>
        public string Residence { get; set; }

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
