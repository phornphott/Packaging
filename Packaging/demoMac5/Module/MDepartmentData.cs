using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class MDepartmentData
    {
        string msgErr = string.Empty;

        #region -- MDepartment--
        public void GetMDepartment(out List<MDepartment> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<MDepartment>();
            MDepartment item = new MDepartment();
            try
            {

                strSQL = "select * FROM [dbo].[M_DEPARTMENT] where 0=0 and Department_Delete=0 ";
                if (id > 0)
                {

                    strSQL += " and Department_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new MDepartment();
                        item.Department_Id = Convert.ToInt32(dt.Rows[i]["Department_Id"].ToString());
                        item.Department_Code = dt.Rows[i]["Department_Code"].ToString();
                        item.Department_NameT = dt.Rows[i]["Department_NameT"].ToString();
                        item.Department_NameE = dt.Rows[i]["Department_NameE"].ToString();
                        item.Department_Uname = "บาท/กก.";
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

        public void InsertMDepartment(MDepartment item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert   [dbo].[M_DEPARTMENT]
                                           ([Department_Code]
                                           ,[Department_NameT]
                                           ,[Department_NameE]
                                           ,[Department_CreateUser]
                                           ,[Department_CreateDate]
                                            ,[Department_Delete]
                                    ) 
                                    values({0},{1},{2},{3},{4},0)";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Department_Code.ToUpper())
                    , Utility.ReplaceString(item.Department_NameT)
                    , Utility.ReplaceString(item.Department_NameE)
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

        public void UpdateMDepartment(MDepartment item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update    [dbo].[M_DEPARTMENT] Set
                                            [Department_Code]={0}
                                           ,[Department_NameT]={1}
                                           ,[Department_NameE]={2}
                                          ,[Department_EditUser]={3}
                                          ,[Department_EditDate]={4}
                                    where Department_Id={5}";

                strSQL = string.Format(strSQL
                   , Utility.ReplaceString(item.Department_Code.ToUpper())
                   , Utility.ReplaceString(item.Department_NameT)
                   , Utility.ReplaceString(item.Department_NameE)
                   , 0
                   , "GetDate()"
                    , item.Department_Id
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

        public void DeleteMDepartment(MDepartment item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update  [dbo].[M_DEPARTMENT] Set 
                                [Department_Delete]=1  
                               ,[Department_DeleteUser] ={1}
                               ,[Department_DeleteDate]= {2}
                                 where Department_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Department_Id,
                    1,// Department_DeleteUser
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

        #endregion -- MDepartment--
    }
}