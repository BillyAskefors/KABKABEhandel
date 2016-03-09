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

        static DataManager()
        {
            products.Add(new Product("1", "Mastersword"));
            products.Add(new Product("2", "Mirror Shield"));
            products.Add(new Product("3", "Green Hood"));
        }

        public void AddProduct(AddProductViewModel viewModel)
        {
            var product = new Product();

            product.Name = viewModel.Name;

            products.Add(product);
        }

        public void EditProduct(EditProductViewModel viewModel)
        {
            var tempProduct = new Product();
            tempProduct = select products
                .Where(c => c.ID == viewModel.ID)
                .Select(c => new EditProductViewModel
                {
                    ID = c.ID,
                    Name = viewModel.Name
                })
                .SingleOrDefault();

            products.Add(tempProduct);
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

        public ListProductViewModel ListSingleProduct(string id)
        {
            return products
                .Where(c => c.ID == id)
                .Select(c => new ListProductViewModel
                {
                    ID = c.ID,
                    Name = c.Name
                })
                .SingleOrDefault();
        }

        public string ListDetails(string id)
        {
            return products
                .Where(c => c.ID == id)
                .Select(p => new ListProductViewModel
                {
                    Details = p.Details
                })
                .ToString();
        }
    }
}
