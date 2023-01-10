using Newtonsoft.Json;
using SpotifyPlus.Services.SpotifyService.Search;

namespace SpotifyPlus.Services.Search
{
    public class SpotifySearchItemBase
    {
        public string Name;

        public string Id;

        public string Href;

        public SpotifyItemType Type;

        public string Uri;

        [JsonProperty("external_urls")]
        public ExternalLinks ExternalLinks;

        //public List<SpotifySearchImage> Images;
    }
}
