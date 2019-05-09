using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using PetrsUrlShortener.Database;
using System.Collections.Generic;
using System.Linq;
using UrlShortener.Abstractions.Model;

namespace UrlShortener.Data.Sqlite
{
    public class ShortUrlValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;
        
        private string _currentSlug = null;

        protected override object NextValue(EntityEntry entry)
        {
            if (_currentSlug == null)
            { 
                var lastEntity = ((UrlDatabaseContext)entry.Context).Urls.OrderBy(k => k.ShortUrl).LastOrDefault();

                if (lastEntity == null)
                {
                    _currentSlug = "0";
                }
                else
                { 
                    _currentSlug = lastEntity.ShortUrl;
                }
            }

            char lastChar = _currentSlug[_currentSlug.Length - 1];

            if (lastChar == 'z')
            {
                _currentSlug += "0";
            }
            else
            { 
                _currentSlug = _currentSlug.Remove(_currentSlug.Length - 1, 1) + (char)((int)lastChar + 1);
            }

            ((ShortenedUrl)entry.Entity).ShortUrl = _currentSlug;

            return _currentSlug;
        }
    }
}
