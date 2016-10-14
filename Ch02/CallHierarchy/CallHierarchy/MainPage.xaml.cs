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

namespace CallHierarchy
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            List<Course> courses = new List<Course>();
            Course c = new Course();
            c.Quarter = Quarters.Fall;
            c.Title = "Computer Science 101";

            

        }
    }
}
