using Licensing.Data;
using Licensing.Models;
using Licensing.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Licensing.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly LicenceContext _context;

        public CompaniesController(LicenceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve a list of companies from the database
            var companies = _context.Companies.ToList();

            if (companies.Count == 0)
            {
                ViewBag.Message = "No Companies Registered.";
                return View();
            }
            
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
