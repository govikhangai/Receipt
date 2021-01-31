using Microsoft.Win32;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;


namespace Receipt
{
    public static class Static
    {
        public static bool ToBool(object pObj)
        {
            if (pObj is bool)
                return (bool)pObj;
            string str = Convert.ToString(pObj);
            if (str == "1")
                return true;
            bool result;
            bool.TryParse(str, out result);
            return result;
        }
        
        public static string ToStr(object pobj)
        {
            string str = "";
            if (pobj != null && !Convert.IsDBNull(pobj))
                str = Convert.ToString(pobj);
            return str;
        }
        public static int ToInt(object pobj)
        {
            return (int)Static.ToDouble(pobj);
        }

        public static double ToDouble(object pobj)
        {
            if (pobj is double)
                return (double)pobj;
            double result;
            if (pobj is bool)
                result = Convert.ToDouble(pobj);
            else
                double.TryParse(Convert.ToString(pobj), NumberStyles.Float, (IFormatProvider)null, out result);
            return result;
        }
        public static Decimal ToDecimal(object pobj)
        {
            if (pobj is Decimal)
                return (Decimal)pobj;
            Decimal result;
            Decimal.TryParse(Convert.ToString(pobj), NumberStyles.Any, null, out result);
            return result;
        }
        public static DateTime ToDate(object pobj)
        {
            if (pobj is DateTime)
                return (DateTime)pobj;
            DateTime result;
            DateTime.TryParseExact(Convert.ToString(pobj), new string[9]
            {
        "G",
        "yyyyMMdd HH:mm:ss",
        "yyyy/M/d HH:mm:ss",
        "yyyy-M-d HH:mm:ss",
        "yyyy.M.d HH:mm:ss",
        "yyyyMMdd",
        "yyyy/M/d",
        "yyyy-M-d",
        "yyyy.M.d"
            }, (IFormatProvider)null, DateTimeStyles.None, out result);
            return result.Date;
        }
        public static DateTime ToDateTime(object pobj)
        {
            if (pobj is DateTime)
                return (DateTime)pobj;
            DateTime result;
            DateTime.TryParseExact(Convert.ToString(pobj), new string[9]
            {
        "G",
        "yyyyMMdd HH:mm:ss",
        "yyyy/M/d HH:mm:ss",
        "yyyy-M-d HH:mm:ss",
        "yyyy.M.d HH:mm:ss",
        "yyyyMMdd",
        "yyyy/M/d",
        "yyyy-M-d",
        "yyyy.M.d"
            }, (IFormatProvider)null, DateTimeStyles.None, out result);
            return result;
        }
        public static string SubStr(string source, int startindex, int len)
        {
            string str = "";
            if (source != null && startindex >= 0)
            {
                int length1 = source.Length;
                int length2 = length1 >= startindex + len ? len : length1 - startindex;
                str = source.Substring(startindex, length2);
            }
            return str;
        }
        public static string SubStr(string source, int startindex)
        {
            string str = "";
            if (source != null && startindex >= 0)
            {
                int length = source.Length;
                if (length > startindex)
                    str = source.Substring(startindex, length - startindex);
            }
            return str;
        }
        
    }
}
