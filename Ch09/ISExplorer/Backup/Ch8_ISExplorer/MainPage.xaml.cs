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
using System.IO.IsolatedStorage;


namespace Ch8_ISExplorer
{
    public partial class MainPage : UserControl
    {
        private string currentDir = "";

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFilesAndDirs();
            GetStorageData();
        }

        private void LoadFilesAndDirs()
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Create three directories in the root.
                store.CreateDirectory("Dir1");
                store.CreateDirectory("Dir2");
                store.CreateDirectory("Dir3");

                // Create three subdirectories under Dir1.
                string subdir1 = System.IO.Path.Combine("Dir1", "SubDir1");
                string subdir2 = System.IO.Path.Combine("Dir2", "SubDir2");
                string subdir3 = System.IO.Path.Combine("Dir3", "SubDir3");
                store.CreateDirectory(subdir1);
                store.CreateDirectory(subdir2);
                store.CreateDirectory(subdir3);

                // Create a file in the root.
                IsolatedStorageFileStream rootFile =
                    store.CreateFile("InTheRoot.txt");
                rootFile.Close();

                // Create a file in a subdirectory.
                IsolatedStorageFileStream subDirFile =
                    store.CreateFile(
                        System.IO.Path.Combine(subdir1, "SubDir1.txt"));
                subDirFile.Close();


            }

        }

        private void GetStorageData()
        {
            this.lstDirectoryListing.Items.Clear();
            this.lstFileListing.Items.Clear();

            using (var store =
                IsolatedStorageFile.GetUserStoreForApplication())
            {
                string searchString =
            System.IO.Path.Combine(currentDir, "*.*");

                string[] directories =
                    store.GetDirectoryNames(searchString);

                foreach (string sDir in directories)
                {
                    this.lstDirectoryListing.Items.Add(sDir);
                }

                string[] files = store.GetFileNames(searchString);

                foreach (string sFile in files)
                {
                    this.lstFileListing.Items.Add(sFile);
                }

                long space = store.AvailableFreeSpace;
                txtAvalSpace.Text = (space / 1000).ToString();

                long quota = store.Quota;
                txtQuota.Text = (quota / 1000).ToString();

                this.lblCurrentDirectory.Text =
                    String.Concat("\\", currentDir);

            }

        }


        private void btnUpDir_Click(object sender, RoutedEventArgs e)
        {
            if (currentDir != "")
            {
                currentDir =
                    System.IO.Path.GetDirectoryName(currentDir);
            }

            GetStorageData();

        }

        private void btnOpenDir_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstDirectoryListing.SelectedItem != null)
            {
                currentDir =
                    System.IO.Path.Combine(
                        currentDir,
                        this.lstDirectoryListing.SelectedItem.ToString());
            }
            GetStorageData();

        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstFileListing.SelectedItem != null)
            {
                this.txtFileName.Text =
                    this.lstFileListing.SelectedItem.ToString();

                using (var store =
                    IsolatedStorageFile.GetUserStoreForApplication())
                {
                    string filePath =
                        System.IO.Path.Combine(
                            currentDir,
                            this.lstFileListing.SelectedItem.ToString());

                    IsolatedStorageFileStream stream =
                        store.OpenFile(filePath, FileMode.Open);
                    StreamReader sr = new StreamReader(stream);

                    this.txtContents.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string fileContents = this.txtContents.Text;

            using (var store =
                IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFileStream stream =
                    store.OpenFile(
                        System.IO.Path.Combine(
                            currentDir,
                            this.txtFileName.Text),
                        FileMode.OpenOrCreate);

                StreamWriter sw = new StreamWriter(stream);
                sw.Write(fileContents);
                sw.Close();
                stream.Close();
            }

            GetStorageData();

        }

        private void btnIncreaseQuota_Click(object sender, RoutedEventArgs e)
        {
            using (var store =
        IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.IncreaseQuotaTo(4000000))
                {
                    GetStorageData();
                }
                else
                {
                    // The user rejected the request to increase the quota size
                }
            }

        }

    }
}
