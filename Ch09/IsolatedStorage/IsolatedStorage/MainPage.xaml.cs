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
using System.IO.IsolatedStorage;

namespace IsolatedStorage
{
    public partial class MainPage : UserControl
    {
        private IsolatedStorageSettings isSettings =
            IsolatedStorageSettings.ApplicationSettings;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
            this.cmdSave.Click += new RoutedEventHandler(cmdSave_Click);
        }

        void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            isSettings["name"] = this.txtName.Text;
            SetWelcomeMessage();
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SetWelcomeMessage();
        }

        private void SetWelcomeMessage()
        {
            if (isSettings.Contains("name"))
            {
                string name = (string)isSettings["name"];
                this.txtWelcome.Text = "Welcome " + name;
            }
            else
            {
                txtWelcome.Text =
                    "Welcome! Enter Your Name and Press Save.";
            }
        }
    }
}
