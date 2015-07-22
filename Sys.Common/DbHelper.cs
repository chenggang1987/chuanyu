/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  DbHelper
 * 版本号：  V1.0.0.0
 * 唯一标识：48eed13f-6541-490e-b390-bc056d7629db
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:42:20
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
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Common
{
    public class DbHelper
    {
        public static bool TryGetConnectionName(string nameOrConnectionString, out string name)
        {
            int num = nameOrConnectionString.IndexOf('=');
            if (num < 0)
            {
                name = nameOrConnectionString;
                return true;
            }
            if (nameOrConnectionString.IndexOf('=', num + 1) >= 0)
            {
                name = null;
                return false;
            }
            if (nameOrConnectionString.Substring(0, num).Trim().Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                name = nameOrConnectionString.Substring(num + 1).Trim();
                return true;
            }
            name = null;
            return false;
        }
        public static bool TryGetConnectionNameXml(string nameOrConnectionString, out string name)
        {
            if (string.IsNullOrEmpty(nameOrConnectionString))
            {
                name = null;
                return false;
            }
            else
            {
                name = nameOrConnectionString;
                return true;
            }

            name = null;
            return false;
        }

        /// <summary>
        /// 创建一个数据库连接依据XML文件（not opened）
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static DbConnection CreateConnectionXml(string nameOrConnectionString, string providerName)
        {
            var name = default(string);
            if (TryGetConnectionNameXml(nameOrConnectionString, out name))
            {
                var connectionStrings = default(ConnectionStringSettings);
                if (string.IsNullOrEmpty(name))
                {
                    throw new InvalidOperationException("Can't find a connection string with the name '" + name + "'");
                }
                else
                {
                    connectionStrings = new ConnectionStringSettings();
                    connectionStrings.ConnectionString = nameOrConnectionString.Trim();
                    connectionStrings.ProviderName = providerName.Trim();
                }

                if (connectionStrings != null)
                {
                    if (string.IsNullOrEmpty(connectionStrings.ProviderName))
                    {
                        throw new InvalidOperationException("Can't find providername with the name '" + name + "'");
                    }
                    else
                    {
                        var factory = DbProviderFactories.GetFactory(connectionStrings.ProviderName);
                        if (factory == null)
                        {
                            throw new InvalidOperationException("Can't find provider=" + connectionStrings.ProviderName + " with the name '" + name + "'");
                        }
                        else
                        {
                            var dbConnection = factory.CreateConnection();
                            dbConnection.ConnectionString = connectionStrings.ConnectionString;
                            return dbConnection;
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("Can't find a connection string with the name '" + name + "'");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(providerName))
                {
                    throw new ArgumentNullException(providerName, "providerName can't is null or empty!");
                }
                else
                {
                    var factory = DbProviderFactories.GetFactory(providerName);
                    if (factory == null)
                    {
                        throw new InvalidOperationException("Can't find provider=" + providerName);
                    }
                    else
                    {
                        var dbConnection = factory.CreateConnection();
                        dbConnection.ConnectionString = nameOrConnectionString;
                        return dbConnection;
                    }
                }
            }
        }
        /// <summary>
        /// 创建一个数据库连接（not opened）
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <returns></returns>
        public static DbConnection CreateConnection(string nameOrConnectionString, string providerName = null)
        {
            var name = default(string);
            if (TryGetConnectionName(nameOrConnectionString, out name))
            {
                var connectionStrings = default(ConnectionStringSettings);
                if (string.IsNullOrEmpty(name))
                {
                    connectionStrings = ConfigurationManager.ConnectionStrings[0];
                }
                else
                {
                    connectionStrings = ConfigurationManager.ConnectionStrings[name];
                }

                if (connectionStrings != null)
                {
                    if (string.IsNullOrEmpty(connectionStrings.ProviderName))
                    {
                        throw new InvalidOperationException("Can't find providername with the name '" + name + "'");
                    }
                    else
                    {
                        var factory = DbProviderFactories.GetFactory(connectionStrings.ProviderName);
                        if (factory == null)
                        {
                            throw new InvalidOperationException("Can't find provider=" + connectionStrings.ProviderName + " with the name '" + name + "'");
                        }
                        else
                        {
                            var dbConnection = factory.CreateConnection();
                            dbConnection.ConnectionString = connectionStrings.ConnectionString;
                            return dbConnection;
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("Can't find a connection string with the name '" + name + "'");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(providerName))
                {
                    throw new ArgumentNullException(providerName, "providerName can't is null or empty!");
                }
                else
                {
                    var factory = DbProviderFactories.GetFactory(providerName);
                    if (factory == null)
                    {
                        throw new InvalidOperationException("Can't find provider=" + providerName);
                    }
                    else
                    {
                        var dbConnection = factory.CreateConnection();
                        dbConnection.ConnectionString = nameOrConnectionString;
                        return dbConnection;
                    }
                }
            }
        }
        private static DbProviderFactory GetDbProviderFactory(string nameOrConnectionString, string providerName, out string connectionString)
        {
            var name = default(string);
            if (TryGetConnectionName(nameOrConnectionString, out name))
            {
                var connectionStrings = default(ConnectionStringSettings);
                if (string.IsNullOrEmpty(name))
                {
                    throw new InvalidOperationException("Can't find a connection string with the name '" + name + "'");
                    // connectionStrings = ConfigurationManager.ConnectionStrings[DefaultConnectionName];
                }
                else
                {
                    connectionStrings = ConfigurationManager.ConnectionStrings[name];
                }

                if (connectionStrings == null)
                {
                    throw new InvalidOperationException("Can't find a connection string with the name '" + name + "'");
                }
                else
                {
                    var factory = DbProviderFactories.GetFactory(connectionStrings.ProviderName);
                    connectionString = connectionStrings.ConnectionString;
                    return factory;
                }
            }
            else
            {
                var factory = DbProviderFactories.GetFactory(providerName);
                connectionString = nameOrConnectionString;
                return factory;
            }
        }
        ///// <summary>
        ///// 创建一个打开的数据库连接
        ///// </summary>
        ///// <param name="nameOrConnectionString"></param>
        ///// <param name="providerName"></param>
        ///// <returns></returns>
        //public static DbConnection CreateOpenConnection(string nameOrConnectionString, string providerName = null)
        //{
        //    var dbConnection = CreateConnection(nameOrConnectionString, providerName);
        //    dbConnection.Open();
        //    return dbConnection;
        //}

        /// <summary>
        /// 创建一个打开的数据库连接
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static DbConnection CreateOpenConnection(string nameOrConnectionString, string providerName = null, TransactionScopeType scopeType = TransactionScopeType.Default)
        {
            if (scopeType == TransactionScopeType.Default)
            {
                var dbConnection = CreateConnection(nameOrConnectionString, providerName);
                dbConnection.Open();
                return dbConnection;
            }
            else
            {
                return GetOpenConnection(nameOrConnectionString, providerName);
            }
        }
        /// <summary>
        ///	Gets a "wrapped" connection that will be not be disposed if a transaction is
        ///	active (created by creating a <see cref="TransactionScope"/> instance). The
        ///	onnection will be disposed when no transaction is active.
        /// </summary>
        /// <returns></returns>
        private static DbConnection GetOpenConnection(string nameOrConnectionString, string providerName = null)
        {
            var connectionString = default(string);
            var factory = GetDbProviderFactory(nameOrConnectionString, providerName, out connectionString);
            var connection = ConcurrentTransactionScopeConnections.GetConnection(connectionString, factory);
            return connection ?? GetWrappedConnection(connectionString, factory);
        }

        /// <summary>
        /// Gets a "wrapped" connection for use outside a transaction.
        /// </summary>
        /// <returns>The wrapped connection.</returns>
        private static DbConnectionWrapper GetWrappedConnection(string connectionString, DbProviderFactory factory)
        {
            var dbConnection = factory.CreateConnection();
            dbConnection.ConnectionString = connectionString;
            dbConnection.Open();
            return new DbConnectionWrapper(dbConnection, factory);
        }
    }
    public enum TransactionScopeType
    {
        Default = 0,
        Concurrent = 1
    }
}
