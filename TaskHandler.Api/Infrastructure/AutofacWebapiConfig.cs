using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using TaskHandler.DataAccess;
using TaskHandler.DataAccess.Repositories;
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
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            builder.RegisterType<TaskDbContext>()
                   .InstancePerRequest();

            builder.RegisterType<MessageHandler>()
                   .As<IMessageHandler>()
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(TaskRepo))
                   .As(typeof(ITaskRepo))
                   .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }

    }
}