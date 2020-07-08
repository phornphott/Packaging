
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class OverheadDetailData
    {
        string msgErr = string.Empty;

        #region -- OVERHEAD_DETAIL--
        public void GetOverheadDetail(out List<OVERHEAD_DETAIL> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<OVERHEAD_DETAIL>();
            OVERHEAD_DETAIL item = new OVERHEAD_DETAIL();
            try
            {

                strSQL = @"select a.*,b.Overhead_Name FROM [dbo].[OVERHEAD_DETAIL] a 
                            left join [dbo].[OVERHEAD_HEADER] b on a.Overhead_Id=b.Overhead_Id
                            where 0=0 and a.Overhead_D_Delete=0 ";
                if (id > 0)
                {

                    strSQL += " and a.Overhead_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new OVERHEAD_DETAIL();
                        item.Overhead_D_Id = Convert.ToInt32(dt.Rows[i]["Overhead_D_Id"].ToString());
                        item.Overhead_Id = Convert.ToInt32(dt.Rows[i]["Overhead_Id"].ToString());
                        item.Deparment_Id = Convert.ToInt32(dt.Rows[i]["Deparment_Id"].ToString());
                        item.Overhead_Header_Name= dt.Rows[i]["Overhead_Name"].ToString() ?? "";
                        item.Overhead_D_Code = dt.Rows[i]["Overhead_D_Code"].ToString()??"";
                        item.Overhead_D_Desc = dt.Rows[i]["Overhead_D_Desc"].ToString() ?? "";
                        item.Overhead_D_Uname = dt.Rows[i]["Overhead_D_Uname"].ToString() ?? "";
                        item.Overhead_D_Uprice = Convert.ToDecimal(dt.Rows[i]["Overhead_D_Uprice"].ToString());
                        item.Overhead_D_Memo = dt.Rows[i]["Overhead_D_Memo"].ToString() ?? "";
                        item.Overhead_D_Listno = i+1;
                        item.Overhead_D_CreateUser = Convert.ToInt32(dt.Rows[i]["Overhead_D_CreateUser"].ToString());
       
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

        public void InsertOverheadDetail(OVERHEAD_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into OVERHEAD_DETAIL(
                                   [Overhead_Id]
                                  ,[Deparment_Id]
                                  ,[Overhead_D_Code]
                                  ,[Overhead_D_Desc]
                                  ,[Overhead_D_Uname]
                                  ,[Overhead_D_Uprice]
                                  ,[Overhead_D_Memo]
                                  ,[Overhead_D_Listno]
                                  ,[Overhead_D_CreateUser]
                                  ,[Overhead_D_CreateDate]
                                 ,[Overhead_D_Delete]
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})";
                strSQL = string.Format(strSQL
                    ,item.Overhead_Id
                    , item.Deparment_Id
                    , Utility.ReplaceString(item.Overhead_D_Code )
                    , Utility.ReplaceString(item.Overhead_D_Desc)
                    , Utility.ReplaceString(item.Overhead_D_Uname)
                    , item.Overhead_D_Uprice
                    , Utility.ReplaceString(item.Overhead_D_Memo ?? "")
                    ,item.Overhead_D_Listno
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

        public void UpdateOverheadDetail(OVERHEAD_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @" UPDATE [dbo].[OVERHEAD_DETAIL]
                                       SET [Overhead_Id] = {1}
                                          ,[Deparment_Id] ={2}
                                          ,[Overhead_D_Code] = {3}
                                          ,[Overhead_D_Desc] = {4}
                                          ,[Overhead_D_Uname] = {5}
                                          ,[Overhead_D_Uprice] = {6}
                                          ,[Overhead_D_Memo] ={7}
                                          ,[Overhead_D_Listno] = {8}
                                          ,[Overhead_D_EditUser] ={9}
                                          ,[Overhead_D_EditDate] = {10}
                                     WHERE [Overhead_D_Id]={0}";

                strSQL = string.Format(strSQL
                    , item.Overhead_D_Id
                    , item.Overhead_Id
                    , item.Deparment_Id
                    , Utility.ReplaceString(item.Overhead_D_Code)
                    , Utility.ReplaceString(item.Overhead_D_Desc)
                    , Utility.ReplaceString(item.Overhead_D_Uname)
                    , item.Overhead_D_Uprice
                    , Utility.ReplaceString(item.Overhead_D_Memo ?? "")
                    , 0
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

        public void DeleteOverheadDetail(OVERHEAD_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update OVERHEAD_DETAIL Set 
                                    Overhead_D_Delete=1 ,
                                    Overhead_D_DeleteUser ={1} ,
                                    Overhead_D_DeleteDate= {2}
                                     where Overhead_D_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Overhead_D_Id,
                    1,// Overhead_D_DeleteUser
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

        #endregion -- OVERHEAD_DETAIL--
    }
}