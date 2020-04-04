using Masuit.MyBlogs.Services.DTO;
using Masuit.Tools.Core.Validator;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Masuit.MyBlogs.Core.Models.Command
{
    /// <summary>
    /// �û���Ϣ����ģ��
    /// </summary>
    public class UserInfoCommand : BaseDto
    {
        public UserInfoCommand()
        {
            IsAdmin = false;
        }

        /// <summary>
        /// �û���
        /// </summary>
        [Required(ErrorMessage = "�û�������Ϊ�գ�"), MinLength(2, ErrorMessage = "�û�������2���ַ���"), MaxLength(24, ErrorMessage = "�û����������24���ַ�")]
        public string Username { get; set; }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        [Required(ErrorMessage = "�ǳƲ���Ϊ�գ�"), MinLength(2, ErrorMessage = "�ǳ�����2���ַ���"), MaxLength(48, ErrorMessage = "�ǳ��������48���ַ�")]
        public string NickName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required(ErrorMessage = "���벻��Ϊ�գ�"), ComplexPassword]
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
    }
}