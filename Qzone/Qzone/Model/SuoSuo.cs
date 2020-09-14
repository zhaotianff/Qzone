using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Qzone.Model
{
    public class Logininfo
    {
        public string name { get; set; }
        public string uin { get; set; }
    }

    public class Conlist
    {
        public string con { get; set; }
        public string type { get; set; }
    }

    public class Lbs
    {
        public string id { get; set; }
        public string idname { get; set; }
        public string name { get; set; }

        public string pos_x { get; set; }
        public string pos_y { get; set; }
    }

    public class Pic
    {
        public string absolute_position { get; set; }
        public string b_height { get; set; }
        public string b_width { get; set; }
        public string curlikekey { get; set; }
        public string height { get; set; }
        public string pic_id { get; set; }
        public string pictype { get; set; }
        public string richsubtype { get; set; }
        public string smallurl { get; set; }
        public string unilikekey { get; set; }
        public string url1 { get; set; }
        public string url2 { get; set; }
        public string url3 { get; set; }
        public string who { get; set; }
        public string width { get; set; }
    }

    public class Msglist
    {
        public string certified { get; set; }
        public string cmtnum { get; set; }
        public List<Conlist> conlist { get; set; }
        public string content { get; set; }
        public DateTime createTime { get; set; }
        public string created_time { get; set; }
        public string editMask { get; set; }
        public string fwdnum { get; set; }
        public string has_more_con { get; set; }
        public string isEditable { get; set; }
        public string issigin { get; set; }
        public Lbs lbs { get; set; }
        public string name { get; set; }
        public List<Pic> pic { get; set; }
        public string pic_template { get; set; }
        public string pictotal { get; set; }
        public string right { get; set; }
        public string rt_sum { get; set; }
        public string secret { get; set; }
        public string source_appid { get; set; }
        public string source_name { get; set; }
        public string source_url { get; set; }
        public string t1_source { get; set; }
        public string t1_subtype { get; set; }
        public string t1_termtype { get; set; }
        public string tid { get; set; }
        public string ugc_right { get; set; }
        public string uin { get; set; }
        public string wbid { get; set; }
    }

    public class Smoothpolicy
    {
        [JsonProperty(PropertyName = "comsw.disable_soso_search")]
        public string comsw_disable_soso_search { get; set; }

        [JsonProperty(PropertyName = "l1sw.read_first_cache_only")]
        public string l1sw_read_first_cache_only { get; set; }

        [JsonProperty(PropertyName = "l2sw.dont_get_reply_cmt")]
        public string l2sw_dont_get_reply_cmt { get; set; }

        [JsonProperty(PropertyName = "l2sw.mixsvr_frdnum_per_time")]
        public string l2sw_mixsvr_frdnum_per_time { get; set; }

        [JsonProperty(PropertyName = "l3sw.hide_reply_cmt")]
        public string l3sw_hide_reply_cmt { get; set; }

        [JsonProperty(PropertyName = "l4sw.read_tdb_only")]
        public string l4sw_read_tdb_only { get; set; }

        [JsonProperty(PropertyName = "l5sw.read_cache_only")]
        public string l5sw_read_cache_only { get; set; }
    }

    public class Usrinfo
    {
        public string concern { get; set; }
        public string createTime { get; set; }
        public string fans { get; set; }
        public string followed { get; set; }
        public string msg { get; set; }
        public string msgnum { get; set; }
        public string name { get; set; }
        public string uin { get; set; }
    }

    public class SuoSuo
    {
        public string auth_flag { get; set; }
        public string censor_count { get; set; }
        public string censor_flag { get; set; }
        public string censor_total { get; set; }
        public string cginame { get; set; }

        public string code { get; set; }

        public Logininfo logininfo { get; set; }

        public string mentioncount { get; set; }

        public string message { get; set; }

        public List<Msglist> msglist { get; set; }

        public string name { get; set; }

        public string num { get; set; }

        public string sign { get; set; }

        public Smoothpolicy smoothpolicy { get; set; }

        public string subcode { get; set; }

        public string timertotal { get; set; }

        public string total { get; set; }

        public Usrinfo usrinfo { get; set; }
    }

}
