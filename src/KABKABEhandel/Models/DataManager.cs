using KABKABEhandel.Models.DAL;
using KABKABEhandel.ViewModels;
using KABKABEhandel.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models
{
    public class DataManager
    {
        static List<Product> products = new List<Product>();

        EHandelDB db;

        static DataManager()
        {
            products.Add(new Product(1, "Mastersword"));
            products.Add(new Product(2, "Mirror Shield"));
            products.Add(new Product(3, "Green Hood"));
        }

        public DataManager(EHandelDB dbContext)
        {
            db = dbContext; 
        }

        public void AddProduct(AddProductViewModel viewModel)
        {
            var product = new Product();

            product.Name = viewModel.Name;
            product.Price = viewModel.Price;
            product.IsActive = viewModel.IsActive;

            //db.AddProduct(product);
            //db.SaveChanges();


            products.Add(product);
        }

        public void EditProduct(EditProductViewModel viewModel)
        {
            //var tempProduct = new Product();
            //tempProduct = Select products
            //    .Where(c => c.ID == viewModel.ID)
            //    .Select(c => new EditProductViewModel
            //    {
            //        ID = c.ID,
            //        Name = viewModel.Name
            //    })
            //    .SingleOrDefault();

            //products.Add(tempProduct);
        }

        public ListProductViewModel[] ListProducts()
        {
            return products
                .OrderBy(p => p.Name)
                .Select(p => new ListProductViewModel
                {
                    Name = p.Name
                })
                .ToArray();
        }

        public ListProductViewModel ListSingleProduct(int id)
        {
            return products
                .Where(c => c.Id == id)
                .Select(c => new ListProductViewModel
                {
                    ID = c.Id,
                    Name = c.Name
                })
                .SingleOrDefault();
        }

        public ListProductViewModel[] GetLatestProducts()
        { 
            return db.GetLatestProducts()
                .Select(product => new ListProductViewModel { ID = product.Id, Name = product.Name, Details = product.Description, Price = product.Price, Vat = product.Vat, ImageURL = product.ImageURL})
                .ToArray();
        }

        public ListProductViewModel[] GetProductsFromCategory(int id)
        {
            return db.GetProductsFromCategoryID(id)
                .Select(product => new ListProductViewModel { ID = product.Id, Name = product.Name, Details = product.Description, Price = product.Price, Vat = product.Vat, ImageURL = product.ImageURL})
                .ToArray();
        }

        public ListOrderHistoryViewModel[] GetOrderHistory(string email)
        {

            return db.GetOrderHistoryFromEmail(email)
                .Select(order => new ListOrderHistoryViewModel { OrderId = order.OrderId, CurrentStatus = order.CurrentStatus, DateAndTime = order.DateAndTime, DeliveryAddress = order.DeliveryAddress })
                .ToArray();
        }
        
        public void SubmitOrder(CreateCustomerViewModel customer, List<OrderDetailViewModel> orders)
        {
            var newCustomer = new Customer(customer.FirstName, customer.LastName, "test@example33.se", customer.Phone);

            var deliveryAddress = new Address { Street = customer.Street, ZipCode = customer.Zip, City = customer.City, Country = customer.Country };

            var products = orders.Select(item => new Product { Id = Convert.ToInt32(item.Id), Quantity = Convert.ToInt32(item.Quantity), Vat = 0, Price = 0 }).ToList();
            //Customer newCustomer = new Customer("Anders", "Larssson", "a.larsso@example.com", "09011111111");

            //Address address = new Address();
            //address.City = "Luleå";
            //address.Street = "Ågatan 44";
            //address.ZipCode = "19012";
            //address.Country = "Sweden";

            //List<Product> products = new List<Product>();
            //Product p = new Product();
            //p.Id = 1;
            //p.Price = 0;
            //p.Vat = 0;
            //p.Quantity = 33;
            //products.Add(p);
            //Product p2 = new Product();
            //p2.Id = 4;
            //p2.Price = 0;
            //p2.Vat = 0;
            //p2.Quantity = 9000;
            //products.Add(p2);
           


            //db.SubmitOrder(newCustomer, deliveryAddress , products);
        }

        //public string ListDetails(int id)
        //{
        //    return products
        //        .Where(c => c.ID == id)
        //        .Select(p => new ListProductViewModel
        //        {
        //            Details = p.Details
        //        })
        //        .ToString();
        //}
    }
}
