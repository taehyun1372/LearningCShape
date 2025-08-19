using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Server.Database
{
    public class DataLogger
    {
        private static string _connectionString;
        private static string _insertQuery = @"
            INSERT INTO parameter_logs (id, [value], [timestamp])
            VALUES (@id, @value, @timestamp)";


        public DataLogger()
        {
            try
            {
                _connectionString = ConfigurationManager.AppSettings["connectionString"];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to fetch the connection string {e.Message}");
            }
        }


        internal void LogParameterIntoDatabase(object sender, ParameterData e)
        {
            if (_connectionString == "") 
            {
                return; //Verify connection string
            }
            Console.WriteLine($"Logging Id : {e.Id}, value : {e.Value} into db");
            try 
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(_insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", e.Id);
                        cmd.Parameters.AddWithValue("@value", e.Value);
                        cmd.Parameters.AddWithValue("@timestamp", DateTime.Now.Date);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Successfully wrote the log");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during writing a data into db {ex.Message}");
            }
        }
    }
}
