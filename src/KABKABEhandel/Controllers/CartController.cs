using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using KABKABEhandel.ViewModels;
using KABKABEhandel.Models;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KABKABEhandel.Controllers
{
    
    public class CartController : Controller
    {
        List<Product> cartList = new List<Product>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            //Kan här lägga in en check om man är inloggad. Om inte så skickas man till login page. 
            // denna bör ta in en list och presentera. Om listan är null ska inga produkter visas.          

            return View();
        }

        public IActionResult TemporaryCart(string product)
        {
            JObject jObject = JObject.Parse(product);

            string id = jObject["id"].ToString();
            string vat = jObject["vat"].ToString();
            string price = jObject["price"].ToString();
            string quantity = jObject["quantity"].ToString();


            //cartList.Add(product);
            //ta emot ajaxpost och lagra :) 

            //returnera error message eller lyckat message! 
            return RedirectToAction(nameof(ProductController.Index));
        }


    }
}
