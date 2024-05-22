using acolhequeer_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace acolhequeer_app.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
            //_logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Casas()
        {
            string image1 = "/imgs/casa-aurora.png";
            string image2 = "/imgs/casa-chama.png";
            string image3 = "/imgs/casa-transviver.png";

            ViewData["Image1"] = image1;
            ViewData["Image2"] = image2;
            ViewData["Image3"] = image3;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
