﻿using CacheManager.Core;
using Masuit.MyBlogs.Core.Extensions;
using Masuit.MyBlogs.Core.Models.ViewModel;
using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Enum;
using Masuit.MyBlogs.Services.DTO;
using Masuit.MyBlogs.Services.Interface;
using Masuit.Tools;
using Masuit.Tools.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Masuit.MyBlogs.Core.Controllers
{
    /// <summary>
    /// 站内搜索
    /// </summary>
    public class SearchController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public ISearchDetailsService SearchDetailsService { get; set; }
        public IPostService PostService { get; set; }

        public ICacheManager<string> CacheManager { get; set; }

        /// <summary>
        /// 搜索页
        /// </summary>
        /// <param name="wd"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [Route("s/{wd?}/{page:int?}/{size:int?}")]
        public ActionResult Search(string wd = "", [Range(1, int.MaxValue, ErrorMessage = "页码必须大于0")]int page = 1, [Range(1, 50, ErrorMessage = "页大小必须在0到50之间")]int size = 15)
        {
            var nul = new SearchResult<PostDto>();
            ViewBag.PageSize = size;
            ViewBag.Keyword = wd;
            string ip = ClientIP;
            string key = "Search:" + ip;
            if (CacheManager.Exists(key) && CacheManager.Get(key) != wd)
            {
                var hotSearches = RedisHelper.Get<List<KeywordsRank>>("SearchRank:Week").Take(10).ToList();
                ViewBag.hotSearches = hotSearches;
                ViewBag.ErrorMsg = "10秒内只能搜索1次！";
                return View(nul);
            }

            wd = wd?.Trim().Replace("+", " ");
            if (!string.IsNullOrWhiteSpace(wd) && !wd.Contains("锟斤拷"))
            {
                if (!HttpContext.Session.TryGetValue("search:" + wd, out _) && !HttpContext.Request.IsRobot())
                {
                    SearchDetailsService.AddEntity(new SearchDetails
                    {
                        Keywords = wd,
                        SearchTime = DateTime.Now,
                        IP = ClientIP
                    });
                    SearchDetailsService.SaveChanges();
                    HttpContext.Session.Set("search:" + wd, wd.ToByteArray());
                }

                var posts = PostService.SearchPage(page, size, wd);
                if (posts.Total > 1)
                {
                    CacheManager.AddOrUpdate(key, wd, s => wd);
                    CacheManager.Expire(key, TimeSpan.FromSeconds(10));
                }

                ViewBag.Ads = AdsService.GetByWeightedPrice(AdvertiseType.PostList);
                ViewBag.hotSearches = new List<KeywordsRank>();
                return View(posts);
            }

            ViewBag.hotSearches = RedisHelper.Get<List<KeywordsRank>>("SearchRank:Week").Take(10).ToList();
            return View(nul);
        }

        /// <summary>
        /// 关键词搜索记录
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [MyAuthorize, HttpPost, ResponseCache(Duration = 600, VaryByQueryKeys = new[] { "page", "size", "search" }, VaryByHeader = "Cookie")]
        public ActionResult SearchList([Range(1, int.MaxValue, ErrorMessage = "页码必须大于0")]int page = 1, [Range(1, 50, ErrorMessage = "页大小必须在0到50之间")]int size = 15, string search = "")
        {
            var where = string.IsNullOrEmpty(search) ? (Expression<Func<SearchDetails, bool>>)(s => true) : s => s.Keywords.Contains(search);
            var pages = SearchDetailsService.GetPages<DateTime, SearchDetailsDto>(page, size, where, s => s.SearchTime, false);
            return Ok(pages);
        }

        /// <summary>
        /// 热词
        /// </summary>
        /// <returns></returns>
        [MyAuthorize, HttpPost, ResponseCache(Duration = 600, VaryByHeader = "Cookie")]
        public ActionResult HotKey()
        {
            return ResultData(new
            {
                month = RedisHelper.Get<List<KeywordsRank>>("SearchRank:Month"),
                week = RedisHelper.Get<List<KeywordsRank>>("SearchRank:Week"),
                today = RedisHelper.Get<List<KeywordsRank>>("SearchRank:Today")
            });
        }

        /// <summary>
        /// 删除搜索记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, MyAuthorize]
        public ActionResult Delete(int id)
        {
            bool b = SearchDetailsService.DeleteByIdSaved(id);
            return ResultData(null, b, b ? "删除成功！" : "删除失败！");
        }
    }
}