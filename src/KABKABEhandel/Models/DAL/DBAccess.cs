﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.Models.DAL
{
    public abstract class DbAccess
    {

        private SqlConnection connection;

        public DbAccess(SqlConnection connection)
        {
                        
            this.connection = connection;
           
        }

        protected int ExcecuteNonQuery(SqlCommand cmd, out string message)
        {
            int affectedRows = 0;

            try
            {
                connection.Open();
                cmd.Connection = connection;
                affectedRows = cmd.ExecuteNonQuery();
                message = "success";

            }
            catch (Exception ex)
            {
                message = "Excecute non query error: " + ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return affectedRows;
        }

        protected DataSet ExecuteQuery(SqlCommand cmd, string tableName, out string message)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                cmd.Connection = connection;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet, tableName);
                message = "success";
            }
            catch (Exception ex)
            {
                message = "Excecute query error: " + ex.Message;
            }
            finally
            {
                connection.Close();

            }

            return dataSet;

        }




    }
}
