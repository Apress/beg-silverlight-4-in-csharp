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

namespace NotifyApplication
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.IsRunningOutOfBrowser)
            {
                NotificationWindow notify = new NotificationWindow();

                NotifyWindow win = new NotifyWindow();
                win.Header.Text = "Custom Message Header";
                win.Description.Text = "This is a custom description.";

                notify.Width = win.Width;
                notify.Height = win.Height;

                notify.Content = win;
                notify.Show(5000);
            }
        }
    }
}
