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

        private void SubmitOrder(Customer customer, Address deliveryAddress, List<Product> shoppingCart)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetLatestProcuts";



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
                product.Price = Convert.ToDouble(row["Price"].ToString());

                latestProducts.Add(product); 

            }

            return latestProducts; 
        }








    }
}
