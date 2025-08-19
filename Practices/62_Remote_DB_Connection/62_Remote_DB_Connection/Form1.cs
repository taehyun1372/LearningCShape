using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Syncfusion.Windows.Forms.Chart;
using System.Data.SqlClient;

namespace _62_Remote_DB_Connection
{
    public partial class Form1 : Form
    {
        private ChartControl _chartControl1;
        private Panel _panel1;
        private string _connectionString = "";


        public Form1()
        {
            InitializeComponent();

            _panel1 = new Panel();
            _panel1.Dock = DockStyle.Fill;
            this.Controls.Add(_panel1);

            _chartControl1 = new ChartControl();
            _chartControl1.Dock = DockStyle.Fill;
            _panel1.Controls.Add(_chartControl1);

            _connectionString = ConfigurationManager.AppSettings["connectionString"];
            MessageBox.Show(_connectionString);

        }

        


    }
}
