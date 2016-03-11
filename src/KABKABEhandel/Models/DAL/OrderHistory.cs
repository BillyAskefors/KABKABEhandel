using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models.DAL
{
    public class OrderHistory
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string CurrentCustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
