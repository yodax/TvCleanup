namespace TvCleanup.Tests.Steps
{
    using System;
    using System.IO.Abstractions;
    using System.Linq;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class InspectTheDiskForMediaSteps
    {
        private Episode foundEpisode;
        private FoundMedia foundMedia;
        private Show foundShow;
        private MediaCollection mediaCollection;
        private ResolveDouble resolve;

        [Given(@"a file system")]
        public void GivenAFileSystem(Table table)
        {
            resolve = new ResolveDouble();
            var fileSystem = resolve.For<IFileSystem>();
            foreach (var tableRow in table.Rows)
            {
                fileSystem.File.CreateText(tableRow["Filename"]).Close();
            }
        }

        [When(@"I look for media in (.*)")]
        public void WhenILookForMedia(string directoryToLookIn)
        {
            var mediaFinder = resolve.For<MediaFinder>();

            foundMedia = mediaFinder.LookIn(directoryToLookIn);
        }

        [Then(@"there should be (.*) show called (.*)")]
        public void ThenThereShouldBeShowCalledShow(int numberOfShows, string showName)
        {
            var foundShows =
                foundMedia.Shows.Where(s => s.Name.Equals(showName, StringComparison.InvariantCultureIgnoreCase));
            foundShows.Should().HaveCount(numberOfShows);

            foundShow = foundShows.First();
        }

        [Then(@"there should be (.*) episode (.*)")]
        public void ThenThereShouldBeEpisodeS(int numberOfEpisodes, string episodeName)
        {
            var foundEpisodes =
                foundShow.Episodes.Where(
                    e => e.Identifier.Equals(episodeName, StringComparison.InvariantCultureIgnoreCase));

            foundEpisodes.Should().HaveCount(numberOfEpisodes);
            foundEpisode = foundEpisodes.First();
        }

        [Then(@"there should be (.*) media called (.*)")]
        public void ThenThereShouldBeMediaCalled(int nrOfMedia, string mediaName)
        {
            var medias =
                foundEpisode.Media.Where(
                    m => m.Name.Equals(mediaName, StringComparison.InvariantCultureIgnoreCase));

            medias.Should().HaveCount(nrOfMedia);

            mediaCollection = medias.First();
        }

        [Then(@"there should be (.*) file called (.*)")]
        public void ThenThereshouldBeFileCalledv(int nrOfFiles, string fileName)
        {
            var files = mediaCollection.Files.Where(f => f.Name.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));

            files.Should().HaveCount(nrOfFiles);
        }
    }
}