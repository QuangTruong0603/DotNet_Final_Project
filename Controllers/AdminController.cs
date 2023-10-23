using Microsoft.AspNetCore.Mvc;

namespace do_an_ck.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
