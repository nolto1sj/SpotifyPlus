using System.Net.Http.Headers;
using Newtonsoft.Json;
using SpotifyPlus.Services.Auth;
using SpotifyPlus.Services.Converters;
using SpotifyPlus.Services.Search;


namespace SpotifyPlus.Services.SpotifyService
{
    public class SpotifyService
    {
        public async Task<SpotifySearchResultRoot> Search(string searchQuery)
        {
            var response = await SpotifySDK.Get(searchQuery);
            string responseBody = await response.Content.ReadAsStringAsync();
            SpotifySearchResultRoot result = JsonConvert.DeserializeObject<SpotifySearchResultRoot>(responseBody, new SearchItemConverter());
            return result;
        }
    }

}
