using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.ViewModels
{
    public class ListOrderHistoryViewModel
    {
        public int OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
