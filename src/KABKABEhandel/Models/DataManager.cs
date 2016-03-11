using KABKABEhandel.Models.DAL;
using KABKABEhandel.ViewModels;
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
                .Select(product => new ListProductViewModel { ID = product.Id, Name = product.Name, Details = product.Description, Price = product.Price, Vat = product.Vat})
                .ToArray();
        }

        public ListProductViewModel[] GetProductsFromCategory(int id)
        {
            return db.GetProductsFromCategoryID(id)
                .Select(product => new ListProductViewModel { ID = product.Id, Name = product.Name, Details = product.Description, Price = product.Price, Vat = product.Vat, ImageURL = product.ImageURL})
                .ToArray();
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
