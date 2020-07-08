using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class SweingOtherData
    {
        string msgErr = string.Empty;

        #region -- SEWING_OTHER--
        public void GetSewingOther(out List<SEWING_OTHER> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<SEWING_OTHER>();
            SEWING_OTHER item = new SEWING_OTHER();
            try
            {

                strSQL = @"select a.*,b.Sewing_Name  FROM [dbo].[SEWING_OTHER]  a
                            left join [dbo].[SEWING_HEADER] b on a.Sewing_Id=b.Sewing_Id
                            where 0=0 and a.Sewing_O_Delete=0 ";
                if (id > 0)
                {
                    strSQL += " and a.Sewing_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new SEWING_OTHER();
                        item.Sewing_O_Id = Convert.ToInt32(dt.Rows[i]["Sewing_O_Id"].ToString());
                        item.Sewing_Id = Convert.ToInt32(dt.Rows[i]["Sewing_Id"].ToString());
                        item.Sewing_Header_Name = dt.Rows[i]["Sewing_Name"].ToString();
                        item.Sew_Id = Convert.ToInt32(dt.Rows[i]["Sew_Id"].ToString());
                        item.Sewing_O_Code = dt.Rows[i]["Sewing_O_Code"].ToString();
                        item.Sewing_O_Desc = dt.Rows[i]["Sewing_O_Desc"].ToString();
                        item.Sewing_O_Uname = dt.Rows[i]["Sewing_O_Uname"].ToString();
                        item.Sewing_O_Uprice = Convert.ToDecimal(dt.Rows[i]["Sewing_O_Uprice"].ToString());
                        item.Sewing_O_Memo = dt.Rows[i]["Sewing_O_Memo"].ToString();
                        item.Sewing_O_Listno = i + 1;
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

        public void InsertSewingOther(SEWING_OTHER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();
            SqlTransaction tran;

            tran = objConn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                //string strSQL = @"insert into SEWING_OTHER(
                //                       [Sewing_Id]
                //                      ,[Sew_Id]
                //                      ,[Sewing_O_Code]
                //                      ,[Sewing_O_Desc]
                //                      ,[Sewing_O_Uname]
                //                      ,[Sewing_O_Uprice]
                //                      ,[Sewing_O_Memo]
                //                      ,[Sewing_O_Listno]
                //                      ,[Sewing_O_CreateUser]
                //                      ,[Sewing_O_CreateDate]
                //                       ,Sewing_O_Delete) 
                //                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})";
                //strSQL = string.Format(strSQL
                //     , item.Sewing_Id
                //     ,item.Sew_Id
                //    , Utility.ReplaceString(item.Sewing_O_Code)
                //    , Utility.ReplaceString(item.Sewing_O_Desc)
                //    , Utility.ReplaceString(item.Sewing_O_Uname)
                //    , item.Sewing_O_Uprice
                //    , Utility.ReplaceString(item.Sewing_O_Memo)
                //    , item.Sewing_O_Listno
                //    , 0
                //    , "GetDate()",
                //    0);


                //DBHelper.Execute(strSQL, objConn);

                string strSQL = "Insert into SEWING_OTHER (Sewing_Id,Sew_Id,Sewing_O_Code,Sewing_O_Desc,Sewing_O_Uname,Sewing_O_Uprice,Sewing_O_Memo,Sewing_O_Listno,Sewing_O_CreateUser,Sewing_O_CreateDate,Sewing_O_Delete)"
                              + " values (@Sewing_Id,@Sew_Id,@Sewing_O_Code,@Sewing_O_Desc,@Sewing_O_Uname,@Sewing_O_Uprice,@Sewing_O_Memo,@Sewing_O_Listno,@Sewing_O_CreateUser,@Sewing_O_CreateDate,@Sewing_O_Delete)";

                cmd.CommandText = strSQL;
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Sewing_Id", SqlDbType.Int).Value = item.Sewing_Id;
                cmd.Parameters.Add("@Sew_Id", SqlDbType.Int).Value = Library.DBInt(item.Sew_Id);
                cmd.Parameters.Add("@Sewing_O_Code", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Sewing_O_Code);
                cmd.Parameters.Add("@Sewing_O_Desc", SqlDbType.NVarChar, 250).Value = Library.DBString(item.Sewing_O_Desc);
                cmd.Parameters.Add("@Sewing_O_Uname", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Sewing_O_Uname);
                cmd.Parameters.Add("@Sewing_O_Uprice", SqlDbType.Decimal).Value = Library.DBDecimal(item.Sewing_O_Uprice);
                cmd.Parameters.Add("@Sewing_O_Memo", SqlDbType.NVarChar, 512).Value = Library.DBString(item.Sewing_O_Memo);
                cmd.Parameters.Add("@Sewing_O_Listno", SqlDbType.SmallInt).Value = Library.DBInt(item.Sewing_O_Listno);
                cmd.Parameters.Add("@Sewing_O_CreateUser", SqlDbType.SmallInt).Value = Library.GBuserID;
                cmd.Parameters.Add("@Sewing_O_CreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Sewing_O_Delete", SqlDbType.Bit).Value = 0;
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

        public void UpdateSewingOther(SEWING_OTHER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SEWING_OTHER Set
                                    Sewing_Id={0}
                                   ,Sew_Id={1}
                                   ,Sewing_O_Code={2}
                                   ,Sewing_O_Desc={3}
                                   ,Sewing_O_Uname={4}
                                   ,Sewing_O_Uprice={5}
                                   ,Sewing_O_Memo={6}
                                   ,Sewing_O_Listno={7}
                                   ,Sewing_O_EditUser={8}
                                   ,Sewing_O_EditDate={9}
                                    where Sewing_O_Id={10}";

                strSQL = string.Format(strSQL
                                 , item.Sewing_Id
                                 , item.Sew_Id
                                , Utility.ReplaceString(item.Sewing_O_Code)
                                , Utility.ReplaceString(item.Sewing_O_Desc)
                                , Utility.ReplaceString(item.Sewing_O_Uname)
                                , item.Sewing_O_Uprice
                                , Utility.ReplaceString(item.Sewing_O_Memo)
                                , item.Sewing_O_Listno
                                , 0
                                , "GetDate()"
                                , item.Sewing_O_Id);

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

        public void DeleteSewingOther(SEWING_OTHER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SEWING_OTHER Set 
                                   Sewing_O_Delete=1 
                                 , Sewing_O_DeleteUser ={1} 
                                  ,Sewing_O_DeleteDate= {2}
                                    where Sewing_O_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Sewing_O_Id,
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

        #endregion -- SEWING_OTHER--
    }
}