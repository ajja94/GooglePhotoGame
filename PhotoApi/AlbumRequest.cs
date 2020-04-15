using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoApi
{
    public class AlbumRequest
    {
        public string pageSize { get; set; }
        public string albumId { get; set; }
    }

    public class PictureAlbum
    {
        public Picture[] mediaItems { get; set; }
    }

    public class Picture
    {
        public string id { get; set; }
        public string productUrl { get; set; }
        public string baseUrl { get; set; }
        public string mimeType { get; set; }
        public Mediametadata mediaMetadata { get; set; }
        public string filename { get; set; }
    }

    public class Mediametadata
    {
        public DateTime creationTime { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public Photo photo { get; set; }
    }

    public class Photo
    {
    }

}
