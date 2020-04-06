using AutoMapper;
using Masuit.LuceneEFCore.SearchEngine.Interfaces;
using Masuit.MyBlogs.Core.Infrastructure.Repository.Interface;
using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.EntityFrameworkCore;
using Masuit.MyBlogs.Services.Interface;
using System;
using System.Collections.Generic;

namespace Masuit.MyBlogs.Services
{
    public partial class SearchDetailsService : BaseService<SearchDetails>, ISearchDetailsService
    {
        private readonly ISearchDetailsRepository _searchDetailsRepository;

        public SearchDetailsService(IBaseRepository<SearchDetails> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, ISearchDetailsRepository searchDetailsRepository,IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
            _searchDetailsRepository = searchDetailsRepository;
        }

        /// <summary>
        /// 搜索统计
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public List<SearchRank> GetRanks(DateTime start)
        {
            return _searchDetailsRepository.GetRanks(start);
        }
    }
}