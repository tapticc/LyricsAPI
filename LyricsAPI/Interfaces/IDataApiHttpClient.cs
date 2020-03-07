using System.Threading.Tasks;

namespace LyricsAPI.Interfaces
{
    public interface IDataApiHttpClient
    {
        string BaseUrl { get; }
        Task<string> Get(string requestUri);
    }
}
