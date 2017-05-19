using Microsoft.AspNetCore.Mvc;

namespace AnimalFeedingCalculator.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["message"] = "your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["message"] = "your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}