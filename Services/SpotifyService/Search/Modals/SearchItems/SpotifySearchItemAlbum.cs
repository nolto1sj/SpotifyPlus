using Newtonsoft.Json;

namespace SpotifyPlus.Services.SpotifyService.Search.Modals.SearchItems
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

        //[JsonProperty("release_date")]
        //public DateTime ReleaseDate;

        [JsonProperty("release_date_precision")]
        public ReleaseDatePrecision ReleaseDatePrecision;

        [JsonProperty("total_tracks")]
        public int TotalTracks;
    }
}
