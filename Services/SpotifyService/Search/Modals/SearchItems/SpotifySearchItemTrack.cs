using Newtonsoft.Json;

namespace SpotifyPlus.Services.SpotifyService.Search.Modals.SearchItems
{
    public class SpotifySearchItemTrack : SpotifySearchItemBase
    {
        SpotifySearchItemAlbum Album;

        List<SpotifySearchItemBase> Artists;

        [JsonProperty("disc_number")]
        public int DiskNumber;

        [JsonProperty("duration_ms")]
        public int DurationMs;

        public bool Explicit;

        [JsonProperty("external_ids")]
        Dictionary<string, string> ExternalIds;

        [JsonProperty("is_local")]
        public bool IsLocal;

        [JsonProperty("is_playable")]
        public bool IsPlayable;

        public int Populatiry;

        [JsonProperty("preview_url")]
        public string PreviewUrl;

        [JsonProperty("track_number")]
        public int TrackNumber;
    }
}
