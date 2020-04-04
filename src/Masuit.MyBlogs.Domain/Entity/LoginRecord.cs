﻿using Masuit.MyBlogs.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    /// <summary>
    /// 用户登陆记录
    /// </summary>
    [Table("loginrecord")]
    public class LoginRecord : BaseEntity
    {
        /// <summary>
        /// 登录点IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录地所在省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 地理位置
        /// </summary>
        public string PhysicAddress { get; set; }

        /// <summary>
        /// 登录类型
        /// </summary>
        public LoginType LoginType { get; set; }

        /// <summary>
        /// 关联的用户id
        /// </summary>
        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}