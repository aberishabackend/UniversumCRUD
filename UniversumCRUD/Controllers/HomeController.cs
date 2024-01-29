using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversumCRUD.Models;

namespace UniversumCRUD.Controllers
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

        [Route("/StatusCodeError/{statuscode}")]
        public IActionResult Error(int statuscode)
        {
            if (statuscode == 404)
            {
                ViewBag.ErrorMessage = "404 Page Not Found Exception.";
            }
            return View("Error");
        }
    }
}
