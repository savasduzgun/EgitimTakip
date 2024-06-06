using EgitimTakip.Data;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll(int companyId)
        {
            var result = _context.Trainings.Where(t => t.CompanyId == companyId && !t.IsDeleted).ToList();
            return Json(new { data = result });
        }
    }
}
