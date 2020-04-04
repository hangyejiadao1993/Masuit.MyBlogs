using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Services.DTO;
using System.Threading.Tasks;

namespace Masuit.MyBlogs.Services.Interface
{
    public partial interface IPostService : IBaseService<Post>
    {
        SearchResult<PostDto> SearchPage(int page, int size, string keyword);

        /// <summary>
        /// 统一保存的方法
        /// </summary>
        /// <returns>受影响的行数</returns>
        int SaveChanges(bool flushIndex);

        /// <summary>
        /// 统一保存数据
        /// </summary>
        /// <returns>受影响的行数</returns>
        Task<int> SaveChangesAsync(bool flushIndex);
    }
}