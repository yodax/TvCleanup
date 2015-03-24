﻿namespace TvCleanup
{
    using System.Collections.Generic;

    public class MediaCollection
    {
        public MediaCollection()
        {
            Files = new List<MediaFile>();
        }

        public string Identifier { get; set; }
        public List<MediaFile> Files { get; set; }
    }
}