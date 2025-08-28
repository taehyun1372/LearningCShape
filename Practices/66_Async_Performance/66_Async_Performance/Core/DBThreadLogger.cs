using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace _66_Async_Performance.Core
{
    public class DBThreadLogger
    {
        private static string _connectionString;
        private static string _insertQuery = @"
            INSERT INTO parameter_logs (id, [value], [timestamp])
            VALUES (@id, @value, @timestamp)";

        Thread _loggerThread;
        ParameterGenerator _generator;

        public int Threshold { get; set; } = 30;


        public int Interval { get; set; } = 10;

        public DBThreadLogger(ParameterGenerator generator)
        {
            _generator = generator;
            _connectionString = ConfigurationManager.AppSettings["connectionString"];

            Start();
        }

        public void Start()
        {
            _loggerThread = new Thread(Process);
            _loggerThread.Start();
        }

        public void Abort()
        {
            if (_loggerThread != null)
            {
                _loggerThread.Abort();
            }
        }

        public void Process()
        {
            while(true)
            {
                if (_generator != null)
                {
                    if (_generator.ParameterQueue.Count > Threshold)
                    {
                        int count = 0;
                        foreach (var item in _generator.ParameterQueue.GetConsumingEnumerable())
                        {
                            count++;
                            LogParameterIntoDB(item);
                            Thread.Sleep(1);
                        }
                        Console.WriteLine($"Logged {count} Parameters");
                    }
                    Thread.Sleep(Interval);
                }
            }
        }

        public void LogParameterIntoDB(Parameter param)
        {
            if (_connectionString == "")
            {
                return;
            }
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(_insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", param.Id);
                    cmd.Parameters.AddWithValue("@value", param.Value);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
