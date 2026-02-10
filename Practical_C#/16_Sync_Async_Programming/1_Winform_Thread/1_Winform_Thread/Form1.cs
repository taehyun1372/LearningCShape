using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;

namespace _1_Winform_Thread
{
    public partial class Form1 : Form
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            progressBar1.Value = 1;
            //_worker.DoWork += DoWork;
            //_worker.RunWorkerCompleted += WorkCompleted;
            //_worker.ProgressChanged += ProgressReport;
            //_worker.WorkerReportsProgress = true;


        }

        private void ProgressReport(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "Finished";
            progressBar1.Value = 100;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBox.Show("Something happened");
            this.label1.Invoke((Action)delegate ()
            {
                label1.Text = "Progress";
            });

            var collection = Enumerable.Range(1, 200).ToArray();
            foreach (var n in collection)
            {
                var per = n * 100 / collection.Length;
                Thread.Sleep(10);
                _worker.ReportProgress(per);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Thread th = new Thread(LongTimeProcess);
            //th.Start();
            //_worker.RunWorkerAsync();
            //Task.Run(() => LongTimeProcess());
            //var currentContext = TaskScheduler.FromCurrentSynchronizationContext();
            //Task.Run(() => BusinessLogic()).ContinueWith(task =>
            //{
            //    label1.Text = "Finished";
            //}, currentContext);
            label1.Text = "Waiting";
            await Task.Run(() => BusinessLogic());
            label1.Text = "Finished";
        }

        public void LongTimeProcess()
        {
            MessageBox.Show("Something happened");
            this.label1.Invoke((Action)delegate ()
            {
                label1.Text = "Progress";
            });
            Thread.Sleep(5000);
            this.label1.Invoke((Action)delegate ()
            {
                label1.Text = "Finished";
            });
        }

        public void BusinessLogic()
        {
            Thread.Sleep(5000);
        }
    }
}
