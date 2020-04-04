﻿using Masuit.LuceneEFCore.SearchEngine.Interfaces;
using Masuit.MyBlogs.Core.Infrastructure.Repository.Interface;
using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.EntityFrameworkCore;
using Masuit.MyBlogs.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Masuit.MyBlogs.Services
{
    public partial class LeaveMessageService : BaseService<LeaveMessage>, ILeaveMessageService
    {
        public LeaveMessageService(IBaseRepository<LeaveMessage> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher) : base(repository, searchEngine, searcher)
        {
        }

        /// <summary>
        /// 通过存储过程获得自己以及自己所有的子元素集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<LeaveMessage> GetSelfAndAllChildrenMessagesByParentId(int id)
        {
            var msg = GetFromCache(m => m.Id == id);
            if (msg != null)
            {
                var msgs = new List<LeaveMessage>() { msg };
                GetSelfAndAllChildrenMessagesByParentId(msg, msgs);
                return msgs;
            }

            return new List<LeaveMessage>();
        }

        /// <summary>
        /// 通过存储过程获得自己以及自己所有的子元素集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void GetSelfAndAllChildrenMessagesByParentId(LeaveMessage msg, List<LeaveMessage> list)
        {
            var msgs = GetQueryFromCache(x => x.ParentId == msg.Id).ToList();
            if (msgs.Any())
            {
                list.AddRange(msgs);
                foreach (var c in msgs)
                {
                    GetSelfAndAllChildrenMessagesByParentId(c, list);
                }
            }
        }

        /// <summary>
        /// 根据无级子级找顶级父级留言id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetParentMessageIdByChildId(int id)
        {
            LeaveMessage msg = GetFromCache(m => m.Id == id);
            if (msg != null)
            {
                return GetParentMessageIdByChildId(msg);
            }
            return 0;
        }

        /// <summary>
        /// 根据无级子级找顶级父级评论id
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private int GetParentMessageIdByChildId(LeaveMessage m)
        {
            LeaveMessage msg = GetNoTracking(c => c.Id == m.ParentId);
            if (msg != null)
            {
                return GetParentMessageIdByChildId(msg);
            }
            return m.Id;
        }
    }
}