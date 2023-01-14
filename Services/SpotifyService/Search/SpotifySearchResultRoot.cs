using Newtonsoft.Json;
using SpotifyPlus.Services.SpotifyService.Search;

namespace SpotifyPlus.Services.Search
{
    public enum SpotifySearchGroup
    {
        albums,
        tracks,
        playlists,
        artists
    }
    public class SpotifySearchResultRoot : Dictionary<SpotifySearchGroup, SpotifySearchResult>
    {
        
    }
}
