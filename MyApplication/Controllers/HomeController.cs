using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyApplication.Models;
using MyApplication.Models.ViewModels;

namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IStringLocalizer<HomeController> _localizer;
        //public HomeController(IStringLocalizer<HomeController> localizer)
        //{
        //    _localizer = localizer;
        //}
        //public IActionResult Index()
        //{
        //    ViewData["Title"] = _localizer["Header"];
        //    ViewData["Message"] = _localizer["Message"];
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
