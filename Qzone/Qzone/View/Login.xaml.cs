using Qzone.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Qzone.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : TianXiaTech.BlurWindow
    {
        public Login()
        {
            InitializeComponent();

            LoadBackgroundImageAsync();
        }

        private async void LoadBackgroundImageAsync()
        {
            var bgPath = Environment.CurrentDirectory + "\\Cache\\bg.jpg";

            await WebUtil.DownloadFileAsync(QzoneUrl.DefaultBackgroundUrl, bgPath);
            
            if (System.IO.File.Exists(bgPath) == false)
                return;

            ImageBrush ib = new ImageBrush();
            ib.Stretch = Stretch.UniformToFill;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(bgPath,UriKind.Absolute);
            bi.EndInit();
            ib.ImageSource = bi;
            this.Background = ib;
        }
    }
}
