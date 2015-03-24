namespace TvCleanup.Tests
{
    using System.IO.Abstractions;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Summary description for WhenResolvingAType
    /// </summary>
    [TestClass]
    public class WhenResolvingAType
    {
        private IResolve actualResolve;
        private IResolve resolveDouble;

        [TestInitialize]
        public void Setup()
        {
            resolveDouble = new ResolveDouble();
            actualResolve = new Resolve();
        }

        [TestMethod]
        public void AllTypesShouldBeAssignable()
        {
            CheckForResolve<IOutput>();
            CheckForResolve<Application>();
            CheckForResolve<IFileSystem>();
            CheckForResolve<MediaFinder>();
        }

        private void CheckForResolve<T>()
        {
            resolveDouble.For<T>().Should().BeAssignableTo<T>();
            actualResolve.For<T>().Should().BeAssignableTo<T>();
        }
    }
}