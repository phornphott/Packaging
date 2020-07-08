using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class ExpensesHeaderData
    {
        string msgErr = string.Empty;

        #region -- EXPENSES_HEADER--
        public void GetExpensesHeader(out List<EXPENSES_HEADER> ls, int ExpensesHeaderid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<EXPENSES_HEADER>();
            EXPENSES_HEADER item = new EXPENSES_HEADER();
            try
            {

                strSQL = "select * FROM [dbo].[EXPENSES_HEADER] where 0=0 and Expenses_Delete=0 ";
                if (ExpensesHeaderid > 0)
                {

                    strSQL += " and Expenses_Id=" + ExpensesHeaderid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new EXPENSES_HEADER();
                        item.Expenses_Id = Convert.ToInt32(dt.Rows[i]["Expenses_Id"].ToString());
                        item.Expenses_Name = dt.Rows[i]["Expenses_Name"].ToString();
                        item.Expenses_Use = Convert.ToBoolean(dt.Rows[i]["Expenses_Use"].ToString());
                        item.Expenses_UseDate = Convert.ToBoolean(dt.Rows[i]["Expenses_UseDate"].ToString());
                        item.Expenses_DateStart = Convert.ToDateTime(dt.Rows[i]["Expenses_DateStart"].ToString());
                        item.Expenses_DateEnd = Convert.ToDateTime(dt.Rows[i]["Expenses_DateEnd"].ToString());
                        item.Expenses_DateStart_Input = item.Expenses_DateStart.ToShortDateString();
                        item.Expenses_DateEnd_Input = item.Expenses_DateEnd.ToShortDateString();
                        item.Expenses_Desc = dt.Rows[i]["Expenses_Desc"].ToString();
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

        public void InsertExpensesHeader(EXPENSES_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into EXPENSES_HEADER(
                                   Expenses_Name
                                   ,Expenses_Use
                                   ,Expenses_UseDate
                                   ,Expenses_DateStart
                                   ,Expenses_DateEnd
                                   ,Expenses_Desc
                                   ,Expenses_CreateUser	
                                   ,Expenses_CreateDate	
                                   ,Expenses_Delete
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Expenses_Name)
                    , item.Expenses_Use == true ? -1 : 0
                    , item.Expenses_UseDate == true ? -1 : 0
                    , Utility.FormateDateTime(item.Expenses_DateStart)
                    , Utility.FormateDateTime(item.Expenses_DateEnd)
                    , Utility.ReplaceString(item.Expenses_Desc ?? "")
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

        public void UpdateExpensesHeader(EXPENSES_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update EXPENSES_HEADER Set
                                    Expenses_Name={1},
                                    Expenses_Use={2},
                                    Expenses_UseDate={3},
                                    Expenses_DateStart={4},
                                    Expenses_DateEnd={5},
                                     Expenses_Desc={6},
                                    Expenses_EditUser=0,
                                    Expenses_EditDate=GetDate()
                                    where Expenses_Id={0}";

                strSQL = string.Format(strSQL
                    , item.Expenses_Id
                    , Utility.ReplaceString(item.Expenses_Name)
                   , item.Expenses_Use == true ? -1 : 0
                    , item.Expenses_UseDate == true ? -1 : 0
                    , Utility.FormateDate(item.Expenses_DateStart)
                    , Utility.FormateDate(item.Expenses_DateEnd)
                    , Utility.ReplaceString(item.Expenses_Desc));

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

        public void DeleteExpensesHeader(EXPENSES_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update EXPENSES_HEADER Set 
Expenses_Delete=1 , Expenses_DeleteUser ={1} ,Expenses_DeleteDate= {2}
                                    where Expenses_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Expenses_Id,
                    1,// Expenses_DeleteUser
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

        #endregion -- EXPENSES_HEADER--
    }
}