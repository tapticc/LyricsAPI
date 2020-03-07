using System.Collections.Generic;

namespace LyricsAPI.Models
{
    public class RecordingsViewModel
    {
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
        public List<RecordingViewModel> Recordings { get; set; }
      
        public int? AverageWordCount { get; set; }
    }
}
