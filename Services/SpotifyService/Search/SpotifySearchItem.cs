using SpotifyPlus.Services.SpotifyService.Search;

namespace SpotifyPlus.Services.Search
{
    public enum AlbumType
    {
        Album
    }

    public enum ReleaseDatePrecision
    {
        Day
    }
    public class SpotifySearchItem
    {
        public string Name { get; set; }

        public DateTime ReleaseDate;
        public AlbumType AlbumType { get; set; }

        public ReleaseDatePrecision ReleaseDatePrecision { get; set; }
        //public List<Artist> Artists { get; set; } // TODO Artist Search result vs full artist query resut?

        public ExternalLinks ExternalLinks { get; set; }

        public string ReferanceUrl{ get; set; }

        public string Id;
        //public List<ImageRefereance> Images;


    }
}
