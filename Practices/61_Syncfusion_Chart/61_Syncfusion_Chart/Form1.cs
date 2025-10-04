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
    public partial class Form1 : Form
    {
        private ChartControl chartConsol1;

        public Form1()
        {
            InitializeComponent();
            chartConsol1 = new ChartControl();
            chartConsol1.Dock = DockStyle.Fill;
            chartConsol1.ChartFormatAxisLabel += ChartControl1_FormatAxisLabel;

            panel1.Controls.Add(chartConsol1);

            float result1 = GetFloatNumber(0x02BC, 0x0000);
            float result2 = GetFloatNumber(0x1B58, 0x0000);

            List<MyDataPoint> points1 = new List<MyDataPoint>();
            points1.Add(new MyDataPoint() { Time = 1, Value = result1 });
            points1.Add(new MyDataPoint() { Time = 2, Value = result2 });
            points1.Add(new MyDataPoint() { Time = 3, Value = result1 });
            points1.Add(new MyDataPoint() { Time = 4, Value = result2 });

            ChartDataBindModel bindModel1 = new ChartDataBindModel(points1);
            bindModel1.XName = "Time";
            bindModel1.YNames = new string[] { "Value" };

            ChartSeries series1 = new ChartSeries("Series 1", ChartSeriesType.StepLine);
            series1.Style.Border.Color = Color.Red;
            series1.Style.DisplayText = true;
            series1.SeriesModel = bindModel1;

            List<MyDataPoint> points2 = new List<MyDataPoint>();
            points2.Add(new MyDataPoint() { Time = 1, Value = result1 });
            points2.Add(new MyDataPoint() { Time = 2, Value = result2 });
            points2.Add(new MyDataPoint() { Time = 3, Value = result1 });
            points2.Add(new MyDataPoint() { Time = 4, Value = result2 });

            ChartDataBindModel bindModel2 = new ChartDataBindModel(points2);
            bindModel2.XName = "Time";
            bindModel2.YNames = new string[] { "Value" };

            ChartSeries series2 = new ChartSeries("Series 2", ChartSeriesType.StepLine);
            series2.Style.Border.Color = Color.Black;
            series2.Style.DisplayText = true;
            series2.SeriesModel = bindModel2;

            chartConsol1.Series.Add(series1);
            chartConsol1.Series.Add(series2);

            chartConsol1.PrimaryXAxis.Title = "Time(s)";
            chartConsol1.PrimaryXAxis.RangeType = ChartAxisRangeType.Auto;

            //Create axis
            ChartAxis axis1 = new ChartAxis(ChartOrientation.Vertical)
            { 
                Title = $"Series 1",
                RangeType = ChartAxisRangeType.Auto,
                ForeColor = Color.Red 
            }; 

            series1.YAxis = axis1;

            ChartAxis axis2 = new ChartAxis(ChartOrientation.Vertical)
            {
                Title = $"Series 2",
                RangeType = ChartAxisRangeType.Auto,
                ForeColor = Color.Black
            };

            series1.YAxis = axis1;
            series2.YAxis = axis2;

            chartConsol1.Axes[1] = axis1;
            chartConsol1.Axes.Add(axis2);

            axis1.Update();

            axis2.Update();

            chartConsol1.PrimaryXAxis.Update();


            chartConsol1.Text = "Basic Syncfusion Chart Example";
        }

        private void ChartControl1_FormatAxisLabel(object sender, ChartFormatAxisLabelEventArgs e)
        {
            if (e.Axis == chartConsol1.PrimaryYAxis)
            {
                e.Label = e.Value.ToString() + " Primary";
                e.Handled = true;
            }
            //else if (e.Axis.Title == "Series 1")
            //{
            //    e.Label = e.Value.ToString() + " Series 1";
            //    e.Handled = true;
            //}
            //else if (e.Axis.Title == "Series 2")
            //{
            //    e.Label = e.Value.ToString() + " Series 2";
            //    e.Handled = true;
            //}
        }

        private float GetFloatNumber(ushort high, ushort low)
        {
            uint combined = ((uint)high << 16) | low;
            byte[] bytes = BitConverter.GetBytes(combined);
            if(BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            float result = BitConverter.ToSingle(bytes, 0);
            
            return result;
        }
    }

    public class MyDataPoint
    {
        public double Time { get; set; }
        public double Value { get; set; }

    }
}
