using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Core.Models.Command
{
    /// <summary>
    /// ����ҳ����ģ��
    /// </summary>
    public class MiscCommand : BaseEntity
    {
        public MiscCommand()
        {
            Status = Masuit.MyBlogs.Domain.Enum.Status.Display;
        }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "���ⲻ��Ϊ�գ�"), MaxLength(64, ErrorMessage = "�����֧��64���ַ���"), MinLength(4, ErrorMessage = "��������4���ַ���")]
        public string Title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "���ݲ���Ϊ�գ�"), SubmitCheck(100000, false)]
        public string Content { get; set; }
    }
}