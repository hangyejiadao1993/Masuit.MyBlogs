﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    /// <summary>
    /// 打赏表
    /// </summary>
    [Table("donate")]
    public class Donate : BaseEntity
    {
        /// <summary>
        /// 打赏人
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 打赏人邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 打赏人的QQ或微信
        /// </summary>
        public string QQorWechat { get; set; }

        /// <summary>
        /// 打赏人的显式邮箱
        /// </summary>
        public string EmailDisplay { get; set; }

        /// <summary>
        /// 打赏人的显式QQ或微信
        /// </summary>
        public string QQorWechatDisplay { get; set; }

        /// <summary>
        /// 打赏金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 打赏途径
        /// </summary>
        public string Via { get; set; }

        /// <summary>
        /// 打赏时间
        /// </summary>
        public DateTime DonateTime { get; set; }
    }
}