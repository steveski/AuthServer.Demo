using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Controllers
{
    public class ClaimsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
