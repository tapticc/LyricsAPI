using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LyricsAPI.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LyricsAPI.HttpClients
{
    public class DataApiHttpClient : IDataApiHttpClient
    {
        private readonly IConfiguration _config;

        private readonly HttpClient _client;
        public string BaseUrl => _client.BaseAddress.AbsoluteUri;

        public DataApiHttpClient(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            _client.DefaultRequestHeaders
                .Accept                                
                .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header        
            _client.DefaultRequestHeaders.Add("User-Agent", "LyricsAPI Demo");
        }

        public async Task<string> Get(string requestUri)
        {
            try
            {
                var response = await _client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
