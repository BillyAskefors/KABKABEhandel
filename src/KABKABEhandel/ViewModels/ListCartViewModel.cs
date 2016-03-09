using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.ViewModels
{
    public class ListCartViewModel
    {
        [Display(Name = "Product name")]
        public string Name { get; set; }
        public int ID { get; set; }
        public double Price { get; set; }

    }
}
