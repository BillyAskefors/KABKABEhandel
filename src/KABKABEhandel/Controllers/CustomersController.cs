using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using KABKABEhandel.ViewModels.Customers;
using KABKABEhandel.Models.DAL;
using KABKABEhandel.Models;
using KABKABEhandel.ViewModels;
using Newtonsoft.Json;

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
        public IActionResult Create( CreateCustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            HttpContext.Session.SetString("CustomerViewModel", JsonConvert.SerializeObject(customer));

            return RedirectToAction(nameof(CustomersController.SubmitOrder)); 
        }

        public IActionResult SubmitOrder()
        {
            var customer = JsonConvert.DeserializeObject<CreateCustomerViewModel>(HttpContext.Session.GetString("CustomerViewModel"));

            

            return View(customer);
        }

        [HttpPost]
        public IActionResult SubmitOrder(List<OrderDetailViewModel> order)
        {
            var customer = JsonConvert.DeserializeObject<CreateCustomerViewModel>(HttpContext.Session.GetString("CustomerViewModel"));

            if (order.Count > 0 && customer != null)
            {
                var newCustomer = new Customer(customer.FirstName, customer.LastName, "test@example33.se", customer.Phone);

                var deliveryAddress = new Address{Street= customer.Street, ZipCode= customer.Zip, City = customer.City, Country = customer.Country};
                
            }


            return View();
        }

        //Lägg här in kod för att lägga konvertera viewModel till en model som går att 
        //skicka in i databasen.

        // return RedirectToAction(nameof(HomeController.Index));



    }
}
