using Masuit.MyBlogs.Domain.Validation;
using Masuit.MyBlogs.Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Core.Models.Command
{
    /// <summary>
    /// �����޸�����
    /// </summary>
    public class PostMergeRequestCommandBase : BaseDto
    {
        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "���±��ⲻ��Ϊ�գ�"), MaxLength(128, ErrorMessage = "���±����֧��128���ַ���"), MinLength(4, ErrorMessage = "���±�������4���ַ���")]
        public string Title { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "�������ݲ���Ϊ�գ�"), SubmitCheck(20, 1000000, false)]
        public string Content { get; set; }
    }
}