using EgitimTakip.Data;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingSubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingSubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var result = _context.TrainingSubjects.ToList();
            return Json(new { data = result }); //datatable da kullanabilmek için
        }
    }
}
