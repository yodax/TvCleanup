namespace TvCleanup
{
    using System.Collections.Generic;

    public class Episode
    {
        public Episode()
        {
            Media = new List<MediaCollection>();
        }

        public string Identifier { get; set; }
        public List<MediaCollection> Media { get; private set; }
    }
}