﻿using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{

    public class CostPrintData
    {
        string msgErr = string.Empty;

        #region -- COST_PRINT--
        public void GetCostPrint(out List<COST_PRINT> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<COST_PRINT>();
            COST_PRINT item = new COST_PRINT();
            try
            {

                strSQL = @"select p.*,b.Cost_Name,mp.Print_NameT FROM [dbo].[COST_PRINT] p 
                        left join[dbo].[M_PRINT] mp on p.Print_Id =mp.Print_Id
                        left join[dbo].[COST_HEADER] b on p.Cost_Id=b.Cost_Id
                        where 0=0 and p.Cost_P_Delete=0 ";
                if (id > 0)
                {

                    strSQL += " and p.Cost_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new COST_PRINT();
                        item.Cost_P_Id = Convert.ToInt32(dt.Rows[i]["Cost_P_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Cost_Id"].ToString());
                        item.Cost_Header_Name = dt.Rows[i]["Cost_Name"].ToString();
                        item.Print_Id = Convert.ToInt32(dt.Rows[i]["Print_Id"].ToString());
                        item.Cost_P_Code = dt.Rows[i]["Cost_P_Code"].ToString();
                        item.Cost_P_Desc = dt.Rows[i]["Cost_P_Desc"].ToString();
                        item.Cost_P_Uname = dt.Rows[i]["Cost_P_Uname"].ToString();
                        item.Cost_P_UpriceR1 = Convert.ToDecimal(dt.Rows[i]["Cost_P_UpriceR1"].ToString());
                        item.Cost_P_UpriceR2 = Convert.ToDecimal(dt.Rows[i]["Cost_P_UpriceR2"].ToString());
                        item.Cost_P_UpriceR3 = Convert.ToDecimal(dt.Rows[i]["Cost_P_UpriceR3"].ToString());
                        item.Cost_P_Memo = dt.Rows[i]["Cost_P_Memo"].ToString();
                        item.Cost_P_Listno = i+1;
                        
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

        public void InsertCostPrint(COST_PRINT item)
        {
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();
            SqlTransaction tran;

            tran = objConn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                
                //string strSQL = @"insert into COST_PRINT(
                //                   [Cost_Id]
                //                  ,[Print_Id]
                //                  ,[Cost_P_Code]
                //                  ,[Cost_P_Desc]
                //                  ,[Cost_P_Uname]
                //                  ,[Cost_P_UpriceR1]
                //                  ,[Cost_P_UpriceR2]
                //                  ,[Cost_P_UpriceR3]
                //                  ,[Cost_P_Memo]
                //                  ,[Cost_P_Listno]
                //                  ,[Cost_P_CreateUser]
                //                  ,[Cost_P_CreateDate]
                //                   ,Cost_P_Delete
                //                    ) 
                //       values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})";

                //        strSQL = string.Format(strSQL
                //            , item.Cost_Id 
                //            , item.Print_Id 
                //            , Utility.ReplaceString(item.Cost_P_Code)
                //            , Utility.ReplaceString(item.Cost_P_Desc)
                //            , Utility.ReplaceString(item.Cost_P_Uname)
                //            , Library.DBDecimal(item.Cost_P_UpriceR1)
                //            , Library.DBDecimal(item.Cost_P_UpriceR2)
                //            ,Library.DBDecimal(item.Cost_P_UpriceR3)
                //            ,Library.DBString(item.Cost_P_Memo)
                //            ,item.Cost_P_Listno
                //            ,0
                //            , "GetDate()"
                //            , 0
                //            );

                //DBHelper.Execute(strSQL, objConn);

                string strSQL = "Insert into COST_PRINT (Cost_Id,Print_Id,Cost_P_Code,Cost_P_Desc,Cost_P_Uname,Cost_P_UpriceR1,Cost_P_UpriceR2,Cost_P_UpriceR3,Cost_P_Memo,Cost_P_Listno,Cost_P_CreateUser,Cost_P_CreateDate,Cost_P_Delete)"
                              + " values (@Cost_Id,@Print_Id,@Cost_P_Code,@Cost_P_Desc,@Cost_P_Uname,@Cost_P_UpriceR1,@Cost_P_UpriceR2,@Cost_P_UpriceR3,@Cost_P_Memo,@Cost_P_Listno,@Cost_P_CreateUser,@Cost_P_CreateDate,@Cost_P_Delete)";

                cmd.CommandText = strSQL;
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Cost_Id", SqlDbType.Int).Value = item.Cost_Id;
                cmd.Parameters.Add("@Print_Id", SqlDbType.Int).Value = Library.DBInt(item.Cost_P_Code);
                cmd.Parameters.Add("@Cost_P_Code", SqlDbType.NVarChar,50).Value = Library.DBString(item.Cost_P_Code);
                cmd.Parameters.Add("@Cost_P_Desc", SqlDbType.NVarChar, 250).Value = Library.DBString(item.Cost_P_Desc);
                cmd.Parameters.Add("@Cost_P_Uname", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Cost_P_Uname);
                cmd.Parameters.Add("@Cost_P_UpriceR1", SqlDbType.Decimal).Value = Library.DBDecimal(item.Cost_P_UpriceR1);
                cmd.Parameters.Add("@Cost_P_UpriceR2", SqlDbType.Decimal).Value = Library.DBDecimal(item.Cost_P_UpriceR2);
                cmd.Parameters.Add("@Cost_P_UpriceR3", SqlDbType.Decimal).Value = Library.DBDecimal(item.Cost_P_UpriceR3);
                cmd.Parameters.Add("@Cost_P_Memo", SqlDbType.NVarChar, 512).Value = Library.DBString(item.Cost_P_Memo);
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

        public void UpdateCostPrint(COST_PRINT item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_PRINT Set
                                   [Cost_Id]={1}
                                  ,[Print_Id]={2}
                                  ,[Cost_P_Code]={3}
                                  ,[Cost_P_Desc]={4}
                                  ,[Cost_P_Uname]={5}
                                  ,[Cost_P_UpriceR1]={6}
                                  ,[Cost_P_UpriceR2]={7}
                                  ,[Cost_P_UpriceR3]={8}
                                  ,[Cost_P_Memo]={9}
                                  ,[Cost_P_Listno]={10}
                                  ,[Cost_P_EditUser]={11}
                                  ,[Cost_P_EditDate]={12}
                                    where Cost_P_Id={0}";

                strSQL = string.Format(strSQL
                            , item.Cost_P_Id
                            , item.Cost_Id
                            , item.Print_Id
                            , Utility.ReplaceString(item.Cost_P_Code)
                            , Utility.ReplaceString(item.Cost_P_Desc)
                            , Utility.ReplaceString(item.Cost_P_Uname)
                            , item.Cost_P_UpriceR1
                            , item.Cost_P_UpriceR2
                             , item.Cost_P_UpriceR3
                             , Utility.ReplaceString(item.Cost_P_Memo)
                             , item.Cost_P_Listno
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

        public void DeleteCostPrint(COST_PRINT item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_PRINT Set 
                                        Cost_P_Delete=1 ,
                                        Cost_P_DeleteUser ={1} ,
                                        Cost_P_DeleteDate= {2}
                                    where Cost_P_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Cost_P_Id,
                    1, 
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

        #endregion -- COST_PRINT--
    }
}