using Masuit.MyBlogs.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    /// <summary>
    /// �����޸�����
    /// </summary>
    [Table("postmergerequest")]
    public class PostMergeRequest : BaseEntity
    {
        /// <summary>
        /// ����id
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// �޸���
        /// </summary>
        public string Modifier { get; set; }

        /// <summary>
        /// �޸�������
        /// </summary>
        public string ModifierEmail { get; set; }

        /// <summary>
        /// �ϲ�״̬
        /// </summary>
        public MergeStatus MergeState { get; set; }

        /// <summary>
        /// �ύʱ��
        /// </summary>
        public DateTime SubmitTime { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}