﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KABKABEhandel.ViewModels.Customers;
using KABKABEhandel.Models.DAL;
using KABKABEhandel.Models;
using KABKABEhandel.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KABKABEhandel.Controllers
{
    public class CustomersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
           
            return View();
        }



        //public IActionResult Info()
        //{
        //    return View();
        //}

        //public IActionResult EditCustomerInfo()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult EditCustomerInfo(EditCustomerInfoViewModel viewModel)
        //{
        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( List<OrderDetailViewModel> order)
        {
       
            return View();
        }

        //Lägg här in kod för att lägga konvertera viewModel till en model som går att 
        //skicka in i databasen.

        // return RedirectToAction(nameof(HomeController.Index));

    

}
}
