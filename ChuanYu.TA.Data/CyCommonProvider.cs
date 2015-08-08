/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34209
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Data
 * 文件名：  CyCommonProvider
 * 版本号：  V1.0.0.0
 * 唯一标识：2b3220e2-0d8f-44ba-a7b3-a7d792a1b45e
 * 创建人：  成刚
 * 创建时间：2015/8/9 1:26:31
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
using ChuanYu.TA.Entity.Common;
using ChuanYu.TA.Entity.Enums;
using ChuanYu.TA.Entity.User;
using Sys.Common;
using Sys.Common.Dapper;

namespace ChuanYu.TA.Data
{
    public class CyCommonProvider
    {
        public CommonResult<CyResourceEntity> GetCyResourceList()
        {
            var commonResult = new CommonResult<CyResourceEntity>();
            const string sql = @"SELECT [ResourceId]
                                        ,[ResourceCode]
                                        ,[ResourceName]
                                        ,[MenuCode]
                                        ,[RequestPath]
                                        ,[ResourceFlag]
                                        ,[Memo]
                                    FROM [dbo].[CyResource](nolock)";
            using (var conn = DbHelper.CreateOpenConnection(DbConnectionStringConfig.CyReadConnectionStringName))
            {
                try
                {
                    var model = conn.Query<CyResourceEntity>(sql).ToList();
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
