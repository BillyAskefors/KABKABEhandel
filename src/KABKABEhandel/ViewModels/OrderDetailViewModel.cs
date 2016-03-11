using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.ViewModels
{
    public class OrderDetailViewModel
    {
        public string Id { get; set; }
        public string Quantity { get; set; }    
        public string Vat { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
    }
}
