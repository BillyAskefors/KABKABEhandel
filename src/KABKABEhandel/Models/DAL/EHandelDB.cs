using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models.DAL
{
    internal class EHandelDB : DbAccess
    {
        const string ConnectionString = "Server=tcp:projekt2server.database.windows.net,1433;Database=Projekt 2 Databas;User ID=awa16@projekt2server;Password=AcademicWorkAcademy16;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        SqlCommand cmd; 

        public EHandelDB():base(new SqlConnection(ConnectionString))
        {

        }

        private int AddCustomer(Customer newCustomer, out string msg)
        {
           
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spAddCustomer"; 
            cmd.Parameters.Add(new SqlParameter("@Email",SqlDbType.NVarChar,320)).Value = newCustomer.Email;
            cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30)).Value = newCustomer.FirstName;
            cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30)).Value = newCustomer.LastName;
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 30)).Value = newCustomer.Phone;

            int affectedRows = ExcecuteNonQuery(cmd, out msg);

            return affectedRows; 
     
        }

        

        private int AddAddress(Address newAddress, out string msg)
        {

            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "spAddCustomer";
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 320)).Value = newCustomer.Email;
            cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30)).Value = newCustomer.FirstName;
            cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30)).Value = newCustomer.LastName;
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 30)).Value = newCustomer.Phone;

            int affectedRows = ExcecuteNonQuery(cmd, out msg);

            return affectedRows;

        }








    }
}
