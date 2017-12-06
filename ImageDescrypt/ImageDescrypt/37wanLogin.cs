using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using ImageDescrypt.Entity;
using XRFAppPlat.Logger;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;

namespace ImageDescrypt
{
    public class _37wanLogin
    {
        private string accName;
        private string passwd;
        private string ipAddress = "183.131.77.103";
        private int Port = 0;
        public _37wanLogin(string loginName, string loginPwd)
        {
            accName = loginName;
            passwd = loginPwd;
        }

        public static string mainURL = "https://regapi.37.com";
        public static string gameMainURL = "http://gameapp.37.com";
        public bool Login(ref HISTORYGAMESERVER serverInfo,ref string errMsg)
        {
            try
            {
                string passwdencrypt = PasswdEncrypt(passwd);
                /*
                 GET /api/p_register_v2.php?callback=jQuery183024481548836811018_1512003074702&login_account=burnblood&password=VGdSbjBVd1Q4ODlBTGZ4YTExMjl6aEcz&game_id=237&game_server_id=&email=&referer=baidu_ppzq&referer_param=&ab_param=&name=&id_card_number=&ab_type=&wd=&verify_code=&s=1&return_userinfo=1&form_type=1&tj_from=202&tj_way=1&_=1512003180508 HTTP/1.1
                 */
                long timestamp = ConvertDateTimeToInt(DateTime.Now);
                string destURL = string.Format("{0}/api/p_register_v2.php?callback=jQuery&login_account={1}&password={2}&_={3}&"
                    +"game_id=237&game_server_id=&email=&referer=baidu_ppzq&referer_param=&ab_param=&name=&id_card_number=&ab_type=&"
                    +"wd=&verify_code=&s=1&return_userinfo=1&form_type=1&tj_from=202&tj_way=1", mainURL, accName, passwdencrypt, timestamp);

                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                handler.MaxAutomaticRedirections = 5;

                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
                var task = client.GetAsync(new Uri(destURL));
                task.Result.EnsureSuccessStatusCode();
                HttpResponseMessage response = task.Result;

                string statuscode = response.StatusCode + " " + response.ReasonPhrase + Environment.NewLine;
                var result = response.Content.ReadAsStringAsync();
                string responseBodyAsText = result.Result;
                // 转为json对象
                string jsonstr = responseBodyAsText.Replace("jQuery({", "{").Replace(");", "");
                webLoginRetInfo retobj = (webLoginRetInfo)JsonManager.JsonToObject(jsonstr, typeof(webLoginRetInfo));

                if (retobj.success == "0")
                {
                    List<HISTORYGAMESERVER> serverlst = retobj.userinfo.HISTORY_GAME_SERVER.ToList();
                    if(serverlst.Count > 0)
                        serverInfo = serverlst[0];
                    //// 获取服务器URL
                    //

                    // 获取服务器信息
                    string jumpURL = string.Format("http://game.37.com/play.php?game_id={0}&sid={1}", serverInfo.GAME_ID, serverInfo.SID);
                    // 请求并获取server_id
                    task = client.GetAsync(new Uri(jumpURL));
                    task.Result.EnsureSuccessStatusCode();
                    response = task.Result;
                    result = response.Content.ReadAsStringAsync();
                    responseBodyAsText = result.Result;
                    // 正则提取server_id
                    jsonstr = Regex.Match(responseBodyAsText, "(?s)SQ.GameTopNav.init(?<value>.*?)\\)")
                        .Groups["value"].Value.Replace("(","");
                    if (string.IsNullOrEmpty(jsonstr))
                        return false;

                    string serverID = Regex.Match(jsonstr, "(?s)serverId: \"(?<value>.*?)\"").Groups["value"].Value;
                    if (string.IsNullOrEmpty(serverID))
                        return false;

                    string jumpURL2 = gameMainURL +
                            string.Format("/controller/enter_game.php?game_id={0}&sid={1}&server_id={2}&showlogintype=1&yksw_from=0",
                                serverInfo.GAME_ID, serverInfo.SID, serverID);

                    // status=302 获取服务器真实URL

                    task = client.GetAsync(new Uri(jumpURL2));
                    // task.Result.E();
                    response = task.Result;
                    Uri realURL= task.Result.Headers.Location;
                    result = response.Content.ReadAsStringAsync();
                    if (response.StatusCode!= HttpStatusCode.Found)
                        return false;

                    task = client.GetAsync(realURL);
                    task.Result.EnsureSuccessStatusCode();
                    response = task.Result;
                    result = response.Content.ReadAsStringAsync();

                    // 获取IP地址 端口号
                    jsonstr = Regex.Match(result.Result, "(?s)window.YOLK7_CLIENT_ENV = (?<value>.*?);").Groups["value"].Value;
                    if (string.IsNullOrEmpty(jsonstr))
                        return false;

                    string port = Regex.Match(jsonstr, "(?s)port:(?<value>.*?)\"").Groups["value"].Value.Replace("\"","").Trim();
                    //Port = port;
                    //webServerInfo serverInfo1 = (webServerInfo)JsonManager.JsonToObject(jsonstr, typeof(webServerInfo));
                    //if (serverInfo1 == null)
                    //{
                    //    return false;
                    //}

                    Port = Convert.ToInt32(port);

                    // retobj2.serverId;
                    return true;
                }
                else
                {
                    errMsg = HttpUtility.UrlDecode(retobj.message);//UnicodeToString(retobj.message);
                }
            }
            catch (Exception ex) 
            { 
                ConsoleLog.Instance.writeInformationLog("ErrMsg=" + ex.Message); 
            }
            return false;
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="unicode">Unicode.</param>
        public static string UnicodeToString(string unicode)
        {
            string resultStr = "";
            string[] strList = unicode.Split('u');
            for (int i = 1; i < strList.Length; i++)
            {
                resultStr += (char)int.Parse(strList[i], System.Globalization.NumberStyles.HexNumber);
            }
            return resultStr;
        }

        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        } 

