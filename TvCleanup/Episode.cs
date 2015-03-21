namespace TvCleanup
{
    using System.Collections.Generic;

    public class Episode
    {
        public Episode()
        {
            MediaFiles = new List<MediaFile>();
        }
        public string Identifier { get; set; }
        public List<MediaFile> MediaFiles { get; private set; }
    }
}