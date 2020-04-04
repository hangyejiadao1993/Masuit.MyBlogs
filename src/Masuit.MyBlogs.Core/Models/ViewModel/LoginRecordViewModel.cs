using Masuit.MyBlogs.Domain.Enum;
using Masuit.MyBlogs.Services.DTO;
using System;

namespace Masuit.MyBlogs.Core.Models.ViewModel
{
    /// <summary>
    /// �û���¼��¼���ģ��
    /// </summary>
    public class LoginRecordViewModel : BaseDto
    {
        /// <summary>
        /// ��¼��IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// ����ʡ��
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// ��ϸ����λ��
        /// </summary>
        public string PhysicAddress { get; set; }

        /// <summary>
        /// ��¼����
        /// </summary>
        public LoginType LoginType { get; set; }

        /// <summary>
        /// ��½��ID
        /// </summary>
        public int UserInfoId { get; set; }
    }
}