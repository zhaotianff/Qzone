using Qzone.Model;
using Qzone.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Qzone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : TianXiaTech.BlurWindow
    {
        private const int WindowWidth = 400;

        private string currentQQNum;
        private string g_tk;
        private int count;

        public MainWindow(string qqNum)
        {
            InitializeComponent();
            currentQQNum = qqNum;
        }

        private void BlurWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ChromiumHelper.GetChromium().FreeChromiumHelper();
        }

        private async void BlurWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);
            count = await GetSSCount();
            RandomFetchSuoSuo();
        }

        private async void RandomFetchSuoSuo()
        {
            var pos = new Random().Next(0, count).ToString();
            var getSSUrl = QzoneUrl.GetQzoneSuoSuoUrl.Replace("@qq", currentQQNum).Replace("@pos", pos).Replace("@num", "1").Replace("@g_tk", g_tk);
            var ssStr = await ChromiumHelper.GetChromium().GetHtmlSource(getSSUrl);
            ssStr = RegexUtil.ExtractJson(ssStr);
            var ss = JsonUtil.Parse<SuoSuo>(ssStr);
            DisplaySuoSuo(ss);
        }

        private void DisplaySuoSuo(SuoSuo ss)
        {
            if (ss == null || ss.msglist.Count == 0)
                return;

            var msg = ss.msglist.First();

            this.lbl_Date.Content = msg.createTime.ToString("yyyy年MM月dd日");
            this.lbl_Time.Content = ConvertUtil.ConvertFromJsTick(ConvertUtil.SafeConvertToLong(msg.created_time)).ToString("HH:mm:ss");
            this.tbox_Content.Text = msg.content;

            area_SuoSuoImage.Children.Clear();
            area_Comment.Children.Clear();
            area_Like.Children.Clear();

            if (msg.pic != null && msg.pic.Count > 0)
            {
                var columns = msg.pic.Count % 3;

                foreach (var item in msg.pic)
                {
                    Image image = new Image() { Width = (WindowWidth - 20) /columns, Height = Width, Margin = new Thickness(5), Stretch = Stretch.UniformToFill };
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(item.url3);
                    bi.EndInit();
                    image.Source = bi;

                    //设置缩略图Tooltip
                    System.Windows.Data.Binding binding = new System.Windows.Data.Binding();
                    //binding.ElementName = "image";
                    binding.Source = image;
                    binding.Path = new PropertyPath("Source");
                    Image toolTipImage = new Image();
                    System.Windows.Controls.ToolTip toolTip = new System.Windows.Controls.ToolTip();
                    toolTipImage.SetBinding(Image.SourceProperty, binding);
                    toolTip.Content = toolTipImage;

                    image.ToolTip = toolTip;

                    area_SuoSuoImage.Children.Add(image);
                }
            }
        }

        /// <summary>
        /// 获取说说总条数
        /// </summary>
        /// <returns></returns>
        private async Task<int> GetSSCount()
        {         
            var chromium = ChromiumHelper.GetChromium();
            var skey = await chromium.GetS_Key();
            g_tk = WebUtil.CalcG_tk(skey);
            var url = QzoneUrl.GetPersonalMain.Replace("@qq", currentQQNum).Replace("@g_tk",g_tk);
            await chromium.LaunchUrl(url);
            var source = await chromium.GetHtmlSource();
            
            if (string.IsNullOrEmpty(source))
                return 0;

            var ssCount =  RegexUtil.Extract(source, RegexUtil.ExtractSSPattern, "ss");

            return ConvertUtil.SafeConvertToInt(ssCount);
        }

        private void BlurWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F5)
            {
                RandomFetchSuoSuo();
            }
        }
    }
}
