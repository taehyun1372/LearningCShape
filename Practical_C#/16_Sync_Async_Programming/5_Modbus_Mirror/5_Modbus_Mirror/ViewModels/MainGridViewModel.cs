using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using NModbus;
using System.Net.Sockets;
using System.Threading;
using _5_Modbus_Mirror.Views;
using System.IO;

namespace _5_Modbus_Mirror.ViewModels
{
    public enum ConnectionState
    {
        disconnected,
        connecting,
        connected
    }
    public class MainGridViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private const int CONNECTION_DELAY = 5000;
        private const int POLLING_INTERVAL = 1000;
        private const int LOGGING_INTERVAL = 1000;
        private const string LOGGING_PATH = "Logs";


        public ObservableCollection<GridRow> Rows { get; set; }

        private ModbusFactory _factory = new ModbusFactory();
        private TcpClient _tcpClient;
        private IModbusMaster _master;

        public Logger LoggerInstance { get; set; }

        private ConnectionState _connectionState = ConnectionState.disconnected;
        public ConnectionState ConnectionState
        {
            get { return _connectionState; }
            set
            {
                _connectionState = value;
                OnNotifyPropertyChanged(nameof(ConnectionState));
            }
        }

        public MainGridViewModel()
        {
            Rows = new ObservableCollection<GridRow>();
            for (int i = 0; i < 10; i++)
            {
                Rows.Add(new GridRow());
            }
            CommunicationProcess();
            LoggingProcess();
        }

        public async Task LoggingProcess()
        {
            while(true)
            {
                if (LoggerInstance is null || !LoggerInstance.Initialised)
                {
                    LoggerInstance = new Logger(LOGGING_PATH);
                }
                else
                {
                    await LoggerInstance.WriteLog($"{DateTime.Now} - Connection Status : {ConnectionState}");
                }
                await Task.Delay(LOGGING_INTERVAL);
            }
        }

        public async Task CommunicationProcess()
        {
            while(true)
            {
                if (ConnectionState == ConnectionState.disconnected)
                {
                    await InitialiseConnection();
                }
                else if(ConnectionState == ConnectionState.connected)
                {
                    await PollAsync();
                }

                int delay = (ConnectionState == ConnectionState.disconnected) ? CONNECTION_DELAY : POLLING_INTERVAL;
                await Task.Delay(delay);
            }
        }


        public async Task InitialiseConnection()
        {
            ConnectionState = ConnectionState.connecting;
            try
            {
                await Task.Run(() =>
                {
                    _tcpClient = new TcpClient("192.168.2.20", 502);
                    _master = _factory.CreateMaster(_tcpClient);
                });
                ConnectionState = ConnectionState.connected;
            }
            catch(Exception e)
            {
                Console.WriteLine("Connection attemped failed..");
                Console.WriteLine(e.Message);
                ConnectionState = ConnectionState.disconnected;
            }

        }

        public async Task PollAsync()
        {
            try
            {
                ushort[] registers = await _master.ReadHoldingRegistersAsync(1, 0, 100);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (i == 0) Rows[j].C1 = registers[i * 10 + j];
                        else if (i == 1) Rows[j].C2 = registers[i * 10 + j];
                        else if (i == 2) Rows[j].C3 = registers[i * 10 + j];
                        else if (i == 3) Rows[j].C4 = registers[i * 10 + j];
                        else if (i == 4) Rows[j].C5 = registers[i * 10 + j];
                        else if (i == 5) Rows[j].C6 = registers[i * 10 + j];
                        else if (i == 6) Rows[j].C7 = registers[i * 10 + j];
                        else if (i == 7) Rows[j].C8 = registers[i * 10 + j];
                        else if (i == 8) Rows[j].C9 = registers[i * 10 + j];
                        else if (i == 9) Rows[j].C10 = registers[i * 10 + j];
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to read server data..");
                Console.WriteLine(e.Message);
                ConnectionState = ConnectionState.disconnected;
                return;
            }
        }

