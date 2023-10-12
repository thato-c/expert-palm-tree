using Microsoft.AspNetCore.Mvc;

namespace Licensing.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
