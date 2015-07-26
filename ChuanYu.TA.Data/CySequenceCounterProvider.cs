using ChuanYu.TA.Entity;
using Sys.Common;
/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Data
 * 文件名：  CySequenceCounterProvider
 * 版本号：  V1.0.0.0
 * 唯一标识：4272e0ac-07f3-415b-b25f-a7e76970e544
 * 创建人：  成刚
 * 创建时间：2015/7/26 19:17:10
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
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.Common.Dapper;

namespace ChuanYu.TA.Data
{
    /// <summary>
    /// 序列计数类
    /// </summary>
    public class CySequenceCounterProvider
    {

        private static readonly Object MutexObj = new Object();
        private static readonly Object MutexObj1 = new Object();
        private static readonly Object MutexObj2 = new Object();
        /// <summary>
        /// 根据Key获取一个自增的序列号 by chenggang
        /// </summary>
        /// <param name="sequenceKey">Key</param>
        /// <returns>序列号</returns>
        public int GetNextCounterId(string sequenceKey)
        {
            int counterId = 1;
            try
            {
                lock (MutexObj)
                {
                    using (var conn = DbHelper.CreateOpenConnection(DbConnectionStringConfig.CyMainDbConnectionStringName))
                    {
                        var model = GetCounterIdByKey(sequenceKey, conn);
                        if (model == null)
                        {
                            var addModel = new CySequenceCounterEntity()
                            {
                                SequenceKey = sequenceKey,
                                CounterId = counterId,
                                UpdateTime = DateTime.Now
                            };
                            int addRow = Add(addModel, conn);
                        }
                        else
                        {
                            counterId = model.CounterId + 1;
                            var updateModel = new CySequenceCounterEntity()
                            {
                                SequenceKey = sequenceKey,
                                CounterId = counterId,
                                UpdateTime = DateTime.Now
                            };
                            int pdateRow = Update(updateModel, conn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ;
            }
            return counterId;
        }

        /// <summary>
        /// 根据Key获取一个递增指定数量的序列号 by chenggang
        /// </summary>
        /// <param name="sequenceKey">Key</param>
        /// <param name="count">递增指定数量</param>
        /// <returns>序列号</returns>
        public int GetNextNumCounterId(string sequenceKey, int count)
        {
            int counterId = 1;
            try
            {
                lock (MutexObj1)
                {
                    using (var conn = DbHelper.CreateOpenConnection(DbConnectionStringConfig.CyMainDbConnectionStringName))
                    {
                        var model = GetCounterIdByKey(sequenceKey, conn);
                        if (model == null)
                        {
                            var addModel = new CySequenceCounterEntity()
                            {
                                SequenceKey = sequenceKey,
                                CounterId = counterId + count,
                                UpdateTime = DateTime.Now
                            };
                            int addRow = Add(addModel, conn);
                        }
                        else
                        {
                            counterId = model.CounterId + count;
                            var updateModel = new CySequenceCounterEntity()
                            {
                                SequenceKey = sequenceKey,
                                CounterId = counterId,
                                UpdateTime = DateTime.Now
                            };
                            int pdateRow = Update(updateModel, conn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ;
            }
            return counterId;
        }

        /// <summary>
        /// 根据日期获取一个新的自增序列编号（每天从1开始重新计数）  by chenggang
        /// </summary>
        /// <param name="sequenceKey">Key</param>
        /// <returns>日期加自增序列组合的编号</returns>
        public long GetNewNoOfEveryDayReset(string sequenceKey)
        {
            try
            {
                int counterId = 1;
                string newNo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
                lock (MutexObj2)
                {
                    using (var conn = DbHelper.CreateOpenConnection(DbConnectionStringConfig.CyMainDbConnectionStringName))
                    {
                        var model = GetCounterIdByKey(sequenceKey, conn);
                        if (model == null)
                        {
                            var addModel = new CySequenceCounterEntity()
                            {
                                SequenceKey = sequenceKey,
                                CounterId = counterId,
                                UpdateTime = DateTime.Now
                            };
                            int addRow = Add(addModel, conn);
                            newNo += counterId.ToString("00000");
                        }
                        else
                        {
                            var currentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                            var dateUpdate = Convert.ToDateTime(model.UpdateTime.ToString("yyyy-MM-dd"));
                            var result = DateTime.Compare(currentDate, dateUpdate);
                            if (result > 0)
                            {
                                var updateModel = new CySequenceCounterEntity()
                                {
                                    SequenceKey = sequenceKey,
                                    CounterId = counterId,
                                    UpdateTime = DateTime.Now
                                };
                                int pdateRow = Update(updateModel, conn);
                                newNo += counterId.ToString("00000");
                            }
                            else
                            {
                                counterId = model.CounterId + 1;
                                var updateModel = new CySequenceCounterEntity()
                                {
                                    SequenceKey = sequenceKey,
                                    CounterId = counterId,
                                    UpdateTime = DateTime.Now
                                };
                                int pdateRow = Update(updateModel, conn);
                                newNo += counterId.ToString("00000");
                            }
                        }
                    }
                    return long.Parse(newNo);
                }
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        public static CySequenceCounterEntity GetCounterIdByKey(string sequenceKey, DbConnection conn)
        {
            const string sql = @"SELECT  CounterId,UpdateTime
                                FROM    [dbo].[CySequenceCounter](nolock) 
                                WHERE   SequenceKey = @SequenceKey";
            try
            {
                var model = conn.Query<CySequenceCounterEntity>(sql, new { SequenceKey = sequenceKey }).FirstOrDefault<CySequenceCounterEntity>();
                return model;
            }
            catch (Exception ex)
            {

                throw ;
            }
        }

        public static int Add(CySequenceCounterEntity entity, DbConnection conn)
        {
            const string sql = @"INSERT INTO [dbo].[CySequenceCounter]
                                ([SequenceKey]
                                ,[CounterId]
                                ,UpdateTime)
                                VALUES
                                (@SequenceKey
                                ,@CounterId
                                ,@UpdateTime)";
            try
            {
                int result = conn.Execute(sql, entity);
                return result;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        public static int Update(CySequenceCounterEntity entity, DbConnection conn)
        {
            const string sql = @"UPDATE  [dbo].[CySequenceCounter]
                                SET     CounterId = @CounterId,UpdateTime=@UpdateTime
                                WHERE   SequenceKey = @SequenceKey";
            try
            {
                int result = conn.Execute(sql, entity);
                return result;
            }
            catch (Exception ex)
            {

                throw ;
            }
        }
    }
}