        public void OnNotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async void OnDataChanged(DataChangedEventArgs e)
        {
            var address = e.Column * 10 + e.Row;
            await _master.WriteSingleRegisterAsync(1, (ushort)address, e.Value);
            if (e.Column == 0) Rows[e.Row].C1 = (ushort)e.Value;
            else if (e.Column == 1) Rows[e.Row].C2 = (ushort)e.Value;
            else if (e.Column == 2) Rows[e.Row].C3 = (ushort)e.Value;
            else if (e.Column == 3) Rows[e.Row].C4 = (ushort)e.Value;
            else if (e.Column == 4) Rows[e.Row].C5 = (ushort)e.Value;
            else if (e.Column == 5) Rows[e.Row].C6 = (ushort)e.Value;
            else if (e.Column == 6) Rows[e.Row].C7 = (ushort)e.Value;
            else if (e.Column == 7) Rows[e.Row].C8 = (ushort)e.Value;
            else if (e.Column == 8) Rows[e.Row].C9 = (ushort)e.Value;
            else if (e.Column == 9) Rows[e.Row].C10 = (ushort)e.Value;
        }
    }

    public class GridRow : INotifyPropertyChanged
    {
        private ushort _c1;
        public ushort C1
        {
            get { return _c1; }
            set
            {
                if (_c1 != value)
                {
                    _c1 = value;
                    OnPropertyChanged(nameof(C1));
                }
            }
        }
        private ushort _c2;
        public ushort C2
        {
            get { return _c2; }
            set
            {
                if (_c2 != value)
                {
                    _c2 = value;
                    OnPropertyChanged(nameof(C2));
                }
            }
        }
        private ushort _c3;
        public ushort C3
        {
            get { return _c3; }
            set
            {
                if (_c3 != value)
                {
                    _c3 = value;
                    OnPropertyChanged(nameof(C3));
                }
            }
        }
        private ushort _c4;
        public ushort C4
        {
            get { return _c4; }
            set
            {
                if (_c4 != value)
                {
                    _c4 = value;
                    OnPropertyChanged(nameof(C4));
                }
            }
        }
        private ushort _c5;
        public ushort C5
        {
            get { return _c5; }
            set
            {
                if (_c5 != value)
                {
                    _c5 = value;
                    OnPropertyChanged(nameof(C5));
                }
            }
        }
        private ushort _c6;
        public ushort C6
        {
            get { return _c6; }
            set
            {
                if (_c6 != value)
                {
                    _c6 = value;
                    OnPropertyChanged(nameof(C6));
                }
            }
        }
        private ushort _c7;
        public ushort C7
        {
            get { return _c7; }
            set
            {
                if (_c7 != value)
                {
                    _c7 = value;
                    OnPropertyChanged(nameof(C7));
                }
            }
        }
        private ushort _c8;
        public ushort C8
        {
            get { return _c8; }
            set
            {
                if (_c8 != value)
                {
                    _c8 = value;
                    OnPropertyChanged(nameof(C8));
                }
            }
        }
        private ushort _c9;
        public ushort C9
        {
            get { return _c9; }
            set
            {
                if (_c9 != value)
                {
                    _c9 = value;
                    OnPropertyChanged(nameof(C9));
                }
            }
        }

        private ushort _c10;
        public ushort C10
        {
            get { return _c10; }
            set
            {
                if (_c10 != value)
                {
                    _c10 = value;
                    OnPropertyChanged(nameof(C10));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Logger
    {
        private const string LOG_FILE_NAME = "log.txt";
        public string FolderPath { get; set; }
        public string FullPath { get; set; }

        public bool Initialised { get; set; } = false;
        public Logger(string folderPath)
        {
            FolderPath = folderPath;
            Initialise();
        }

        public void Initialise()
        {
            try
            {
                var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FolderPath);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                FullPath = Path.Combine(folderPath, LOG_FILE_NAME);

                Initialised = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Initialised = false;
            }
        }


        public async Task WriteLog(string content)
        {
            if(Initialised)
            {
                try
                {
                    using (var writer = new StreamWriter(FullPath, true, Encoding.UTF8))
                    {
                        await writer.WriteLineAsync(content);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to write logs..");
                    Console.WriteLine(e.Message);
                    Initialised = false;
                }
            }
        }
    }
}
