using KABKABEhandel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models.DAL
{
    public class EHandelDB : DbAccess
    {  

        const string ConnectionString = "Server=tcp:projekt2server.database.windows.net,1433;Database=Projekt 2 Databas;User ID=awa16@projekt2server;Password=AcademicWorkAcademy16;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        SqlCommand cmd; 

        public EHandelDB():base(new SqlConnection(ConnectionString))
        {

        }

        private int AddProduct(Product newProduct, out string msg)
        {
            int newProductId;
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spAddProduct";
            cmd.Parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int)).Value = newProduct.CategoryId;
            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 30)).Value = newProduct.Name;
            cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money)).Value = newProduct.Price;
            cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 800)).Value = newProduct.Description;
            cmd.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)).Value = newProduct.IsActive;
            cmd.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Float)).Value = newProduct.Discount;
            cmd.Parameters.Add(new SqlParameter("@ImageURL", SqlDbType.NVarChar, 320)).Value = newProduct.ImageURL;
            cmd.Parameters.Add(new SqlParameter("@Vat", SqlDbType.Float)).Value = newProduct.Discount;


            SqlParameter outputParam = cmd.Parameters.Add("@new_id", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;

            int affectedRows = ExcecuteNonQuery(cmd, out msg);

            newProductId = (int)outputParam.Value;

            return newProductId;

        }

        //private int AddCustomer(Customer newCustomer, out string msg)
        //{
        //    int newCustomerId;
        //    cmd = new SqlCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = "spAddCustomer"; 
        //    cmd.Parameters.Add(new SqlParameter("@Email",SqlDbType.NVarChar,320)).Value = newCustomer.Email;
        //    cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30)).Value = newCustomer.FirstName;
        //    cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30)).Value = newCustomer.LastName;
        //    cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 30)).Value = newCustomer.Phone;


        //    SqlParameter outputParam = cmd.Parameters.Add("@new_id", SqlDbType.Int);
        //    outputParam.Direction = ParameterDirection.Output;

        //    int affectedRows = ExcecuteNonQuery(cmd, out msg);

        //    newCustomerId = (int) outputParam.Value;

        //    return newCustomerId;

        //}

        

        //private int AddAddress(Address newAddress, out string msg)
        //{
        //    int newAddressId; 
        //    cmd = new SqlCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = "spAddAddress";

        //    cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 30)).Value = newAddress.Street;
        //    cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 30)).Value = newAddress.City;
        //    cmd.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.NVarChar, 15)).Value = newAddress.ZipCode;
        //    cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 30)).Value = newAddress.Country;

        //    SqlParameter outputParam = cmd.Parameters.Add("@new_id", SqlDbType.Int);
        //    outputParam.Direction = ParameterDirection.Output;

        //    int affectedRows = ExcecuteNonQuery(cmd, out msg);

        //    newAddressId = (int) outputParam.Value;
           
        //    return newAddressId;

        //}

        public string SubmitOrder(Customer newCustomer, Address address, List<Product> shoppingCart)
        {
            string msg;

            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spSubmitOrder";
            
            // Add customer.
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 320)).Value = newCustomer.Email;
            cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30)).Value = newCustomer.FirstName;
            cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30)).Value = newCustomer.LastName;
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 30)).Value = newCustomer.Phone;
            
            // Add address 
            cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 30)).Value = address.Street;
            cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 30)).Value = address.City;
            cmd.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.NVarChar, 15)).Value = address.ZipCode;
            cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 30)).Value = address.Country;

            var orderDetails = new DataTable();
            orderDetails.Columns.Add("ProductId", typeof(int));
            orderDetails.Columns.Add("Quantity", typeof(int));
            orderDetails.Columns.Add("Price", typeof(decimal));
            orderDetails.Columns.Add("Vat", typeof(double));

            foreach (var product in shoppingCart)
            {
                DataRow row = orderDetails.NewRow();
                row["ProductId"] = product.Id;
                row["Quantity"] = product.Quantity;
                row["Price"] = product.Price;
                row["Vat"] = product.Vat;

                orderDetails.Rows.Add(row);
              
            }

            cmd.Parameters.Add(new SqlParameter("@products", SqlDbType.Structured)).Value = orderDetails;

            int affectedRows = ExcecuteNonQuery(cmd, out msg);

            return msg;

        }
     
        public List<Product> GetLatestProducts()
        {
            string msg; 
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetLatestProducts";

            DataSet dataSet = ExecuteQuery(cmd, "LatestProducts", out msg);

            List<Product> latestProducts = new List<Product>(); 

            foreach (DataRow row in dataSet.Tables["LatestProducts"].Rows)
            {
             
                Product product = new Product();
                product.Id = Convert.ToInt32(row["Id"].ToString());
                product.Name = row["Name"].ToString();
                product.ImageURL = row["ImageUrl"].ToString();
                product.Vat = Convert.ToDouble(row["Vat"].ToString());
                product.Price = Convert.ToDecimal(row["Price"].ToString());
                product.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                product.Description = row["Description"].ToString();
                product.Discount = Convert.ToDouble(row["Discount"].ToString());
                product.NumberInStock = Convert.ToInt32(row["NrInStock"].ToString());

                latestProducts.Add(product); 

            }

            return latestProducts; 
        }

        public List<Product> GetProductsFromCategoryID(int id)
        {

            string msg;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;       

            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int)).Value = id;
            cmd.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)).Value = 1;

            cmd.CommandText = "spGetAllProductsFromCategoryID";

            DataSet dataSet = ExecuteQuery(cmd, "ProductsFromCategory", out msg);

            List<Product> latestProducts = new List<Product>();

            foreach (DataRow row in dataSet.Tables["ProductsFromCategory"].Rows)
            {

                Product product = new Product();
                product.Id = Convert.ToInt32(row["Id"].ToString());
                product.Name = row["Name"].ToString();
                product.ImageURL = row["ImageUrl"].ToString();
                product.Vat = Convert.ToDouble(row["Vat"].ToString());
                //product.Price = Convert.ToDecimal(row["Price"].ToString());
                product.Price = Decimal.Round(Convert.ToDecimal(row["Price"].ToString()), 2, MidpointRounding.AwayFromZero); 
                product.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                product.Description = row["Description"].ToString();
                product.Discount = Convert.ToDouble(row["Discount"].ToString());
                product.NumberInStock = Convert.ToInt32(row["NrInStock"].ToString());

                latestProducts.Add(product);

            }

            return latestProducts;
        }

        public List<Product> FindProduct(string searchTerm)
        {

            string msg;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 30)).Value = searchTerm;
            cmd.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)).Value = 1;

            cmd.CommandText = "spFindProduct";

            DataSet dataSet = ExecuteQuery(cmd, "FoundProduct", out msg);

            List<Product> searchResults = new List<Product>();

            foreach (DataRow row in dataSet.Tables["FoundProduct"].Rows)
            {

                Product product = new Product();
                product.Id = Convert.ToInt32(row["Id"].ToString());
                product.Name = row["Name"].ToString();
                product.ImageURL = row["ImageUrl"].ToString();
                product.Vat = Convert.ToDouble(row["Vat"].ToString());
                //product.Price = Convert.ToDecimal(row["Price"].ToString());
                product.Price = Decimal.Round(Convert.ToDecimal(row["Price"].ToString()), 2, MidpointRounding.AwayFromZero);
                product.IsActive = Convert.ToBoolean(row["IsActive"].ToString());
                product.Description = row["Description"].ToString();
                product.Discount = Convert.ToDouble(row["Discount"].ToString());
                product.NumberInStock = Convert.ToInt32(row["NrInStock"].ToString());

                searchResults.Add(product);

            }

            return searchResults;
        }



        //Anropar Stored Procedure och får order history utifrån inloggad Email.
        public List<OrderHistory> GetOrderHistoryFromEmail(string email)
        {

            string msg;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 320)).Value = email;
            

            cmd.CommandText = "spGetOrderHistoriesFromMailAddress";

            DataSet dataSet = ExecuteQuery(cmd, "OrderHistories", out msg);

            List<OrderHistory> orderHistoryList = new List<OrderHistory>();

            foreach (DataRow row in dataSet.Tables["OrderHistories"].Rows)
            {

                OrderHistory order = new OrderHistory();
                order.CurrentCustomerName = row["CurrentCustomerName"].ToString();
                order.CustomerId = Convert.ToInt32(row["CustomerId"].ToString());
                order.CurrentStatus = row["CurrentStatus"].ToString();
                order.DateAndTime = Convert.ToDateTime(row["DateAndTime"].ToString());
                order.DeliveryAddress = row["DeliveryAddress"].ToString();
                order.OrderId = Convert.ToInt32(row["OrderId"].ToString());                

                orderHistoryList.Add(order);

            }

            return orderHistoryList;
        }








    }
}
