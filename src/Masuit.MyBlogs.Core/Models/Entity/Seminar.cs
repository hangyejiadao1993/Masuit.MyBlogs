using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Core.Models.Entity
{
    /// <summary>
    /// ����ר��
    /// </summary>
    [Table("seminar")]
    public partial class Seminar : BaseEntity
    {
        public Seminar()
        {
            this.Post = new HashSet<SeminarPost>();
        }

        /// <summary>
        /// ר����
        /// </summary>
        [Required(ErrorMessage = "ר�����Ʋ���Ϊ�գ�")]
        public string Title { get; set; }

        /// <summary>
        /// ר���ӱ���
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// ר������
        /// </summary>
        [Required(ErrorMessage = "ר����������Ϊ�գ�")]
        public string Description { get; set; }

        public virtual ICollection<SeminarPost> Post { get; set; }
        public virtual ICollection<SeminarPostHistoryVersion> PostHistoryVersion { get; set; }
    }
}