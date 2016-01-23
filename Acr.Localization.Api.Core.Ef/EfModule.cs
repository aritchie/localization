using System;
using Autofac;
using HibernatingRhinos.Profiler.Appender.EntityFramework;


namespace Acr.Localization.Api.Core.Ef
{
    public class EfModule : Module
    {
        public bool IsDebugEnabled { get; set; }


        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            if (this.IsDebugEnabled)
                EntityFrameworkProfiler.Initialize();

            builder
                .Register(x => new LocalDbContext())
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<LocalizationManagerImpl>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
