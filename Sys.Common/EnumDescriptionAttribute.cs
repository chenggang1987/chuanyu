/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  EnumDescriptionAttribute
 * 版本号：  V1.0.0.0
 * 唯一标识：2265430c-5d71-4cd6-8551-6a1dce9afb5f
 * 创建人：  成刚
 * 创建时间：2015/7/29 0:10:05
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

namespace Sys.Common
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumDescriptionAttribute : Attribute
    {
        public int Order { get; set; }
        public bool Display { get; set; }
        public string Name { get; internal set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public object Value { get; internal set; }
        public long Number { get; internal set; }


        public EnumDescriptionAttribute()
        {
            Display = true;
        }

        public EnumDescriptionAttribute(string displayName, string description)
        {
            DisplayName = displayName;
            Description = description;
            Display = true;
        }

        public EnumDescriptionAttribute(string displayName)
        {
            DisplayName = displayName;
            Display = true;
        }
    }
}
