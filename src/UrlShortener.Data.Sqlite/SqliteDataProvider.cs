using PetrsUrlShortener.Database;
using System;
using System.Threading.Tasks;
using UrlShortener.Abstractions;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Data.Sqlite
{
    public class SqliteDataProvider : IDataProvider
    {
        private readonly UrlDatabaseContext _databaseContext = new UrlDatabaseContext();

        public async Task<bool> AddUrl(string url, string shortUrl, string userId)
        {
            await _databaseContext.AddAsync(
                new ShortenedUrl()
                    {
                        Created = DateTimeOffset.Now,
                        Url = url,
                        ShortUrl = shortUrl
                    });

            return (await _databaseContext.SaveChangesAsync()) == 0;
        }

        public async Task<ShortenedUrl> Get(string shortUrl)
        {
            var url = await _databaseContext.FindAsync<ShortenedUrl>(shortUrl);

            return url;
        }
    }
}
