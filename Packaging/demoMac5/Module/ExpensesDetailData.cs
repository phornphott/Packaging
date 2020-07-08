

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class ExpensesDetailData
    {
        string msgErr = string.Empty;

        #region -- EXPENSES_DETAIL--
        public void GetExpensesDetail(out List<EXPENSES_DETAIL> ls, int ExpensesDetailid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<EXPENSES_DETAIL>();
            EXPENSES_DETAIL item = new EXPENSES_DETAIL();
            try
            {

                strSQL = @"select a.*,b.Expenses_Name  FROM [dbo].[EXPENSES_DETAIL] a
                        left join  [dbo].[EXPENSES_HEADER] b on a.EXPENSES_Id=b.Expenses_Id
                        where 0=0 and a.Expenses_D_Delete=0 ";
                if (ExpensesDetailid > 0)
                {

                    strSQL += " and a.Expenses_D_Id=" + ExpensesDetailid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new EXPENSES_DETAIL();
                        item.Expenses_D_Id = Convert.ToInt32(dt.Rows[i]["Expenses_D_Id"].ToString());
                        item.Expenses_Id = Convert.ToInt32(dt.Rows[i]["Expenses_Id"].ToString());
                        item.Expense_Id = Convert.ToInt32(dt.Rows[i]["Expense_Id"].ToString());
                        item.Expenses_Header_Name = dt.Rows[i]["Expenses_Name"].ToString();
                      
                        item.Expenses_D_Code = dt.Rows[i]["Expenses_D_Code"].ToString()??"";
                        item.Expenses_D_Desc = dt.Rows[i]["Expenses_D_Desc"].ToString() ?? "";
                        item.Expenses_D_Uname = dt.Rows[i]["Expenses_D_Uname"].ToString() ?? "";
                        item.Expenses_D_Uprice= Convert.ToDecimal(dt.Rows[i]["Expenses_D_Uprice"].ToString());
                        item.Expenses_D_Memo= dt.Rows[i]["Expenses_D_Memo"].ToString();
                        item.Expenses_D_Listno=Convert.ToInt32(dt.Rows[i]["Expenses_D_Listno"].ToString());



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

        public void InsertExpensesDetail(EXPENSES_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into EXPENSES_DETAIL(
                                       [Expenses_Id]
                                      ,[Expense_Id]
                                      ,[Expenses_D_Code]
                                      ,[Expenses_D_Desc]
                                      ,[Expenses_D_Uname]
                                      ,[Expenses_D_Uprice]
                                      ,[Expenses_D_Memo]
                                      ,[Expenses_D_Listno]
                                      ,[Expenses_D_CreateUser]
                                      ,[Expenses_D_CreateDate]
                                       ,[Expenses_D_Delete]
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})";
                strSQL = string.Format(strSQL
                    , item.Expenses_Id
                    , item.Expense_Id
                    , Utility.ReplaceString(item.Expenses_D_Code??"")
                    , Utility.ReplaceString(item.Expenses_D_Desc ?? "")
                    , Utility.ReplaceString(item.Expenses_D_Uname ?? "")
                    , item.Expenses_D_Uprice
                    , Utility.ReplaceString(item.Expenses_D_Memo ?? "")
                    , item.Expenses_D_Listno
                    ,0
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

        public void UpdateExpensesDetail(EXPENSES_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update EXPENSES_DETAIL Set
                                    [Expenses_Id]={1}
                                  ,[Expense_Id]={2}
                                  ,[Expenses_D_Code]={3}
                                  ,[Expenses_D_Desc]={4}
                                  ,[Expenses_D_Uname]={5}
                                  ,[Expenses_D_Uprice]={6}
                                  ,[Expenses_D_Memo]={7}
                                  ,[Expenses_D_Listno]={8}
                                  ,[Expenses_D_EditUser]={9}
                                  ,[Expenses_D_EditDate]={10}
                                    where Expenses_D_Id={0}";

                strSQL = string.Format(strSQL
                    , item.Expenses_D_Id
                    , item.Expenses_Id
                    , item.Expense_Id
                    , Utility.ReplaceString(item.Expenses_D_Code)
                    , Utility.ReplaceString(item.Expenses_D_Desc)
                    , Utility.ReplaceString(item.Expenses_D_Uname)
                    , item.Expenses_D_Uprice
                    , Utility.ReplaceString(item.Expenses_D_Memo)
                    , item.Expenses_D_Listno
                    , 0
                    , "GetDate()"
                
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

        public void DeleteExpensesDetail(EXPENSES_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update EXPENSES_DETAIL Set 
                                    Expenses_D_Delete=1 ,
                                    Expenses_D_DeleteUser ={1} ,
                                    Expenses_D_DeleteDate= {2}
                                    where Expenses_D_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Expenses_D_Id,
                    1,// Expenses_D_DeleteUser
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

        #endregion -- EXPENSES_DETAIL--
    }
}