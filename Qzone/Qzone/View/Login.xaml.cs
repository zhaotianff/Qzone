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

            LoadLoginPage();
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

        private async void LoadLoginPage()
        {
            var chromium = ChromiumHelper.GetChromium();
            await chromium.InitBrowser();
            chromium.SetTargetChangedHandler(NavigateToQzone);
            await chromium.LaunchUrl(QzoneUrl.LoginUrl);            
            using(System.IO.Stream stream = await chromium.Screenshot())
            {
                System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(stream);
                var hBitmap = bitmap.GetHbitmap();

                try
                {
                    var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                    ImageBrush ib = new ImageBrush();
                    ib.ImageSource = source;
                    ib.Stretch = Stretch.UniformToFill;
                    this.Background = ib;
                }
                finally
                {
                    WinAPI.DeleteObject(hBitmap);
                }
                
            }
        }

        private void NavigateToQzone(object sender, PuppeteerSharp.TargetChangedArgs args)
        {
            
        }
    }
}
