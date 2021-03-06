﻿using AutoMapper;
using Masuit.LuceneEFCore.SearchEngine.Interfaces;
using Masuit.MyBlogs.Core.Infrastructure.Repository.Interface;
using Masuit.MyBlogs.Domain.Entity;
using Masuit.MyBlogs.EntityFrameworkCore;
using Masuit.MyBlogs.Services.Interface;

namespace Masuit.MyBlogs.Services
{
    public partial class BroadcastService : BaseService<Broadcast>, IBroadcastService
    {
        public BroadcastService(IBaseRepository<Broadcast> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class DonateService : BaseService<Donate>, IDonateService
    {
        public DonateService(IBaseRepository<Donate> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class FastShareService : BaseService<FastShare>, IFastShareService
    {
        public FastShareService(IBaseRepository<FastShare> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class InternalMessageService : BaseService<InternalMessage>, IInternalMessageService
    {
        public InternalMessageService(IBaseRepository<InternalMessage> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class LinksService : BaseService<Links>, ILinksService
    {
        public LinksService(IBaseRepository<Links> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class LoginRecordService : BaseService<LoginRecord>, ILoginRecordService
    {
        public LoginRecordService(IBaseRepository<LoginRecord> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class MiscService : BaseService<Misc>, IMiscService
    {
        public MiscService(IBaseRepository<Misc> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(IBaseRepository<Notice> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class PostHistoryVersionService : BaseService<PostHistoryVersion>, IPostHistoryVersionService
    {
        public PostHistoryVersionService(IBaseRepository<PostHistoryVersion> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class SeminarService : BaseService<Seminar>, ISeminarService
    {
        public SeminarService(IBaseRepository<Seminar> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class SystemSettingService : BaseService<SystemSetting>, ISystemSettingService
    {
        public SystemSettingService(IBaseRepository<SystemSetting> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class SeminarPostService : BaseService<SeminarPost>, ISeminarPostService
    {
        public SeminarPostService(IBaseRepository<SeminarPost> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }

    public partial class SeminarPostHistoryVersionService : BaseService<SeminarPostHistoryVersion>, ISeminarPostHistoryVersionService
    {
        public SeminarPostHistoryVersionService(IBaseRepository<SeminarPostHistoryVersion> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher,mapper)
        {
        }
    }
    public partial class PostMergeRequestService : BaseService<PostMergeRequest>, IPostMergeRequestService
    {
        public PostMergeRequestService(IBaseRepository<PostMergeRequest> repository, ISearchEngine<DataContext> searchEngine, ILuceneIndexSearcher searcher, IMapper mapper) : base(repository, searchEngine, searcher, mapper)
        {
        }
    }
}