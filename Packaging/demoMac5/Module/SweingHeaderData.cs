
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class SweingHeaderData
    {
        string msgErr = string.Empty;

        #region -- SEWING_HEADER--
        public void GetSweingHeader(out List<SEWING_HEADER> ls, int SweingHeaderid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<SEWING_HEADER>();
            SEWING_HEADER item = new SEWING_HEADER();
            try
            {

                strSQL = "select * FROM [dbo].[SEWING_HEADER] where 0=0 and Sewing_Delete=0 ";
                if (SweingHeaderid > 0)
                {

                    strSQL += " and Sewing_Id=" + SweingHeaderid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new SEWING_HEADER();
                        item.Sewing_Id = Convert.ToInt32(dt.Rows[i]["Sewing_Id"].ToString());
                        item.Sewing_Name = dt.Rows[i]["Sewing_Name"].ToString();
                        item.Sewing_Use = Convert.ToBoolean(dt.Rows[i]["Sewing_Use"].ToString());
                        item.Sewing_UseDate = Convert.ToBoolean(dt.Rows[i]["Sewing_UseDate"].ToString());
                        item.Sewing_DateStart = Convert.ToDateTime(dt.Rows[i]["Sewing_DateStart"].ToString());
                        item.Sewing_DateEnd = Convert.ToDateTime(dt.Rows[i]["Sewing_DateEnd"].ToString());
                        item.Sewing_DateStart_Input = item.Sewing_DateStart.ToShortDateString();
                        item.Sewing_DateEnd_Input = item.Sewing_DateEnd.ToShortDateString();
                        item.Sewing_Desc = dt.Rows[i]["Sewing_Desc"].ToString();
                        ls.Add(item);
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

        }

        public void InsertSweingHeader(SEWING_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into SEWING_HEADER(
                                   Sewing_Name
                                   ,Sewing_Use
                                   ,Sewing_UseDate
                                   ,Sewing_DateStart
                                   ,Sewing_DateEnd
                                   ,Sewing_Desc
                                   ,Sewing_CreateUser	
                                   ,Sewing_CreateDate	
                                   ,Sewing_Delete
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Sewing_Name)
                    , item.Sewing_Use == true ? -1 : 0
                    , item.Sewing_UseDate == true ? -1 : 0
                    , Utility.FormateDateTime(item.Sewing_DateStart)
                    , Utility.FormateDateTime(item.Sewing_DateEnd)
                    , Utility.ReplaceString(item.Sewing_Desc ?? "")
                    , 0
                    , "GetDate()"
                    , 0
                    );

                DBHelper.Execute(strSQL, objConn);

            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
        }

        public void UpdateSweingHeader(SEWING_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SEWING_HEADER Set
                                    Sewing_Name={1},
                                    Sewing_Use={2},
                                    Sewing_UseDate={3},
                                    Sewing_DateStart={4},
                                    Sewing_DateEnd={5},
                                     Sewing_Desc={6},
                                    Sewing_EditUser=0,
                                    Sewing_EditDate=GetDate()
                                    where Sewing_Id={0}";

                strSQL = string.Format(strSQL
                    , item.Sewing_Id
                    , Utility.ReplaceString(item.Sewing_Name)
                   , item.Sewing_Use == true ? -1 : 0
                    , item.Sewing_UseDate == true ? -1 : 0
                    , Utility.FormateDate(item.Sewing_DateStart)
                    , Utility.FormateDate(item.Sewing_DateEnd)
                    , Utility.ReplaceString(item.Sewing_Desc));

                DBHelper.Execute(strSQL, objConn);

            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
        }

        public void DeleteSweingHeader(SEWING_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SEWING_HEADER Set 
Sewing_Delete=1 , Sewing_DeleteUser ={1} ,Sewing_DeleteDate= {2}
                                    where Sewing_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Sewing_Id,
                    1,// Sewing_DeleteUser
                    "GetDate()");

                DBHelper.Execute(strSQL, objConn);

            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
        }

        #endregion -- SEWING_HEADER--
    }
}