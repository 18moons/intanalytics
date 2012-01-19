using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MibClient2.Objects;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace DXAnalytics.Base
{
    public class Tools
    {
        #region CacheTime
        public static int GetCacheTime(string strMediaType)
        {
            var mCache = new MibObject(strMediaType);
            return mCache.CacheTime;
        }
        #endregion

        #region ClearString
        /// <summary>
        /// Clears string
        /// </summary>
        /// <param name="body">Dirty string (with special characters)</param>
        /// <returns>String cleared</returns>
        public static string ClearString(string body)
        {
            if (body != string.Empty && body != null)
            {
                // resolve o problema da string &$8230:
                body = Regex.Replace(body, "&#8230;", ".");
                // Troca versões acentuadas por equivalentes sem acento
                body = Regex.Replace(body, "[áäàâã]", "a");
                body = Regex.Replace(body, "[éëèê]", "e");
                body = Regex.Replace(body, "[íïìî]", "i");
                body = Regex.Replace(body, "[óöòôõ]", "o");
                body = Regex.Replace(body, "[úüùû]", "u");
                body = Regex.Replace(body, "[ç]", "c");
                body = Regex.Replace(body, "[ñ]", "n");

                // Idem para maiúsculas
                body = Regex.Replace(body, "[ÁÄÀÂÃ]", "A");
                body = Regex.Replace(body, "[ÉËÈÊ]", "E");
                body = Regex.Replace(body, "[ÍÏÌÎ]", "I");
                body = Regex.Replace(body, "[ÓÖÒÔÕ]", "O");
                body = Regex.Replace(body, "[ÚÜÙÛ]", "U");
                body = Regex.Replace(body, "[Ç]", "C");
                body = Regex.Replace(body, "[Ñ]", "N");

                // Remove caracteres invalidos
                body = Regex.Replace(body, "[:,.|?^~´`!@#$%¨&*()_='\"\\/]", " ");

                // Remove espaços múltiplos que possam ter sobrado
                body = Regex.Replace(body, "\\s+", " ");
            }
            return (body);
        }

        /// <summary>
        /// Clears string for well formatted url
        /// </summary>
        /// <param name="body">Dirty string (with special characters)</param>
        /// <returns>String cleared</returns>
        public static string urlEncode(string body)
        {
            if (body != string.Empty && body != null)
            {
                body = Tools.ClearString(body.ToLower());
                body = Regex.Replace(body, "\\s", "-");
            }
            return (body);
        }

        public static string urlEncodeSpaces(string body)
        {
            if (body != string.Empty && body != null)
            {
                body = Regex.Replace(body, "\\s", "_");
            }
            return (body);
        }

        public static string urlDecodeSpaces(string body)
        {
            if (body != string.Empty && body != null)
            {
                body = Regex.Replace(body, "_", " ");
            }
            return (body);
        }

        public static string unclearString(string value)
        {
            return Regex.Replace(value, "-", " ");
        }
        #endregion

        #region MD5
        public static string MD5(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);

            var cryptHandler = new MD5CryptoServiceProvider();
            byte[] hash = cryptHandler.ComputeHash(textBytes);

            string ret = "";
            foreach (byte a in hash)
            {
                ret += a.ToString("x2");
            }

            return ret;

        }

        public static bool ValidateGeneralMD5(string key, string hash)
        {
            return hash == MD5(key + GeneralConfig.Current.GeneralMD5Key);
        }

        public static string ComputeGeneralMD5(string key)
        {
            return MD5(key + GeneralConfig.Current.GeneralMD5Key);
        }

        #endregion

        #region Base64String
        #region Summary
        /// <summary>
        /// Converts a string to a base64 string
        /// </summary>
        /// <param name="text">Text to be converted</param>
        /// <returns>base64 string</returns>
        #endregion
        public static string ToBase64String(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            return (Convert.ToBase64String(bytes));
        }

        #region Summary
        /// <summary>
        /// Converts a base64 string to a regular one
        /// </summary>
        /// <param name="text">Base64 string</param>
        /// <returns>String</returns>
        #endregion
        public static string FromBase64String(string text)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(text);
                return (Encoding.UTF8.GetString(bytes));
            }
            catch
            {
                return ("");
            }
        }
        #endregion

        #region Base36
        public static string Base36Encode(int value)
        {
            char[] base36Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string returnValue = "";
            if (value < 0)
            {
                value *= -1;
            }
            do
            {
                returnValue = base36Chars[value % base36Chars.Length] + returnValue;
                value /= 36;
            } while (value != 0);
            return returnValue;
        }

        public static int Base36Decode(string input)
        {
            string base36Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] arrInput = input.ToCharArray();
            Array.Reverse(arrInput);
            int returnValue = 0;
            for (int i = 0; i < arrInput.Length; i++)
            {
                int valueindex = base36Chars.IndexOf(arrInput[i]);
                double val = valueindex * Math.Pow(36, i);

                if ((val > 0) && (val + returnValue < Int32.MaxValue))
                {
                    returnValue += Convert.ToInt32(val);
                }
                else
                {
                    return 0;
                }
            }
            return returnValue;
        }

        #endregion
    }
}