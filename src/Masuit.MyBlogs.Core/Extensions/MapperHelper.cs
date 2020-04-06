using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masuit.MyBlogs.Core.Extensions
{
    public static class MapperHelper
    {
         
        public static T Mapper<T>(this object source) where T : class => Startup.ServiceProvider.GetRequiredService<IMapper>().Map<T>(source);


    }
}
