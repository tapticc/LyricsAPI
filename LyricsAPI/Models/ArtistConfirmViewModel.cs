using System.Collections.Generic;

namespace LyricsAPI.Models
{
    public class ArtistConfirmViewModel
    {
        public ArtistConfirmViewModel()
        {
            Artists = new List<ArtistViewModel>();
        }

        public string ArtistSearchName { get; set; }
        public string ValidationMessage { get; set; }
        public List<ArtistViewModel> Artists { get; set; }
        public string SelectedArtistId { get; set; }
    }
}
