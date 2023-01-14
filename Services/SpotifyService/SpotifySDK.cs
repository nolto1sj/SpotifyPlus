using SpotifyPlus.Services.Auth;
using System.Net.Http.Headers;

namespace SpotifyPlus.Services.SpotifyService
{
    public static class SpotifySDK
    {
        private static SpotifyAuth spotifyAuth = new SpotifyAuth();
        static readonly HttpClient client = new HttpClient();
        private static readonly string BaseUrl = "https://api.spotify.com/v1/";

        public static async Task<HttpResponseMessage> Get(string endPoint)
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
    }
}
