namespace TvCleanup.Tests
{
    using Autofac;

    public class ResolveDouble : IResolve
    {
        private readonly ILifetimeScope scope;

        public ResolveDouble()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().InstancePerLifetimeScope();
            builder.RegisterInstance(new OutputDouble()).As<AbstractOutput>();

            scope = builder.Build().BeginLifetimeScope();
        }

        public T For<T>()
        {
            return scope.Resolve<T>();
        }
    }
}