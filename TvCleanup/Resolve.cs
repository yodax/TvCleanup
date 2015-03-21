namespace TvCleanup
{
    using System.IO.Abstractions;
    using Autofac;

    public class Resolve : IResolve
    {
        private readonly ILifetimeScope scope;

        public Resolve()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().InstancePerLifetimeScope();
            builder.RegisterInstance(new Output()).As<AbstractOutput>();
            builder.RegisterType<FileSystem>().As<IFileSystem>();
            builder.RegisterType<MediaFinder>();

            scope = builder.Build().BeginLifetimeScope();
        }

        public T For<T>()
        {
            return scope.Resolve<T>();
        }
    }
}