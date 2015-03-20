namespace TvCleanup.Tests.Steps
{
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class StartingTheApplicationSteps
    {
        [Given(@"an application")]
        public void GivenAnApplication()
        {
            var resolve = new ResolveDouble();
            ScenarioContext.Current.Add("Resolve", resolve);

            ScenarioContext.Current.Add("Application", resolve.For<Application>());
        }

        [When(@"I start the application")]
        public void WhenIStartTheApplication()
        {
            var application = (Application) ScenarioContext.Current["Application"];
            application.Start();
        }

        [Then(@"on the screen I should see")]
        public void ThenOnTheScreenIShouldSee(string consoleOutput)
        {
            var resolve = (IResolve) ScenarioContext.Current["Resolve"];
            var output = resolve.For<AbstractOutput>();

            output.Messages.Should().BeEquivalentTo(consoleOutput);
        }
    }
}