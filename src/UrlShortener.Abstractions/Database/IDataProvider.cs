using System.Threading.Tasks;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Abstractions
{
    public interface IDataProvider
    {
        // returns false in case of collision
        Task<bool> AddUrl(string url, string shortUrl, string userId);

        Task<ShortenedUrl> Get(string shortUrl);
    }
}
