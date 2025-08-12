using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _57_Database_Test
{
    class Program
    {
        private static string _connString = "To do";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            SqlConnection conn = new SqlConnection(_connString);
            SqlCommand comm = null;

            try
            {
                
                conn.Open();

                comm = conn.CreateCommand();

                comm.CommandText = "HMI_SP_Add_Parameter_Logs";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("DeviceId", SqlDbType.Int).Value = 9999;
                comm.Parameters.Add("ParameterId", SqlDbType.Int).Value = 1111;
                comm.Parameters.Add("Value", SqlDbType.Float).Value = 7777;
                comm.Parameters.Add("Unit", SqlDbType.Float).Value = "Test";
                comm.Parameters.Add("PriorityLevel", SqlDbType.Int).Value = 1;
                comm.Parameters.Add("AlarmType", SqlDbType.Int).Value = 1;
                comm.Parameters.Add("Ids_String", SqlDbType.NVarChar).Value = "";
                comm.Parameters.Add("TimeStamp", SqlDbType.DateTime2).Value = DateTime.Now.ToUniversalTime();

                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"A Exception happend while writing a data");
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }


            


            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
