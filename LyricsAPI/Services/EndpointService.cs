using LyricsAPI.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LyricsAPI.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IConfiguration _configuration;

        public EndpointService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetEndpoint(string configKey)
        {
            const string sectionName = "ApiEndpoints";
            var endpoint = _configuration.GetSection(sectionName)[configKey];

            return endpoint;
        }
    }
}
