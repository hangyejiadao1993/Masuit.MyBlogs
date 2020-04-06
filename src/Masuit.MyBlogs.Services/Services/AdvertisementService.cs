using AutoMapper;
using CacheManager.Core;
using Masuit.LuceneEFCore.SearchEngine.Interfaces;
using Masuit.LuceneEFCore.SearchEngine.Linq;
using Masuit.MyBlogs.Core.Infrastructure.Repository.Interface;
using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Enum;
using Masuit.MyBlogs.EntityFrameworkCore;
using Masuit.MyBlogs.Services.Interface;
using Masuit.Tools;
using Masuit.Tools.RandomSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Masuit.MyBlogs.Services
{
    public partial class AdvertisementService : BaseService<Advertisement>, IAdvertisementService
    {
        public ICacheManager<List<Advertisement>> CacheManager { get; set; }
        public ICacheManager<bool> ValueCacheManager { get; set; }

        public AdvertisementService(IBaseRepository<Advertisement> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher,IMapper mapper) : base(repository, searchEngine, searcher,mapper)
        {
        }

        /// <summary>
        /// 按权重随机筛选一个元素
        /// </summary>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        public Advertisement GetByWeightedRandom(AdvertiseType type, int? cid = null)
        {
            return GetsByWeightedRandom(1, type, cid).FirstOrDefault();
        }

        /// <summary>
        /// 按权重随机筛选一个元素
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        public List<Advertisement> GetsByWeightedRandom(int count, AdvertiseType type, int? cid = null)
        {
            Expression<Func<Advertisement, bool>> where = a => a.Types.Contains(type.ToString("D")) && a.Status == Status.Available;
            if (cid.HasValue)
            {
                var scid = cid.ToString();
                if (ValueCacheManager.GetOrAdd(scid, s => Any(a => a.CategoryIds.Contains(scid))))
                {
                    where = where.And(a => a.CategoryIds.Contains(scid) || a.CategoryIds == null);
                }
                else
                {
                    where = where.And(a => a.CategoryIds == null);
                }
            }

            return CacheManager.GetOrAdd($"{count}{type}{cid}", _ => GetQuery(where).AsEnumerable().Select(a => new WeightedItem<Advertisement>(a, a.Weight)).WeightedItems(count));
        }

        /// <summary>
        /// 按价格随机筛选一个元素
        /// </summary>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        public Advertisement GetByWeightedPrice(AdvertiseType type, int? cid = null)
        {
            return GetsByWeightedPrice(1, type, cid).FirstOrDefault();
        }

        /// <summary>
        /// 按价格随机筛选一个元素
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="type">广告类型</param>
        /// <param name="cid">分类id</param>
        /// <returns></returns>
        public List<Advertisement> GetsByWeightedPrice(int count, AdvertiseType type, int? cid = null)
        {
            Expression<Func<Advertisement, bool>> where = a => a.Types.Contains(type.ToString("D")) && a.Status == Status.Available;
            if (cid.HasValue)
            {
                var scid = cid.ToString();
                if (ValueCacheManager.GetOrAdd(scid, s => Any(a => a.CategoryIds.Contains(scid))))
                {
                    where = where.And(a => a.CategoryIds.Contains(scid) || a.CategoryIds == null);
                }
                else
                {
                    where = where.And(a => a.CategoryIds == null);
                }
            }
            return CacheManager.GetOrAdd($"{count}{type}{cid}", _ => GetQuery(where).AsEnumerable().Select(a => new WeightedItem<Advertisement>(a, (int)a.Price)).WeightedItems(count));
        }
    }
}