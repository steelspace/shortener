using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Abstractions;
using UrlShortener.Abstractions.Model;
using UrlShortener.Abstractions.Shortener;

namespace UrlShortener.Shortener
{
    public class DbGeneratorShortProvider : IShortUrlProvider
    {
        private readonly IDataProvider _dataProvider;

        public DbGeneratorShortProvider(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<string> GenerateSlug(string url, string userId)
        {
            return await _dataProvider.AddUrl(url, userId);
        }

        public async Task<string> GetUrl(string slug)
        {
            var shortenedUrl = await _dataProvider.Get(slug);

            if (shortenedUrl == null)
            {
                return null;
            }

            return shortenedUrl.Url;
        }

        public async Task<IReadOnlyList<ShortenedUrl>> GetUrls(string userId)
        {
            var urls = await _dataProvider.GetAll(userId);

            return urls;
        }
    }
}
