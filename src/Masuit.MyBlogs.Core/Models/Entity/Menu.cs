using Masuit.MyBlogs.Core.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Core.Models.Entity
{
    /// <summary>
    /// �����˵�
    /// </summary>
    [Table("menu")]
    public class Menu : BaseEntity
    {
        public Menu()
        {
            ParentId = 0;
            Status = Status.Available;
        }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "�˵�������Ϊ�գ�")]
        public string Name { get; set; }

        /// <summary>
        /// ͼ��
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [Required(ErrorMessage = "�˵���URL����Ϊ�գ�")]
        public string Url { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        [DefaultValue(0)]
        public int ParentId { get; set; }

        /// <summary>
        /// �˵�����
        /// </summary>
        public virtual MenuType MenuType { get; set; }

        /// <summary>
        /// �Ƿ����±�ǩҳ��
        /// </summary>
        public bool NewTab { get; set; }

    }
}