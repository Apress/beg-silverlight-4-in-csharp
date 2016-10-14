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
using System.Windows.Navigation;

namespace NavAppFromScratch
{
    public partial class View1 : Page
    {
        public View1()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string color = Color.SelectionBoxItem.ToString();

            NavigationService.Navigate(
                new Uri(string.Format("/InnerView1.xaml?Color={0}", color),
                    UriKind.Relative));
        }

    }
}
