using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace _50_GridGroupingControl
{
    public partial class Form1 : Form
    {
        private BindingList<Product> _products;
        public Form1()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        public void OnLoad(object sender, EventArgs e)
        {

            _products = new BindingList<Product>
            {
                new Product { Id = 1, Category = "Books", Name = "C# Programming", Price = 29.99 },
                new Product { Id = 2, Category = "Books", Name = "Data Structures", Price = 39.99 },
                new Product { Id = 3, Category = "Electronics", Name = "Keyboard", Price = 49.99 },
                new Product { Id = 4, Category = "Electronics", Name = "Mouse", Price = 19.99 },
                new Product { Id = 5, Category = "Books", Name = "Design Patterns", Price = 45.00 },
                new Product { Id = 6, Category = "Electronics", Name = "Monitor", Price = 149.99 },
                new Product { Id = 7, Category = "Books", Name = "Clean Code", Price = 35.50 },
                new Product { Id = 8, Category = "Stationery", Name = "Notebook", Price = 3.50 },
                new Product { Id = 9, Category = "Stationery", Name = "Pen", Price = 1.20 },
                new Product { Id = 10, Category = "Stationery", Name = "Highlighter", Price = 2.50 },
                new Product { Id = 11, Category = "Electronics", Name = "Webcam", Price = 59.99 },
                new Product { Id = 12, Category = "Books", Name = "Algorithms", Price = 42.00 },
                new Product { Id = 13, Category = "Electronics", Name = "Laptop Stand", Price = 25.00 },
                new Product { Id = 14, Category = "Stationery", Name = "Stapler", Price = 4.50 },
                new Product { Id = 15, Category = "Books", Name = "LINQ in Action", Price = 27.99 },
                new Product { Id = 16, Category = "Books", Name = "Effective C#", Price = 37.99 },
                new Product { Id = 17, Category = "Electronics", Name = "External SSD", Price = 99.99 },
                new Product { Id = 18, Category = "Electronics", Name = "HDMI Cable", Price = 10.99 },
                new Product { Id = 19, Category = "Stationery", Name = "Paper Clips", Price = 1.00 },
                new Product { Id = 20, Category = "Stationery", Name = "Eraser", Price = 0.80 }
            };
            gridGroupingControl1.DataSource = _products;
            //gridGroupingControl1.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.None; //Disable user cell editting 
            //gridGroupingControl1.TableControlCurrentCellStartEditing += OnTableControlCurrentCellStartEditing; //Customised editting action
            //gridGroupingControl1.TableControlCurrentCellEditingComplete += OnTableControlCurrentCellEditingComplete; //Customised editting action
            gridGroupingControl1.ShowGroupDropArea = true; //Showing grouping area
            //gridGroupingControl1.TableOptions.AllowSortColumns = false; //Allowing sorting 
            
            gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            foreach ( var column in gridGroupingControl1.TableDescriptor.Columns)
            {
                column.AllowFilter = true;
            }


            //gridGroupingControl1.TableDescriptor.GroupedColumns.Add("Category");
        }

        private void OnTableControlCurrentCellEditingComplete(object sender, GridTableControlEventArgs e)
        {
            MessageBox.Show("A information message after finishing edit");
        }

        private void OnTableControlCurrentCellStartEditing(object sender, GridTableControlCancelEventArgs e)
        {
            MessageBox.Show("A warning message before starting edit");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_products.Count() > 1)
            {
                _products.RemoveAt(_products.Count() - 1);
            }
        }


    }



    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
