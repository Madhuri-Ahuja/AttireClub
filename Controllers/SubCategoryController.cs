using AttireClub.Data;
using AttireClub.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttireClub.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly AttireClubDbContext _db;

        public SubCategoryController(AttireClubDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SubCategory> objList = _db.SubCategory;
            return View(objList);
        }
        //GET-CREATE
        public IActionResult Create()
        {
             return View();
        }
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategory obj)
        {
            if(ModelState.IsValid)
            {
                _db.SubCategory.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var obj = _db.SubCategory.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubCategory obj)
        {
            if (ModelState.IsValid)
            {
                _db.SubCategory.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.SubCategory.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int ?id)
        {
            var obj = _db.SubCategory.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.SubCategory.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");      
        }
    
}
}
