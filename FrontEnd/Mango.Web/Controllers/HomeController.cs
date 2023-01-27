﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mango.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        [HttpGet("Login")]
        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
