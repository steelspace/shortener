using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Abstractions
{
    public interface IDataProvider
    {
        Task<ShortenedUrl> AddUrl(string url, string userId);

        Task<ShortenedUrl> Get(long id);

        Task<IReadOnlyList<ShortenedUrl>> GetAll(string userId);
    }
}
