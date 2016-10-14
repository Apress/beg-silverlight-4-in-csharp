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

namespace EventHandlers
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.btnManaged.Click += new RoutedEventHandler(btnManaged_Click);
        }

        void btnManaged_Click(object sender, RoutedEventArgs e)
        {
            txtManagedEventText.Text = "Thank you for clicking";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtXAMLEventText.Text = "Thank you for clicking!";
        }
    }
}
