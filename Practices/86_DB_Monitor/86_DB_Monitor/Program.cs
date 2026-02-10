using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace _86_DB_Monitor
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Something");

            var monitor = new ServerMonitor();
            monitor.TestSelect();
            monitor.SearchParameterIds();
            
            //var count101 = monitor.CountRowsByParameterId(101);
            Console.WriteLine("Found {count101} rows!");

            Console.WriteLine("Happened");
            Console.ReadLine();
        }
    }

    class Config
    {
        public string ConnectionString { get; set; }
        public string TestSelectCommand { get; set; }
        public string SearchParameterIdsCommand { get; set; }
        public string CsvPath { get; set; }


        public Config()
        {
            Console.WriteLine("Loading configurations..");
            ConnectionString = ConfigurationManager.AppSettings["connectionString"];
            TestSelectCommand = ConfigurationManager.AppSettings["testSelectCommand"];
            SearchParameterIdsCommand = ConfigurationManager.AppSettings["searchParameterIdsCommand"];
            CsvPath = ConfigurationManager.AppSettings["csvPath"];

            Console.WriteLine("Finished loading configuraitons");
        }
    }

    class ServerMonitor
    {
   

        private List<int> _parameterIds = new List<int>();
        public Config Config { get; set; }
        public CsvLogger CsvLogger { get; set; } 

        public ServerMonitor()
        {
            Config = new Config();
            CsvLogger = new CsvLogger(Config.CsvPath);
        }

        public void SearchParameterIds()
        {
            using (var conn = new SqlConnection(Config.ConnectionString))
            {
                using (var cmd = new SqlCommand(Config.SearchParameterIdsCommand, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int parameterId = reader.GetInt32(0);
                            _parameterIds.Add(parameterId);
                        }
                    }
                }
            }
            Console.WriteLine("---Searched all parameters---");
            //Test Logging
            CsvLogger.Log(DateTime)
            foreach(var parameterId in _parameterIds)
            {
                Console.Write($"{parameterId}, ");
            }
        }

        public int CountRowsByParameterId(int parameterId)
        {
            string countRowsByParameterId = $@"
                    SELECT
                        COUNT(*) AS RowCount
                    FROM dbo.HMI_TBL_Parameter_Logs
                ";

            using (var conn = new SqlConnection(Config.ConnectionString))
            {
                using (var cmd = new SqlCommand(countRowsByParameterId, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                        return count;
                    }
                }
            }
        }

        public void TestSelect()
        {
            using (var conn = new SqlConnection(Config.ConnectionString))
            {
                using (var cmd = new SqlCommand(Config.TestSelectCommand, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var i = 0;
                        while(reader.Read())
                        {
                            int deviceId = reader.GetInt32(0);
                            int parameterId = reader.GetInt32(1);
                            DateTime timeStamp = reader.GetDateTime(7);


                            Console.WriteLine($"{i} : device Id : {deviceId}, Parameter Id  {parameterId}, Time Stamp : {timeStamp}");
                            i++;
                        }
                    }
                }
            }
        }

    }

    public class CsvLogger : IDisposable
    {
        private readonly object _lock = new object();
        private readonly StreamWriter _writer;
        private bool _disposed;

        public CsvLogger(string fileName)
        {

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDir, fileName);

            bool fileExists = File.Exists(filePath);

            _writer = new StreamWriter(
                new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read),
                Encoding.UTF8
            );

            string headerLine = DateTime.Now.ToString() + " - Logging stated..";

            if (!string.IsNullOrEmpty(headerLine))
            {
                _writer.WriteLine(headerLine);
                _writer.Flush();
            }
        }

        public void Log(params object[] values)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(CsvLogger));

            string line = BuildCsvLine(values);

            lock (_lock)
            {
                _writer.WriteLine(line);
            }
        }

        private static string BuildCsvLine(object[] values)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0)
                    sb.Append(',');

                string value = Convert.ToString(values[i], CultureInfo.InvariantCulture);

                if (value.Contains("\"") || value.Contains(",") || value.Contains("\n"))
                {
                    value = "\"" + value.Replace("\"", "\"\"") + "\"";
                }

                sb.Append(value);
            }

            return sb.ToString();
        }

        public void Flush()
        {
            lock (_lock)
            {
                _writer.Flush();
            }
        }

        public void Dispose()
        {
            if (_disposed) return;

            lock (_lock)
            {
                _writer.Dispose();
                _disposed = true;
            }
        }
    }
}
