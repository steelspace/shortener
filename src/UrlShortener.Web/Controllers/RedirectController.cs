using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortener.Abstractions.Shortener;

namespace PetrsUrlShortener.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RedirectController: Controller
    {
        private readonly IShortenedUrlProvider _urlProvider;

        public RedirectController(IShortenedUrlProvider urlProvider)
        {
            _urlProvider = urlProvider;
        }

        [HttpGet]
        [Route("{slug}")]
        [ProducesResponseType(StatusCodes.Status307TemporaryRedirect)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Go()
        {
            string slug = Request.Path;

            string url = await _urlProvider.GetUrl(slug.TrimStart('/'));

            if (url == null)
            {
                return NotFound();
            }

            return await Task.Run<ActionResult>(() =>
            {
                return Redirect(url);
            });
        }
    }
}
