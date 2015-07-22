using System;
using ChuanYu.TA.Entity.Enums;

namespace ChuanYu.TA.Entity.Base
{
    public class BaseEntity
    {
        private DataStatus _dataState = DataStatus.Valid;

        /// <summary>
        /// 数据状态：=0无效=1有效=2数据归档=255逻辑删除
        /// </summary>
        public DataStatus DataState
        {
            get { return _dataState; }
            set { _dataState = value; }
        }


        /// <summary>
        /// 创建用户名
        /// </summary>  
        public string CreateUserName { get; set; }

        private DateTime _createTime = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>  
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// 修改用户名
        /// </summary> 
        public string UpdateUserName { get; set; }

        private DateTime _updateTime = DateTime.Now;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
    }
}
