﻿using Masuit.MyBlogs.Domain.Enum;
using System;

namespace Masuit.MyBlogs.Services.DTO
{
    public class BroadcastDto : BaseDto
    {
        /// <summary>
        /// 订阅接收邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidateCode { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 订阅类型
        /// </summary>
        public SubscribeType SubscribeType { get; set; }
    }
}