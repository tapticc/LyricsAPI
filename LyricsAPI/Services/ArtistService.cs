using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyricsAPI.Interfaces;
using LyricsAPI.Models;
using Newtonsoft.Json.Linq;

namespace LyricsAPI.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IDataApiHttpClient _httpClient;
        private readonly IEndpointService _endpointService;

        public ArtistService(
            IDataApiHttpClient httpClient,
            IEndpointService endpointService)
        {
            _httpClient = httpClient;
            _endpointService = endpointService;
        }

        public async Task<IEnumerable<ArtistViewModel>> GetByName(string name)
        {
            var url = _endpointService.GetEndpoint("Artists.ByName");
            url = url.Replace("{name}", name);
            var response = await _httpClient.Get(url);
            var parsedResponse = JObject.Parse(response);

            var artists = parsedResponse["artists"].Children().ToList();

            var artistList = new List<ArtistViewModel>();

            foreach (var artist in artists)
            {
                var newArtist = artist.ToObject<ArtistViewModel>();                
                artistList.Add(newArtist);
            }

            return artistList;
        }

    }
}
