using System.Threading.Tasks;

namespace UrlShortener.Abstractions.Shortener
{
    public interface IShortUrlProvider
    {
        Task<string> GenerateUrl(string url, string userId);
    }
}
