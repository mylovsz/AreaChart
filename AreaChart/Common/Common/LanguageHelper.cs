using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Common.Common
{
    public class LanguageHelper
    {
        public enum LanguageType
        {
            auto,
            //自动检测
            zh
,//中文
            en,
            //英语
            yue
,//粤语
            wyw
,//文言文
            jp
,//日语
            kor
,//韩语
            fra
,//法语
            spa
,//西班牙语
            th
,//泰语
            ara
,//阿拉伯语
            ru
,//俄语
            pt
,//葡萄牙语
            de
,//德语
            it
,//意大利语
            el
,//希腊语
            nl
,//荷兰语
            pl
,//波兰语
            bul
,//保加利亚语
            est
,//爱沙尼亚语
            dan
,//丹麦语
            fin
,//芬兰语
            cs
,//捷克语
            rom
,//罗马尼亚语
            slo
,//斯洛文尼亚语
            swe
,//瑞典语
            hu
,//匈牙利语
            cht
,//繁体中文
            vie
,//越南语
        }

        public class LanguageInfo
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public LanguageInfo(string key, string value)
            {
                Key = key;
                Value = value;
            }

        }

        private static Dictionary<string, LanguageInfo> resources;

        private static string languageType;
        /// <summary>
        /// 初始化语言
        /// </summary>
        public static bool InitLanguage(Control control)
        {
            ////如果没有资源，那么不必遍历控件，提高速度
            //if (!JsonLanguage.Default.HasResource)
            //    return;
            if (resources == null)
            {
                string language = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
                languageType = language;
                LoadLanguage(language);
            }
            if (!languageType.Equals(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString()))
            {
                languageType = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
                LoadLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString());
            }

            var isOK = true;

            //使用递归的方式对控件及其子控件进行处理
            isOK = isOK & SetControlLanguage(control);
            foreach (Control ctrl in control.Controls)
            {
                isOK = isOK & InitLanguage(ctrl);
            }

            //工具栏或者菜单动态构建窗体或者控件的时候，重新对子控件进行处理
            control.ControlAdded += (sender, e) =>
            {
                isOK = isOK & InitLanguage(e.Control);
            };
            return isOK;
        }

        /// <summary>
        /// 替换文字
        /// </summary>
        /// <param name="control"></param>
        private static bool SetControlLanguage(Control control)
        {
            LanguageInfo vl = new LanguageInfo(control.Text, control.Text);
            string key = control.Name;

            if (resources.TryGetValue(key, out vl))
            {
                control.Text = vl.Value;
                return true;
            }
            else
            {
                if (IsContainChinese(control.Text))
                {
                    resources.Add(key, new LanguageInfo(control.Text, ""));
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public static void updateFile()
        {
            var languageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("lang/{0}", languageName));
            if (!Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
                File.Create(dir + "/Basic.json").Close();
            }
            if (Directory.Exists(dir))
            {
                var jsonFiles = Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories);
                foreach (string file in jsonFiles)
                {
                    LoadFile(file, true);
                    break;
                }
            }
        }

        /// <summary>
        /// 根据语言初始化信息。
        /// 加载对应语言的JSON信息，把翻译信息存储在全属性resources里面。
        /// </summary>
        /// <param name="language">默认的语言类型，如zh，en-US等</param>
        ///
        private static void LoadLanguage(string language = "")
        {
            if (string.IsNullOrEmpty(language))
            {
                language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            }
            resources = new Dictionary<string, LanguageInfo>();
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("lang/{0}", language));
            if (!Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
                File.Create(dir + "/Basic.json").Close();
            }
            var jsonFiles = Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories);
            foreach (string file in jsonFiles)
            {
                LoadFile(file);
            }
        }

        private static void LoadFile(string file, bool isTranslate = false)
        {
            Encoding encoding = Encoding.GetEncoding("GBK");
            var content = File.ReadAllText(file, encoding);
            if (!string.IsNullOrEmpty(content) || isTranslate)
            {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, LanguageInfo>>(content);
                if (isTranslate)
                {
                    dict = new Dictionary<string, LanguageInfo>(resources);
                }

                var isTranslation = false;

                var dicts = new Dictionary<string, LanguageInfo>(dict);


                foreach (string key in dicts.Keys)
                {
                    var value = dict[key];
                    try
                    {
                        if (string.IsNullOrWhiteSpace(value.Value) && !string.IsNullOrWhiteSpace(value.Key) && IsContainChinese(value.Key))
                        {
                            
                            //如果值为空，那么调用翻译接口处理
                            double temp = 0;
                            if (double.TryParse(value.Key, out temp))
                            {
                                dict.Remove(key);
                                //value.Value = value.Key;
                                //dict[key] = value;
                                //isTranslation = false;
                                continue;
                            }

                            var newValue = TranslationHelper.Translate(value.Key,
                               LanguageType.zh.ToString(),
                               System.Threading.Thread.CurrentThread.CurrentUICulture.Name);

                            if (!string.IsNullOrWhiteSpace(newValue))
                            {
                                value.Value = newValue;
                                dict[key] = value;
                                isTranslation = true;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                    //遍历集合如果语言资源键值不存在，则创建，否则更新
                    if (!resources.ContainsKey(key))
                    {
                        resources.Add(key, dict[key]);
                    }
                    else
                    {
                        resources[key] = dict[key];
                    }
                }


                if (isTranslation)
                {
                    //进行排序
                    SortedDictionary<string, LanguageInfo> sortedDict = new SortedDictionary<string, LanguageInfo>(dict);
                    var newContent = JsonConvert.SerializeObject(sortedDict, Formatting.Indented);
                    File.WriteAllText(file, newContent, encoding);
                }
            }
        }

        /// <summary>
        /// 获取resources
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, LanguageInfo> getResources()
        {
            return resources;
        }

        /// <summary>
        /// 获取资源值 通过Name 返回Value 
        /// 
        /// 保持Name唯一
        /// 
        /// "Name": {
        /// "Key": "默认值",
        /// "Value": "默认值"
        /// }
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>返回Value，不存在时返回Name</returns>
        public static string getResources(string Name)
        {
            LanguageInfo dft = new LanguageInfo(Name, Name);

            if (resources != null)
            {
                if (resources.TryGetValue(Name, out dft))
                {
                    return resources[Name].Value;
                }
            }
            if (dft==null)
            {
                return Name;
            }
            return dft.Value;
        }

        /// <summary>
        /// 判断字符串中是否包含中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsContainChinese(string str)
        {
            bool bflag = false;
            if (str == null)
            {
                return bflag;
            }
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] >= 0x4E00 && c[i] <= 0x29FA5)
                {
                    bflag = true;
                    return bflag;// 有一个中文字符就返回
                }
            }
            return bflag;
        }

    }
}