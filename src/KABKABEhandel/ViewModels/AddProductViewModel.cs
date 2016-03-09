﻿using System;
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
    }
}