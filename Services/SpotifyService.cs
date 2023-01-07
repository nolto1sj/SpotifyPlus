using System.Net.Http.Headers;

namespace SpotifyPlus.Services
{
    public class SpotifyService
    {
        public SpotifyAuth spotifyAuth = new SpotifyAuth();
        static readonly HttpClient client = new HttpClient();
        private readonly string BaseUrl = "https://api.spotify.com/v1/";

        public async Task<HttpResponseMessage> Get(string endPoint)
        {
            if (!spotifyAuth.IsTokenFresh())
            {
                await spotifyAuth.RefreshAuthToken();
            }
            client.DefaultRequestHeaders.Add("Authorization", $"{spotifyAuth._authToken.TokenType} {spotifyAuth._authToken.AccessToken}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await client.GetAsync($"{BaseUrl}{endPoint}");
            string responseBody = await response.Content.ReadAsStringAsync();
            return response;
        }

        public async Task<List<SearchItem>> Search(string searchQuery)
        {
            var result = new List<SearchItem>();
            var stringResponse = await (await Get($"search?q={searchQuery}&type=album&market=US&limit=24")).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<SearchItem>(stringResponse);
        }
    }

}
