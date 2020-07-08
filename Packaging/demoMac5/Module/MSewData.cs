using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;
using Dapper;

namespace demoMac5.Module
{
    public class MSewData
    {
        string msgErr = string.Empty;

        #region -- MSew--
        public void GetMSew(out List<MSew> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<MSew>();
            MSew item = new MSew();
            try
            {

                strSQL = "select *,CONCAT('บาท/',Sew_Uname) as Sew_UnamePrice FROM  [dbo].[M_SEW] where 0=0 and Sew_Delete=0 ";
                if (id > 0)
                {

                    strSQL += " and Sew_Id=" + id;
                }
                ls = objConn.Query<MSew>(strSQL).ToList();

                //DataTable dt = DBHelper.List(strSQL, objConn);

                //if (dt.Rows.Count > 0)
                //{

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        item = new MSew();
                //        item.Sew_Id = Convert.ToInt32(dt.Rows[i]["Sew_Id"].ToString());
                //        item.Sew_Code = dt.Rows[i]["Sew_Code"].ToString();
                //        item.Sew_NameT = dt.Rows[i]["Sew_NameT"].ToString();
                //        item.Sew_NameE = dt.Rows[i]["Sew_NameE"].ToString();
                //        item.Sew_Uname = dt.Rows[i]["Sew_Uname"].ToString();
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

        public void InsertMSew(MSew item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert   [dbo].[M_SEW]
                                           ([Sew_Code]
                                           ,[Sew_NameT]
                                           ,[Sew_NameE]
                                           ,[Sew_Uname]
                                           ,[Sew_CreateUser]
                                           ,[Sew_CreateDate]
                                           ,[Sew_Delete]
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Sew_Code.ToUpper())
                    , Utility.ReplaceString(item.Sew_NameT)
                    , Utility.ReplaceString(item.Sew_NameE)
                    , Utility.ReplaceString(item.Sew_Uname)
                    , 0
                    , "GetDate()"
                    ,0
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

        public void UpdateMSew(MSew item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update M_SEW Set
                                            [Sew_Code]={1}
                                           ,[Sew_NameT]={2}
                                           ,[Sew_NameE]={3}
                                           ,[Sew_Uname]={4}
                                          ,[Sew_EditUser]={5}
                                          ,[Sew_EditDate]={6}
                                    where Sew_Id={0}";

                strSQL = string.Format(strSQL
                   , item.Sew_Id
                   , Utility.ReplaceString(item.Sew_Code.ToUpper())
                   , Utility.ReplaceString(item.Sew_NameT)
                   , Utility.ReplaceString(item.Sew_NameE)
                   , Utility.ReplaceString(item.Sew_Uname)
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

        public void DeleteMSew(MSew item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update M_SEW Set 
                                [Sew_Delete]=1 
                               ,[Sew_DeleteUser] ={1}
                               ,[Sew_DeleteDate]= {2}
                                 where Sew_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Sew_Id,
                    1,// Sew_DeleteUser
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

        #endregion -- MSew--
    }
}