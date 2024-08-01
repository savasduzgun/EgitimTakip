using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public TrainingController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly ITrainingRepository _repo;

        public TrainingController(ITrainingRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAll(int companyId)
        {
            ////var result = _context.Trainings.Where(t => t.CompanyId == companyId && !t.IsDeleted).ToList();
            ////return Json(new { data = result });
            //return Json(new { data = _context.Trainings.Where(t => t.CompanyId == companyId && !t.IsDeleted)});
            return Json(new { data = _repo.GetAll(companyId) });
        }

        [HttpPost]
        public IActionResult Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            //    _context.Trainings.Add(training);
            //    _context.SaveChanges();
            //    foreach (var item in trainingsSubjectsMaps)
            //    {
            //        item.TrainingId = training.Id;
            //        _context.TrainingsSubjectsMaps.Add(item);
            //    }
            //    _context.SaveChanges();
            //    return Ok(training);
            return Ok(_repo.Add(training, trainingsSubjectsMaps));

        }

        [HttpPost]
        public IActionResult Update(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            //_context.Trainings.Update(training);
            //_context.SaveChanges();
            //return Ok(training);
            training.TrainingsSubjectsMap = new List<TrainingsSubjectsMap>();
            _repo.Update(training);
            training.TrainingsSubjectsMap = trainingsSubjectsMaps;
            return Ok(_repo.Update(training));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //Training training = _context.Trainings.Find(id);
            //training.IsDeleted = true;
            //_context.Trainings.Update(training);
            //_context.SaveChanges();
            //return Ok(training);
            return Ok(_repo.Delete(id) is object);
        }
    }
}
