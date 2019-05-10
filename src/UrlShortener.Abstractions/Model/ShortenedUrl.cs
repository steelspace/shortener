using System;

namespace UrlShortener.Abstractions.Model
{
    public class ShortenedUrl
    {
        public long Id { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public DateTimeOffset Created { get; set; }

        public string UserId { get; set; }
        
        public bool IsExpired => Created.AddHours(1) < DateTimeOffset.Now;
    }
}
