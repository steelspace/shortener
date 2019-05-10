using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Abstractions.Shortener
{
    public interface IShortUrlProvider
    {
        Task<string> GenerateSlug(string url, string userId);

        Task<string> GetUrl(string slug);

        // needs paging, sorting etc.
        Task<IReadOnlyList<ShortenedUrl>> GetUrls(string userId);
    }
}
