
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class OverHeadHeaderData
    {
        string msgErr = string.Empty;

        #region -- OVERHEAD_HEADER--
        public void GetOverheadHeader(out List<OVERHEAD_HEADER> ls, int OverheadHeaderid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<OVERHEAD_HEADER>();
            OVERHEAD_HEADER item = new OVERHEAD_HEADER();
            try
            {

                strSQL = "select * FROM [dbo].[OVERHEAD_HEADER] where 0=0 and Overhead_Delete=0 ";
                if (OverheadHeaderid > 0)
                {

                    strSQL += " and Overhead_Id=" + OverheadHeaderid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new OVERHEAD_HEADER();
                        item.Overhead_Id = Convert.ToInt32(dt.Rows[i]["Overhead_Id"].ToString());
                        item.Overhead_Name = dt.Rows[i]["Overhead_Name"].ToString();
                        item.Overhead_Use = Convert.ToBoolean(dt.Rows[i]["Overhead_Use"].ToString());
                        item.Overhead_UseDate = Convert.ToBoolean(dt.Rows[i]["Overhead_UseDate"].ToString());
                        item.Overhead_DateStart = Convert.ToDateTime(dt.Rows[i]["Overhead_DateStart"].ToString());
                        item.Overhead_DateEnd = Convert.ToDateTime(dt.Rows[i]["Overhead_DateEnd"].ToString());
                        item.Overhead_DateStart_Input = item.Overhead_DateStart.ToShortDateString();
                        item.Overhead_DateEnd_Input = item.Overhead_DateEnd.ToShortDateString();
                        item.Overhead_Desc = dt.Rows[i]["Overhead_Desc"].ToString();
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

        public void InsertOverheadHeader(OVERHEAD_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into OVERHEAD_HEADER(
                                   Overhead_Name
                                   ,Overhead_Use
                                   ,Overhead_UseDate
                                   ,Overhead_DateStart
                                   ,Overhead_DateEnd
                                   ,Overhead_Desc
                                   ,Overhead_CreateUser	
                                   ,Overhead_CreateDate	
                                   ,Overhead_Delete
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Overhead_Name)
                    , item.Overhead_Use == true ? -1 : 0
                    , item.Overhead_UseDate == true ? -1 : 0
                    , Utility.FormateDateTime(item.Overhead_DateStart)
                    , Utility.FormateDateTime(item.Overhead_DateEnd)
                    , Utility.ReplaceString(item.Overhead_Desc ?? "")
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

        public void UpdateOverheadHeader(OVERHEAD_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update OVERHEAD_HEADER Set
                                    Overhead_Name={1},
                                    Overhead_Use={2},
                                    Overhead_UseDate={3},
                                    Overhead_DateStart={4},
                                    Overhead_DateEnd={5},
                                     Overhead_Desc={6},
                                    Overhead_EditUser=0,
                                    Overhead_EditDate=GetDate()
                                    where Overhead_Id={0}";

                strSQL = string.Format(strSQL
                    , item.Overhead_Id
                    , Utility.ReplaceString(item.Overhead_Name)
                   , item.Overhead_Use == true ? -1 : 0
                    , item.Overhead_UseDate == true ? -1 : 0
                    , Utility.FormateDate(item.Overhead_DateStart)
                    , Utility.FormateDate(item.Overhead_DateEnd)
                    , Utility.ReplaceString(item.Overhead_Desc));

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

        public void DeleteOverheadHeader(OVERHEAD_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update OVERHEAD_HEADER Set 
Overhead_Delete=1 , Overhead_DeleteUser ={1} ,Overhead_DeleteDate= {2}
                                    where Overhead_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Overhead_Id,
                    1,// Overhead_DeleteUser
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

        #endregion -- OVERHEAD_HEADER--
    }
}