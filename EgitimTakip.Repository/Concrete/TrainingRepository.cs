using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using EgitimTakip.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Concrete
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        //private readonly ApplicationDbContext _context;
        public TrainingRepository(ApplicationDbContext context) : base(context)
        {
            //_context = context;
        }

        public Training Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            base.Add(training);
            foreach (var item in trainingsSubjectsMaps)
            {
                item.TrainingId = training.Id;
                //_context.TrainingsSubjectsMaps.Add(item);
            }
            training.TrainingsSubjectsMap = trainingsSubjectsMaps;
            base.Update(training);
            return training;
        }

        public ICollection<Training> GetAll(int companyId)
        {
            return base.GetAll().Where(t=>t.CompanyId == companyId).ToList();
        }
    }
}
