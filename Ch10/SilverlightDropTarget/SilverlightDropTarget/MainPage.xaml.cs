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
using System.IO;

namespace SilverlightDropTarget
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            LayoutRoot.Drop += new DragEventHandler(LayoutRoot_Drop);
        }

        void LayoutRoot_Drop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                IDataObject obj = e.Data;
                FileInfo[] files = obj.GetData(DataFormats.FileDrop) as FileInfo[];

                foreach (FileInfo file in files)
                {
                    if (file.Extension.Equals(".txt"))
                    {
                        string fileContents;
                        using (Stream stream = file.OpenRead())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                FileContents.Text = reader.ReadToEnd();
                            }
                        }
                    }

                }
            }
        }
    }
}
