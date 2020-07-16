using LogManage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Common
{
    public class TranslationHelper
    {
        /// <summary>
        /// 百度接口翻译
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <param name="from">源内容语言</param>
        /// <param name="to">目标语言</param>
        /// <returns></returns>
        private static string BaiduTranslate(string inputString, string from, string to)
        {
            string content = "";
            string appId = "20190103000254215";
            string securityId = "CTXsfN18ayqGnMk23Pt4";
            Random random = new Random();
            int salt = random.Next(111111, 999999);

            StringBuilder signString = new StringBuilder();
            string md5Result = string.Empty;
            //1.拼接字符,为了生成sign
            signString.Append(appId);
            signString.Append(inputString);
            signString.Append(salt);
            signString.Append(securityId);

            //2.通过md5获取sign
            byte[] sourceMd5Byte = Encoding.UTF8.GetBytes(signString.ToString());
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] destMd5Byte = md5.ComputeHash(sourceMd5Byte);
            md5Result = BitConverter.ToString(destMd5Byte).Replace("-", "");
            md5Result = md5Result.ToLower();

            try
            {
                //3.获取web翻译的json结果
                string url = string.Format("http://api.fanyi.baidu.com/api/trans/vip/translate?q={0}&from=" + from.ToString() +
                    "&to=" + to.ToString() +
                    "&appid={1}&salt={2}&sign={3}", inputString, appId, salt, md5Result);
                LogHelper.Info("翻译 url：" + url);
                var response = HttpHelper.HttpRequest("GET", url, null, null, Encoding.UTF8, null);
                var resStream = response.GetResponseStream();
                string result = "";

                using (StreamReader sr = new StreamReader(resStream))
                {
                    result = sr.ReadToEnd();
                }
                LogHelper.Info("翻译 result：" + result);
                var trans = JsonConvert.DeserializeObject<TranslationJson>(result);
                if (trans != null&& trans.from!=null)
                {
                    content = trans.trans_result[0].dst;
                    content = StringUtil.ToProperCase(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return content;
        }

        /// <summary>
        /// 中译英
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static string Translate(string key, string from, string to)
        {

            return BaiduTranslate(key, from, to);
        }

        internal class TranslationJson
        {
            public string from { get; set; }
            public string to { get; set; }
            public List<TranslationResult> trans_result { get; set; }
        }
        internal class TranslationResult
        {
            public string src { get; set; }
            public string dst { get; set; }
        }

    }
}
