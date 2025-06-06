﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using _4_MVVM_Demo_Application.ViewModels;

namespace _4_MVVM_Demo_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); 
            MainWindow window = new MainWindow();
            // Create the ViewModel to which 
            // the main window binds. 
            string path = "Data/customers.xml";
            var viewModel = new MainWindowViewModel(path);
            // When the ViewModel asks to be closed, 
            // close the window. 
            viewModel.RequestClose += delegate { window.Close(); };
            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree. 
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
