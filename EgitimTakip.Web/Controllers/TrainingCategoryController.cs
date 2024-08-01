using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingCategoryController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public TrainingCategoryController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IRepository<TrainingCategory> _repo;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _repo.GetAll() });
        }
        [HttpPost]
        public IActionResult Add(TrainingCategory trainingCategory)
        {
            //try
            //{
            //    _context.TrainingCategories.Add(trainingCategory);
            //    _context.SaveChanges();
            //    return Ok(trainingCategory);
            //    //return StatusCode(200, trainingCategory);
            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex); //hata gönderileceği zaman ok ile gönderilmez
            //    //return StatusCode(400, ex.Message);
            //    //500 - Internal Server Error
            //}
            TrainingCategory category = _repo.Add(trainingCategory);
            if (category.Id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(category);
            }

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            ////var traininCategory = _context.TrainingCategories.Find(id);
            //var traininCategory = _context.TrainingCategories.FirstOrDefault(tc => tc.Id == id);
            //traininCategory.IsDeleted = true;
            //_context.TrainingCategories.Update(traininCategory);
            //_context.SaveChanges();
            //return Ok();
            return Ok(_repo.Delete(id) is object);
        }
        [HttpPost]
        public IActionResult Update(TrainingCategory trainingCategory)
        {
            //_context.TrainingCategories.Update(trainingCategory);
            //_context.SaveChanges();
            //return Ok(trainingCategory);
            return Ok(_repo.Update(trainingCategory));
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            //return Ok(_context.TrainingCategories.Find(id));
            return Ok(_repo.GetById(id));   
        }
    }
}
