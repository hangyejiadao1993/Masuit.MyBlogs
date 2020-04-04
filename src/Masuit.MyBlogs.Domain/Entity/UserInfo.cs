using Masuit.Tools.Core.Validator;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    /// <summary>
    /// �û�
    /// </summary>
    [Table("userinfo")]
    public class UserInfo : BaseEntity
    {
        public UserInfo()
        {
            IsAdmin = false;
        }

        /// <summary>
        /// �û���
        /// </summary>
        [Required(ErrorMessage = "�û�������Ϊ�գ�")]
        public string Username { get; set; }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        [Required(ErrorMessage = "�ǳƲ���Ϊ�գ�")]
        public string NickName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "���벻��Ϊ�գ�")]
        public string Password { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required]
        public string SaltKey { get; set; }

        /// <summary>
        /// �Ƿ��ǹ���Ա
        /// </summary>
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

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
        /// �û�ͷ��
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// AccessToken�������������½ʱ��
        /// </summary>
        public string AccessToken { get; set; }

        public virtual ICollection<LoginRecord> LoginRecord { get; set; }
    }
}