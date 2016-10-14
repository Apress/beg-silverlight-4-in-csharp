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

namespace TextBoxControl
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.btnTry.Click += new RoutedEventHandler(btnTry_Click);
        }

        void btnTry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ellipse.Fill = new SolidColorBrush(
                Color.FromArgb(
                    255,
                    byte.Parse(this.txtRed.Text),
                    byte.Parse(this.txtGreen.Text),
                    byte.Parse(this.txtBlue.Text)
                ));

                this.lblColor.Text = "";
            }
            catch
            {
                this.lblColor.Text = "Error with R,G,B Values";
            }
        }
    }
}
