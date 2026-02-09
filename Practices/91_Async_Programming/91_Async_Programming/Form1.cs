using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _91_Async_Programming
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _startTimer = new System.Windows.Forms.Timer();

        private Thread _processThread;
        private Task _processTask;
        private BackgroundWorker _processBackgroundWorker;
        private Task _process4Task;


        private Stopwatch _sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            lbProgress1.Text = "Not Initiated..";
            lbProgress2.Text = "Not Initiated..";
            lbProgress3.Text = "Not Initiated..";
            lbProgress4.Text = "Not Initiated..";


            _startTimer.Interval = 3000;
            _startTimer.Tick += OnStartTimerTick;
            _startTimer.Enabled = true;
        }

        public async void OnStartTimerTick(object sender, EventArgs e)
        {
            lbProgress1.Text = "Initiated..";
            lbProgress2.Text = "Initiated..";
            lbProgress3.Text = "Initiated..";
            lbProgress4.Text = "Initiated..";

            _startTimer.Enabled = false;

            _processThread = new Thread(LongRunningProcess1);
            _processThread.Start();

            _processTask = new Task(LongRunningProcess2);
            _processTask.Start();

            _processBackgroundWorker = new BackgroundWorker();
            _processBackgroundWorker.DoWork += LongRunningProcess3;
            _processBackgroundWorker.RunWorkerCompleted += LongRunningProcess3Finished;
            _processBackgroundWorker.RunWorkerAsync();


            await LongRunningProcess4();

        }

        public void LongRunningProcess1()
        {
            _sw.Start();
            if (InvokeRequired)
            {
                Invoke(new Action(() => lbProgress1.Text = "In process"));
            }
            
            Thread.Sleep(7000);
            _sw.Stop();

            LongRunningProcess1Finished(_sw.ElapsedMilliseconds);
        }

        public void LongRunningProcess2()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lbProgress2.Text = "In process"));
            }

            Thread.Sleep(6000);

            LongRunningProcess2Finished();
        }

        public void LongRunningProcess3(object sender, DoWorkEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lbProgress3.Text = "In process"));
            }

            Thread.Sleep(5000);
        }

        public Task LongRunningProcess4()
        {
            Thread.Sleep(4000);
            return Task.;
        }

        public void LongRunningProcess1Finished(long elapsed)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lbProgress1.Text = $"Finished - after {_sw.ElapsedMilliseconds}ms.."));
            }
        }

        public void LongRunningProcess2Finished()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lbProgress2.Text = $"Finished.."));
            }
        }

        public void LongRunningProcess3Finished(object sender, RunWorkerCompletedEventArgs e)
        {
            lbProgress3.Text = $"Finished..";
        }
    }
}
