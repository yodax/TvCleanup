namespace TvCleanup
{
    using System.Collections.Generic;

    public class FoundMedia
    {
        public FoundMedia()
        {
            Shows = new List<Show>();
        }

        public List<Show> Shows { get; private set; }
    }
}