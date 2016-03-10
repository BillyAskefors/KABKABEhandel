using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.ViewModels
{
    public class AddProductViewModel
    {
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Enter a product name")]
        public string Name { get; set; }

        [Display(Price = "Product price")]
        [Required(ErrorMessage = "Enter number of doors - 3-5")]
        public int Price { get; set; }

        [Range(0, 300)]
        [Required(ErrorMessage = "Enter maximum velocity")]
        public int TopSpeed { get; set; }

        [Display(Name = "I accept terms and conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        public bool AcceptTerms { get; set; }
    }
}