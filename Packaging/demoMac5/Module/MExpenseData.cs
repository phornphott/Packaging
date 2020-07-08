using Dapper;
using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
   
    public class MExpenseData
    {
        string msgErr = string.Empty;

        #region -- MExpense--
        public void GetMExpense(out List<MExpense> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<MExpense>();
            MExpense item = new MExpense();
            try
            {

                strSQL = "select * FROM  [dbo].[M_Expense] where 0=0 and Expense_Delete=0 ";
                if (id > 0)
                {

                    strSQL += " and Expense_Id=" + id;
                }
                ls = objConn.Query<MExpense>(strSQL).ToList();

                //DataTable dt = DBHelper.List(strSQL, objConn);

                //if (dt.Rows.Count > 0)
                //{

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        item = new MExpense();
                //        item.Expense_Id = Convert.ToInt32(dt.Rows[i]["Expense_Id"].ToString());
                //        item.Expense_Code = dt.Rows[i]["Expense_Code"].ToString();
                //        item.Expense_NameT = dt.Rows[i]["Expense_NameT"].ToString();
                //        item.Expense_NameE = dt.Rows[i]["Expense_NameE"].ToString();
                //        ls.Add(item);
                //    }
                //}
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

        public void InsertMExpense(MExpense item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert   [dbo].[M_Expense]
                                           ([Expense_Code]
                                           ,[Expense_NameT]
                                           ,[Expense_NameE]
                                           ,[Expense_CreateUser]
                                           ,[Expense_CreateDate]
                                           ,[Expense_Delete]
                                    ) 
                                    values({0},{1},{2},{3},{4},{5})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Expense_Code.ToUpper())
                    , Utility.ReplaceString(item.Expense_NameT)
                    , Utility.ReplaceString(item.Expense_NameE)
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

        public void UpdateMExpense(MExpense item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update [dbo].[M_Expense] Set
                                            [Expense_Code]={1}
                                           ,[Expense_NameT]={2}
                                           ,[Expense_NameE]={3}
                                          ,[Expense_EditUser]={4}
                                          ,[Expense_EditDate]={5}
                                    where Expense_Id={0}";

                strSQL = string.Format(strSQL
                   , item.Expense_Id
                   , Utility.ReplaceString(item.Expense_Code.ToUpper())
                   , Utility.ReplaceString(item.Expense_NameT)
                   , Utility.ReplaceString(item.Expense_NameE)
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

        public void DeleteMExpense(MExpense item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update [dbo].[M_Expense] Set 
                                [Expense_Delete]=1 
                               ,[Expense_DeleteUser] ={1}
                               ,[Expense_DeleteDate]= {2}
                                 where Expense_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Expense_Id,
                    1,// Expense_DeleteUser
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

        #endregion -- MExpense--
    }
}