using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace demoMac5.Module
{
    public class Utility
    {
        static string errMsg = "";
        public static int GetCheckUniqe (string tableName, string columnName , string wheredata )
        {

            SqlConnection ObjConn = DBHelper.ConnectDb(ref errMsg);

            try
            {

                string StrSql = @" Select "+ columnName  +" From " + tableName +  "   where 0=0  "  +  wheredata  ;
                DataTable dt = DBHelper.List(StrSql, ObjConn);
                return dt.Rows.Count;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ObjConn.Close();
            }
        }

        public static bool IsHolidays(DateTime date, DateTime[] holidays)
        {
            return holidays.Contains(date.Date);

        }

        public static DateTime[] Holidays(int activated)
        {


            SqlConnection ObjConn = DBHelper.ConnectDb(ref errMsg);
            string StrSql = "";
            try
            {



                StrSql = @" SELECT * FROM holidays WHERE  deleted=0 ";


                if (activated > 0)
                {
                    StrSql += " and activated=1  ";
                }


                DataTable dt = DBHelper.List(StrSql, ObjConn);

                DateTime[] Holidays = new DateTime[dt.Rows.Count]; ;
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Holidays[i] = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());

                    }

                }

                return Holidays;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {


                ObjConn.Close();

            }


        }

        public static String FormateCurrency(Decimal value)
        {
            String data;
            data = String.Format("{0:0,0.00}", value);
            return data;
        }

        public static String FormateDate(DateTime date)
        {
            String strDate;
            CultureInfo invC = System.Globalization.CultureInfo.InvariantCulture;
            strDate = "{ d '" + date.ToString("yyyy-MM-dd", invC) + "' }";
            return strDate;
        }

        public static String FormateDate(DateTime? date)
        {
            String strDate;
            DateTime date2;
            CultureInfo invC = System.Globalization.CultureInfo.InvariantCulture;
            if (date != null)
            {
                date2 = Convert.ToDateTime(date);
                strDate = "{ d '" + date2.ToString("yyyy-MM-dd", invC) + "' }";

            }
            else {
                strDate = "null"; 
            }
            return strDate;
        }

        public static String FormateDateTime(DateTime date)
        {
            String strDate;
            CultureInfo invC = System.Globalization.CultureInfo.InvariantCulture;
            strDate = "{ ts '" + date.ToString("yyyy-MM-dd HH:mm:ss", invC) + "' }";
            return strDate;
        }

        public static String ReplaceString(String text)
        {
            String data = "";
            if (String.IsNullOrEmpty(text))
            {
                text = "";
            }
            data = text.Replace("'", "''");
            data = data.Replace("\\", "\\\\");
            data = data.Replace("'-'", "");
            data = data.Replace("''", "");
            data = data.Replace("'&'", "");
            data = data.Replace("'*'", "");
            data = data.Replace("' or''-'", "");
            data = data.Replace("' or 'x'='x", "");
            data = data.Replace("' or 'x'='x", "");

            return "'" + data + "'";
        }

        public static String HashPassword(String password)
        {
            String strHash = null;
            String passwordFormat = "SHA1";
            strHash = FormsAuthentication.HashPasswordForStoringInConfigFile(password, passwordFormat);
            return strHash;
        }

        public static DateTime ConvertStringDateToDateTime(string strDate)
        {
            string[] strValue = strDate.Split('-');
            DateTime dateTime;
            if (strValue[2].IndexOf(" ") != -1)
            {
                string[] strData = strValue[2].Split(' ');
                string[] strTime = strData[1].Split(':');
                dateTime = new DateTime(Convert.ToInt32(strValue[0]), Convert.ToInt32(strValue[1]), Convert.ToInt32(strValue[2]), Convert.ToInt32(strTime[0]), Convert.ToInt32(strTime[1]), 0);

            }
            else
            {
                dateTime = new DateTime(Convert.ToInt32(strValue[0]), Convert.ToInt32(strValue[1]), Convert.ToInt32(strValue[2]));

            }

            return dateTime;

        }

        public static DateTime ConvertStringDateToDateTime(string strDate, string strTime)
        {
            string[] strValue = strDate.Split('-');
            DateTime dateTime;
            if (strTime != "" || strTime != null)
            {
                string[] strTimeData = strTime.Split(':');
                dateTime = new DateTime(Convert.ToInt32(strValue[0]), Convert.ToInt32(strValue[1]), Convert.ToInt32(strValue[2]), Convert.ToInt32(strTimeData[0]), Convert.ToInt32(strTimeData[1]), 0);

            }
            else
            {
                dateTime = new DateTime(Convert.ToInt32(strValue[0]), Convert.ToInt32(strValue[1]), Convert.ToInt32(strValue[2]));

            }

            return dateTime;

        }

        public static bool IsDate(Object obj)
        {

            if (obj == null)
            {
                return false;
            }
            string strDate = obj.ToString();

            try
            {
                if (DBDateTime(strDate) == DateTime.MinValue)
                {
                    return false;
                }
                if (DBDateTime(strDate) == DateTime.MaxValue)
                {
                    return false;
                }
                DateTime dt = DateTime.Parse(strDate);
                if ((dt.Day < 1 && dt.Day > 31))
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime DBDateTime(object obj)
        {
            DateTime dt;

            dt = obj == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(obj);

            return dt;
        }
    }
}