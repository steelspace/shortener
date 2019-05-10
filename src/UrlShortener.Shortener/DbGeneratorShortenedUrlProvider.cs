using AdvancedREI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Abstractions;
using UrlShortener.Abstractions.Model;
using UrlShortener.Abstractions.Shortener;

namespace UrlShortener.Shortener
{
    public class DbGeneratorShortenedUrlProvider : IShortenedUrlProvider
    {
        private readonly IDataProvider _dataProvider;

        public DbGeneratorShortenedUrlProvider(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<string> GenerateSlug(string url, string userId)
        {
            var shortenedUrl = await _dataProvider.AddUrl(url, userId);

            if (shortenedUrl == null)
            {
                return null;
            }

            return shortenedUrl.Id.ToBase36();
        }

        public async Task<ShortenedUrl> GetUrl(string slug)
        {
            long id;

            try
            {
                id = slug.FromBase36();
            }

            catch (InvalidBase36NumberException)
            {
                return null;
            }

            var shortenedUrl = await _dataProvider.Get(id);

            if (shortenedUrl == null)
            {
                return null;
            }

            shortenedUrl.Slug = shortenedUrl.Id.ToBase36();

            return shortenedUrl;
        }

        public async Task<IReadOnlyList<ShortenedUrl>> GetUrls(string userId)
        {
            var urls = await _dataProvider.GetAll(userId);

            foreach (var url in urls)
            {
                url.Slug = url.Id.ToBase36();
            }

            return urls;
        }
    }
}
