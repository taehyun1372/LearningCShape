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

namespace _49_Background_Worker
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();

            this.Load += Initialise;

        }
        //public void Initialise(object sender, EventArgs e)
        //{
        //    Thread th = new Thread(() => {
        //        LongRunningTask();
        //    });
        //    th.Start();
        //}

        public void Initialise(object sender, EventArgs e)
        {
            worker = new BackgroundWorker();

            worker.DoWork += Work_DoWork;
            worker.RunWorkerCompleted += Work_RunWorkerCompleted;

            label1.Text = "Ready";
            worker.RunWorkerAsync();
        }

        private void Work_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(10000); //Long running process
        }

        private void Work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "Finsihed"; //UI element access from main UI Thread
        }

        public void LongRunningTask()
        {
            this.BeginInvoke((Action)(() => label1.Text = "Ready"));
            Thread.Sleep(10000);
            this.BeginInvoke((Action)(() => label1.Text = "Finished"));
        }
    }
}
