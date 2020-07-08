using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{

    public class CostPrintAdd1Data
    {
        string msgErr = string.Empty;

        #region -- COST_PRINT_ADD1--
        public void GetCostPrintAdd1(out List<COST_PRINT_ADD1> ls, int CostPrintAdd1id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<COST_PRINT_ADD1>();
            COST_PRINT_ADD1 item = new COST_PRINT_ADD1();
            try
            {

                strSQL = @"select b.Cost_Name , c.* FROM [dbo].[COST_PRINT_ADD1] c  
                           left join[dbo].[COST_HEADER] b on c.Cost_Id=b.Cost_Id
                            where 0=0 and c.Cost_P_Delete=0 ";
                if (CostPrintAdd1id > 0)
                {

                    strSQL += " and c.Cost_Id=" + CostPrintAdd1id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new COST_PRINT_ADD1();
                        item.Cost_P_Id = Convert.ToInt32(dt.Rows[i]["Cost_P_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Cost_Id"].ToString());
                        item.Cost_Header_Name = dt.Rows[i]["Cost_Name"].ToString();
                        item.Cost_P_Range = dt.Rows[i]["Cost_P_Range"].ToString();
                        item.Cost_P_Uname = dt.Rows[i]["Cost_P_Uname"].ToString();
                        item.Cost_P_Uprice = Convert.ToDecimal(dt.Rows[i]["Cost_P_Uprice"].ToString());
                        item.Cost_P_Listno = i + 1;

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

        public void InsertCostPrintAdd1(COST_PRINT_ADD1 item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();
            SqlTransaction tran;

            tran = objConn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                //string strSQL = @"insert into COST_PRINT_ADD1(
                //                   [Cost_Id]
                //                  ,[Cost_P_Range]
                //                  ,[Cost_P_Uname]
                //                  ,[Cost_P_Uprice]
                //                  ,[Cost_P_Listno]
                //                  ,[Cost_P_CreateUser]
                //                  ,[Cost_P_CreateDate]
                //                  ,[Cost_P_Delete]

                //                    ) 
                //                    values({0},{1},{2},{3},{4},{5},{6},{7})";
                //strSQL = string.Format(strSQL,
                //        item.Cost_Id
                //      , Utility.ReplaceString(item.Cost_P_Range)
                //      , Utility.ReplaceString(item.Cost_P_Uname)
                //      , item.Cost_P_Uprice
                //      , item.Cost_P_Listno
                //      , 0
                //      , "GetDate()"
                //      , 0
                //    );

                //DBHelper.Execute(strSQL, objConn);

                string strSQL = "Insert into COST_PRINT_ADD1 (Cost_Id,Cost_P_Range,Cost_P_Uname,Cost_P_Uprice,Cost_P_Listno,Cost_P_CreateUser,Cost_P_CreateDate,Cost_P_Delete)"
                              + " values (@Cost_Id,@Cost_P_Range,@Cost_P_Uname,@Cost_P_Uprice,@Cost_P_Listno,@Cost_P_CreateUser,@Cost_P_CreateDate,@Cost_P_Delete)";

                cmd.CommandText = strSQL;
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Cost_Id", SqlDbType.Int).Value = item.Cost_Id;
                cmd.Parameters.Add("@Cost_P_Range", SqlDbType.NVarChar, 100).Value = Library.DBString(item.Cost_P_Range);
                cmd.Parameters.Add("@Cost_P_Uname", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Cost_P_Uname);
                cmd.Parameters.Add("@Cost_P_Uprice", SqlDbType.Decimal).Value = Library.DBDecimal(item.Cost_P_Uprice);
                cmd.Parameters.Add("@Cost_P_Listno", SqlDbType.SmallInt).Value = Library.DBInt(item.Cost_P_Listno);
                cmd.Parameters.Add("@Cost_P_CreateUser", SqlDbType.SmallInt).Value = Library.GBuserID;
                cmd.Parameters.Add("@Cost_P_CreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Cost_P_Delete", SqlDbType.Bit).Value = 0;
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

        public void UpdateCostPrintAdd1(COST_PRINT_ADD1 item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_PRINT_ADD1 Set
                                    [Cost_Id]={0}
                                  ,[Cost_P_Range]={1}
                                  ,[Cost_P_Uname]={2}
                                  ,[Cost_P_Uprice]={3}
                                  ,[Cost_P_Listno]={4}
                                  ,[Cost_P_CreateUser]={5}
                                  ,[Cost_P_CreateDate]={6}
                                    where Cost_P_Id={7}";

                strSQL = string.Format(strSQL
                    , item.Cost_Id
                    , Utility.ReplaceString(item.Cost_P_Range)
                    , Utility.ReplaceString(item.Cost_P_Uname)
                    , item.Cost_P_Uprice
                    , item.Cost_P_Listno
                    , item.Cost_P_CreateUser
                    , "GetDate()"
                    ,item.Cost_P_Id);

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

        public void DeleteCostPrintAdd1(COST_PRINT_ADD1 item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_PRINT_ADD1 Set 
                                Cost_P_Delete=1 ,
                                Cost_P_DeleteUser ={1} ,
                                Cost_P_DeleteDate= {2}
                                where Cost_P_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Cost_P_Id,
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

        #endregion -- COST_PRINT_ADD1--
    }
}