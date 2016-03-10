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
        //Customer customer = new Customer("Anders", "Larssson", "a.larsso@example.com", "09011111111");

        //Address address = new Address();
        //address.City = "Luleå";
        //    address.Street = "Ågatan 44";
        //    address.ZipCode = "19012";
        //    address.Country = "Sweden";

        //    List<Product> products = new List<Product>();
        //Product p = new Product();
        //p.Id = 1;
        //    p.Price = 30;
        //    p.Vat = 0.45;
        //    p.Quantity = 33;
        //    products.Add(p);
        //    Product p2 = new Product();
        //p2.Id = 4;
        //    p2.Price = 100;
        //    p2.Vat = 0.50;
        //    p2.Quantity = 9000;
        //    products.Add(p2);
        //    EHandelDB db = new EHandelDB();
        //string msg = db.SubmitOrder(customer, address, products);
        //ViewBag.msg = msg; 
        //    return View();


        const string ConnectionString = "Server=tcp:projekt2server.database.windows.net,1433;Database=Projekt 2 Databas;User ID=awa16@projekt2server;Password=AcademicWorkAcademy16;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        SqlCommand cmd; 

        public EHandelDB():base(new SqlConnection(ConnectionString))
        {

        }

        private int AddCustomer(Customer newCustomer, out string msg)
        {
            int newCustomerId;
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spAddCustomer"; 
            cmd.Parameters.Add(new SqlParameter("@Email",SqlDbType.NVarChar,320)).Value = newCustomer.Email;
            cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30)).Value = newCustomer.FirstName;
            cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30)).Value = newCustomer.LastName;
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 30)).Value = newCustomer.Phone;


            SqlParameter outputParam = cmd.Parameters.Add("@new_id", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;

            int affectedRows = ExcecuteNonQuery(cmd, out msg);

            newCustomerId = (int) outputParam.Value;

            return newCustomerId;

        }

        

        private int AddAddress(Address newAddress, out string msg)
        {
            int newAddressId; 
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spAddAddress";

            cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 30)).Value = newAddress.Street;
            cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 30)).Value = newAddress.City;
            cmd.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.NVarChar, 15)).Value = newAddress.ZipCode;
            cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 30)).Value = newAddress.Country;

            SqlParameter outputParam = cmd.Parameters.Add("@new_id", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;

            int affectedRows = ExcecuteNonQuery(cmd, out msg);

            newAddressId = (int) outputParam.Value;
           
            return newAddressId;

        }

        private string SubmitOrder(Customer newCustomer, Address address, List<Product> shoppingCart)
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
                product.Discount = Convert.ToInt32(row["NrInStock"].ToString());

                latestProducts.Add(product); 

            }

            return latestProducts; 
        }








    }
}
