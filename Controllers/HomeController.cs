using Microsoft.AspNetCore.Mvc;

namespace SumitPortfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
