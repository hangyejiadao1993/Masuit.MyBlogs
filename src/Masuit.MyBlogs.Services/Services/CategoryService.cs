using AutoMapper;
using Masuit.LuceneEFCore.SearchEngine.Interfaces;
using Masuit.MyBlogs.Core.Infrastructure.Repository.Interface;
using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.EntityFrameworkCore;
using Masuit.MyBlogs.Services.Interface;
using Masuit.Tools;

namespace Masuit.MyBlogs.Services
{
    public partial class CategoryService : BaseService<Category>, ICategoryService
    {
        /// <summary>
        /// 删除分类，并将该分类下的文章移动到新分类下
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public bool Delete(int id, int mid)
        {
            Category category = GetById(id);
            Category moveCat = GetById(mid);
            category.Post.ForEach(p =>
            {
                moveCat.Post.Add(p);
                p.PostHistoryVersion.ForEach(v => moveCat.PostHistoryVersion.Add(v));
            });
            category.PostHistoryVersion.ForEach(p =>
            {
                moveCat.PostHistoryVersion.Add(p);
            });

            bool b = DeleteByIdSaved(id);
            return b;
        }

        public CategoryService(IBaseRepository<Category> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }
}