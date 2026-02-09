using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using Edwards.EMS.DataLogger;

namespace _74_RetrieveDataFromLog
{
    class Program
    {

        public static DataLoggerManager loggerManager = new DataLoggerManager();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            
            short[] data = new short[] { 1, 2, 3, 4 };
            while(true)
            {
                var input = Console.ReadLine();
                if (input == "write") WriteDataRecord(data);
                //else if (input == "read") loggerManager.ReadDataRecord(1, DateTime.Today);
                else if (input == "close") CloseDatalogger();
                else if (input == "read") ReadDataRecord();
            }

        }

        static void WriteDataRecord(short[] data)
        {
            try
            {
                loggerManager.WriteDataRecord(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CloseDatalogger()
        {
            try
            {
                loggerManager.CloseDatalogger();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ReadDataRecord()
        {
            try
            {
                var result = loggerManager.ReadDataRecord(1, DateTime.Today);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class DataLoggerManager
    {
        DataLogger dataLogger;

        public DataLoggerManager()
        {
            SetUpDataLogger();
        }

        private void SetUpDataLogger()
        {
            try
            {
                dataLogger = new DataLogger(string.Empty); //Needs to add Exception class later

                string startLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string supportFilesLocation = Path.Combine(startLocation, "Support Files");
                string setupFolderLocation = Path.Combine(supportFilesLocation, "Setup");
                string setupPath = Path.Combine(startLocation, setupFolderLocation);
                string parameterDefinition = Path.Combine(setupPath, "Proteus Parameters Definition.dat");
                string commsDefinition = Path.Combine(setupPath, "Proteus Comms Definition.dat");
                string logFolderLocation = Path.Combine(startLocation, "Logs");

                dataLogger.CompressEventLogsOnCompletion = true;
                dataLogger.NumberOfDaysBeforeCompressingLogFiles = 0; //190122 - [Luke] the Log Data Compression function Disabled.
                dataLogger.NumberOfDaysToKeepEventLogFiles = 60;
                dataLogger.NumberOfDaysToKeepSystemLogFiles = 60;

                dataLogger.NumberOfDaysToKeepSystemLogFiles = 30; //190122 - [Luke] the automatically delete period changed 100 days to 30 days.
                dataLogger.PreEventDurationInMinutes = 100; //??? = CUShort(data(DisplayConfig.PreEventTime))
                dataLogger.PostEventDurationInMinutes = 100; //??? = CUShort(data(DisplayConfig.PostEventTime))

                dataLogger.HmiSoftwareVersion = "12345"; //버전 네이밍 변수로 다시
                dataLogger.SystemBuildNumber = "Proteus MK2 Ch.A ";

                dataLogger.ControllerFirmware = "FirmWare"; //New String(FirmwareArray).TrimEnd(Chr(0))
                dataLogger.ControllerSerialNumber = "controllerSN"; //New String(SerialNumberArray).TrimEnd(Chr(0))
                dataLogger.PlcSoftwareVersion = "PLCVersion"; //New String(PLCCodeArray).TrimEnd(Chr(0))

                dataLogger.InitialiseDataLogger(startLocation, parameterDefinition, commsDefinition, 40, 35, 20,
                    ByteOrder.BigEndian, 15, 1, "controllerSN", "FirmWare", "PLCVersion");

                dataLogger.RecordDLLVersions(startLocation);
                dataLogger.SetUpNewCommsTableLogging(1, 1, 60000);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void WriteDataRecord(short[] data)
        {
            try
            {
                byte[] DataByteArray = new byte[(data.Length * 2)];

                DataRecord dr = new DataRecord(1, DateTime.Now, 1, DataByteArray);

                if (dataLogger != null) this.dataLogger.WriteDataRecord(dr);

                byte[] ByteData;
                for (var i = 0; i <= (data.Length - 1); i++)
                {
                    ByteData = BitConverter.GetBytes(data[i]);
                    DataByteArray[i * 2] = ByteData[1];
                    DataByteArray[(i * 2) + 1] = ByteData[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public SortedList<DateTime, byte[]> ReadDataRecord(int dataPointer, DateTime plotDate)
        {
            DateTime logStartTime = new DateTime(plotDate.Year, plotDate.Month, plotDate.Day, 0, 0, 0, 0);
            DateTime logEndTime = new DateTime(plotDate.Year, plotDate.Month, plotDate.Day, 23, 59, 59, 0);
            ParameterDataRetrievalInfo pdri = new ParameterDataRetrievalInfo(1, 1, dataPointer, 2);
            dataLogger.RetrieveDataFromLogs(logStartTime, logEndTime, pdri, LogType.System, false, true);
            return pdri.RetrievedData;
        }

        public void CloseDatalogger()
        {

            if (this.dataLogger != null)
            {
                this.dataLogger.CloseDataLogger();
            }
        }
    }
}
