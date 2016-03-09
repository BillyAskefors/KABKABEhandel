using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KABKABEhandel.Controllers
{
    public class CartController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Add(AddProductViewModel viewModel)
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Remove()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Remove(RemoveProductViewModel viewModel)
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Edit(EditProductViewModel viewModel)
        //{
        //    return View();
        //}
    }
}
