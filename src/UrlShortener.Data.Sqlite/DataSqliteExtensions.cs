using Microsoft.Extensions.DependencyInjection;
using PetrsUrlShortener.Database;
using UrlShortener.Abstractions;

namespace UrlShortener.Data.Sqlite
{
    public static class DataSqliteExtensions
    {
        public static void AddSqliteDataProvider(this IServiceCollection services)
        {
            services.AddSingleton<IDataProvider, SqliteDataProvider>();

            using (var client = new UrlDatabaseContext())
            {
                // Create the database file
                client.Database.EnsureCreated();
            }
        }
    }
}
