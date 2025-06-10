using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace _18_Data_Logging
{
    class Program
    {
        public const string logFileName = "log_test";
        public struct DataRecord
        {
            public int value1;
            public int value2;
            public int value3;
            public int value4;
            public DateTime timeStamp;
            public byte[] series;
            public string description;
        }

        static void Main(string[] args)
        {
            DataRecord record = new DataRecord();
            record.value1 = 1;
            record.value2 = 2;
            record.value3 = 3;
            record.value4 = 4;
            record.timeStamp = DateTime.Now;
            record.series = new byte[4] {1, 2, 3, 4};
            record.description = "Default Description";

            while(true)
            {
                var command = Console.ReadLine();
                Stopwatch sw = new Stopwatch();
                if (command == "1")
                {
                    sw.Start();
                    for (int i = 0; i < 100; i++)
                    {
                        BinaryLogging(record);
                    }
                    sw.Stop();
                    Console.WriteLine($"Binary logging time measured {sw.ElapsedMilliseconds}");
                    
                }
                else if (command == "2")
                {
                    sw.Start();
                    for (int i = 0; i < 100; i++)
                    {
                        CSVLogging(record);
                    }
                    sw.Stop();
                    Console.WriteLine($"CSV logging time measured {sw.ElapsedMilliseconds}");
                }
            }

            Console.ReadLine();
        }

        public static void BinaryLogging(DataRecord record)
        {
            Console.WriteLine("Starting logging data");

            var logFilePath = logFileName + ".bin";
            using (FileStream fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write))
            {
                using (BinaryWriter logFileBinaryWriter = new BinaryWriter(fs))
                {
                    logFileBinaryWriter.Write(record.value1);
                    logFileBinaryWriter.Write(record.value2);
                    logFileBinaryWriter.Write(record.value3);
                    logFileBinaryWriter.Write(record.value4);
                    logFileBinaryWriter.Write(record.timeStamp.ToBinary());
                    logFileBinaryWriter.Write(record.series);
                    logFileBinaryWriter.Write(record.description);
                }
            }
            Console.WriteLine("Finished logging data");
        }

        public static void CSVLogging(DataRecord record)
        {
            Console.WriteLine("Starting logging data");
            var logFilePath = logFileName + ".csv";
            using (StreamWriter writer = new StreamWriter(logFilePath, append : true, Encoding.UTF8))
            {
                string series = string.Join("", record.series);

                string line = $"{record.value1},{record.value2},{record.value3},{record.value4}," +
                    $"{record.timeStamp},{series},{record.description}";
                writer.WriteLine(line);
            } 
            Console.WriteLine("Finished logging data");
        }
    }
}
