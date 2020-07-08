using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class Library
    {
        static string msgErr = string.Empty;
        public static int GBuserID = 0;

        public static DateTime Date_CvDMY(int dd, int mm, int yy, bool Tdisp)
        {
            //Get And Check And Assign to Public Function the Input Date String
            //Data must be integer of Date,Month,Year
            int Yx;

            Yx = yy;
            if (Tdisp)
            {
                Yx = Yx - 543;
            }

            if (Date_ValidIDMY(dd, mm, Yx))
            {
                string Xdate = dd.ToString("00") + "/" + mm.ToString("00") + "/" + Yx.ToString("0000");
                return Convert.ToDateTime(Xdate);
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static bool Date_ValidIDMY(int Dx, int Mx, int Yx)
        {
            bool functionReturnValue = false;
            //Xdate is in English Year ONLY
            if ((Mx < 1) | (Mx > 12))
                goto VDinvalidIDMY;
            if ((Dx < 1) | (Dx > DateTime.DaysInMonth(Yx,Mx)))
                goto VDinvalidIDMY;
            functionReturnValue = true;
            return functionReturnValue;
        VDinvalidIDMY:
            functionReturnValue = false;
            return functionReturnValue;
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
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

        public static byte DBByte(object obj)
        {
            byte i;
            try
            {
                i = obj == DBNull.Value ? (byte)0 : Convert.ToByte(obj);
            }
            catch
            {
                i = 0;
            }
            return i;
        }

        public static decimal DBDecimal(object obj)
        {
            decimal dec;

            try
            {
                dec = obj == DBNull.Value ? 0 : Convert.ToDecimal(obj);
            }
            catch
            {
                dec = 0;
            }

            return dec;
        }

        public static Int16 DBInt16(object obj)
        {
            Int16 i;

            try
            {
                i = obj == DBNull.Value ? (Int16)0 : Convert.ToInt16(obj);
            }
            catch
            {
                i = 0;
            }

            return i;
        }

        public static int DBInt(object obj)
        {
            int i;

            try
            {
                i = obj == DBNull.Value ? 0 : Convert.ToInt32(obj);
            }
            catch
            {
                i = 0;
            }

            return i;
        }

        public static ulong DBUInt64(object obj)
        {
            ulong i;

            try
            {
                i = obj == DBNull.Value ? 0 : Convert.ToUInt64(obj);
            }
            catch
            {
                i = 0;
            }

            return i;
        }

        public static string DBString(object obj)
        {
            string str;

            str = obj == DBNull.Value ? "" : Convert.ToString(obj);

            return str;
        }

        public static DateTime DBDateTime(object obj)
        {
            DateTime dt;

            dt = obj == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(obj);

            return dt;
        }

        public static double DBDouble(object obj)
        {
            double db;

            try
            {
                db = obj == DBNull.Value ? 0 : Convert.ToDouble(obj);
            }
            catch
            {
                db = 0;
            }

            return db;
        }

        public static bool DBbool(object obj)
        {
            bool ok;

            ok = obj == DBNull.Value ? false : Convert.ToBoolean(obj);

            return ok;
        }

        public static string SequenceStr(string Xval)
        {
            int i, j, ch, NoS;
            string Xsequnce = "";
            string[] Xarr = new string[0];


            Xsequnce = "";
            if (Xval.Length == 0) return
            Xsequnce = Xval;
            //ReDim Xarr(1)
            NoS = Xval.Length;
            Array.Resize(ref Xarr, NoS);
            //ReDim Xarr(NoS)
            for (i = 0; i < NoS; i++)
            {
                Xarr[i] = Xval.Substring(i, 1);
            }

            j = 1;
            for (i = NoS - 1; i >= 0; i = i - 1)
            {
                ch = Convert.ToInt32(Xarr[i]);
                ch = ch + j;
                switch (ch)
                {
                    case 91:
                        Xarr[i] = Convert.ToString((char)65);
                        j = 1;
                        break;
                    case 207:
                        Xarr[i] = Convert.ToString((char)161);
                        j = 1;
                        break;
                    case 58:
                        Xarr[i] = Convert.ToString((char)48);
                        j = 1;
                        break;
                    case 256:
                        i = 0;
                        break;
                    default:
                        Xarr[i] = Convert.ToString(ch);
                        i = 0;
                        break;
                }
            }

            Xsequnce = "";
            for (i = 0; i < NoS; i++)
            {
                Xsequnce = Xsequnce + Xarr[i];
            }
            //Xsequnce = XYZremoveFLCNL(Xsequnce, Chr$(255))
            return Xsequnce;
        }

        #region -- Check Code -- 
        public static bool CheckExistCode(string vTable, int vID, string vCode)
        {
            bool OK = false;
            DataTable dt;
            int id = 0;
            string tf = string.Empty;
            string tfid = string.Empty;
            string tfdelete = string.Empty;
            msgErr = "";

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                switch (vTable)
                {
                    case "STG":
                        tfid = "STGid";
                        tf = "STGcode";
                        break;
                    case "STK":
                        tfid = "STKid";
                        tf = "STKcode";
                        break;
                    case "DEG":
                        tfid = "DEGid";
                        tf = "DEGcode";
                        break;
                    case "DEB":
                        tfid = "DEBid";
                        tf = "DEBcode";
                        break;
                    case "PER":
                        tfid = "PERid";
                        tf = "PERcode";
                        break;
                    case "JOB":
                        tfid = "JOBid";
                        tf = "JOBcode";
                        break;
                    case "M_DEPARTMENT":
                        tfid = "Department_Id";
                        tf = "Department_Code";
                        break;
                    case "M_PLASTIC":
                        tfid = "Plastic_Id";
                        tf = "Plastic_Code";
                        break;
                    case "M_PRINT":
                        tfid = "Print_Id";
                        tf = "Print_Code";
                        break;
                    case "M_EQUIPMENT":
                        tfid = "Equipment_Id";
                        tf = "Equipment_Code";
                        break;
                    case "M_SEW":
                        tfid = "Sew_Id";
                        tf = "Sew_Code";
                        break;
                    case "M_EXPENSE":
                        tfid = "Expense_Id";
                        tf = "Expense_Code";
                        break;
                    case "M_OVERHEAD":
                        tfid = "Overhead_Id";
                        tf = "Overhead_Code";
                        break;
                    case "CLIPBOARD":
                        tfid = "Clipboard_Id";
                        tf = "Clipboard_Nos";
                        break;
                }
                string strSQL = @"select * from " + vTable + " where " + tf + "={0}";
                switch (vTable)
                {
                    case "M_DEPARTMENT":
                        tfid = "Department_Id";
                        tf = "Department_Code";
                        tfdelete = "Department_Delete";
                        break;
                    case "M_PLASTIC":
                        tfid = "Plastic_Id";
                        tf = "Plastic_Code";
                        tfdelete = "Plastic_Delete";
                        break;
                    case "M_PRINT":
                        tfid = "Print_Id";
                        tf = "Print_Code";
                        tfdelete = "Print_Delete";
                        break;
                    case "M_EQUIPMENT":
                        tfid = "Equipment_Id";
                        tf = "Equipment_Code";
                        tfdelete = "Equipment_Delete";
                        break;
                    case "M_SEW":
                        tfid = "Sew_Id";
                        tf = "Sew_Code";
                        tfdelete = "Sew_Delete";
                        break;
                    case "M_EXPENSE":
                        tfid = "Expense_Id";
                        tf = "Expense_Code";
                        tfdelete = "Expense_Delete";
                        break;
                    case "CLIPBOARD":
                        tfid = "Clipboard_Id";
                        tf = "Clipboard_Nos";
                        tfdelete = "Clipboard_Delete";
                        break;
                    default:
                        tfdelete = "";
                        break;
                }
                if (tfdelete.Length > 0)
                {
                    strSQL += " and " + tfdelete + "=0";
                }
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(vCode));

                dt = DBHelper.List(strSQL, objConn);
                if (dt.Rows.Count > 0)
                {
                    if (vID > 0)
                    {
                        id = Convert.ToInt32(dt.Rows[0][tfid]);
                        if (vID != id)
                        {
                            OK = true;
                        }
                    }
                    else
                    {
                        OK = true;
                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
            return OK;
        }
        #endregion

        #region -- Check Data --
        public static string GetRunVoucher(int mode, int id, string Xf, int Xyear, int Xmonth = 0)
        {
            DataTable dt = new DataTable("Voucher");
            SqlDataAdapter da = null;
            string sql = string.Empty;
            string Xnos = "";
            string Xvnos = "";
            string Tyear = "";
            int Xy = 0;

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);

            try
            {
                Xy = Xyear;
                //if (Xy < 2500) Xy += 543;
                Tyear = DBString(Xy);

                Tyear = Tyear.Substring(Tyear.Length - 2, 2);
                if (Xf.Length > 0)
                {
                    sql = "Select top 1 " + Xf + " From CLIPBOARD where Clipboard_Delete =@Clipboard_Delete";
                }
                else
                {
                    sql = "Select top 1 Clipboard_Nos From CLIPBOARD where Clipboard_Delete=@Clipboard_Delete";
                }
                Xnos = Tyear + "%";
                sql += " and Clipboard_Nos Like '" + Xnos + "'";

                if (mode == 1)
                {
                    sql += " and year(Clipboard_Date)=@V_Year";
                    if (Xmonth > 0)
                    {
                        sql += " and month(Clipboard_Date)=@V_month";
                    }
                }


                sql += " Order By Clipboard_Date desc,Clipboard_Nos ";
                da = new SqlDataAdapter(sql, objConn);
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.Add("@Clipboard_Delete", SqlDbType.Bit).Value = 0;
                if (mode == 1)
                {
                    da.SelectCommand.Parameters.Add("@V_Year", SqlDbType.Int).Value = Xyear;
                    if (Xmonth > 0)
                    {
                        da.SelectCommand.Parameters.Add("@V_month", SqlDbType.Int).Value = Xmonth;
                    }
                }
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Xvnos = DBString(dt.Rows[0]["Clipboard_Nos"]);
                }
            }
            catch
            {
                dt = null;
            }
            finally
            {
                objConn.Close();
            }
            return Xvnos;
        }
        #endregion
    }
}