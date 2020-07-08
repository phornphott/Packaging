using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;


namespace demoMac5.Module
{

    public class SweingDetailData
    {
        string msgErr = string.Empty;

        #region -- SEWING_DETAIL--
        public void GetSweingDetail(out List<SEWING_DETAIL> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<SEWING_DETAIL>();
            SEWING_DETAIL item = new SEWING_DETAIL();
            try
            {

                strSQL = @"select a.*,b.Sewing_Name FROM [dbo].[SEWING_DETAIL]  a
                    left join [dbo].[SEWING_HEADER] b on a.Sewing_Id=b.Sewing_Id

                    where 0=0 and a.Sewing_D_Delete=0 ";
                if (id > 0)
                {

                    strSQL += " and a.Sewing_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new SEWING_DETAIL();
                        item.Sewing_D_Id = Convert.ToInt32(dt.Rows[i]["Sewing_D_Id"].ToString());
                        item.Sewing_Id = Convert.ToInt32(dt.Rows[i]["Sewing_Id"].ToString());
                        item.Sew_Id = Convert.ToInt32(dt.Rows[i]["Sew_Id"].ToString());
                        item.Sewing_Header_Name = dt.Rows[i]["Sewing_Name"].ToString();
                        item.Sewing_D_Code = dt.Rows[i]["Sewing_D_Code"].ToString();
                        item.Sewing_D_Desc = dt.Rows[i]["Sewing_D_Desc"].ToString();
                        item.Sewing_D_Uname = dt.Rows[i]["Sewing_D_Uname"].ToString();
                        item.Sewing_D_Uprice = Convert.ToDecimal(dt.Rows[i]["Sewing_D_Uprice"].ToString());
                        item.Sewing_D_Memo = dt.Rows[i]["Sewing_D_Memo"].ToString();
                        item.Sewing_D_Listno = i + 1;
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

        public void InsertSweingDetail(SEWING_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();
            SqlTransaction tran;

            tran = objConn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                ////string strSQL = @"insert into SEWING_DETAIL(
                ////                   [Sewing_Id]
                ////                  ,[Sew_Id]
                ////                  ,[Sewing_D_Code]
                ////                  ,[Sewing_D_Desc]
                ////                  ,[Sewing_D_Uname]
                ////                  ,[Sewing_D_Uprice]
                ////                  ,[Sewing_D_Memo]
                ////                  ,[Sewing_D_Listno]
                ////                  ,[Sewing_D_CreateUser]
                ////                  ,[Sewing_D_CreateDate]
                ////                   ,Sewing_D_Delete) 
                ////                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},0)";
                ////strSQL = string.Format(strSQL
                ////     , item.Sewing_Id
                ////     , item.Sew_Id
                ////    , Utility.ReplaceString(item.Sewing_D_Code)
                ////    , Utility.ReplaceString(item.Sewing_D_Desc)
                ////    , Utility.ReplaceString(item.Sewing_D_Uname)
                ////    , item.Sewing_D_Uprice
                ////    , Utility.ReplaceString(item.Sewing_D_Memo)
                ////    , item.Sewing_D_Listno
                ////    , 0
                ////    , "GetDate()"
                ////    ,0);


                //DBHelper.Execute(strSQL, objConn);

                string strSQL = "Insert into SEWING_DETAIL (Sewing_Id,Sew_Id,Sewing_D_Code,Sewing_D_Desc,Sewing_D_Uname,Sewing_D_Uprice,Sewing_D_Memo,Sewing_D_Listno,Sewing_D_CreateUser,Sewing_D_CreateDate,Sewing_D_Delete)"
                              + " values (@Sewing_Id,@Sew_Id,@Sewing_D_Code,@Sewing_D_Desc,@Sewing_D_Uname,@Sewing_D_Uprice,@Sewing_D_Memo,@Sewing_D_Listno,@Sewing_D_CreateUser,@Sewing_D_CreateDate,@Sewing_D_Delete)";

                cmd.CommandText = strSQL;
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Sewing_Id", SqlDbType.Int).Value = item.Sewing_Id;
                cmd.Parameters.Add("@Sew_Id", SqlDbType.Int).Value = Library.DBInt(item.Sew_Id);
                cmd.Parameters.Add("@Sewing_D_Code", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Sewing_D_Code);
                cmd.Parameters.Add("@Sewing_D_Desc", SqlDbType.NVarChar, 250).Value = Library.DBString(item.Sewing_D_Desc);
                cmd.Parameters.Add("@Sewing_D_Uname", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Sewing_D_Uname);
                cmd.Parameters.Add("@Sewing_D_Uprice", SqlDbType.Decimal).Value = Library.DBDecimal(item.Sewing_D_Uprice);
                cmd.Parameters.Add("@Sewing_D_Memo", SqlDbType.NVarChar, 512).Value = Library.DBString(item.Sewing_D_Memo);
                cmd.Parameters.Add("@Sewing_D_Listno", SqlDbType.SmallInt).Value = Library.DBInt(item.Sewing_D_Listno);
                cmd.Parameters.Add("@Sewing_D_CreateUser", SqlDbType.SmallInt).Value = Library.GBuserID;
                cmd.Parameters.Add("@Sewing_D_CreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Sewing_D_Delete", SqlDbType.Bit).Value = 0;
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

        public void UpdateSweingDetail(SEWING_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SEWING_DETAIL Set
                                    Sewing_Id={0}
                                   ,Sew_Id={1}
                                   ,Sewing_D_Code={2}
                                   ,Sewing_D_Desc={3}
                                   ,Sewing_D_Uname={4}
                                   ,Sewing_D_Uprice={5}
                                   ,Sewing_D_Memo={6}
                                   ,Sewing_D_Listno={7}
                                   ,Sewing_D_EditUser={8}
                                   ,Sewing_D_EditDate={9}
                                    where Sewing_D_Id={10}";

                strSQL = string.Format(strSQL
                                 , item.Sewing_Id
                                 , item.Sew_Id
                                , Utility.ReplaceString(item.Sewing_D_Code)
                                , Utility.ReplaceString(item.Sewing_D_Desc)
                                , Utility.ReplaceString(item.Sewing_D_Uname)
                                , item.Sewing_D_Uprice
                                , Utility.ReplaceString(item.Sewing_D_Memo)
                                , item.Sewing_D_Listno
                                , 0
                                , "GetDate()"
                                , item.Sewing_D_Id);

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

        public void DeleteSweingDetail(SEWING_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SEWING_DETAIL Set 
                                   Sewing_D_Delete=1 
                                 , Sewing_D_DeleteUser ={1} 
                                  ,Sewing_D_DeleteDate= {2}
                                    where Sewing_D_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Sewing_D_Id,
                    1,// Cost_DeleteUser
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

        #endregion -- SEWING_DETAIL--
    }
}