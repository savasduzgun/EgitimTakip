using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class CompanyController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public CompanyController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<Company> _repo;

        public CompanyController(IRepository<Company> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            //return Json(_context.Companies.Where(c => !c.IsDeleted).ToList());
              return Json(_repo.GetAll());  
        }

        [HttpPost]
        public IActionResult Add(Company company)
        {
            //_context.Companies.Add(company);
            //_context.SaveChanges();
            //return Ok(company); //Database eklenmiş company nesnesini gönderiyoruz ki Ajax reload yapmadan direkt datatable a satır olarak ekleyeceğim nesne bana gelsin

            return Ok(_repo.Add(company));
        }

        [HttpPost]
        public IActionResult Update(Company company)
        {
            //_context.Companies.Update(company);
            //_context.SaveChanges();
            //return Ok(company);

            return Ok(_repo.Update(company));
        }

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    //HARD DELETE
        //    var company = _context.Companies.Find(id);
        //    _context.Companies.Remove(company);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult Delete(Company company) 
        //{
        //    // HARD DELETE
        //    _context.Companies.Remove(company);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult SoftDelete(int id) //burada company nesnesi gönderirsek ön yüzden bütün prop ları ile gelmesi gerekir ve burada update yaptığımız için boş gelen değerleri biz boşaltmışız gibi database gönderir prop değerleri uçmuş olur ama bize sadece IsDeleted lazım böyle sadece id istersek frondend çi müteşekkir olur
        {
            //SOFT DELETE
            //var company = _context.Companies.Find(id);
            //company.IsDeleted=true;
            //_context.Companies.Update(company);
            //_context.SaveChanges();
            //return Ok();
            
            //return Ok(_repo.Delete(id) is object);
            _repo.Delete(id);
            return Ok();  
        }
    }
}
