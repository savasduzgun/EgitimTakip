﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T Add(T entity);
        List<T> AddRange(List<T> entities); //liste olarak ekleme
        T Update(T entity);

        //void Delete(T entity); Hard Delete
        void Delete(int id); //Soft Delete
        T GetById(int id); 
        T GetFirstOrDefault(Expression<Func<T,bool>>predicate);
        void Save();

    }
}
