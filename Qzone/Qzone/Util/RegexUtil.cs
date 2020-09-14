using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Qzone.Util
{
    public class RegexUtil
    {
        public const string ExtractJsonPattern = "(?<Json>{[.\\S\\s]+})";

        /// <summary>
        /// 匹配说说总数
        /// </summary>
        /// <remarks>"SS":1678</remarks>
        public const string ExtractSSPattern = "\"SS\":(?<ss>\\d+)";

        public static string Extract(string input,string pattern,string group = "")
        {
            var match = Regex.Match(input, pattern);

            if(match.Success)
            {
                if (string.IsNullOrEmpty(group))
                    return match.Value;
                else
                    return match.Groups[group].Value;
            }

            return "";
        }

        public static int ExtractDigit(string input)
        {
            int num = 123456789;
            var match = Regex.Match(input, "\\d+");

            if (match.Success)
                num = Convert.ToInt32(match.Value);

            return num;
        }

        public static string ExtractJson(string input)
        {
            return Extract(input, ExtractJsonPattern, "Json");
        }
    }
}
