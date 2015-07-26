/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Domain.Services
 * 文件名：  CyUserService
 * 版本号：  V1.0.0.0
 * 唯一标识：224a9885-9ad8-4fa5-87b9-979319a5b4aa
 * 创建人：  成刚
 * 创建时间：2015/7/26 14:34:47
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
using ChuanYu.TA.Data.User;
using ChuanYu.TA.Entity.Common;
using ChuanYu.TA.Entity.User;
using Sys.Common;

namespace ChuanYu.TA.Domain.Services
{
    public class CyUserService
    {
        #region 实例化对象
        /// <summary>
        /// 用户类对象
        /// </summary>
        private readonly Lazy<CyUserProvider> _userProvider = new Lazy<CyUserProvider>();
        public CyUserProvider CyUserProvider
        {
            get
            {
                return _userProvider.Value;
            }
        }
        #endregion

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务</param>
        /// <returns>执行结果</returns>
        public CommonResult<string> AddCyUser(CyUserEntity entity, IDbTransaction trans = null)
        {
            try
            {
                return CyUserProvider.AddCyUser(entity, trans);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务</param>
        /// <returns>执行结果</returns>
        public CommonResult<string> ModifyCyUser(CyUserEntity entity, IDbTransaction trans = null)
        {
            try
            {
                return CyUserProvider.ModifyCyUser(entity, trans);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userNo">用户编号</param>
        /// <returns></returns>
        public CommonResult<CyUserEntity> GetCyUserByNo(string userNo)
        {
            try
            {
                return CyUserProvider.GetCyUserByNo(userNo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 添加登录日志
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public CommonResult<string> AddCyUserLoginLog(CyUserLoginLogEntity entity, IDbTransaction trans = null)
        {
            try
            {
                return CyUserProvider.AddCyUserLoginLog(entity, trans);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CommonResult<CyUserEntity> Login(CyUserEntity user)
        {
            try
            {
                var commonResult = new CommonResult<CyUserEntity>();
                if (string.IsNullOrEmpty(user.UserName))
                {

                    commonResult.Success = false;
                    commonResult.Message = "用户名为空";
                    return commonResult;
                }

                if (string.IsNullOrEmpty(user.UserPwd))
                {

                    commonResult.Success = false;
                    commonResult.Message = "密码为空";
                    return commonResult;
                }

                var userResult = CyUserProvider.GetCyUserByUserName(user.UserName);
                if (userResult.Success)
                {
                    var userModel = userResult.ResultObjList;
                    if (userModel.Count == 0)
                    {
                        commonResult.Success = false;
                        commonResult.Message = "用户名不存在";
                        return commonResult;
                    }
                    //如果同一用户名出现重复记录
                    if (userModel.Count > 1)
                    {
                        commonResult.Success = false;
                        commonResult.Message = "用户信息异常请联系管理员";
                        return commonResult;
                    }
                    if (userModel[0].UserPwd != StringUtil.ToHashString(user.UserPwd))
                    {
                        commonResult.Success = false;
                        commonResult.Message = "密码错误";
                        return commonResult;
                    }

                    commonResult.Success = true;
                    commonResult.Message = "验证成功";
                    commonResult.ResultObj = userModel[0];
                }
                else
                {
                    commonResult = userResult;
                    return commonResult;
                }

                return commonResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
