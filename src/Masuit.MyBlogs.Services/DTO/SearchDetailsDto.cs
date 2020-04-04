﻿using System;

namespace Masuit.MyBlogs.Services.DTO
{
    /// <summary>
    /// 搜索详情输出模型
    /// </summary>
    public class SearchDetailsDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 搜索时间
        /// </summary>
        public DateTime SearchTime { get; set; }

        /// <summary>
        /// 访问者IP
        /// </summary>
        public string IP { get; set; }
    }
}