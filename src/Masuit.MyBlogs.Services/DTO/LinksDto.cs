﻿namespace Masuit.MyBlogs.Services.DTO
{
    /// <summary>
    /// 友情链接输出模型
    /// </summary>
    public class LinksDto : BaseDto
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否检测白名单
        /// </summary>
        public bool Except { get; set; }

        /// <summary>
        /// 是否是推荐站点
        /// </summary>
        public bool Recommend { get; set; }

        /// <summary>
        /// 友链权重
        /// </summary>
        public int Weight { get; set; }
    }
}