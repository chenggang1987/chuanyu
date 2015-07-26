using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChuanYu.TA.Data;
using ChuanYu.TA.Domain.Services;
using ChuanYu.TA.Entity;
using ChuanYu.TA.Entity.Enums;
using ChuanYu.TA.Entity.User;
using NUnit.Framework;
using Sys.Common;

namespace ChuanYu.TA.Test
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestAddUser()
        {
            try
            {
                var userPwd = StringUtil.ToHashString("123");

                var userNo = new CySequenceCounterProvider().GetNextCounterId("UserNo");
                var entity = new CyUserEntity()
                {
                    UserNo = userNo.ToString(),
                    UserName = "chenggang",
                    UserPwd = userPwd,
                    Birthday = "1987-09-14",
                    BirthPlace = "四川岳池",
                    CreateTime = DateTime.Now,
                    CreateUserNo = "Admin",
                    DataStatus = DataStatus.Valid,
                    Email = "",
                    Gender = Gender.Male,
                    MemberType = MemberType.Normal,
                    MobilePhone = "",
                    NickName = "潇刚",
                    QQ = "",
                    Residence = "北京",
                    Role = Role.Admin,
                    TrueName = "成刚",
                    UpdateTime = DateTime.Now,
                    UpdateUserNo = "Admin"
                };
                var userId = new CyUserService().AddCyUser(entity, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
