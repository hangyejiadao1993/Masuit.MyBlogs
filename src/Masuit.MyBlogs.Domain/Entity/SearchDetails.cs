using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    /// <summary>
    /// ������ϸ��¼
    /// </summary>
    [Table("searchdetails")]
    public class SearchDetails
    {
        public SearchDetails()
        {
            SearchTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// �ؼ���
        /// </summary>
        [Required(ErrorMessage = "�ؼ��ʲ���Ϊ��")]
        public string Keywords { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime SearchTime { get; set; }

        /// <summary>
        /// ������IP
        /// </summary>
        public string IP { get; set; }
    }

    public class SearchRank
    {
        public string Keywords { get; set; }
        public int Count { get; set; }
    }
}