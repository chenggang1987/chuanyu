/*****************************************************************************
 * Copyright (c) 2015 川渝同乡联合会 All Rights Reserved.
 * CLR版本： 4.0.30319.34014
 * 机器名称：CG
 * 命名空间：ChuanYu.TA.Entity.Enums
 * 文件名：  Industry
 * 版本号：  V1.0.0.0
 * 唯一标识：9863e1cc-c98c-4beb-8b05-b0652e78f97f
 * 创建人：  成刚
 * 创建时间：2015/7/28 23:38:28
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuanYu.TA.Entity.Enums
{
    /// <summary>
    /// 行业
    /// </summary>
    public enum Industry:byte
    {
        /// <summary>
        /// IT|通信|电子|互联网
        /// </summary>
        [Description("IT|通信|电子|互联网")]
        Internet = 1,

        /// <summary>
        /// 贸易|批发|零售|租赁业
        /// </summary>
        [Description("贸易|批发|零售|租赁业")]
        Trade = 2,

        /// <summary>
        /// 交通|运输|物流|仓储
        /// </summary>
        [Description("交通|运输|物流|仓储")]
        Logistics = 3,

        /// <summary>
        /// 生产|加工|制造
        /// </summary>
        [Description("生产|加工|制造")]
        Manufacture = 4,

        /// <summary>
        /// 文化|传媒|娱乐|体育
        /// </summary>
        [Description("文化|传媒|娱乐|体育")]
        Entertainment = 5,

        /// <summary>
        /// 文体教育|工艺美术
        /// </summary>
        [Description("文体教育|工艺美术")]
        Education = 6,

        /// <summary>
        /// 能源|矿产|环保
        /// </summary>
        [Description("能源|矿产|环保")]
        Energy = 7,

        /// <summary>
        /// 房地产|建筑业
        /// </summary>
        [Description("房地产|建筑业")]
        Realty = 8,

        /// <summary>
        /// 政府|非盈利机构
        /// </summary>
        [Description("政府|非盈利机构")]
        Government = 9,

        /// <summary>
        /// 金融业
        /// </summary>
        [Description("金融业")]
        Financial = 10,

        /// <summary>
        /// 商业服务
        /// </summary>
        [Description("商业服务（中介、外包、咨询、检验、广告）")]
        BusinessServices = 11,

        /// <summary>
        /// 服务业
        /// </summary>
        [Description("服务业（餐饮、旅游、医疗、保健）")]
        Services = 12,

        /// <summary>
        /// 其它
        /// </summary>
        [Description("其它")]
        Other = 13
    }
}
