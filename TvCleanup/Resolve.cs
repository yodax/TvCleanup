namespace TvCleanup
{
    using Autofac;

    public class Resolve : IResolve
    {
        private readonly ILifetimeScope scope;

        public Resolve()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().InstancePerLifetimeScope();
            builder.RegisterInstance(new Output()).As<AbstractOutput>();

            scope = builder.Build().BeginLifetimeScope();
        }

        public T For<T>()
        {
            return scope.Resolve<T>();
        }
    }
}