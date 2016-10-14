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
using System.Windows.Printing;

namespace SimplePrinting
{
    public partial class MainPage : UserControl
    {
        List<Contact> Contacts;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Contacts = new List<Contact>();

            Contacts.Add(new Contact() {
                Name = "John Doe",
                Address = "123 Driveway Road",
                CityStateZip = "SomeCity, OH 12345",
                Phone = "(123) 456-7890"
            });

            Contacts.Add(new Contact()
            {
                Name = "Jane Doe",
                Address = "456 Windy Road",
                CityStateZip = "Cityville, FL 34566",
                Phone = "(111) 222-3333"
            });

            ContactGrid.ItemsSource = Contacts;
        }

        private void PrintAsIs(object sender, RoutedEventArgs e)
        {
            PrintDocument doc = new PrintDocument();

            doc.PrintPage += (s, args) =>
                {
                    args.PageVisual = LayoutRoot;
                };

            doc.Print("As Is");
        }

        private void PrintFormatted(object sender, RoutedEventArgs e)
        {
            PrintDocument doc = new PrintDocument();

            doc.BeginPrint += (s, args) =>
            {
                PrintStatus.Text = "Printing...";
            };

            doc.EndPrint += (s, args) =>
            {
                PrintStatus.Text += "Printing Finished!";
            };

            doc.PrintPage += (s, args) =>
                {
                    StackPanel customPrintPanel = new StackPanel();

                    foreach (Contact c in Contacts)
                    {
                        StackPanel contactPanel = new StackPanel();
                        contactPanel.Margin = new Thickness(25);

                        TextBlock name = new TextBlock();
                        name.Text = c.Name;
                        contactPanel.Children.Add(name);

                        TextBlock address = new TextBlock();
                        address.Text = c.Address;
                        contactPanel.Children.Add(address);

                        TextBlock city = new TextBlock();
                        city.Text = c.CityStateZip;
                        contactPanel.Children.Add(city);

                        TextBlock phone = new TextBlock();
                        phone.Text = c.Phone;
                        contactPanel.Children.Add(phone);

                        customPrintPanel.Children.Add(contactPanel);
                    }

                    args.PageVisual = customPrintPanel;
                };

            doc.Print("Formatted Print");
        }
    }

    public class Contact
    {
         public string Name { get; set; }
         public string Address{ get; set; }
         public string CityStateZip{ get; set; }
         public string Phone{ get; set; }
    }
}
