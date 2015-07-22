/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Data
 * 文件名：  DbConnectionStringConfig
 * 版本号：  V1.0.0.0
 * 唯一标识：1db4149e-b223-4f00-abee-b2f43e0116c5
 * 创建人：  成刚
 * 创建时间：2015/7/22 1:54:24
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

namespace ChuanYu.TA.Data
{
    public class DbConnectionStringConfig
    {

        /// <summary>
        /// Cy数据库:只读(商品库)
        /// </summary>
        public const string CyReadConnectionStringName = "Cy.ReadDbConn";
        /// <summary>
        /// Cy主数据库
        /// </summary>
        public const string CyMainDbConnectionStringName = "Cy.MainDbConn";
    }
}
