/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Domain.Common
 * 文件名：  AutoMappingProfile
 * 版本号：  V1.0.0.0
 * 唯一标识：41bafbc0-013c-4cf4-a2f8-0ee883ef8129
 * 创建人：  成刚
 * 创建时间：2015/7/29 1:08:40
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
using ChuanYu.TA.Entity.User;
using ChuanYu.TA.MvcApp.Models;

namespace ChuanYu.TA.MvcApp.Common
{
    class AutoMappingProfile : Profile
    {
         public override string ProfileName
        {
            get { return "CyAutoMapper"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CyUser, CyUserEntity>();
            Mapper.CreateMap<CyUserEntity, CyUser>();
            Mapper.CreateMap<CyCompany, CyCompanyEntity>();
        }
    }
}
