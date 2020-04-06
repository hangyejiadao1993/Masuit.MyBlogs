using Autofac;
using AutoMapper;
using Hangfire;
using Masuit.LuceneEFCore.SearchEngine.Interfaces;
using Masuit.MyBlogs.Core.Extensions;
using Masuit.MyBlogs.Core.Extensions.Hangfire;
using Masuit.MyBlogs.Core.Infrastructure.Repository.Interface;
using Masuit.MyBlogs.Services.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Masuit.Tools.Core.Configs
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            List<Assembly> assembly = new List<Assembly>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in assemblies)
            {
                if (item.FullName.Contains("Masuit")||item.FullName.Contains("AutoMapper"))
                {
                    assembly.Add(item);
                }
            }
            //    var test = builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly.ToArray()).AsImplementedInterfaces().Where(t => (t.Name.EndsWith("Repository") || t.Name.EndsWith("Service") || t.Name.EndsWith("Controller") || t.Name.EndsWith("Attribute")) && !t.Name.Contains("HostedService")).PropertiesAutowired().AsSelf().InstancePerDependency();

            builder.RegisterType<BackgroundJobClient>().SingleInstance();
            builder.RegisterType<FirewallAttribute>().PropertiesAutowired().AsSelf().InstancePerDependency();
            builder.RegisterType<HangfireBackJob>().As<IHangfireBackJob>().PropertiesAutowired(PropertyWiringOptions.PreserveSetValues).InstancePerDependency();
            builder.Register(c => new Stopwatch()).As<Stopwatch>().AsSelf().PropertiesAutowired(PropertyWiringOptions.PreserveSetValues).InstancePerLifetimeScope();
           
            builder.RegisterType<Test>().As<ITest>().PropertiesAutowired(PropertyWiringOptions.PreserveSetValues).InstancePerDependency();

             //var container = builder.Build();
             //var service = container.Resolve<ITest>();
        
            //Console.WriteLine();
        }

    }



    public class ITest
    {

    }
    public class Test:ITest
    {
        public    IMapper _mapper { get; set; }
        public Test(IMapper mapper)
        {
            _mapper = mapper;
        }


        public void Demo()
        {
            if (_mapper==null)
            {

            }
            else
            {

            }
        }
    }



}