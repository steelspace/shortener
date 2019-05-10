using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Abstractions
{
    public interface IDataProvider
    {
        Task<string> AddUrl(string url, string userId);

        Task<ShortenedUrl> Get(string slug);

        Task<IReadOnlyList<ShortenedUrl>> GetAll(string userId);
    }
}
