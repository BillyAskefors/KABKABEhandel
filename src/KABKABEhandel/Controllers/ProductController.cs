﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KABKABEhandel.Models;
using KABKABEhandel.Models.DAL;
using KABKABEhandel.ViewModels;

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
        public IActionResult Index()
        {
            var viewModels = dataManager.GetLatestProducts(); 
       
            return View(viewModels);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost] //om en post fungerar ska den sluta med redirect
        public IActionResult AddProduct(AddProductViewModel product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var dataManager = new DataManager(new EHandelDB());
            dataManager.AddProduct(product);

            return RedirectToAction(nameof(ProductController.AddProduct));
        }

        public IActionResult GetAllProducts()
        {
            //var dataManager = new DataManager();
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
