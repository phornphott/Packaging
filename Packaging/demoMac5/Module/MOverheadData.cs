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
   
    public class MOverheadData
    {
        string msgErr = string.Empty;

        #region -- MOverhea--
        public void GetMOverhead(out List<MOverhead> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<MOverhead>();
            MOverhead item = new MOverhead();
            try
            {

                strSQL = "select * FROM  [dbo].[M_OVERHEAD] where 0=0 and Overhead_Delete=0 ";
                if (id > 0)
                {

                    strSQL += " and Overhead_Id=" + id;
                }
                ls = objConn.Query<MOverhead>(strSQL).ToList();

                //DataTable dt = DBHelper.List(strSQL, objConn);

                //if (dt.Rows.Count > 0)
                //{

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        item = new MOverhead();
                //        item.Overhead_Id = Convert.ToInt32(dt.Rows[i]["Overhead_Id"].ToString());
                //        item.Overhead_Code = dt.Rows[i]["Overhead_Code"].ToString();
                //        item.Overhead_NameT = dt.Rows[i]["Overhead_NameT"].ToString();
                //        item.Overhead_NameE = dt.Rows[i]["Overhead_NameE"].ToString();
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

        public void InsertMOverhead(MOverhead item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();
            SqlTransaction tran;

            tran = objConn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                //string strSQL = @"insert   [dbo].[M_OVERHEAD]
                //                           ([Overhead_Code]
                //                           ,[Overhead_NameT]
                //                           ,[Overhead_NameE]
                //                           ,[Overhead_CreateUser]
                //                           ,[Overhead_CreateDate]
                //                           ,[Overhead_Delete]
                //                    ) 
                //                    values({0},{1},{2},{3},{4},{5})";
                //strSQL = string.Format(strSQL
                //    , Utility.ReplaceString(item.Overhead_Code.ToUpper())
                //    , Utility.ReplaceString(item.Overhead_NameT)
                //    , Utility.ReplaceString(item.Overhead_NameE)
                //    , 0
                //    , "GetDate()"
                //    , 0
                //    );

                //DBHelper.Execute(strSQL, objConn);

                string strSQL = "Insert into M_OVERHEAD (Overhead_Code,Overhead_NameT,Overhead_NameE,Overhead_CreateUser,Overhead_CreateDate,Overhead_Delete)"
                              + " values (@Overhead_Code,@Overhead_NameT,@Overhead_NameE,@Overhead_CreateUser,@Overhead_CreateDate,@Overhead_Delete)";

                cmd.CommandText = strSQL;
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Overhead_Code", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Overhead_Code.ToUpper());
                cmd.Parameters.Add("@Overhead_NameT", SqlDbType.NVarChar, 250).Value = Library.DBString(item.Overhead_NameT);
                cmd.Parameters.Add("@Overhead_NameE", SqlDbType.NVarChar, 250).Value = Library.DBString(item.Overhead_NameE);
                cmd.Parameters.Add("@Overhead_CreateUser", SqlDbType.SmallInt).Value = Library.GBuserID;
                cmd.Parameters.Add("@Overhead_CreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Overhead_Delete", SqlDbType.Bit).Value = 0;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
        }

        public void UpdateMOverhead(MOverhead item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update [dbo].[M_OVERHEAD] Set
                                            [Overhead_Code]={1}
                                           ,[Overhead_NameT]={2}
                                           ,[Overhead_NameE]={3}
                                          ,[Overhead_EditUser]={4}
                                          ,[Overhead_EditDate]={5}
                                    where Overhead_Id={0}";

                strSQL = string.Format(strSQL
                   , item.Overhead_Id
                   , Utility.ReplaceString(item.Overhead_Code.ToUpper())
                   , Utility.ReplaceString(item.Overhead_NameT)
                   , Utility.ReplaceString(item.Overhead_NameE)
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

        public void DeleteMOverhead(MOverhead item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update [dbo].[M_OVERHEAD] Set 
                                [Overhead_Delete]=1 
                               ,[Overhead_DeleteUser] ={1}
                               ,[Overhead_DeleteDate]= {2}
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

        #endregion -- MOverhead--
    }
}