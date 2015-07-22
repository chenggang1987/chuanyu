/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  ConcurrentTransactionScopeConnections
 * 版本号：  V1.0.0.0
 * 唯一标识：990fb7e8-8bfb-40ae-ba89-80f5896f6ec3
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:49:12
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sys.Common
{
    /// <summary>
    ///	This class manages the connections that will be used when transactions are active
    ///	as a result of instantiating a <see cref="TransactionScope"/>. When a transaction
    ///	is active, all database access must be through this single connection unless you want
    ///	to use a distributed transaction, which is an expensive operation.
    /// </summary>
    public static class ConcurrentTransactionScopeConnections
    {
        // There's a reason why this field is not thread-static: notifications for completed Oracle transactions
        // may happen in a different thread
        private static readonly ConcurrentDictionary<System.Transactions.Transaction, ConcurrentDictionary<string, DbConnectionWrapper>> _transactionConnections =
            new ConcurrentDictionary<System.Transactions.Transaction, ConcurrentDictionary<string, DbConnectionWrapper>>();

        /// <summary>
        ///	Returns a connection for the current transaction. This will be an existing <see cref="DbConnection"/>
        ///	instance or a new one if there is a <see cref="TransactionScope"/> active. Otherwise this method
        ///	returns null.
        /// </summary>
        /// <param name="db"></param>
        /// <returns>Either a <see cref="DbConnection"/> instance or null.</returns>
        public static DbConnectionWrapper GetConnection(string connectionString, DbProviderFactory factory)
        {
            var currentTransaction = System.Transactions.Transaction.Current;

            if (currentTransaction == null)
            {
                return null;
            }

            var connectionList = _transactionConnections.GetOrAdd(currentTransaction, (t) =>
            {
                t.TransactionCompleted += OnTransactionCompleted; return new ConcurrentDictionary<string, DbConnectionWrapper>();
            });

            var connection = connectionList.GetOrAdd(connectionString, (s) =>
            {
                var dbConnection = factory.CreateConnection();
                dbConnection.ConnectionString = connectionString;
                dbConnection.Open();
                return new DbConnectionWrapper(dbConnection, factory);
            });

            connection.AddRef();
            return connection;
        }

        /// <summary>
        ///	This event handler is called whenever a transaction is about to be disposed, which allows
        ///	us to remove the transaction from our list and dispose the connection instance we created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void OnTransactionCompleted(object sender, TransactionEventArgs e)
        {
            var connectionList = default(ConcurrentDictionary<string, DbConnectionWrapper>);

            if (_transactionConnections.TryRemove(e.Transaction, out connectionList))
            {
                foreach (var connectionWrapper in connectionList.Values)
                {
                    connectionWrapper.Dispose();
                }
            }
        }
    }
}
