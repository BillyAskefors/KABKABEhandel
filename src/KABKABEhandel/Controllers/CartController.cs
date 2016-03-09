using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KABKABEhandel.ViewModels.Carts;

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
        public IActionResult AddToCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddtoCart(AddToCartViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RemoveFromCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveFromCart(RemoveFromCartViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditInCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditInCart(EditInCartViewModel viewModel)
        {
            return View();
        }
    }
}
