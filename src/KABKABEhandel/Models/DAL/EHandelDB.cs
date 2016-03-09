using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models.DAL
{
    internal class EHandelDB : DbAccess
    {
        const string ConnectionString = "Server=tcp:projekt2server.database.windows.net,1433;Database=Projekt 2 Databas;User ID=awa16@projekt2server;Password=AcademicWorkAcademy16;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public EHandelDB():base(new SqlConnection(ConnectionString))
        {

        }

        public int AddCustomer(Customer newCustomer)
        {
            return 1; 

        }

        

        




    }
}