        private string PasswdEncrypt(string passwd)
        {
            string contractstr = ContractStr(passwd);
            string encryptpasswd = __rsa(contractstr);

            return encryptpasswd;
        }
        private static string ch = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        public static string ContractStr(string a) {
            Random r = new Random();
            int maxPos = ch.Length - 2;
            List<string> list = new List<string>();
                //, w = [];
            for (int i = 0; i < 15; i++) {
                string substr =ch.Substring((int)Math.Floor(r.NextDouble() * maxPos), 1);
                list.Add(substr);
                if (i == 7) {
                    list.Add(a.Substring(0, 3));
                }
                if (i == 12) {
                    list.Add(a.Substring(3));
                }
            }
            string contractstr = string.Join("", list.ToArray());
            return contractstr;
	    }

        public static string  __rsa(string str) {
            string outstr="";
            int len=0;

            len = str.Length;
            int i = 0;
            outstr = "";
            while (i < len) {
                int c1 = str.Substring(i++,1)[0] & 0xff;
                if (i == len) {
                    outstr += ch.Substring(c1 >> 2,1);
                    outstr += ch.Substring((c1 & 0x3) << 4,1);
                    outstr += "==";
                    break;
                }
                int c2 = str.Substring(i++,1)[0];
                if (i == len) {
                    outstr += ch.Substring(c1 >> 2,1);
                    outstr += ch.Substring(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4),1);
                    outstr += ch.Substring((c2 & 0xF) << 2,1);
                    outstr += "=";
                    break;
                }
                int c3 = str.Substring(i++,1)[0];
                outstr += ch.Substring(c1 >> 2,1);
                outstr += ch.Substring(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4),1);
                outstr += ch.Substring(((c2 & 0xF) << 2) | ((c3 & 0xC0) >> 6),1);
                outstr += ch.Substring(c3 & 0x3F,1);
            }
            return outstr;
        }
    }
}
