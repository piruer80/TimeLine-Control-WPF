using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VideoStateAxis;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
        }

        ObservableCollection<BitmapImage> Images = new ObservableCollection<BitmapImage>();
    

        private void Window_Initialized(object sender, EventArgs e)
        {
            PART_TimeLine.HisVideoSources = PART_TimeLine.VideoSource;

            ShowImagePage(0);
        }

        int imgPage = 0;
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            imgPage++;
            ShowImagePage(imgPage);
        }

        public void ShowImagePage(int page)
        {
            Images.Clear();

            var files = Directory.GetFiles(@"C:\Lenovo\SORT", "*.jpg");
            int start = page;
            int end = ((page) + 20);


            int position = 0;
            if (((page * 10) - files.Length) > 0) return;

            for (int i = start; i < end; i++)
            {
                if (i == files.Length) break;
                Images.Add(new BitmapImage(new Uri(files[i])));
                position++;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            imgPage--;
            ShowImagePage(imgPage);
        }
    }
}
