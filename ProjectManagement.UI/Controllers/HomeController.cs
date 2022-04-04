using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
