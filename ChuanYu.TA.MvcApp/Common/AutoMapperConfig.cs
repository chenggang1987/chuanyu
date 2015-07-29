/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Domain.Common
 * 文件名：  AutoMapperConfig
 * 版本号：  V1.0.0.0
 * 唯一标识：b86e316d-5d85-47a1-9f82-26df79396b0c
 * 创建人：  成刚
 * 创建时间：2015/7/29 1:13:10
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

using AutoMapper;
using ChuanYu.TA.Domain.Common;

namespace ChuanYu.TA.MvcApp.Common
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMappingProfile>();
            });
        }
    }
}
