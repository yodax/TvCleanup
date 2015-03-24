namespace TvCleanup
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Abstractions;
    using System.Linq;

    public class MediaFinder
    {
        private readonly IFileSystem fileSystem;

        public MediaFinder(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public FoundMedia LookIn(string directoryToLookIn)
        {
            var foundMedia = new FoundMedia();

            foreach (var showDirectory in ShowDirectoriesIn(directoryToLookIn))
            {
                var show = CreateShowFrom(showDirectory);

                foreach (var episodeDirectory in EpisodeDirectoriesIn(showDirectory))
                {
                    var episode = CreateEpisodeFrom(episodeDirectory);

                    foreach (var mediaCollectionName in GetUniqueMediaCollectionsIn(episodeDirectory))
                    {
                        var mediaCollection = MediaCollectionFrom(mediaCollectionName);

                        foreach (var fileBelongingToMediaCollection in FilesBelongingToMediaCollection(episodeDirectory, mediaCollection.Identifier))
                        {
                            mediaCollection
                                .Files
                                .Add(MediaFileFrom(fileBelongingToMediaCollection));
                        }

                        episode.MediaCollections.Add(mediaCollection);
                    }

                    show.Episodes.Add(episode);
                }

                foundMedia.Shows.Add(show);
            }

            return foundMedia;
        }

        private static MediaFile MediaFileFrom(string fileBelongingToMediaCollection)
        {
            return new MediaFile { Name = fileBelongingToMediaCollection };
        }

        private Show CreateShowFrom(string showDirectory)
        {
            var show = new Show
            {
                Name = DirectoryName(showDirectory)
            };

            return show;
        }

        private IEnumerable<string> EpisodeDirectoriesIn(string showDirectory)
        {
            return fileSystem.Directory.GetDirectories(showDirectory);
        }

        private Episode CreateEpisodeFrom(string episodeDirectory)
        {
            var episode = new Episode {Identifier = DirectoryName(episodeDirectory)};

            return episode;
        }

        private MediaCollection MediaCollectionFrom(string mediaCollectionName)
        {
            return new MediaCollection
            {
                Identifier = mediaCollectionName
            };
        }

        private IEnumerable<string> FilesBelongingToMediaCollection(string episodeDirectory, string mediaCollectionIdentifier)
        {
            return fileSystem.Directory.GetFiles(episodeDirectory, mediaCollectionIdentifier + ".*");
        }

        private IEnumerable<string> GetUniqueMediaCollectionsIn(string episodeDirectory)
        {
            return fileSystem.Directory.GetFiles(episodeDirectory)
                .Select(Path.GetFileNameWithoutExtension)
                .Distinct();
        }

        private IEnumerable<string> ShowDirectoriesIn(string directoryToLookIn)
        {
            return fileSystem.Directory.GetDirectories(directoryToLookIn);
        }

        private string DirectoryName(string showDirectory)
        {
            return fileSystem.DirectoryInfo.FromDirectoryName(showDirectory).Name;
        }
    }
}