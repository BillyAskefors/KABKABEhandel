﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KABKABEhandel.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KABKABEhandel.Controllers
{
    public class CartController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            //Kan här lägga in en check om man är inloggad. Om inte så skickas man till login page. 
            // denna bör ta in en list och presentera. Om listan är null ska inga produkter visas.          

            return View();
        }

        //[HttpGet]
        //public IActionResult AddToCart()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddToCart(AddProductViewModel viewModel)
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult RemoveFromCart()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Remove(RemoveProductViewModel viewModel)
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult EditInCart()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Edit(EditProductViewModel viewModel)
        //{
        //    return View();
        //}
    }
}
