using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace Qzone.Util
{
    public class ConvertUtil
    {
        public static int SafeConvertToInt(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int n;
            if (int.TryParse(str, out n))
                return n;

            return 0;
        }

        public static long SafeConvertToLong(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            long n;
            if (long.TryParse(str, out n))
                return n;

            return 0;
        }

        /// <summary>
        /// 从js tick转换为本地时间 
        /// </summary>
        /// <param name="tick"></param>
        /// <returns></returns>
        /// <remarks>https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Global_Objects/Date The ECMAScript epoch and timestamps</remarks>
        public static DateTime ConvertFromJsTick(long tick)
        {
            var start = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            var strTick = tick.ToString().PadRight(17, '0');
            tick = long.Parse(strTick);
            return start.AddTicks(tick);          
        }
    }
}
