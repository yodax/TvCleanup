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
        private ResolveDouble resolve;
        private FoundMedia foundMedia;

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

        [Then(@"(.*) media file for show (.*) and episode (.*) should be found")]
        public void ThenMediaFileForShowShowAndEpisodeSShouldBeFound(int nrOfMediaFilesForShows, string showName, string episode)
        {
            var foundShow = foundMedia.Shows.First(s => s.Name.Equals(showName, StringComparison.InvariantCultureIgnoreCase));
            foundShow.Should().NotBeNull(" show was not found");

            var foundEpisode = foundShow.Episodes.First(e => e.Identifier.Equals(episode, StringComparison.InvariantCultureIgnoreCase));
            foundEpisode.Should().NotBeNull(" episode was not found");

            foundEpisode.MediaFiles.Count().Should().Be(nrOfMediaFilesForShows);
        }
    }
}