﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetrsUrlShortener.Models;
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
        public async Task<IActionResult> Add([FromBody] ShortUrlRequest request)
        {
            if (string.IsNullOrEmpty(request.Url) || string.IsNullOrEmpty(request.UserId))
            {
                return BadRequest();
            }

            string slug = await _urlProvider.GenerateSlug(request.Url, request.UserId);

            return Content(slug);
        }

        [HttpGet]
        [Route("{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShortenedUrl))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("text/plain")]
        public async Task<IActionResult> Get(string slug)
        {
            string url = await _urlProvider.GetUrl(slug);

            if (url == null)
            {
                return NotFound();
            }

            return Content(url);
        }

        [HttpGet]
        [Route("all/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShortenedUrl))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("text/json")]
        public async Task<IActionResult> GetAll(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var urls = await _urlProvider.GetUrls(userId);

            return Json(urls);
        }
    }
}
