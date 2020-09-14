using System;
using System.Collections.Generic;
using System.Text;

namespace Qzone.Model
{
    public class Items
    {
        /// <summary>
        /// 
        /// </summary>
        public int uin { get; set; }

        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int online { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int yellow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isolate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int supervip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int superstarvip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int starvip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int starlevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int staryear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int src { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int platform_src { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int service_src { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int flag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int hide_from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string img { get; set; }
    }

    public class Modvisitcount
    {
        /// <summary>
        /// 
        /// </summary>
        public int mod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int todaycount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int totalcount { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public int Ishost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Items> items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Modvisitcount> modvisitcount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int twlogincount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lastgettime { get; set; }
    }

    public class Module_3
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int subcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int default_i { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }

    public class Data_2
    {
        /// <summary>
        /// 
        /// </summary>
        public int annual { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bitmap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int charm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int charmpercent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int edge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int endcharm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime expiredate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imgsrc_guin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imgsrc_uin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int leftday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nfoverday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int now { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string overday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pay_20077 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int paytips { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int qbaccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string qbossadv { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int recoverscores { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int reminder_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int speed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startcharm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime superexpire { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string superoverday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tips { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int uin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vip { get; set; }
    }

    public class Module_8
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int subcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int default_i { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }

    public class Data_3
    {
        /// <summary>
        /// 
        /// </summary>
        public int RZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int XC { get; set; }
    }

    public class Module_16
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int subcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int default_i { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }

    public class Data_4
    {
        /// <summary>
        /// 
        /// </summary>
        public Module_3 module_3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Module_8 module_8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Module_16 module_16 { get; set; }
    }

    /// <summary>
    /// 这个暂时用不到这么多信息
    /// </summary>
    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int subcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int default_i { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }

}
