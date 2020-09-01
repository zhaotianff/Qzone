using System;
using System.Collections.Generic;
using System.IO;
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
                    Headless = false
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

        ~ChromiumHelper()
        {
            if (browser != null)
            {
                browser.Disconnect();
                browser.Dispose();
            }
        }
    }
}
