using ChuanYu.TA.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChuanYu.TA.MvcApp.Models
{
    public class CyUser
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

        public string GenderName { get; set; }

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
        /// 行业
        /// </summary>
        public Industry Industry { get; set; }

        public string IndustryName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

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

    }
}