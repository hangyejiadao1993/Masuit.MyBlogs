﻿using AngleSharp.Text;
using Masuit.LuceneEFCore.SearchEngine.Linq;
using Masuit.MyBlogs.Core.Extensions;
using Masuit.MyBlogs.Core.Infrastructure.Repository;
using Masuit.MyBlogs.Core.Models.ViewModel;
using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Enum;
using Masuit.MyBlogs.Services.DTO;
using Masuit.MyBlogs.Services.Interface;
using Masuit.Tools;
using Masuit.Tools.Core.Net;
using Masuit.Tools.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Masuit.MyBlogs.Core.Controllers
{
    [Route("partner/[action]")]
    public class AdvertisementController : BaseController
    {
        public ICategoryService CategoryService { get; set; }

        /// <summary>
        /// 前往
        /// </summary>
        /// <param name="id">广告id</param>
        /// <returns></returns>
        [HttpGet("{id:int}"), ResponseCache(Duration = 3600)]
        public async Task<IActionResult> Redirect(int id)
        {
            var ad = await AdsService.GetByIdAsync(id) ?? throw new NotFoundException("推广链接不存在");
            if (!HttpContext.Request.IsRobot() && string.IsNullOrEmpty(HttpContext.Session.Get<string>("ads" + id)))
            {
                HttpContext.Session.Set("ads" + id, id.ToString());
                ad.ViewCount++;
                await AdsService.SaveChangesAsync();
            }

            return RedirectPermanent(ad.Url);
        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <returns></returns>
        [MyAuthorize]
        public ActionResult GetPageData([Range(1, int.MaxValue, ErrorMessage = "页数必须大于0")]int page = 1, [Range(1, int.MaxValue, ErrorMessage = "页大小必须大于0")]int size = 10, string kw = "")
        {
            Expression<Func<Advertisement, bool>> where = p => true;
            if (!string.IsNullOrEmpty(kw))
            {
                where = where.And(p => p.Title.Contains(kw) || p.Description.Contains(kw));
            }

            var list = AdsService.GetQuery(where).OrderByDescending(p => p.Price).ThenByDescending(a => a.Weight).ToPagedList<Advertisement, AdvertisementViewModel>(page, size, MapperConfig);
            var cids = list.Data.Where(m => !string.IsNullOrEmpty(m.CategoryIds)).SelectMany(m => m.CategoryIds.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)).Distinct().ToArray();
            var dic = CategoryService.GetQuery(c => cids.Contains(c.Id)).ToDictionary(c => c.Id + "", c => c.Name);
            foreach (var ad in list.Data.Where(ad => !string.IsNullOrEmpty(ad.CategoryIds)))
            {
                ad.CategoryNames = ad.CategoryIds.Split(",").Select(c => dic[c]).Join(",");
            }

            return Ok(list);
        }

        /// <summary>
        /// 保存banner
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, MyAuthorize]
        public async Task<IActionResult> Save(AdvertisementDto model)
        {
            model.CategoryIds = model.CategoryIds?.Replace("null", "");
            var b = await AdsService.AddOrUpdateSavedAsync(a => a.Id, model.Mapper<Advertisement>()) > 0;
            return ResultData(null, b, b ? "保存成功" : "保存失败");
        }

        /// <summary>
        /// 删除banner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}"), HttpGet("{id}"), MyAuthorize]
        public async Task<IActionResult> Delete(int id)
        {
            bool b = await AdsService.DeleteByIdSavedAsync(id) > 0;
            return ResultData(null, b, b ? "删除成功" : "删除失败");
        }


        /// <summary>
        /// 禁用或开启文章评论
        /// </summary>
        /// <param name="id">文章id</param>
        /// <returns></returns>
        [MyAuthorize, HttpPost("{id}")]
        public ActionResult ChangeState(int id)
        {
            var ad = AdsService.GetById(id) ?? throw new NotFoundException("广告不存在！");
            ad.Status = ad.Status == Status.Available ? Status.Unavailable : Status.Available;
            return ResultData(null, AdsService.SaveChanges() > 0, ad.Status == Status.Available ? $"【{ad.Title}】已上架！" : $"【{ad.Title}】已下架！");
        }
    }
}