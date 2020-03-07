using System.Collections.Generic;
using System.Threading.Tasks;
using LyricsAPI.Models;

namespace LyricsAPI.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistViewModel>> GetByName(string name);        
    }
}
