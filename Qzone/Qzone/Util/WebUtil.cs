using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Qzone.Util
{
    public class WebUtil
    {
        public static async Task DownloadFileAsync(string url, string fileName)
        {
            WebClient client = new WebClient();

            if (System.IO.File.Exists(fileName))
                return;

            await client.DownloadFileTaskAsync(new Uri(url), fileName);
        }
    }
}
