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

        public async Task<string> AddUrl(string url, string userId)
        {
            var entityEntry = await _databaseContext.AddAsync(
                            new ShortenedUrl()
                                {
                                    Created = DateTimeOffset.Now,
                                    Url = url
                                });

            if ((await _databaseContext.SaveChangesAsync()) != 0)
            {
                return null;
            }

            return entityEntry.Entity.ShortUrl;
        }

        public async Task<ShortenedUrl> Get(string shortUrl)
        {
            var url = await _databaseContext.FindAsync<ShortenedUrl>(shortUrl);

            return url;
        }
    }
}
