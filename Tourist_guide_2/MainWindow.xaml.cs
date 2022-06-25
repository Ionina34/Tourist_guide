using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tourist_guide_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> path;
        Process pr;
        public MainWindow()
        {
            InitializeComponent();
            path = new List<string>();
            path.Add("D:\\ДАША)))\\C# HomeWork\\Tourist_guide");
            pr = new Process();
            BackToolStrip.IsEnabled = false;
            SerchDick();

            Catalog.MouseDoubleClick += DoubleClick_listBox1;
            BackToolStrip.Click += Back_Click;
            OpenToolStrip.Click += Open_Click;

        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Catalog.SelectedIndex != -1)
                {
                    path.Add(Catalog.SelectedItem.ToString());
                    BackToolStrip.IsEnabled = true;
                    var result = String.Join("\\", path.ToArray());
                    if (File.Exists(result))
                    {
                        pr.StartInfo.FileName = result;
                        pr.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(result);
                        pr.Start();
                    }
                    else
                        SerchFile();
                }
            }
            catch (Exception) { }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (path.Count == 1)
                return;
            if (path.Count == 2)
            {
                path.RemoveAt(path.Count - 1);
                Catalog.Items.Clear();
                SerchDick();
                BackToolStrip.IsEnabled = false;
            }
            else
            {
                path.RemoveAt(path.Count - 1);
                SerchFile();
            }
        }
        private void DoubleClick_listBox1(object sender, RoutedEventArgs e)
        {
            if (Catalog.SelectedIndex != -1)
            {
                path.Add(Catalog.SelectedItem.ToString());
                BackToolStrip.IsEnabled = true;
                var result = String.Join("\\", path.ToArray());
                if (File.Exists(result))
                {
                    pr.StartInfo.FileName = result;
                    pr.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(result);
                    pr.Start();
                }
                else
                    SerchFile();
            }
        }
        public void SerchDick()
        {
            DirectoryInfo dr = new DirectoryInfo("D:\\ДАША)))\\C# HomeWork\\Tourist_guide");
            foreach (var d in dr.GetDirectories())
            {
                Catalog.Items.Add(d.Name);
            }
            foreach (var d in dr.GetFiles())
            {
                Catalog.Items.Add(d.Name);
            }
        }
        public void SerchFile()
        {
            Catalog.Items.Clear();
            var result = String.Join("\\", path.ToArray());
            DirectoryInfo dr = new DirectoryInfo(result);
            foreach (var d in dr.GetDirectories())
            {
                Catalog.Items.Add(d.Name);
            }
            foreach (var d in dr.GetFiles())
            {
                Catalog.Items.Add(d.Name);
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int openWin = 0;
            foreach (var Window in App.Current.Windows)
                openWin += 1;

            if (openWin == 1)
            {
                Window1 window = new Window1();
                window.Show();
            }
            else return;
        }
    }
}
