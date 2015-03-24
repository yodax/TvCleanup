namespace TvCleanup
{
    using System.Collections.Generic;

    public class Episode
    {
        public Episode()
        {
            MediaCollections = new List<MediaCollection>();
        }

        public string Identifier { get; set; }
        public List<MediaCollection> MediaCollections { get; private set; }
    }
}