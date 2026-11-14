using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetDoc.Data;

namespace VetDoc.Controllers
{
    public class ClinicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClinicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clinics = _context.Clinics
                .Include(c => c.Vets)
                .ToList();

            return View(clinics);
        }
    }
}
