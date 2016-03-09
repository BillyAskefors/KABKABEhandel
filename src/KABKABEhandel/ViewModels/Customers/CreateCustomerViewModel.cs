using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.ViewModels.Customers
{
    public class CreateCustomerViewModel
    {
        [Required(ErrorMessage = "You must enter a firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter a phone number")]
        public string Phone { get; set; }

     
    }
}
