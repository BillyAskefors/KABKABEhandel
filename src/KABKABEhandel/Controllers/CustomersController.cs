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
        DataManager dataManager;
        // GET: /<controller>/

        public CustomersController()
        {
            dataManager = new DataManager(new EHandelDB()); 
        }

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
            if (HttpContext.Session.GetString("CustomerViewModel") != null)
            {
                return RedirectToAction(nameof(CustomersController.SubmitOrder));
            }

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
            
            if (HttpContext.Session.GetString("CustomerViewModel") != null)
            {
                var customer = JsonConvert.DeserializeObject<CreateCustomerViewModel>(HttpContext.Session.GetString("CustomerViewModel"));
                return View(customer);
            }

            return RedirectToAction(nameof(CustomersController.Create));
        }

        [HttpPost]
        public IActionResult SubmitOrder(List<OrderDetailViewModel> order)
        {
            string msg = "fail";
            
            if (HttpContext.Session.GetString("CustomerViewModel") != null)
            {
                var customer = JsonConvert.DeserializeObject<CreateCustomerViewModel>(HttpContext.Session.GetString("CustomerViewModel"));
              
                if (order.Count > 0 && customer != null)
                {
                    dataManager.SubmitOrder(customer, order, out msg);
                }
            }
            return Json(msg);
        }


    }
}
