using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Enum;
using Masuit.MyBlogs.Domain.Validation;
using Masuit.Tools.Core.Validator;
using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Core.Models.Command
{
    /// <summary>
    /// ���԰�����ģ��
    /// </summary>
    public class LeaveMessageCommand : BaseEntity
    {
        public LeaveMessageCommand()
        {
            Status = Status.Pending;
        }

        /// <summary>
        /// �ǳ�
        /// </summary>
        [Required(ErrorMessage = "�ǳƲ���Ϊ�գ�"), MaxLength(36, ErrorMessage = "�ǳ����֧��36���ַ�"), MinLength(2, ErrorMessage = "�ǳ�����2����")]
        public string NickName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "�������ݲ���Ϊ�գ�"), SubmitCheck(2, 500)]
        public string Content { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [IsEmail]
        public string Email { get; set; }

        /// <summary>
        /// QQ��΢��
        /// </summary>
        public string QQorWechat { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// ������汾
        /// </summary>
        [StringLength(255)]
        public string Browser { get; set; }

        /// <summary>
        /// ����ϵͳ�汾
        /// </summary>
        [StringLength(255)]
        public string OperatingSystem { get; set; }

        /// <summary>
        /// �Ƿ��ѽ�������
        /// </summary>
        [AssignTrue(ErrorMessage = "����ͬ����ܱ�վ�ġ�������֪��")]
        public bool Agree { get; set; }
    }
}