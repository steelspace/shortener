using AdvancedREI;
using Microsoft.EntityFrameworkCore;
using PetrsUrlShortener.Database;
using System;
using System.Collections.Generic;
using System.Linq;
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
                                    Url = url,
                                    UserId = userId
                                });

            var result = (await _databaseContext.SaveChangesAsync());
            
            if (result != 1)
            {
                return null;
            }

            return entityEntry.Entity.Id.ToBase36();
        }

        public async Task<ShortenedUrl> Get(string shortUrl)
        {
            try
            { 
                var url = await _databaseContext.FindAsync<ShortenedUrl>(shortUrl.FromBase36());

                return url;
            }

            catch (InvalidBase36NumberException)
            {
                return null;
            }
        }

        public async Task<IReadOnlyList<ShortenedUrl>> GetAll(string userId)
        {
            var urls = await _databaseContext.Urls.Where(u => u.UserId == userId).ToListAsync();

            foreach (var url in urls)
            {
                url.ShortUrl = url.Id.ToBase36();
            }

            return urls;
        }
    }
}
