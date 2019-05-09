using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortener.Abstractions.Model;
using UrlShortener.Abstractions.Shortener;

namespace PetrsUrlShortener.Controllers
{
    [Route("/api/v1/short-url")]
    public class ShortenerController : Controller
    {
        private readonly IShortUrlProvider _urlProvider;

        public ShortenerController(IShortUrlProvider urlProvider)
        {
            _urlProvider = urlProvider;
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShortenedUrl))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("text/plain")]
        public async Task<IActionResult> Add(string url, string userId)
        {
            return Content(await _urlProvider.GenerateUrl(url, userId));
        }
    }
}
