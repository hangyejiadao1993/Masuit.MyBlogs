﻿using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Enum;
using System.Collections.Generic;

namespace Masuit.MyBlogs.Services.Interface
{
    public partial interface IAdvertisementService : IBaseService<Advertisement>
    {
        /// <summary>
        /// 按权重随机筛选一个元素
        /// </summary>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        Advertisement GetByWeightedRandom(AdvertiseType type, int? cid = null);

        /// <summary>
        /// 按权重随机筛选多个元素
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        List<Advertisement> GetsByWeightedRandom(int count, AdvertiseType type, int? cid = null);

        /// <summary>
        /// 按价格随机筛选一个元素
        /// </summary>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        Advertisement GetByWeightedPrice(AdvertiseType type, int? cid = null);

        /// <summary>
        /// 按价格随机筛选多个元素
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        List<Advertisement> GetsByWeightedPrice(int count, AdvertiseType type, int? cid = null);
    }
}