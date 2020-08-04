using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System.Web.Http;
using TaskHandler.Data;
using TaskHandler.Data.Repositories;
using TaskHandler.QueueService;

namespace TaskHandler.Api.Infrastructure
{
    public static class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<TaskDbContext>()
                    .InstancePerRequest();

            builder.Register(c => new MapperConfiguration(cfg => cfg.AddProfile(new TaskDataProfile())))
                    .AsSelf()
                    .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                    .As<IMapper>()
                    .InstancePerLifetimeScope();

            builder.RegisterType<MessageHandler>()
                   .As<IMessageHandler>()
                   .InstancePerRequest();

            builder.RegisterType(typeof(TaskRepo))
                   .As(typeof(ITaskRepo))
                   .InstancePerRequest();

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            Container = builder.Build();

            return Container;
        }
    }
}