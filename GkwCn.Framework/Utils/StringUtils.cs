using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
    public static class NStringUtils
    {
        #region ToStringNotScript
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(this bool value)
        {
            if (value)
            {
                return "是";
            }
            else
            {
                return "否";
            }
        }

        public static string ObjectToString(this object value)
        {
            if (value.IsNull())
                return string.Empty;
            return value.ToString();
        }
        #endregion

        #region ToByte
        /// <summary>
        /// ToByte
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>retValue</returns>
        public static byte ToByte(this object value)
        {
            return value.ToByte(0);
        }

        /// <summary>
        /// ToByte
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>retValue</returns>
        public static byte ToByte(this object value, byte defaultValue)
        {
            if (!value.IsNull())
            {
                if (value.ToString().IsNumberSign())
                {
                    return Convert.ToByte(value);
                }
            }
            return defaultValue;
        }
        #endregion

        #region ToInt
        /// <summary>
        /// ToInt
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>retValue</returns>
        public static int ToInt(this object value)
        {
            return value.ToInt(0);
        }

        /// <summary>
        /// ToInt
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>retValue</returns>
        public static int ToInt(this object value, int defaultValue)
        {
            if (!value.IsNull())
            {
                if (value.ToString().IsNumberSign())
                {
                    return Convert.ToInt32(value);
                }
            }
            return defaultValue;
        }
        #endregion

        #region ToLong
        /// <summary>
        /// ToLong
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>retValue</returns>
        public static long ToLong(this object value)
        {
            return value.ToLong(0);
        }

        /// <summary>
        /// ToLong
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>retValue</returns>
        public static long ToLong(this object value, long defaultValue)
        {
            if (!value.IsNull())
            {
                if (value.ToString().IsNumberSign())
                {
                    return Convert.ToInt64(value);
                }
            }
            return defaultValue;
        }
        #endregion

        #region ToDecimal
        /// <summary>
        /// ToDecimal
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>retValue</returns>
        public static decimal ToDecimal(this object value)
        {
            return value.ToDecimal(0);
        }

        /// <summary>
        /// ToDecimal
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>retValue</returns>
        public static decimal ToDecimal(this object value, decimal defaultValue)
        {
            if (!value.IsNull())
            {
                if (value.ToString().IsNumberSign())
                {
                    return Convert.ToDecimal(value);
                }
            }
            return defaultValue;
        }
        #endregion

        #region ToDouble
        /// <summary>
        /// ToDouble
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>retValue</returns>
        public static double ToDouble(this object value)
        {
            return value.ToDouble(0);
        }

        /// <summary>
        /// ToDouble
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>retValue</returns>
        public static double ToDouble(this object value, double defaultValue)
        {
            if (!value.IsNull())
            {
                if (value.ToString().IsNumberSign())
                {
                    return Convert.ToDouble(value);
                }
            }
            return defaultValue;
        }
        #endregion

        #region ToBoolean
        /// <summary>
        /// ToBoolean
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>retValue</returns>
        public static bool ToBoolean(this object value)
        {
            return value.ToBoolean(false);
        }

        /// <summary>
        /// ToBoolean
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>retValue</returns>
        public static bool ToBoolean(this object value, bool defaultValue)
        {
            if (value.IsNull())
            {
                return defaultValue;
            }
            try
            {
                if (("1".Equals(value) || "true".Equals(value) || "y".Equals(value) || "t".Equals(value)))
                {
                    return true;
                }
                if (("0".Equals(value) || "false".Equals(value)) || ("n".Equals(value) || "f".Equals(value)))
                {
                    return false;
                }
                return Convert.ToBoolean(value);
            }
            catch
            {
                return defaultValue;
            }
        }
        #endregion

        public static DateTime ToDateTimeNow(this object value)
        {
            return value.ToDateTimeNow(DateTime.Now);
        }
        public static DateTime ToDateTimeNow(this object value, DateTime defaultValue)
        {
            try
            {
                if (!value.IsNull()) { return DateTime.Parse(value.ToString()); }
                else { return defaultValue; }
            }
            catch
            {
                return defaultValue;
            }
        }

        #region CutString

        /// <summary>
        /// 去Html
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string content)
        {
            string regexstr = @"<[^>]*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// Html分段 将\n 变成<br/>
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static string SubSection(this string content)
        {
            return content.Replace("\n", "<br/>");
        }

        /// <summary>
        /// 去Html标记后，截取指定长度的A标签字符串
        /// </summary>
        /// <param name="stringToSub"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ASubString(this string stringToSub, int length)
        {
            if (string.IsNullOrEmpty(stringToSub))
            {
                return null;
            }
            if (length <= 0)
            {
                return stringToSub;
            }
            stringToSub = RemoveHtml(stringToSub);
            string tag = null;
            string end = null;


            if (stringToSub.ToLower().IndexOf("<a") > -1)
            {
                int wordStart = stringToSub.IndexOf(">") + 1;
                int wordEnd = stringToSub.IndexOf("</");

                tag = stringToSub.Substring(0, wordStart);
                end = stringToSub.Substring(wordEnd);
                stringToSub = stringToSub.Substring(wordStart, wordEnd - wordStart);
            }
            Regex regex = new Regex("[一-龥]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (stringChar[i].Equals('…') || stringChar[i].Equals('—'))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else if (regex.IsMatch(stringChar[i].ToString()))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength++;
                }
                if (nLength > length)
                {
                    sb.Append("…");
                    break;
                }
            }
            return tag + sb.ToString() + end;
        }

        /// <summary>
        /// 不区分大小写的匹配
        /// </summary>
        /// <param name="value"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool NewEquals(this string value, object obj)
        {
            if (value.IsNull() || obj.IsNull())
                return false;
            return value.Equals(obj.ToString(), StringComparison.OrdinalIgnoreCase);
        }
        #endregion

        #region ToDBStr 转化为数据库字符(防止Sql注入)
        /// <summary>
        /// 转化为数据库字符(防止Sql注入)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDBStr(this string value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            bool hasKeywords = false;

            if (value.Length > 0)
            {
                Regex reg = new Regex("insert|update|delete|drop");
                string sLowerStr = value.ToLower();
                Match m = reg.Match(sLowerStr);
                hasKeywords = m.Success;
            }
            if (hasKeywords)
            {
                return string.Empty;
            }
            return value;
        }
        #endregion

        #region IsNullOrEmpty 自动Trim()
        /// <summary>
        /// IsNullOrEmpty 自动Trim()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            if (value == null)
            {
                return true;
            }
            return string.IsNullOrEmpty(value.Trim());
        }

        /// <summary>
        /// IsNullOrEmpty 自动Trim()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return true;
            }
            return value.ToString().IsNullOrEmpty();
        }
        #endregion

        #region NotNullStr
        /// <summary>
        ///  NotNullStr object转换Str
        /// </summary>
        /// <param name="canNullStr"></param>
        /// <returns></returns>
        public static string NotNullStr(this object canNullStr)
        {
            return canNullStr.NotNullStr("");
        }

        /// <summary>
        /// NotNullStr object转换Str
        /// </summary>
        /// <param name="canNullStr"></param>
        /// <param name="defaultStr"></param>
        /// <returns></returns>
        public static string NotNullStr(this object canNullStr, string defaultStr)
        {
            try
            {
                if ((canNullStr == null) || (canNullStr is DBNull))
                {
                    if (defaultStr != null)
                    {
                        return defaultStr;
                    }
                    return "";
                }
                return Convert.ToString(canNullStr).Trim();
            }
            catch
            {
                return defaultStr;
            }
        }
        #endregion

        #region 是否存在指定字符串

        /// <summary>
        /// 判断是否能匹配到指定字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool IsContains(this string str, string subString)
        {
            if (str.IndexOf(subString) == -1)
                return false;
            else
                return true;
        }

        #endregion

        #region 判断字符串中是否包含英文,包含都转化为大写
        /// <summary>
        /// 判断字符串中是否包含英文,包含都转化为大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ChangeContainEn(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                if (Regex.IsMatch(str, "[A-Za-z]"))
                {
                    return str.ToUpper();
                }
                else
                {
                    return str;
                }
            }
        }
        #endregion

        #region ToList 将以指定隔开的文本 转化成IList(string)

        /// <summary>
        /// 将以","隔开的文本 转化成IList(string)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IList<string> ToList(this string value)
        {
            return value.ToList(',');
        }

        /// <summary>
        /// 将以指定符号隔开的文本 转化成IList(string)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IList<string> ToList(this string value, char opr)
        {
            IList<string> lst = new List<string>();

            if (!value.IsNull())
            {
                string[] arr = value.ToString().TrimStart(opr).TrimEnd(opr).Split(opr);

                foreach (string s in arr)
                {
                    if (!s.IsNullOrEmpty())
                    {
                        if (!lst.Contains(s))
                        {
                            lst.Add(s);
                        }
                    }
                }
            }
            return lst;
        }
        #endregion

        #region ListToString 将IList(string)转化为以指定符号隔开的字符串

        /// <summary>
        /// 将IList(string)转化为以“,”隔开的字符
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string ListToString(this IList<string> lst)
        {
            return lst.ListToString(",");
        }

        /// <summary>
        /// 将IList(string)转化为以指定符号隔开的字符
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string ListToString(this IList<string> lst, string opr)
        {
            string str = string.Empty;

            if (lst == null || lst.Count == 0)
            {
                return str;
            }

            foreach (string s in lst)
            {
                if (!s.IsNullOrEmpty())
                {
                    str += string.Format("{0}{1}", s, opr);
                }
            }

            return str.TrimEnd(opr.ToCharArray());
        }
        #endregion
    }
}
