namespace SpotifyPlus.Services
{
    public class SpotifyAuth
    {
        private readonly string _clientId = "818e44b14cf64fdca299229621e4827a";
        private readonly string _clientSecret = "cf0023b3db254de1b5ca01e7c29ff94f";
        private string _authToken;
        static readonly HttpClient client = new HttpClient();

        public SpotifyAuth() 
        {

        }

        public async void RefreshAuthToken()
        {
            var clientInfo = System.Text.Encoding.UTF8.GetBytes(this._clientId + ":" + this._clientSecret);
           
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {System.Convert.ToBase64String(clientInfo)}");
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

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        public void MakeAuthorizedCall()
        {

        }

    }
}
