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

namespace ModalWindow
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Confirm confirmDlg = new Confirm();
            confirmDlg.Closed += new EventHandler(confirmDlg_Closed);
            confirmDlg.Show();
        }

        void confirmDlg_Closed(object sender, EventArgs e)
        {
            Confirm confirmDlg = (Confirm)sender;

            if (confirmDlg.DialogResult == true)
            {
                this.Result.Text = "Terms and Conditions Accepted";
            }
            else if (confirmDlg.DialogResult == false)
            {
                this.Result.Text = "Terms and Conditions Not Accepted";
            }
        }
    }
}
