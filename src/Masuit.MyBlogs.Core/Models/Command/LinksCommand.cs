using Masuit.MyBlogs.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Core.Models.Command
{
    /// <summary>
    /// ��������
    /// </summary>
    public class LinksCommand : BaseEntity
    {
        public LinksCommand()
        {
            Status = Masuit.MyBlogs.Domain.Enum.Status.Available;
            Except = false;
        }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "վ��������Ϊ�գ�"), MaxLength(16, ErrorMessage = "վ�������ֻ����16���ַ���"), MinLength(2, ErrorMessage = "վ����������2����")]
        public string Name { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [Required(ErrorMessage = "վ���URL����Ϊ�գ�"), StringLength(256, ErrorMessage = "URL�֧��256���ַ���")]
        public string Url { get; set; }

        /// <summary>
        /// �Ƿ��������
        /// </summary>
        public bool Except { get; set; }
    }
}