using System;

namespace UrlShortener.Abstractions.Model
{
    public class ShortenedUrl
    {
        public long Id { get; set; }

        public string ShortUrl { get; set; }

        public string Url { get; set; }

        public DateTimeOffset Created { get; set; }

        public string UserId { get; set; }
    }
}
