using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Qzone.Util
{
    public class ChromiumHelper
    {
        private Browser browser;
        private Page page;

        private static object obj = new object();
        private static ChromiumHelper helper;

        public Browser ChromiumBrowser 
        { 
            get 
            {
                return browser;
            }
        }

        public Page CurrentBrowserTab
        {
            get
            {
                return page;
            }
        }

        public ChromiumHelper()
        {
            
        }

        public static ChromiumHelper GetChromium()
        {
            if(helper == null)
            {
                lock(obj)
                {
                    if (helper == null)
                        helper = new ChromiumHelper();
                }
            }

            return helper;
        }

        public async Task InitBrowser()
        {
            if (browser == null)
            {
                await new PuppeteerSharp.BrowserFetcher().DownloadAsync(PuppeteerSharp.BrowserFetcher.DefaultRevision);

                browser = await PuppeteerSharp.Puppeteer.LaunchAsync(new PuppeteerSharp.LaunchOptions
                {
                    Headless = true
                });

                page = await browser.NewPageAsync();
            }
        }

        public async Task LaunchUrl(string url)
        {
            if(page != null)
            {
                await page.GoToAsync(url);
            }
        }

        /// <summary>
        /// 二维码超时，点击刷新
        /// </summary>
        public async void RefreshQR()
        {
            if(page != null)
            {
                await page.ReloadAsync();
            }
        }

        public async Task<Stream> Screenshot()
        {
            if(page != null)
            {
                return await page.ScreenshotStreamAsync();
            }

            return null;
        }      
        
        public void SetTargetChangedHandler(EventHandler<TargetChangedArgs> eventHandler)
        {
            if(browser != null)
            {
                browser.TargetChanged += eventHandler;
            }
        }

        public void RemoveTargetChangedHandler(EventHandler<TargetChangedArgs> eventHandler)
        {
            if (browser != null)
            {
                browser.TargetChanged -= eventHandler;
            }
        }

        public async Task<string> GetHtmlSource()
        {
            if(page != null)
            {
                return await page.GetContentAsync();
            }

            return "";
        }

        public async Task<string> GetHtmlSource(string url)
        {
            await LaunchUrl(url);
            return await GetHtmlSource();
        }

        public async Task<string> GetS_Key()
        {
            if(page != null)
            {
                var cookies = await page.GetCookiesAsync();
                var sKey = cookies.Where(x => x.Name == "skey").FirstOrDefault();

                if (sKey == null)
                    return "";
                else
                    return sKey.Value;
            }

            return "";
        }

        public async void FreeChromiumHelper()
        {
            if (browser != null)
            {
                await browser.CloseAsync();
                browser.Disconnect();
                browser.Dispose();              
            }
        }
    }
}
