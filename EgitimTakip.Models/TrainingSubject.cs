﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EgitimTakip.Models
{
    public class TrainingSubject : BaseModel
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TrainingCategoryId { get; set; }
        public virtual TrainingCategory TrainingCategory { get; set; } //navigation property
        public virtual ICollection<TrainingsSubjectsMap> TrainingsSubjectsMap { get; set; } = new List<TrainingsSubjectsMap>();
    }
}
