using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KABKABEhandel.Models;
using KABKABEhandel.Models.DAL;
using KABKABEhandel.ViewModels;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KABKABEhandel.Controllers
{
    public class ProductController : Controller
    {
        DataManager dataManager;

        public ProductController()
        {
            dataManager = new DataManager(new EHandelDB()); 
        }

        // GET: /Product/Index
        public IActionResult Index(string id)
        {
            int x = Convert.ToInt32(id);
            ListProductViewModel[] viewModels;

            if (x == 0)
            {
                viewModels = dataManager.GetLatestProducts();
            }
            else
            {                
                var tempViewModels = dataManager.GetProductsFromCategory(x);
                viewModels = tempViewModels                    
                    .Select(product => new ListProductViewModel { ID = product.ID, Name = product.Name, Details = product.Details, Price = product.Price, Vat = product.Vat, ImageURL = product.ImageURL})
                    .ToArray();
            }

                return View(viewModels);
        }
        [Authorize]
        public IActionResult AddProduct()
        {
            return View();
        }

        [Authorize]
        [HttpPost] //om en post fungerar ska den sluta med redirect
        public IActionResult AddProduct(AddProductViewModel product)
        {
            if (!ModelState.IsValid)
                return View(product);
            string msg; 
            dataManager.AddProduct(product, out msg);
            ViewBag.msg = msg; 
            return RedirectToAction(nameof(ProductController.AddProduct));
        }

        public IActionResult GetAllProducts()
        {
            //var dataManager = new DataManager();
            var model = dataManager.ListProducts();
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchProduct(string id)
        {
            //DataManager dataManager = new DataManager(new EHandelDB());
            //var products = from m in dataManager.ListProducts()
            //               select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(p => p.Name.Contains(searchString));
            //}

            EHandelDB myEHDB = new EHandelDB();
            return View(myEHDB.FindProduct(id));
        }

        //public IActionResult GetAllDetails()
        //{
        //    var dataManager = new DataManager();
        //    var model = dataManager.ListDetails();
        //    return View(model);
        //}
    }
}
