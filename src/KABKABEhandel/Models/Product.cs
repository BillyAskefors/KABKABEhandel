using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models
{
    public class Product
    {
        public Product(string name, decimal price, int numberInStock, int id, string description, double discount, bool isActive, string imageURL, double vat)
        {
            Id = id;
            Name = name;
            Price = price;
            Vat = vat;
            Discount = discount;
            NumberInStock = numberInStock;
            Description = description;
            //Details = details;
            ImageURL = imageURL;
            IsActive = isActive;
            
            //NumInStock = numInStock;
            //Status = status;
            //StockPos = stockPos;
            //Color = color;
            //Weight = weight;
            //Measurements = measurements;
            //AcValue = acValue;
            //SupSKU = supSKU;

            //ProductList = new List<Product>();
        }

        public Product(int id, string name) //Konstruktor som är till för att admin ska kunna lägga till en produkt som inte är klar än
        {
            Id = id;
            Name = name;
        }

        public Product() //Konstruktor som är till för att admin ska kunna lägga till en produkt som inte är klar än
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }
        public int NumberInStock { get; set; }
        public string Description { get; set; }
        //public string Details { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }

        public int Quantity { get; set; }
        //public int NumInStock { get; set; }
        //public string Status { get; set; }
        //public string StockPos { get; set; }
        //public string Color { get; set; }
        //public double Weight { get; set; }
        //public string Measurements { get; set; }
        //public double AcValue { get; set; }
        //public string SupSKU { get; set; }
        //public List<Product> ProductList { get; set; }
    }
}
