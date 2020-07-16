﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Common
{
    /// <summary>
    /// StringUtil 的摘要说明。
    /// </summary>
    public class StringUtil
    {
        public StringUtil()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 功能描述：将字符串转换成参数。
        /// </summary>
        /// <param name="str">需转换的字符串</param>
        /// <returns></returns>
        public static string paramChg(string str)
        {
            str = "@" + str;
            return str;
        }
        /// <summary>
        /// 功能描述：从字符串中的尾部删除指定的字符串。
        /// </summary>
        /// <param name="sourceString">原字符串</param>
        /// <param name="removedString">移除字符串</param>
        /// <returns>留下的字符串</returns>
        public static string Remove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) == -1)
                    throw new Exception("原字符串中不包含移除字符串！");
                string result = sourceString;
                int LengthOfsourceString = sourceString.Length;
                int LengthOfremovedString = removedString.Length;
                int startIndex = LengthOfsourceString - LengthOfremovedString;
                string sourceStringSub = sourceString.Substring(startIndex);
                if (sourceStringSub.ToUpper() == removedString.ToUpper())
                {
                    result = sourceString.Remove(startIndex, LengthOfremovedString);
                }
                return result;
            }
            catch
            {
                return sourceString;
            }
        }
        /// <summary>
        /// 功能描述：从字符串中的指定位置删除指定的字符串。
        /// </summary>
        /// <param name="sourceString">原字符串</param>
        /// <param name="removedString">移除字符串</param>
        /// <returns>留下的字符串</returns>
        public static string StrRemove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) == -1)
                    throw new Exception("原字符串中不包含移除字符串！");
                string result = sourceString;
                int LengthOfremovedString = removedString.Length;
                if (sourceString.IndexOf(removedString) > 0)
                {
                    int startIndex = sourceString.IndexOf(removedString);
                    result = sourceString.Remove(startIndex, LengthOfremovedString);
                }
                return result;
            }
            catch
            {
                return sourceString;
            }
        }

        /// <summary>
        /// 做一些特殊的操作
        /// </summary>
        /// <param name="content">原字符串</param>
        /// <returns>原字符串</returns>
        internal static string ToProperCase(string content)
        {
            return content;
        }

        /// <summary>
        /// 功能描述：获取拆分符右边的字符串。
        /// </summary>
        /// <param name="sourceString">原字符串</param>
        /// <param name="splitChar">拆分字符</param>
        /// <returns>右边的字符串</returns>
        public static string RightSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempStr = sourceString.Split(splitChar);
            if (tempStr.Length > 0)
            {
                result = tempStr[tempStr.Length - 1].ToString();
            }
            return result;
        }
        /// <summary>
        /// 功能描述：获取拆分符左边的字符串。
        /// </summary>
        /// <param name="sourceString">原字符串</param>
        /// <param name="splitChar">拆分字符</param>
        /// <returns>左边的字符串</returns>
        public static string LeftSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempStr = sourceString.Split(splitChar);
            if (tempStr.Length > 0)
            {
                result = tempStr[0].ToString();
            }
            return result;
        }
        /// <summary>
        /// 功能描述：去掉最后一个逗号后面的字符串。
        /// </summary>
        /// <param name="sourceString">原字符串</param>
        /// <param name="splitChar">拆分字符</param>
        /// <returns>左边的字符串</returns>
        public static string DelLsatComma(string sourceString)
        {
            if (sourceString.IndexOf(",") == -1)
            {
                return sourceString;
            }
            return sourceString.Substring(0, sourceString.LastIndexOf(","));
        }
        /// <summary>
        /// 功能描述：删除不可见字符。
        /// </summary>
        /// <param name="sourceString">原字符串</param>
        /// <returns></returns>
        public static string DeleteUnVisibleChar(string sourceString)
        {
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder(131);
            for (int i = 0; i < sourceString.Length; i++)
            {
                int Unicode = sourceString[i];
                if (Unicode >= 16)
                {
                    strBuilder.Append(sourceString[i].ToString());
                }
            }
            return strBuilder.ToString();
        }
        /// <summary>
        /// 功能描述：获取数组元素的合并字符串。
        /// </summary>
        /// <param name="stringArray">字符串数组</param>
        /// <returns></returns>
        public static string GetArrayString(string[] stringArray)
        {
            string totalString = null;
            for (int i = 0; i < stringArray.Length; i++)
            {
                totalString = totalString + stringArray[i];
            }
            return totalString;
        }
        /// <summary>
        /// 功能描述：获取某一字符串在字符串数组中出现的次数。
        /// </summary>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="findString">某一字符串</param>
        /// <returns></returns>
        public static int GetStringCount(string[] stringArray, string findString)
        {
            int count = 0;
            string totalString = GetArrayString(stringArray);
            int findStringLength = findString.Length;
            string subString = totalString;
            while (subString.IndexOf(findString) >= 0)
            {
                subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
                count += 1;
            }
            return count;
        }
        /// <summary>
        /// 功能描述：获取某一字符串在字符串中出现的次数。
        /// </summary>
        /// <param name="sourceString">字符串</param>
        /// <param name="findString">某一字符串</param>
        /// <returns></returns>
        public static int GetStringCount(string sourceString, string findString)
        {
            int count = 0;
            int findStringLength = findString.Length;
            string subString = sourceString;
            while (subString.IndexOf(findString) >= 0)
            {
                subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
                count += 1;
            }
            return count;
        }
        /// <summary>
        /// 功能描述：截取从startString开始到原字符串结尾的所有字符。
        /// </summary>
        /// <param name="sourceString">字符串</param>
        /// <param name="startString">某一字符串</param>
        /// <returns></returns>
        public static string GetSubstring(string sourceString, string startString)
        {
            int startIndex = sourceString.IndexOf(startString);
            if (startIndex > 0)
                return sourceString.Substring(startIndex);
            return sourceString;
        }
        /// <summary>
        /// 功能描述：按字节数取出字符串的长度。
        /// </summary>
        /// <param name="sourceString">要计算的字符串</param>
        /// <returns>字符串的字节数</returns>
        public static int GetByteCount(string sourceString)
        {
            int itnCharCount = 0;
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (System.Text.UTF8Encoding.UTF8.GetByteCount(sourceString.Substring(i, 1)) == 3)
                {
                    itnCharCount = itnCharCount + 2;
                }
                else
                {
                    itnCharCount = itnCharCount + 1;
                }
            }
            return itnCharCount;
        }
        /// <summary>
        /// 功能描述：按字节数要在字符串的位置。
        /// </summary>
        /// <param name="intIns">字符串的位置</param>
        /// <param name="strTmp">要计算的字符串</param>
        /// <returns>字节的位置</returns>
        public static int GetByteIndex(int intIns, string strTmp)
        {
            int intReIns = 0;
            if (strTmp.Trim() == "")
            {
                return intIns;
            }
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
                {
                    intReIns = intReIns + 2;
                }
                else
                {
                    intReIns = intReIns + 1;
                }
                if (intReIns >= intIns)
                {
                    intReIns = i + 1;
                    break;
                }
            }
            return intReIns;
        }
        /// <summary>
        /// 返回路径分割符号"\"最后一个字符串。
        /// </summary>
        /// <param name="sourceStr">原字符串</param>
        /// <param name="splitChar">分割符号</param>
        /// <returns></returns>
        public static string getLastStr(string sourceStr, char splitChar)
        {
            string[] strArr = sourceStr.Split(splitChar);
            string lastStr = strArr[strArr.Length - 1];
            if (lastStr == "")
                return strArr[strArr.Length - 2];
            return lastStr;
        }
        /// <summary>
        /// 获取路径最后一个分隔符"\"左边的全部字符串
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="splitChar">分隔符</param>
        /// <returns></returns>
        public static string getLeftStr(string sourceStr, char splitChar)
        {
            string[] strArr = sourceStr.Split(splitChar);
            int length = sourceStr.Length - getLastStr(sourceStr, '\\').Length;
            string leftStr = sourceStr.Substring(0, length);
            return leftStr;
        }
        /// <summary>
        /// 编码字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            str = str.Replace("<p>", "<br>");
            str = str.Replace("</p>", "");
            str = str.Replace(".", "．");
            str = str.Replace("'", "''");
            str = str.Replace(":", "：");
            //   str = str.Replace("<", "&lt;");
            //   str = str.Replace(">", "&gt;");
            str = str.Replace("//", "／／");
            str = str.Replace("http", "ｈｔｔｐ");
            str = str.Replace("js", "ｊｓ");
            str = str.Replace("gif", "ｇｉｆ");
            return str;
        }
        public static string SqlEncode(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }
        /// <summary>
        /// 解码字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            //str = str.Replace("&gt;", ">");
            //str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }
        /// <summary>
        /// 文本域的html编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            //   str = str.Replace("<", "&lt;");
            //   str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            str = str.Replace("//", "／／");
            str = str.Replace("http", "ｈｔｔｐ");
            str = str.Replace("js", "ｊｓ");
            str = str.Replace("gif", "ｇｉｆ");
            str = str.Replace("com", "ｃｏｍ");
            str = str.Replace(".", "．");
            return str;
        }
        /// <summary>
        /// 文本域的html解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlDecode(string str)
        {
            //   str = str.Replace("&gt;", ">");
            //   str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            str = str.Replace("''", "'");
            str = str.Replace("<br>", "\n");
            return str;
        }
        /// <summary>
        /// 出去空格，并见对尖括号内的空格加入。
        /// </summary>
        /// <param name="contStr"></param>
        /// <returns></returns>
        public static string ReplaceStr(string contStr)
        {
            contStr = System.Text.RegularExpressions.Regex.Replace(contStr, "\\s", "&nbsp;");
            int y, z;
            z = 0;
            int i = 0;
            do
            {
                y = contStr.IndexOf("<", z);
                if (y >= 0)
                {
                    z = contStr.IndexOf(">", y);
                    if (z >= 0)
                    {
                        i += contStr.Substring(y, z - y + 1).Replace("&nbsp;", " ").Length + 4; //统计超级链接标签占用的字符数
                        string tStr1, tStr2;
                        tStr1 = contStr.Substring(0, z + 1);
                        tStr2 = contStr.Substring(z + 1);
                        contStr = tStr1.Replace(tStr1.Substring(y, z - y + 1), tStr1.Substring(y, z - y + 1).Replace("&nbsp;", " ")) + tStr2;
                    }
                    else
                    {

                        z = y + 1;
                        if (z > contStr.Length - 1)
                            break;
                    }
                }
            }
            while (y >= 0 && z <= contStr.Length - 1);
            return contStr;
        }
    }
}
