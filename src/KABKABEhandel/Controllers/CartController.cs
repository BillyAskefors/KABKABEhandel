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
        public IActionResult Index()
        {
            //Kan här lägga in en check om man är inloggad. Om inte så skickas man till login page. 
            // denna bör ta in en list och presentera. Om listan är null ska inga produkter visas.          

            return View();
        }

      

    }
}
