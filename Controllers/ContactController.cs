using Microsoft.AspNetCore.Mvc;

namespace SumitPortfolio.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string name, string email, string message)
        {
            // This is a placeholder. You can integrate email sending or storage here.
            ViewBag.Message = "Thank you, " + name + ". Your message has been received.";
            return View();
        }
    }
}
