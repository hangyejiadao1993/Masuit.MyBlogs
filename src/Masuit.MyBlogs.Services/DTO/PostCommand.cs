using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Validation;
using Masuit.Tools.Core.Validator;
using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Services.DTO
{
    /// <summary>
    /// ��������ģ��
    /// </summary>
    public class PostCommand : BaseEntity
    {
        public PostCommand()
        {
            Status = Masuit.MyBlogs.Domain.Enum.Status.Pending;
        }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "���±��ⲻ��Ϊ�գ�"), MaxLength(128, ErrorMessage = "���±����֧��128���ַ���"), MinLength(4, ErrorMessage = "���±�������4���ַ���")]
        public string Title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required, MaxLength(36, ErrorMessage = "�������֧��36���ַ���"), MinLength(2, ErrorMessage = "����������2���ַ���")]
        public string Author { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "�������ݲ���Ϊ�գ�"), SubmitCheck(20, 1000000, false)]
        public string Content { get; set; }

        /// <summary>
        /// ���¹ؼ���
        /// </summary>
        [StringLength(256, ErrorMessage = "���¹ؼ����������255���ַ�")]
        public string Keyword { get; set; }

        /// <summary>
        /// �ܱ���������
        /// </summary>
        public string ProtectContent { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "�������䲻��Ϊ�գ�"), MinLength(6, ErrorMessage = "�����ʽ����ȷ��"), IsEmail]
        public string Email { get; set; }

        /// <summary>
        /// ��ǩ
        /// </summary>
        [StringLength(255, ErrorMessage = "��ǩ�������255���ַ�")]
        public string Label { get; set; }

        /// <summary>
        /// ר��
        /// </summary>
        public string Seminars { get; set; }

        /// <summary>
        /// ��ֹ����
        /// </summary>
        public bool DisableComment { get; set; }

        /// <summary>
        /// ��ֹת��
        /// </summary>
        public bool DisableCopy { get; set; }
    }
}