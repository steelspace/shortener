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

        public async Task<ShortenedUrl> AddUrl(string url, string userId)
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

            return entityEntry.Entity;
        }

        public async Task<ShortenedUrl> Get(long id)
        {
            return await _databaseContext.FindAsync<ShortenedUrl>(id);
        }

        public async Task<IReadOnlyList<ShortenedUrl>> GetAll(string userId)
        {
            return await _databaseContext.Urls.Where(u => u.UserId == userId).ToListAsync();
        }
    }
}
