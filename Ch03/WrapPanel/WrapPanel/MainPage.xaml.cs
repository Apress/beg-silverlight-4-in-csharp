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

namespace WrapPanel
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            Rectangle newRect = new Rectangle();
            newRect.Width = 50;
            newRect.Height = 50;
            newRect.Margin = new Thickness(5);
            newRect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

            wrapPanel1.Children.Add(newRect);

        }
    }
}
