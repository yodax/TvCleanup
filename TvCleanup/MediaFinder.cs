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

            foreach (var showDirectory in ShowDirectoriesOnDisk(directoryToLookIn))
            {
                foundMedia.Shows.Add(CreateShowFrom(showDirectory));
            }

            return foundMedia;
        }

        private Show CreateShowFrom(string showDirectory)
        {
            var show = new Show
            {
                Name = DirectoryName(showDirectory)
            };

            foreach (var episodeDirectory in EpisodeDirectories(showDirectory))
            {
                show.Episodes.Add(CreateEpisodeFrom(episodeDirectory));
            }
            return show;
        }

        private IEnumerable<string> EpisodeDirectories(string showDirectory)
        {
            return fileSystem.Directory.GetDirectories(showDirectory);
        }

        private Episode CreateEpisodeFrom(string episodeDirectory)
        {
            var episode = new Episode {Identifier = DirectoryName(episodeDirectory)};

            foreach (
                var mediaCollectionName in
                    GetUniqueMediaCollections(episodeDirectory))
            {
                episode.Media.Add(MediaCollectionFrom(episodeDirectory, mediaCollectionName));
            }
            return episode;
        }

        private MediaCollection MediaCollectionFrom(string episodeDirectory, string mediaCollectionName)
        {
            var media = new MediaCollection {Name = mediaCollectionName};
            foreach (var fileBelongingToMediaCollection in
                    FilesBelongingToMediaCollection(episodeDirectory, media))
            {
                media.Files.Add(new MediaFile {Name = fileBelongingToMediaCollection});
            }
            return media;
        }

        private IEnumerable<string> FilesBelongingToMediaCollection(string episodeDirectory, MediaCollection media)
        {
            return fileSystem.Directory.GetFiles(episodeDirectory, media.Name + ".*");
        }

        private IEnumerable<string> GetUniqueMediaCollections(string episodeDirectory)
        {
            return fileSystem.Directory.GetFiles(episodeDirectory)
                .Select(Path.GetFileNameWithoutExtension)
                .Distinct();
        }

        private IEnumerable<string> ShowDirectoriesOnDisk(string directoryToLookIn)
        {
            return fileSystem.Directory.GetDirectories(directoryToLookIn);
        }

        private string DirectoryName(string showDirectory)
        {
            return fileSystem.DirectoryInfo.FromDirectoryName(showDirectory).Name;
        }
    }
}