namespace TvCleanup
{
    using System.IO.Abstractions;

    public class MediaFinder
    {
        private IFileSystem fileSystem;

        public MediaFinder(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public FoundMedia LookIn(string directoryToLookIn)
        {
            var foundMedia = new FoundMedia();

            foreach (var showDirectory in fileSystem.Directory.GetDirectories(directoryToLookIn))
            {
                var show = new Show {Name = DirectoryName(showDirectory)};

                foreach (var episodeDirectory in fileSystem.Directory.GetDirectories(showDirectory))
                {
                    var episode = new Episode {Identifier = DirectoryName(episodeDirectory)};

                    foreach (var mediaFile in fileSystem.Directory.GetFiles(episodeDirectory))
                    {
                        episode.MediaFiles.Add(new MediaFile{Name = fileSystem.FileInfo.FromFileName(mediaFile).Name});
                    }
                    show.Episodes.Add(episode);
                }

                foundMedia.Shows.Add(show);
            }

            return foundMedia;
        }

        private string DirectoryName(string showDirectory)
        {
            return fileSystem.DirectoryInfo.FromDirectoryName(showDirectory).Name;
        }
    }
}