using Newtonsoft.Json;

namespace SpotifyPlus.Services.Auth
{
    public class SpotifyAuthToken
    {
        [JsonProperty("access_token")]
        public string AccessToken;
        [JsonProperty("token_type")]
        public string TokenType;
        [JsonProperty("expires_in")]
        public int TimeToLive;
        public DateTime ExpireTime;

    }

    public class SpotifyAuth
    {
        private readonly string _clientId = "818e44b14cf64fdca299229621e4827a";
        private readonly string _clientSecret = "cf0023b3db254de1b5ca01e7c29ff94f";
        public SpotifyAuthToken _authToken;
        static readonly HttpClient client = new HttpClient();


        public bool IsTokenFresh()
        {
            return _authToken != null && DateTime.Now < _authToken.ExpireTime;
        }

        public async Task<bool> RefreshAuthToken()
        {
            var clientInfo = System.Text.Encoding.UTF8.GetBytes(_clientId + ":" + _clientSecret);

            client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(clientInfo)}");
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"grant_type", "client_credentials" }
                };
                var content = new FormUrlEncodedContent(values);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                using HttpResponseMessage response = await client.PostAsync("https://accounts.spotify.com/api/token", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                _authToken = JsonConvert.DeserializeObject<SpotifyAuthToken>(responseBody);

                _authToken.ExpireTime = DateTime.Now.AddSeconds(_authToken.TimeToLive);
                return true;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
        }
    }
}
