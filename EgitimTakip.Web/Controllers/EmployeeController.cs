﻿using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAll(int companyId) //companyId ye göre bütün employees çeken metod
        {
            //var result = _context.Employees.Where(e => e.CompanyId == companyId && !e.IsDeleted).ToList();
            //return Json(new { data = result });
            return Json(new { data = _repo.GetAll(companyId) });
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            //_context.Employees.Add(employee);
            //_context.SaveChanges();
            //return Ok(employee);

            return Ok(_repo.Add(employee));
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            //_context.Employees.Update(employee);
            //_context.SaveChanges();
            //return Ok(employee);

            return Ok(_repo.Update(employee));
        }

        [HttpPost] //HttpGet ile de çalışabilir
        public IActionResult Delete(int id)
        {
            ////SOFT DELETE   
            //Employee employee = _context.Employees.Find(id);
            //employee.IsDeleted = true;
            //_context.Employees.Update(employee);
            //_context.SaveChanges();
            //return Ok(employee);

            return Ok(_repo.Delete(id) is object);
        }

        //[HttpPost]
        //public IActionResult HardDelete(int id)
        //{
        //    Employee employee = _context.Employees.Find(id);
        //    _context.Employees.Remove(employee);
        //    _context.SaveChanges();
        //    return Ok(employee);
        //}

    }
}
