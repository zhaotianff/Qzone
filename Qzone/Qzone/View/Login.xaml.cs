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
        private bool isLoginSuccess = false;
        private System.Windows.Threading.DispatcherTimer timer;

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
            await chromium.LaunchUrl(QzoneUrl.LoginUrl);            
            chromium.SetTargetChangedHandler(NavigateToQzone);
            ScreenShotLoginPage();
            StartTimerRefreshLoginQR();
        }

        private async void ScreenShotLoginPage()
        {
            var chromium = ChromiumHelper.GetChromium();
            using (System.IO.Stream stream = await chromium.Screenshot())
            {
                System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(stream);
                var hBitmap = bitmap.GetHbitmap();

                try
                {
                    var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                    loginImg.Source = source;
                }
                finally
                {
                    WinAPI.DeleteObject(hBitmap);
                }

            }
        }

        /// <summary>
        /// 登录二维码会一直刷新，浏览器也取不到状态 
        /// </summary>
        private void StartTimerRefreshLoginQR()
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (a, b) => { ScreenShotLoginPage(); };
            timer.IsEnabled = true;
        }

        private void NavigateToQzone(object sender, PuppeteerSharp.TargetChangedArgs args)
        {
            //navigate to qzone success
            if(args.Target.Url.StartsWith(QzoneUrl.QzoneDefautUrl))
            {
                isLoginSuccess = true;
                Dispatcher.Invoke(()=> {
                    ChromiumHelper.GetChromium().RemoveTargetChangedHandler(NavigateToQzone);
                    var qq = RegexUtil.Extract(args.Target.Url, "\\d+");
                    MainWindow mainWindow = new MainWindow(qq);
                    Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();
                    this.Close();
                }); 
            }
        }

        private void BlurWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isLoginSuccess == false)
            {
                ChromiumHelper.GetChromium().FreeChromiumHelper();
            }

            if(timer != null)
            {
                timer.IsEnabled = false;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChromiumHelper.GetChromium().RefreshQR();
        }
    }
}
