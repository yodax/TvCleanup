namespace TvCleanup.Tests
{
    using System.IO.Abstractions;
    using System.IO.Abstractions.TestingHelpers;
    using Autofac;

    public class ResolveDouble : IResolve
    {
        private readonly ILifetimeScope scope;

        public ResolveDouble()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().InstancePerLifetimeScope();
            builder.RegisterInstance(new OutputDouble()).As<IOutput>();
            builder.RegisterType<MockFileSystem>().As<IFileSystem>().InstancePerLifetimeScope();
            builder.RegisterType<MediaFinder>();

            scope = builder.Build().BeginLifetimeScope();
        }

        public T For<T>()
        {
            return scope.Resolve<T>();
        }
    }
}