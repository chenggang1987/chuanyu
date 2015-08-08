/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34209
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  ListExtensions
 * 版本号：  V1.0.0.0
 * 唯一标识：b244d626-2a45-4c13-b1d7-e9595fd29757
 * 创建人：  成刚
 * 创建时间：2015/8/9 2:18:02
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Common
{
    public static class ListExtensions
    {
        /// <summary>
        /// 生成随机序列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public static void RandomPermute<T>(this IList<T> data)
        {
            var rnd = new Random();
            int count = data.Count;
            for (int i = 0; i < count; i++)
            {
                int index0 = rnd.Next(0, count - i);
                int index1 = count - i - 1;
                T tmp = data[index0];
                data[index0] = data[index1];
                data[index1] = tmp;
            }
        }
        /// <summary>
        /// 拆分集合为多个子集合
        /// </summary>
        /// <typeparam name="TData">元数据</typeparam>
        /// <param name="list">为拆分数据集合</param>
        /// <param name="size">拆分后每个集合数</param>
        /// <returns>返回拆分后的集合</returns>
        public static List<List<TData>> SplitStatic<TData>(this List<TData> list, int size) where TData : class
        {
            List<List<TData>> ret = null;
            if (list != null && list.Count > 0)
            {
                ret = new List<List<TData>>();
                if (list.Count <= size)
                {
                    ret.Add(list);
                    return ret;
                }
                var pages = (int)Math.Ceiling((list.Count / (double)size));
                var elem = list.AsEnumerable();
                for (int i = 0; i < pages; i++)
                {
                    ret.Add(elem.Skip(i * size).Take(size).ToList());
                }
                //int i = 0;
                //var temp = new List<TData>();
                //foreach (TData t in list)
                //{
                //    temp.Add(t);
                //    i++;
                //    if (i == size)
                //    {
                //        ret.Add(temp);
                //        temp = new List<TData>();
                //        i = 0;
                //    }
                //}

                //if (temp != null && temp.Count > 0)
                //{
                //    ret.Add(temp);
                //}
            }
            return ret;
        }
        /// <summary>
        /// 对集合的拆分
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="datas"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static ICollection<ICollection<TData>> SplitStaticCollenction<TData>(this ICollection<TData> datas, int size = 500) where TData : class
        {
            ICollection<ICollection<TData>> ret = null;
            if (datas != null && datas.Count > 0)
            {
                ret = new List<ICollection<TData>>();
                if (datas.Count <= size)
                {
                    ret.Add(datas);
                    return ret;
                }
                var pages = (int)Math.Ceiling(datas.Count / (double)size);
                var elms = datas.AsEnumerable();
                for (int i = 0; i < pages; i++)
                {
                    ret.Add(elms.Skip(i * size).Take(size).ToList());
                }
            }
            return ret;
        }

        public static ICollection<ICollection<TData>> SplitStaticConcurrentBag<TData>(this ConcurrentBag<TData> datas, int size = 500) where TData : class
        {
            ICollection<ICollection<TData>> ret = null;
            if (datas != null && datas.Count > 0)
            {
                ret = new List<ICollection<TData>>();
                if (datas.Count <= size)
                {
                    ret.Add(datas.ToArray());
                    return ret;
                }
                var pages = (int)Math.Ceiling(datas.Count / (double)size);
                var elms = datas.AsEnumerable();
                for (int i = 0; i < pages; i++)
                {
                    ret.Add(elms.Skip(i * size).Take(size).ToArray());
                }
            }
            return ret;
        }
        //public static List<List<TData>> SplitStaticByCount<TData>(this List<TData> source, int count = 5) where TData : class
        //{ 
        //    int 
        //}
        /// <summary>
        /// 遍历集合并提供方法
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="datas"></param>
        /// <param name="action"></param>
        public static void ForEach<TData>(this ICollection<TData> datas, Action<TData> action)
        {
            if (datas == null || datas.Count == 0)
            {
                return;
            }
            foreach (var item in datas)
            {
                action(item);
            }
        }
    }
}
