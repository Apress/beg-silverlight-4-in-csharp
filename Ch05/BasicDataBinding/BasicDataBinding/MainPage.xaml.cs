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
using System.ComponentModel;

namespace BasicDataBinding
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
            Book b = new Book()
            {
                Title = "Beginning Silverlight 4: From Novice to Professional",
                ISBN = "978-1430229889"
            };

            this.LayoutRoot.DataContext = b;
        }
    }

public class Book : INotifyPropertyChanged
{
    private string _title;
    private string _isbn;

    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
            FirePropertyChanged("Title");
        }
    }

    public string ISBN
    {
        get
        {
            return _isbn;
        }
        set
        {
            _isbn = value;
            FirePropertyChanged("ISBN");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void FirePropertyChanged(string property)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }
    }
}
}
