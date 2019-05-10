using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Abstractions.Shortener
{
    public interface IShortenedUrlProvider
    {
        Task<string> GenerateSlug(string url, string userId);

        Task<ShortenedUrl> GetUrl(string slug);

        // needs paging, sorting etc.
        Task<IReadOnlyList<ShortenedUrl>> GetUrls(string userId);
    }
}
