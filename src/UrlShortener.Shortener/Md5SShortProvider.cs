using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Abstractions;
using UrlShortener.Abstractions.Shortener;

namespace UrlShortener.Shortener
{
    public class Md5SShortProvider : IShortUrlProvider
    {
        private readonly IDataProvider _dataProvider;
        private readonly MD5CryptoServiceProvider _md5provider = new MD5CryptoServiceProvider();

        const int SHORT_LEN_BYTES = 7;

        public Md5SShortProvider(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<string> GenerateUrl(string url, string userId)
        {
            string shortUrl  = GetHashCode(url, SHORT_LEN_BYTES);

            if (!await _dataProvider.AddUrl(url, shortUrl, userId))
            {
                // second attempt
                shortUrl = GetHashCode(url, SHORT_LEN_BYTES + 4);

                if (!await _dataProvider.AddUrl(url, shortUrl, userId))
                {
                    return null;
                }
            }

            return shortUrl;
        }

        private string GetHashCode(string url, int maxBytes)
        {
            StringBuilder hash = new StringBuilder();
            byte[] bytes = _md5provider.ComputeHash(new UTF8Encoding().GetBytes(url));

            for (int i = 0; i < maxBytes; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
