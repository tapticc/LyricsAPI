using System.Collections.Generic;
using System.Threading.Tasks;
using LyricsAPI.Models;

namespace LyricsAPI.Interfaces
{
    public interface ILyricsService
    {
        Task<RecordingsViewModel> GetRecordingsByArtistId(string artistId, string artistName);
    }
}
