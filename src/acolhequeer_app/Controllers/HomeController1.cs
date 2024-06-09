using Microsoft.AspNetCore.Mvc;

namespace acolhequeer_app.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
