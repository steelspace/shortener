using System.Threading.Tasks;
using UrlShortener.Abstractions;
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

        public async Task<string> GenerateUrl(string url, string userId)
        {
            return await _dataProvider.AddUrl(url, userId);
        }
    }
}
