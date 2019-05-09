using System;

namespace UrlShortener.Abstractions.Model
{
    public class ShortenedUrl
    {
        public string Url { get; set; }

        public string ShortUrl { get; set; }

        public DateTimeOffset Created { get; set; }

        public string UserId { get; set; }
    }
}
