using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school.Data;
using school.Models.ViewModel;
using school.Models;
using Microsoft.EntityFrameworkCore;

namespace school.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _db;

        [BindProperty]
        public StudentViewModel ModelStd { get; set; }
        public StudentController(SchoolDbContext db)
        {
            _db = db;
            ModelStd = new StudentViewModel()
            {
                Classes = _db.Classes.ToList(),
                Student = new Models.Student()
            };
        }
        public IActionResult Index()
        {
            var model = _db.Students.Include(c => c.Classe);
            return View(model);
        }
        //Htttp Get
        public IActionResult Create()
        {
            return View(ModelStd);
        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelStd);
            }
            _db.Students.Add(ModelStd.Student);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            ModelStd.Student = _db.Students.Include(c => c.Classe).SingleOrDefault(c => c.id == id);
            if (ModelStd.Student==null)
            {
                return NotFound();
            }
            return View(ModelStd);
        }
        [HttpPost,ActionName("Edit")]
        public IActionResult Edit()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelStd);
            }
                _db.Update(ModelStd.Student);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }
        public IActionResult Delete(int id)
        {
            Student s = _db.Students.Find(id);
            if (s == null)
                return NotFound();

            _db.Students.Remove(s);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}