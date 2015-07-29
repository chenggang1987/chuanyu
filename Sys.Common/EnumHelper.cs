/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：Sys.Common
 * 文件名：  EnumHelper
 * 版本号：  V1.0.0.0
 * 唯一标识：5b0d37b6-0436-46b2-a7ce-5e030df395be
 * 创建人：  成刚
 * 创建时间：2015/7/29 0:09:00
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
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Common
{
    public class EnumHelper
    {
        private static readonly ConcurrentDictionary<Type, EnumDescriptionAttribute[]> EnumTypeDescs = new ConcurrentDictionary<Type, EnumDescriptionAttribute[]>();
        private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<object, EnumDescriptionAttribute[]>> EnumValueDescs = new ConcurrentDictionary<Type, ConcurrentDictionary<object, EnumDescriptionAttribute[]>>();

        /// <summary>
        /// objA Contains objB
        /// </summary>
        /// <param name="objA"></param>
        /// <param name="objB"></param>
        /// <param name="underlyingType"></param>
        /// <returns></returns>
        public static bool Contains(object objA, object objB, Type underlyingType)
        {
            if (objA == null || objB == null)
            {
                return false;
            }
            switch (underlyingType.Name)
            {
                case "Byte":
                    var byte1 = (byte)objA;
                    var byte2 = (byte)objB;
                    if ((byte1 & byte2) == byte2 && byte2 != 0)
                    {
                        return true;
                    }
                    break;
                case "SByte":
                    var sbyte1 = (sbyte)objA;
                    var sbyte2 = (sbyte)objB;
                    if ((sbyte1 & sbyte2) == sbyte2 && sbyte2 != 0)
                    {
                        return true;
                    }
                    break;
                case "Int16":
                    var short1 = (short)objA;
                    var short2 = (short)objB;
                    if ((short1 & short2) == short2 && short2 != 0)
                    {
                        return true;
                    }
                    break;
                case "UInt16":
                    var ushort1 = (ushort)objA;
                    var ushort2 = (ushort)objB;
                    if ((ushort1 & ushort2) == ushort2 && ushort2 != 0)
                    {
                        return true;
                    }
                    break;
                case "Int32":
                    var int1 = (int)objA;
                    var int2 = (int)objB;
                    if ((int1 & int2) == int2 && int2 != 0)
                    {
                        return true;
                    }
                    break;
                case "UInt32":
                    var uint1 = (uint)objA;
                    var uint2 = (uint)objB;
                    if ((uint1 & uint2) == uint2 && uint2 != 0)
                    {
                        return true;
                    }
                    break;
                case "Int64":
                    var long1 = (long)objA;
                    var long2 = (long)objB;
                    if ((long1 & long2) == long2 && long2 != 0)
                    {
                        return true;
                    }
                    break;
                case "UInt64":
                    var ulong1 = (ulong)objA;
                    var ulong2 = (ulong)objB;
                    if ((ulong1 & ulong2) == ulong2 && ulong2 != 0)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        /// <summary>
        /// 得到枚举的描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumType">枚举类型</param>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(T enumValue, string separator = ",")
        {
            return string.Join(separator, GetEnumValueDescriptions(enumValue).Select(e => e.Description));
        }

        /// <summary>
        /// 得到枚举的描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static IEnumerable<EnumDescriptionAttribute> GetEnumValueDescriptions<T>(T enumValue)
        {
            var enumType = enumValue.GetType();
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("invalid enumvalue");
            }

            var dic = EnumValueDescs.GetOrAdd(enumType, new ConcurrentDictionary<object, EnumDescriptionAttribute[]>());
            var val = Convert.ChangeType(enumValue, ((Enum)(object)enumValue).GetTypeCode());
            return dic.GetOrAdd(val, (v) =>
            {
                var underlyingType = enumType.GetEnumUnderlyingType();
                var flags = enumType.GetCustomAttributes(typeof(FlagsAttribute), true);
                var typeDescs = GetEnumDescriptions(enumType);
                var valueDescs = new List<EnumDescriptionAttribute>();

                if (flags.Length > 0)
                {
                    foreach (var desc in typeDescs)
                    {

                        switch (underlyingType.Name)
                        {
                            case "Byte":
                                var byte1 = (byte)v;
                                var byte2 = (byte)desc.Value;
                                if ((byte1 & byte2) == byte2 && byte2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                            case "SByte":
                                var sbyte1 = (sbyte)v;
                                var sbyte2 = (sbyte)desc.Value;
                                if ((sbyte1 & sbyte2) == sbyte2 && sbyte2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                            case "Int16":
                                var short1 = (short)v;
                                var short2 = (short)desc.Value;
                                if ((short1 & short2) == short2 && short2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                            case "UInt16":
                                var ushort1 = (ushort)v;
                                var ushort2 = (ushort)desc.Value;
                                if ((ushort1 & ushort2) == ushort2 && ushort2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                            case "Int32":
                                var int1 = (int)v;
                                var int2 = (int)desc.Value;
                                if ((int1 & int2) == int2 && int2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                            case "UInt32":
                                var uint1 = (uint)v;
                                var uint2 = (uint)desc.Value;
                                if ((uint1 & uint2) == uint2 && uint2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                            case "Int64":
                                var long1 = (long)v;
                                var long2 = (long)desc.Value;
                                if ((long1 & long2) == long2 && long2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                            case "UInt64":
                                var ulong1 = (ulong)v;
                                var ulong2 = (ulong)desc.Value;
                                if ((ulong1 & ulong2) == ulong2 && ulong2 != 0)
                                {
                                    valueDescs.Add(desc);
                                }
                                break;
                        }
                    }
                }
                else
                {
                    foreach (var desc in typeDescs)
                    {
                        if (v.Equals(desc.Value))
                        {
                            valueDescs.Add(desc);
                            break;
                        }
                    }
                }

                return valueDescs.ToArray();
            });
        }

        /// <summary>
        /// 得到枚举类型的全部值描述
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumDescriptionAttribute> GetEnumDescriptions(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("invalid enumvalue");
            }

            return InternalGetEnumDescriptions(enumType).ToList();
        }

        private static EnumDescriptionAttribute[] InternalGetEnumDescriptions(Type enumType)
        {
            return EnumTypeDescs.GetOrAdd(enumType, (type) =>
            {
                var descs = new List<EnumDescriptionAttribute>();
                var fields = type.GetFields();
                for (int i = 1; i < fields.Length; ++i)
                {
                    var fieldValue = (Enum)Enum.Parse(type, fields[i].Name);
                    var enumValue = Convert.ChangeType(fieldValue, fieldValue.GetTypeCode());
                    var attrs = fields[i].GetCustomAttributes(true);
                    var findAttr = false;
                    foreach (object attr in attrs)
                    {
                        var temp = attr as EnumDescriptionAttribute;
                        if (temp != null)
                        {
                            var desc = new EnumDescriptionAttribute();
                            var name = fields[i].Name;
                            desc.Value = enumValue;
                            desc.Number = Convert.ToInt64(enumValue);
                            desc.Name = name;
                            desc.Order = temp.Order;
                            desc.Display = temp.Display;
                            desc.DisplayName = temp.DisplayName ?? name;
                            desc.Description = temp.Description ?? desc.DisplayName;
                            descs.Add(desc);
                            findAttr = true;
                            break;
                        }
                    }

                    if (!findAttr)
                    {
                        var desc = new EnumDescriptionAttribute();
                        var name = fields[i].Name;
                        desc.Display = true;
                        desc.Value = enumValue;
                        desc.Number = Convert.ToInt64(enumValue);
                        desc.Name = name;
                        desc.DisplayName = name;
                        desc.Description = name;
                        descs.Add(desc);
                    }
                }

                return descs.OrderBy(d => d.Order).ToArray();
            }
                );
        }

        public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct
        {
            result = default(TEnum);
            long num = 0L;
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (value.IndexOf(',') != -1)
            {
                var enumType = typeof(TEnum);
                var underlyingType = Enum.GetUnderlyingType(enumType);
                var array = value.Split(',');
                var attrs = GetEnumDescriptions(enumType);
                foreach (var v in array)
                {
                    TEnum temp = default(TEnum);

                    if (Enum.TryParse(v, ignoreCase, out temp))
                    {
                        var t = Convert.ChangeType(temp, underlyingType);
                        num |= Convert.ToInt64(Convert.ChangeType(temp, underlyingType));
                    }
                    else
                    {
                        return false;
                    }
                }
                result = (TEnum)Enum.ToObject(enumType, num);
            }
            else
            {
                return Enum.TryParse(value, ignoreCase, out result);
            }

            return true;
        }

        /// <summary>
        /// 获取枚举字典信息  2015-03-08 zz
        /// 处理乱序或者包含负数的Enum顺序问题
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumValueAndDescriptionsEx<T>()
        {
            var rValue = new Dictionary<int, string>();
            Type type = typeof(T);
            FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
            string[] names = Enum.GetNames(typeof(T));
            int[] values = Enum.GetValues(typeof(T)) as int[];
            if (values != null && (fields.Length == names.Length && fields.Length == values.Length))
            {
                for (int i = 0; i < names.Length; i++)
                {
                    var desc = GetEnumValue(fields, names[i]);
                    if (!rValue.ContainsKey(values[i]))
                    {
                        rValue.Add(values[i], desc);
                    }
                }
            }
            return rValue;
        }


        /// <summary>
        /// 根据Name取得描述值
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetEnumValue(FieldInfo[] fields, string name)
        {
            foreach (var item in fields)
            {
                if (item.Name.Equals(name))
                {
                    object[] custAttrs = item.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (custAttrs != null && custAttrs.Length > 0)
                    {
                        return ((DescriptionAttribute)custAttrs[0]).Description;
                    }
                }
            }
            return name;
        }

        /// <summary>
        /// 获取枚举的描述文本
        /// </summary>
        /// <param name="e">枚举成员</param>
        /// <returns></returns>
        public static string GetDescription(object e)
        {
            //获取字段信息
            System.Reflection.FieldInfo[] ms = e.GetType().GetFields();

            var t = e.GetType();
            foreach (System.Reflection.FieldInfo f in ms)
            {
                //判断名称是否相等
                if (f.Name != e.ToString()) continue;

                //反射出自定义属性
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    //类型转换找到一个Description，用Description作为成员名称
                    var dscript = attr as System.ComponentModel.DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }

            }
            //如果没有检测到合适的注释，则用默认名称
            return e.ToString();
        }
    }
}
