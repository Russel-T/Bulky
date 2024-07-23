using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;

        /**
         * CategoryController: a constructor
         * It has an implementation of db 
         * The implementation is then assigned to the local variable: _db
         * This allows us to use that implementation inside any other action method
         */
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        /** 
         * Index(): A list of Categories is retrieved from the database
         * Which is then passed to the views in Category
         * Location: Views -> Category -> Index.cshtml
        */
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        // CREATE:

        /**
         * Create(): method that allows user to create a category
         * Location: Views -> Category -> Create.cshtml
         */
        public IActionResult Create()
        {
            return View();
        }

        /**
         * Create(Category obj): this is a POST method to add more Categories in the db
         * _db.SaveChanges() allows the user to update the changes directly in the db
         * This is called in the controller and when the user presses Submit
         * 
         * ModelState.IsValid checks if the appropriate inputs are correct
         * The constraints are given in the Category Controller.
         * One of the constraints of a correct DisplayOrder input should be in the range of 1-100.
         * This constraint was specified in the category controller:[Range(1, 100)]
         * 
         * This makes you go back to the website of the list : return RedirectToAction("Index", "Category");
         */
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();

        }

        // EDIT:

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();// or an error page
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();

        }

        // DELETE:
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();// or an error page
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}