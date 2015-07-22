/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Data.UserProvider
 * 文件名：  CyUserProvider
 * 版本号：  V1.0.0.0
 * 唯一标识：a88dd1d9-19ed-425a-b0eb-32f928106497
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:33:41
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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChuanYu.TA.Entity.Common;
using ChuanYu.TA.Entity.Enums;
using ChuanYu.TA.Entity.User;
using Sys.Common;
using Sys.Common.Dapper;

namespace ChuanYu.TA.Data.UserProvider
{
    public class CyUserProvider
    {
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务</param>
        /// <returns>执行结果</returns>
        public CommonResult<string> AddCyUser(CyUserEntity entity, IDbTransaction trans = null)
        {
            var commonResult = new CommonResult<string>();
            const string sql = @"INSERT INTO [dbo].[CyUser]
                                        ([UserNo]
                                        ,[UserName]
                                        ,[UserPwd]
                                        ,[NickName]
                                        ,[TrueName]
                                        ,[Gender]
                                        ,[MobilePhone]
                                        ,[Email]
                                        ,[QQ]
                                        ,[Birthday]
                                        ,[BirthPlace]
                                        ,[Residence]
                                        ,[MemberType]
                                        ,[Role]
                                        ,[CreateUserNo]
                                        ,[CreateTime]
                                        ,[UpdateUserNo]
                                        ,[UpdateTime]
                                        ,[DataStatus])
                                    VALUES
                                        (@UserNo
                                        ,@UserName
                                        ,@UserPwd
                                        ,@NickName
                                        ,@TrueName
                                        ,@Gender
                                        ,@MobilePhone
                                        ,@Email
                                        ,@QQ
                                        ,@Birthday
                                        ,@BirthPlace
                                        ,@Residence
                                        ,@MemberType
                                        ,@Role
                                        ,@CreateUserNo
                                        ,@CreateTime
                                        ,@UpdateUserNo
                                        ,@UpdateTime
                                        ,@DataStatus)";
            if (trans == null)
            {
                using (var conn = DbHelper.CreateOpenConnection(DbConnectionStringConfig.CyMainDbConnectionStringName))
                {
                    try
                    {
                        var rows = conn.Execute(sql, entity);

                        commonResult.Success = true;
                        commonResult.Message = "执行成功";
                        commonResult.EffectRows = rows;
                    }
                    catch (Exception ex)
                    {
                        commonResult.Success = false;
                        commonResult.IsHappenEx = true;
                        commonResult.Message = "执行失败";
                        commonResult.ExMessage = ex.Message;
                        commonResult.ExData = ex;
                    }
                }
            }
            else
            {
                try
                {
                    var rows = trans.Connection.Execute(sql, entity, transaction: trans);

                    commonResult.Success = true;
                    commonResult.Message = "执行成功";
                    commonResult.EffectRows = rows;
                }
                catch (Exception ex)
                {
                    commonResult.Success = false;
                    commonResult.IsHappenEx = true;
                    commonResult.Message = "执行失败";
                    commonResult.ExMessage = ex.Message;
                    commonResult.ExData = ex;
                }
            }
            return commonResult;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务</param>
        /// <returns>执行结果</returns>
        public CommonResult<string> ModifyCyUser(CyUserEntity entity, IDbTransaction trans = null)
        {
            var commonResult = new CommonResult<string>();
            const string sql = @"UPDATE [dbo].[CyUser]
                                   SET [UserName] =@UserName
                                      ,[UserPwd] =@UserPwd
                                      ,[NickName] =@NickName
                                      ,[TrueName] =@TrueName
                                      ,[Gender] =@Gender
                                      ,[MobilePhone] =@MobilePhone
                                      ,[Email] =@Email
                                      ,[QQ] =@QQ
                                      ,[Birthday] =@Birthday
                                      ,[BirthPlace] =@BirthPlace
                                      ,[Residence] =@Residence
                                      ,[MemberType] =@MemberType
                                      ,[Role] =@Role
                                      ,[CreateUserNo] =@CreateUserNo
                                      ,[CreateTime] =@CreateTime
                                      ,[UpdateUserNo] =@UpdateUserNo
                                      ,[UpdateTime] =@UpdateTime
                                      ,[DataStatus] =@DataStatus
                                WHERE UserNo=@UserNo";
            if (trans == null)
            {
                using (var conn = DbHelper.CreateOpenConnection(DbConnectionStringConfig.CyMainDbConnectionStringName))
                {
                    try
                    {
                        var rows = conn.Execute(sql,entity);
                        commonResult.Success = true;
                        commonResult.Message = "执行成功";
                        commonResult.EffectRows = rows;
                    }
                    catch (Exception ex)
                    {
                        commonResult.Success = false;
                        commonResult.IsHappenEx = true;
                        commonResult.Message = "执行失败";
                        commonResult.ExMessage = ex.Message;
                        commonResult.ExData = ex;
                    }
                }
            }
            else
            {
                try
                {
                    var rows = trans.Connection.Execute(sql, entity, transaction: trans);

                    commonResult.Success = true;
                    commonResult.Message = "执行成功";
                    commonResult.EffectRows = rows;
                }
                catch (Exception ex)
                {
                    commonResult.Success = false;
                    commonResult.IsHappenEx = true;
                    commonResult.Message = "执行失败";
                    commonResult.ExMessage = ex.Message;
                    commonResult.ExData = ex;
                }
            }
            return commonResult;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <returns></returns>
        public CommonResult<CyUserEntity> GetCyUserByNo(string userNo)
        {
            var commonResult = new CommonResult<CyUserEntity>();
            const string sql = @"SELECT [UserId]
                                        ,[UserNo]
                                        ,[UserName]
                                        ,[UserPwd]
                                        ,[NickName]
                                        ,[TrueName]
                                        ,[Gender]
                                        ,[MobilePhone]
                                        ,[Email]
                                        ,[QQ]
                                        ,[Birthday]
                                        ,[BirthPlace]
                                        ,[Residence]
                                        ,[MemberType]
                                        ,[Role]
                                        ,[CreateUserNo]
                                        ,[CreateTime]
                                        ,[UpdateUserNo]
                                        ,[UpdateTime]
                                        ,[DataStatus]
                                    FROM [dbo].[CyUser](NOLOCK)
                                    WHERE UserNo=@UserNo";
            using (var conn = DbHelper.CreateOpenConnection(DbConnectionStringConfig.CyReadConnectionStringName))
            {
                try
                {
                    var model = conn.Query<CyUserEntity>(sql, new { UserNo = userNo, DataStatus = DataStatus.Valid }).ToList();
                    commonResult.Success = true;
                    commonResult.Message = "执行成功";
                    commonResult.ResultObjList = model;
                }
                catch (Exception ex)
                {
                    commonResult.Success = false;
                    commonResult.IsHappenEx = true;
                    commonResult.Message = "执行失败";
                    commonResult.ExMessage = ex.Message;
                    commonResult.ExData = ex;
                }
                return commonResult;
            }
        }

    }
}
