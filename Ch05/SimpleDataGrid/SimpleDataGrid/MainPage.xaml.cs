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

namespace SimpleDataGrid
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.grid.ItemsSource = GridData.GetData();
        }
    }

    public class GridData
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }

        public static ObservableCollection<GridData> GetData()
        {
            ObservableCollection<GridData> data =
                new ObservableCollection<GridData>();

            data.Add(new GridData()
            {
                Name = "John Doe",
                Age = 30,
                Male = true
            });

            data.Add(new GridData()
            {
                Name = "Jane Doe",
                Age = 32,
                Male = false
            });

            data.Add(new GridData()
            {
                Name = "Jason Smith",
                Age = 54,
                Male = true
            });

            data.Add(new GridData()
            {
                Name = "Kayli Jayne",
                Age = 25,
                Male = false
            });

            return data;
        }
    }
}
