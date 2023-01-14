using Newtonsoft.Json;
using SpotifyPlus.Services.SpotifyService.Search.Modals.SearchItems;

namespace SpotifyPlus.Services.SpotifyService.Search
{
    public class SpotifySearchResult
    {
        public int Limit;
        public int Total;
        public int Offset;

        [JsonProperty("items")]
        List<SpotifySearchItemBase> SearchItems;
    }
}
