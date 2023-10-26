using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace do_an_ck.Controllers
{
    [Authorize(Roles = "1")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
