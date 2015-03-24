namespace TvCleanup.Tests.Steps
{
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class StartingTheApplicationSteps
    {
        private Application application;
        private ResolveDouble resolve;

        [Given(@"an application")]
        public void GivenAnApplication()
        {
            resolve = new ResolveDouble();

            application = resolve.For<Application>();
        }

        [When(@"I start the application")]
        public void WhenIStartTheApplication()
        {
            application.Start();
        }

        [Then(@"on the screen I should see")]
        public void ThenOnTheScreenIShouldSee(string consoleOutput)
        {
            var output = resolve.For<IOutput>().As<OutputDouble>();

            output.Messages.Should().BeEquivalentTo(consoleOutput);
        }
    }
}