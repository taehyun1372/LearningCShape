using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;

namespace _61_Syncfusion_Chart
{
    public partial class Form2 : Form
    {
        public Panel _panel1;
        public ChartControl _chartControl1;
        public Form2()
        {
            InitializeComponent();
            _panel1 = new Panel();
            _panel1.Dock = DockStyle.Fill;
            this.Controls.Add(_panel1);

            _chartControl1 = new ChartControl();
            _chartControl1.Dock = DockStyle.Fill;
            _panel1.Controls.Add(_chartControl1);

            ChartSeries _series1 = new ChartSeries("Series 1", ChartSeriesType.Line);

            double multiplier = 0.000000000000000000000001;
            _series1.Points.Add(1, 3 * multiplier);
            _series1.Points.Add(2, 4 * multiplier);
            _series1.Points.Add(3, 5 * multiplier);
            _series1.Points.Add(5, 6 * multiplier);
            _series1.Points.Add(6, 7 * multiplier);

            _series1.Style.Border.Color = Color.Black;
            _series1.Style.Border.Width = 3;

            _chartControl1.Series.Add(_series1);
        }
    }
}
