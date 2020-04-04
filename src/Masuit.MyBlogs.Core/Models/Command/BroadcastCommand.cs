using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.Domain.Enum;
using Masuit.Tools.Core.Validator;
using System;

namespace Masuit.MyBlogs.Core.Models.Command
{
    /// <summary>
    /// �ÿͶ��ı�
    /// </summary>
    public class BroadcastCommand : BaseEntity
    {
        public BroadcastCommand()
        {
            Status = Status.Subscribing;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// ���Ľ�������
        /// </summary>
        [IsEmail]
        public string Email { get; set; }

        /// <summary>
        /// ��֤��
        /// </summary>
        public string ValidateCode { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public SubscribeType SubscribeType { get; set; }
    }
}