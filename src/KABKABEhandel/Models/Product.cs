using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models
{
    public class Product
    {
        public Product(string name, double price, int id, string description, string details, int discount, bool isActive, string imageURL, double vat)
        {
            Name = name;
            Price = price;
            ID = id;
            Description = description;
            Details = details;
            Discount = discount;
            IsActive = isActive;
            ImageURL = imageURL;
            Vat = vat;
            
            //NumInStock = numInStock;
            //Status = status;
            //StockPos = stockPos;
            //Color = color;
            //Weight = weight;
            //Measurements = measurements;
            //AcValue = acValue;
            //SupSKU = supSKU;

            ProductList = new List<Product>();
        }

        public Product(int id, string name) //Konstruktor som är till för att admin ska kunna lägga till en produkt som inte är klar än
        {
            ID = id;
            Name = name;
        }

        public Product() //Konstruktor som är till för att admin ska kunna lägga till en produkt som inte är klar än
        {
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
        public string ImageURL { get; set; }
        public double Vat { get; set; }
        //public int NumInStock { get; set; }
        //public string Status { get; set; }
        //public string StockPos { get; set; }
        //public string Color { get; set; }
        //public double Weight { get; set; }
        //public string Measurements { get; set; }
        //public double AcValue { get; set; }
        //public string SupSKU { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
