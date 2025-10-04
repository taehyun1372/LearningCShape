using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Interfaces;
using System.Data.SqlClient;

namespace Server.Database
{
    public class DataReader
    {
        private string _connectionString;
        private static string _readQuery = @"
            SELECT * FROM parameter_logs";

        public DataReader()
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

        public List<ParameterHistoryData> ReadParametersFromDatabase()
        {
            
            if (_connectionString == "")
            {
                return null; //Verify connection string
            }
            Console.WriteLine($"Reading parameters from db");
            try
            {
                var result = new List<ParameterHistoryData>();
                var count = 0;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(_readQuery, conn))
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            
                            while(reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                double value = reader.GetDouble(reader.GetOrdinal("value"));
                                DateTime timeStamp = reader.GetDateTime(reader.GetOrdinal("timestamp"));
                                result.Add(new ParameterHistoryData() 
                                { 
                                    Id = id,
                                    Value = value,
                                    TimeStamp = timeStamp
                                });
                                count++;
                            }
                        }
                    }
                }

                Console.WriteLine($"Successfully read {count} parameters");
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during reading parameters from db {ex.Message}");
                return null;
            }

        }
    }

}
