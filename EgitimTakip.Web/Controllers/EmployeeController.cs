using EgitimTakip.Data;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll(int companyId)
        {
            var result = _context.Employees.Where(e => e.CompanyId == companyId && !e.IsDeleted).ToList();
            return Json(new { data = result });
        }
    }
}
