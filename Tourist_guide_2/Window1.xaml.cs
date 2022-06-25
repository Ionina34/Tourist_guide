using System;
using System.IO;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Tourist_guide_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string[] filePath;
        string text;
        public Window1()
        {
            InitializeComponent();
            Picture.GotFocus += Box_GotFocus;
            Picture.LostFocus += Box_LostFocus;
            Video.GotFocus += Box_GotFocus;
            Video.LostFocus += Box_LostFocus;
        }
        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Clear();
        }
        private void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.BorderBrush = Brushes.Black;
            if (box.Text == "")
            {
                box.Text = "Введите кол-во картинок";
                return;
            }

            if (!(int.TryParse(box.Text, out int value)) || value < 0)
            {
                box.Text = "Должны быть только цифры";
                box.BorderBrush = Brushes.Red;
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Point.Text != "" && Picture.Text != "" && Description.Text != "" && Currency.Text != ""
                && Price.Text != "")
            {
                for (int i = 0; i < filePath.Length; i++)
                {
                    //Bitmap btm = new Bitmap();
                }
            }
            else
            {
                Point.BorderBrush = Brushes.Red;
                Picture.BorderBrush = Brushes.Red;
                Description.BorderBrush = Brushes.Red;
                Currency.BorderBrush = Brushes.Red;
                Price.BorderBrush = Brushes.Red;
            }
        }

        private void btnPicture_Click(object sender, RoutedEventArgs e)
        {
            string str = Picture.Text;
            int num = int.Parse(str);
            filePath = new string[num];

            for (int i = 0; i < num; i++)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";

                if (open.ShowDialog() == true)
                    filePath[i] = open.FileName;
            }
            Picture.Text = "Картинки загружены";
        }

        private void Picture_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text == "")
                text = "";
            if (int.TryParse(box.Text, out int value) && value > 0)
                text = box.Text;
            else
            {
                box.Text = text;
                box.CaretIndex = box.Text.Length;
            }
        }
    }
}