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

        public static string CalcG_tk(string sKey)
        {
            var hash = 5381;
            for (int i = 0, len = sKey.Length; i < len; ++i)
            {
                hash += (hash << 5) + (int)sKey[i];
            }
            return (hash & 0x7fffffff).ToString();
        }
    }
}
