using Newtonsoft.Json;
using SpotifyPlus.Services.SpotifyService.Search;

namespace SpotifyPlus.Services.Search
{
    public enum SpotifySearchGroup
    {
        albums,
        tracks,
        playlists
    }
    public class SpotifySearchResultRoot : Dictionary<SpotifySearchGroup, SpotifySearchResult>
    {
        
    }
}
