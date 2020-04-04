using Masuit.MyBlogs.Domain.Enum;
using Masuit.MyBlogs.Domain.Validation;
using Masuit.Tools.Core.Validator;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    /// <summary>
    /// ���԰�
    /// </summary>
    [Table("leavemessage")]
    public class LeaveMessage : BaseEntity
    {
        public LeaveMessage()
        {
            PostDate = DateTime.Now;
            Status = Status.Pending;
            IsMaster = false;
        }

        /// <summary>
        /// �ǳ�
        /// </summary>
        [Required(ErrorMessage = "�ǳƲ���Ϊ�գ�")]
        public string NickName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "�������ݲ���Ϊ�գ�"), SubmitCheck]
        public string Content { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime PostDate { get; set; }

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
        /// �Ƿ��ǲ���
        /// </summary>
        [DefaultValue(false)]
        public bool IsMaster { get; set; }

        /// <summary>
        /// �ύ��IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Location { get; set; }
    }
}