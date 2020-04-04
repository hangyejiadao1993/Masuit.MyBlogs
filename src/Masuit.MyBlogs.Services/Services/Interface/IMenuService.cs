using Masuit.MyBlogs.Domain.Entity;
using System.Collections.Generic;

namespace Masuit.MyBlogs.Services.Interface
{
    public partial interface IMenuService : IBaseService<Menu>
    {
        /// <summary>
        /// 通过存储过程获得自己以及自己所有的子元素集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Menu> GetChildrenMenusByParentId(int id);

    }
}