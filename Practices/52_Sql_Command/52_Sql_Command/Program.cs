using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _52_Sql_Command
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            string connectionString = @"server=OVO-YD2YXBFUANE\SQLEXPRESS;database=HMI_DB_EUV;uid=HMI_User;password=!Onetwo3";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HMI_SP_Get_AlertHistory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@equipmentId", SqlDbType.NChar, 50)).Value = "192.168.2.2";
                    cmd.Parameters.Add(new SqlParameter("@parameterId", SqlDbType.Int)).Value = DBNull.Value;
                    cmd.Parameters.Add(new SqlParameter("@fromDate", SqlDbType.DateTime)).Value = new DateTime(2025, 7, 1); ;
                    cmd.Parameters.Add(new SqlParameter("@toDate", SqlDbType.DateTime, 50)).Value = new DateTime(2025, 8, 1); ;

                    conn.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            string equipmentId = reader["EquipmentId"].ToString();
                            int parameterId = reader["ParameterId"] != DBNull.Value ? Convert.ToInt32(reader["ParameterId"]) : -1;
                            DateTime alertStart = Convert.ToDateTime(reader["AlertStartTime"]);
                            DateTime alertEnd = Convert.ToDateTime(reader["AlertEndTime"]);
                            string description = reader["Description"].ToString();

                            Console.WriteLine($"{equipmentId} | {parameterId} | {alertStart} ~ {alertEnd} | {description}");
                        }
                    }
                }
            }
            
            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
