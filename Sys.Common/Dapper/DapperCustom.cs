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

using System.Data;

namespace Sys.Common.Dapper
{
    public partial class SqlMapper
    {
        #region Custom
        public static IDataReader ExecuteReader(
#if CSHARP30
            this IDbConnection cnn, string sql, object param, IDbTransaction transaction, int? commandTimeout, CommandType? commandType
#else
this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null
#endif
)
        {
            Identity identity = new SqlMapper.Identity(sql, commandType, cnn, typeof(SqlMapper.GridReader), (object)param == null ? null : ((object)param).GetType(), null);
            CacheInfo info = GetCacheInfo(identity);

            IDbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                cmd = SetupCommand(cnn, transaction, sql, info.ParamReader, (object)param, commandTimeout, commandType);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                if (reader != null) reader.Dispose();
                if (cmd != null) cmd.Dispose();
                throw;
            }
        }
        #endregion
    }
}
