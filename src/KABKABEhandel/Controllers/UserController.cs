using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KABKABEhandel.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }

        public IActionResult EditInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditInfo(EditInfoViewModel viewModel)
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            return View();
        }


    }
}
