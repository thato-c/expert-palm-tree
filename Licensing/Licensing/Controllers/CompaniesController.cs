using Licensing.Data;
using Licensing.Models;
using Licensing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Licensing.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly LicenceContext _context;

        public CompaniesController(LicenceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve a list of companies from the database
            var companies = await _context.Companies.ToListAsync();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the ViewModel to Company entity
                var Company = new Company
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };

                // Add and save the new company to the database
                _context.Companies.Add(Company);
                await _context.SaveChangesAsync();
                    
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
