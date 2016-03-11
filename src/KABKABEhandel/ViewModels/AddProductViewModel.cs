using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.ViewModels
{
    public class AddProductViewModel
    {
        [Display(Name = "Category Id")]
        [Required(ErrorMessage = "Enter a category id")]
        public int CategoryId { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Enter a product name")]
        public string Name { get; set; }

        [Display(Name = "Product price")]
        [Required(ErrorMessage = "Enter price of product")]
        public decimal Price { get; set; }

        [Display(Name = "Product Vat")]
        public double Vat { get; set; }

        [Display(Name = "Price discount")]
        public double Discount { get; set; }

        [Display(Name = "Product availability")]
        [Required(ErrorMessage = "Enter product availability")]
        public int NumberInStock { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Enter product description")]
        public string Description { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Enter product URL")]
        public string ImageURL { get; set; }

        // Add validator
        public bool IsActive { get; set; }

        //[Display(Name = "I accept terms and conditions")]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        //public bool AcceptTerms { get; set; }
    }
}