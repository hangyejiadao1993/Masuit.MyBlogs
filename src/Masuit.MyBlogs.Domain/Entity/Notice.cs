using Masuit.MyBlogs.Domain.Enum;
using Masuit.MyBlogs.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    /// <summary>
    /// 网站公告
    /// </summary>
    [Table("notice")]
    public class Notice : BaseEntity
    {
        public Notice()
        {
            PostDate = DateTime.Now;
            ModifyDate = DateTime.Now;
            Status = Status.Display;
        }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "公告标题不能为空！")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "公告内容不能为空！"), SubmitCheck(3000, false)]
        public string Content { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime PostDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// 浏览人数
        /// </summary>
        public int ViewCount { get; set; }
    }
}