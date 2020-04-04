﻿using Masuit.MyBlogs.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Masuit.MyBlogs.Services.Interface
{
    public partial interface ISearchDetailsService : IBaseService<SearchDetails>
    {

        /// <summary>
        /// 搜索统计
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        List<SearchRank> GetRanks(DateTime start);
    }
}