using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server.Database
{
    public class DataLogger
    {
        private static string _connectionString = @"server=OVO-YD2YXBFUANE\SQLEXPRESS;database=TEST_DB;uid=HMI_User;password=!Onetwo3";
        private static int _index = 0;
        private static string _insertQuery = @"
            INSERT INTO Parameter_Logs ([index], id, [value], [timestamp])
            VALUES (@index, @id, @value, @timestamp)";

        internal void LogParameterIntoDatabase(object sender, ParameterData e)
        {
            Console.WriteLine($"Logging index : {e.Id}, value : {e.Value} into db");
            try 
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(_insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@index", _index);
                        cmd.Parameters.AddWithValue("@id", e.Id);
                        cmd.Parameters.AddWithValue("@value", e.Value);
                        cmd.Parameters.AddWithValue("@timestamp", DateTime.Now.Date);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Successfully wrote the log");
                        _index++;
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
