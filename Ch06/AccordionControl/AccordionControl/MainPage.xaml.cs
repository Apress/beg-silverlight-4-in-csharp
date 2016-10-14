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

namespace AccordionControl
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
            List<BookCategory> Library = new List<BookCategory>();

            BookCategory cat1 = new BookCategory() { 
                CategoryName = "Silverlight", 
                Books = new List<Book>() };
            cat1.Books.Add(new Book() { Title = "Beginning Silverlight 4" });
            cat1.Books.Add(new Book() { Title = "Pro Silverlight 4" });
            Library.Add(cat1);

            BookCategory cat2 = new BookCategory() { 
                CategoryName = "ASP.NET", 
                Books = new List<Book>() };
            cat2.Books.Add(new Book() { Title = "Pro ASP.NET 4" }) ;
            Library.Add(cat2);

            this.BookList.ItemsSource = Library;
        }
    }

    public class BookCategory
    {
        public string CategoryName { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
    }
}
