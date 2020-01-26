using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school.Models;
using school.Data;
namespace school.Controllers
{
    public class ClasseController : Controller
    {
        private readonly SchoolDbContext _db;
        public ClasseController(SchoolDbContext db)
        {
           _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Classes.ToList());
        }
        //Http get 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Classe s)
        {
            if (ModelState.IsValid)
            {
                if (!_db.Classes.Any(p => p.id == s.id))
                {
                    _db.Add(s);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(s);
        }
        // hhtp post
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var member = _db.Classes.Find(id);
            if (member==null)
            {
                return NotFound();
            }
            else
            {
                _db.Classes.Remove(member);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Edit(int id)
        {
            var member = _db.Classes.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                return View(member);
            }
        }
        [HttpPost]
        public IActionResult Edit(Classe s)
        {
            if (ModelState.IsValid )
            {
               
                _db.Update(s);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(s);
        }
    }

}