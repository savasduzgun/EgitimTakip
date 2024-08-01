using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Abstract
{
    public interface ITrainingRepository:IRepository<Training>
    {
        ICollection<Training> GetAll(int companyId);
        Training Add(Training training,List<TrainingsSubjectsMap> trainingsSubjectsMaps);
    }
}
