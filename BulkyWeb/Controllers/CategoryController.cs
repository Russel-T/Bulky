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
         */
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}