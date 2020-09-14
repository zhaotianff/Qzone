using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Qzone.Util
{
    public class JsonUtil
    {
        public static T Parse<T>(string jsonStr)
        {
            T t = default(T);
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch
            {
                return t;
            }
        }
    }
}
