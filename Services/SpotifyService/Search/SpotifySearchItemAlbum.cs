using Newtonsoft.Json;
using SpotifyPlus.Services.Search;

namespace SpotifyPlus.Services.SpotifyService.Search
{
    public enum AlbumType
    {
        Album,
        Single
    }

    public enum ReleaseDatePrecision
    {
        Day,
        Year
    }
    public class SpotifySearchItemAlbum : SpotifySearchItemBase
    {
        [JsonProperty("album_type")]
        public AlbumType AlbumType;

        public List<SpotifySearchItemBase> Artists;

        public List<SpotifySearchImage> Images;
        
        //[JsonProperty("release_date")]
        //public DateTime ReleaseDate;

        [JsonProperty("release_date_precision")]
        public ReleaseDatePrecision ReleaseDatePrecision;

        [JsonProperty("total_tracks")]
        public int TotalTracks;
    }
}
