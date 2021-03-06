﻿/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Common
 * 文件名：  CommonResult
 * 版本号：  V1.0.0.0
 * 唯一标识：1ef1b705-81ad-406a-b7a1-3ba177b758b9
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:35:12
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

using System.Collections.Generic;

namespace ChuanYu.TA.Entity.Common.Menu
{
    public class Menu
    {
        public List<CurrentMenu> CurrentMenu { get; set; }
    }

    public class CurrentMenu
    {
        public MenuItem CurrentNavMenu { get; set; }
        public List<MenuItem> CurrentSideMenu { get; set; }
    }
}