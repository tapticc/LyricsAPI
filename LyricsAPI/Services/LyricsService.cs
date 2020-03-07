using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyricsAPI.Interfaces;
using LyricsAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LyricsAPI.Services 
{
    public class LyricsService : ILyricsService
    {
        private readonly IDataApiHttpClient _httpClient;
        private readonly IEndpointService _endpointService;

        public LyricsService(
            IDataApiHttpClient httpClient,
            IEndpointService endpointService)
        {
            _httpClient = httpClient;
            _endpointService = endpointService;
        }

        public async Task<RecordingsViewModel> GetRecordingsByArtistId(string artistId, string artistName)
        {
            var url = _endpointService.GetEndpoint("Recordings.ByArtistId");
            url = url.Replace("{artistId}", artistId);
            var response = await _httpClient.Get(url);
            var parsedResponse = JObject.Parse(response);

            var recordings = parsedResponse["recordings"].Children().ToList();

            var recordingList = new List<RecordingViewModel>();

            foreach (var recording in recordings)
            {
                var newRecording = recording.ToObject<RecordingViewModel>();
                recordingList.Add(newRecording);
            }

            var recordingsViewModel = new RecordingsViewModel
            {
                ArtistId = artistId,
                ArtistName = artistName,
                Recordings = recordingList
            };

            return recordingsViewModel;
        }

    }
}
