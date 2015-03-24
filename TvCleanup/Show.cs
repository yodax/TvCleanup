namespace TvCleanup
{
    using System.Collections.Generic;

    public class Show
    {
        public Show()
        {
            Episodes = new List<Episode>();
        }

        public string Name { get; set; }
        public List<Episode> Episodes { get; private set; }
    }
}