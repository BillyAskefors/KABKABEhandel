using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KABKABEhandel.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KABKABEhandel.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllProducts()
        {
            var dataManager = new DataManager();
            var model = dataManager.ListProducts();
            return View(model);
        }
        
        //public IActionResult GetAllDetails()
        //{
        //    var dataManager = new DataManager();
        //    var model = dataManager.ListDetails();
        //    return View(model);
        //}
    }
}
