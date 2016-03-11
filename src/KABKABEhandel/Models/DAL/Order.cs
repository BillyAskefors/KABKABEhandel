using KABKABEhandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Controllers
{
    public class Order
    {
        public Order(int id, string status, int customer, int deliveryAddress)
        {
            ID = id;
            Status = status;
            Customer = customer;
            DeliveryAddress = deliveryAddress;

            ProdcutList = new List<Product>();
        }

        public int ID { get; set; }
        public string Status { get; set; }
        public int Customer { get; set; }
        public int DeliveryAddress { get; set; }
        public List<Product> ProdcutList { get; set; }
    }
}
