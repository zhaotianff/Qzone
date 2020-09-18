using System;
using System.Collections.Generic;
using System.Text;

namespace Qzone.Util
{
    public class QzoneUrl
    {
        public const string DefaultBackgroundUrl = "http://qzonestyle.gtimg.cn/qzone/qzactStatics/imgs/20171122191532_f2975b.jpg";

        /// <summary>
        /// 访问该链接会弹出快捷登录
        /// </summary>
        public const string LoginUrl = "https://xui.ptlogin2.qq.com/cgi-bin/xlogin?proxy_url=https%3A//qzs.qq.com/qzone/v6/portal/proxy.html&daid=5&&hide_title_bar=1&low_login=0&qlogin_auto_login=1&no_verifyimg=1&link_target=blank&appid=549000912&style=22&target=self&s_url=https%3A%2F%2Fqzs.qzone.qq.com%2Fqzone%2Fv5%2Floginsucc.html%3Fpara%3Dizone&pt_qr_app=手机QQ空间&pt_qr_link=http%3A//z.qzone.com/download.html&self_regurl=https%3A//qzs.qq.com/qzone/v6/reg/index.html&pt_qr_help_link=http%3A//z.qzone.com/download.html&pt_no_auth=1";

        public const string QzoneDefautUrl = "https://user.qzone.qq.com";

        /// <summary>
        /// 获取空间说说
        /// </summary>
        /// <remarks>@qq=qq号 @pos=第几条说说 @num=从pos开始显示多少条说说 g_tk=g_tk </remarks>
        public const string GetQzoneSuoSuoUrl = "https://user.qzone.qq.com/proxy/domain/taotao.qq.com/cgi-bin/emotion_cgi_msglist_v6?uin=@qq&inCharset=utf-8&outCharset=utf-8&hostUin=@qq&notice=0&sort=0&pos=@pos&num=@num&cgi_host=https%3A%2F%2Fuser.qzone.qq.com%2Fproxy%2Fdomain%2Ftaotao.qq.com%2Fcgi-bin%2Femotion_cgi_msglist_v6&code_version=1&format=json&need_private_comment=1&g_tk=@g_tk&g_tk=@g_tk";

        /// <summary>
        /// 获取个人主页信息（访客、日志条数、说说条数等）
        /// </summary>
        /// <remarks>jsonp</remarks>
        public const string GetPersonalMain = "https://user.qzone.qq.com/proxy/domain/r.qzone.qq.com/cgi-bin/main_page_cgi?uin=@qq&param=3_@qq_0%7C8_8_@qq_0_1_0_0_1%7C16&g_tk=@g_tk&g_tk=@g_tk";

        /// <summary>
        /// 获取说说点赞列表
        /// </summary>
        public const string GetSuoSuoLikeUrl = "https://user.qzone.qq.com/proxy/domain/taotao.qq.com/cgi-bin/emotion_cgi_msglist_v6?uin=@qq&inCharset=utf-8&outCharset=utf-8&hostUin=@qq&notice=0&sort=0&pos=@pos&num=@num&cgi_host=https%3A%2F%2Fuser.qzone.qq.com%2Fproxy%2Fdomain%2Ftaotao.qq.com%2Fcgi-bin%2Femotion_cgi_msglist_v6&code_version=1&format=jsonp&need_private_comment=1&g_tk=@g_tk&g_tk=@g_tk";
    }
}
