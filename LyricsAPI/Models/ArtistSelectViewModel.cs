using System.ComponentModel;
using System.Runtime.Serialization;

namespace LyricsAPI.Models
{
    public class ArtistSelectViewModel
    {               
        [DisplayName("Artist Name")]
        public string ArtistName { get; set; }
        public string ValidationMessage { get; set; }
    }
}
