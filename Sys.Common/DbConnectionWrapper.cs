/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  DbConnectionWrapper
 * 版本号：  V1.0.0.0
 * 唯一标识：34b00714-b391-4927-a254-dcddf20c7fc9
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:51:23
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
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sys.Common
{
    [DesignerCategory("")]
    public class DbConnectionWrapper : DbConnection
    {
        private int _refCount;
        private DbConnection _conn;
        private DbProviderFactory _factory;

        protected override DbProviderFactory DbProviderFactory { get { return base.DbProviderFactory ?? _factory; } }

        public DbConnection WrappedConnection
        {
            get
            {
                return this._conn;
            }
        }
        protected override bool CanRaiseEvents
        {
            get
            {
                return true;
            }
        }

        public override string ConnectionString
        {
            get
            {
                return this._conn.ConnectionString;
            }
            set
            {
                this._conn.ConnectionString = value;
            }
        }

        public override int ConnectionTimeout
        {
            get
            {
                return this._conn.ConnectionTimeout;
            }
        }
        public override string Database
        {
            get
            {
                return this._conn.Database;
            }
        }
        public override string DataSource
        {
            get
            {
                return this._conn.DataSource;
            }
        }
        public override string ServerVersion
        {
            get
            {
                return this._conn.ServerVersion;
            }
        }
        public override ConnectionState State
        {
            get
            {
                return this._conn.State;
            }
        }

        public bool IsDisposed
        {
            get { return _refCount == 0; }
        }

        public DbConnectionWrapper(DbConnection connection, DbProviderFactory factory)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            _factory = factory;
            _refCount = 1;
            this._conn = connection;
            this._conn.StateChange += new StateChangeEventHandler(this.StateChangeHandler);
        }
        public override void ChangeDatabase(string databaseName)
        {
            this._conn.ChangeDatabase(databaseName);
        }
        public override void Close()
        {
            this._conn.Close();
        }
        public override void EnlistTransaction(System.Transactions.Transaction transaction)
        {
            this._conn.EnlistTransaction(transaction);
        }
        public override DataTable GetSchema()
        {
            return this._conn.GetSchema();
        }
        public override DataTable GetSchema(string collectionName)
        {
            return this._conn.GetSchema(collectionName);
        }
        public override DataTable GetSchema(string collectionName, string[] restrictionValues)
        {
            return this._conn.GetSchema(collectionName, restrictionValues);
        }
        public override void Open()
        {
            this._conn.Open();
        }
        protected override DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel)
        {
            return this._conn.BeginTransaction(isolationLevel);
        }
        protected override DbCommand CreateDbCommand()
        {
            return this._conn.CreateCommand();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this._conn != null)
            {
                int count = Interlocked.Decrement(ref _refCount);
                if (count == 0)
                {
                    this._conn.StateChange -= new StateChangeEventHandler(this.StateChangeHandler);
                    this._conn.Dispose();
                    this._conn = null;
                    base.Dispose(disposing);
                }
            }
        }

        private void StateChangeHandler(object sender, StateChangeEventArgs e)
        {
            this.OnStateChange(e);
        }

        /// <summary>
        /// Increment the reference count for the wrapped connection.
        /// </summary>
        public DbConnectionWrapper AddRef()
        {
            Interlocked.Increment(ref _refCount);
            return this;
        }
    }
}
