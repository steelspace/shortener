using System.Threading.Tasks;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Abstractions
{
    public interface IDataProvider
    {
        Task<string> AddUrl(string url, string userId);

        Task<ShortenedUrl> Get(string shortUrl);
    }
}
