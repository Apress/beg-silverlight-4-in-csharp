using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace StringFormattingBinding
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            GridData data = new GridData()
            {
                DecimalValue = decimal.Parse("12345.123456789")
            };

            this.LayoutRoot.DataContext = data;
        }
    }

    public class GridData
    {
        public decimal DecimalValue { get; set;}
    }
}
