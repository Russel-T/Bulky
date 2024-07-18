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
         * CategoryController is a constructor
         * It has an implementation of db 
         * The implementation is then assigned to the local variable: _db
         * This allows us to use that implementation inside any other action method
         */
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            /** A list of Categories is retrieved from the database
             * Which is then passed to the views in Category
             * Location: Views -> Category -> Index.cshtml
             */
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
    }
}