using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetrsUrlShortener.Models;

namespace PetrsUrlShortener.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string id = GetBrowserId();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // cookie management
        const string COOKIE_ID_NAME = "Browser-Id";

        private string GetBrowserId()
        {
            string id = Request.Cookies[COOKIE_ID_NAME];

            if (id == null)
            {
                id = Guid.NewGuid().ToString();

                SetBrowserId(id);
            }

            return id;
        }

        private void SetBrowserId(string value)
        {
            var option = new CookieOptions()
                                {
                                    Expires = DateTime.Now.AddYears(1)
                                };

            Response.Cookies.Append(COOKIE_ID_NAME, value, option);
        }
    }
}
