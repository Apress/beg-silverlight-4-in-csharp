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
    public partial class InnerView1 : Page
    {
        public InnerView1()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string color = NavigationContext.QueryString["Color"].ToString();
            Brush b;

            switch (color)
            {
                case "Red":
                    b = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    ViewHeader.Foreground = b;
                    ViewColor.Foreground = b;
                    ViewColor.Text = "(Red)";
                    break;

                case "Green":
                    b = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    ViewHeader.Foreground = b;
                    ViewColor.Foreground = b;
                    ViewColor.Text = "(Green)";
                    break;

                default:
                    b = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                    ViewHeader.Foreground = b;
                    ViewColor.Foreground = b;
                    ViewColor.Text = "(Blue)";
                    break;
            }
        }

    }
}
