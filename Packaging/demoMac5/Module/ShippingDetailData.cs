using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{

    public class ShippingDetailData
    {
        string msgErr = string.Empty;

        #region -- SHIPPING_DETAIL--
        public void GetShippingDetail(out List<SHIPPING_DETAIL> ls, int ShippingDetailid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<SHIPPING_DETAIL>();
            SHIPPING_DETAIL item = new SHIPPING_DETAIL();
            try
            {

                strSQL = @" select a.*, b.SHIPPING_NAME FROM [dbo].[SHIPPING_DETAIL] a 
                            left join  [dbo].[SHIPPING_HEADER] b on a.SHIPPING_Id=b.SHIPPING_Id
                            where 0=0 and a.Shipping_D_Delete=0 ";

                if (ShippingDetailid > 0)
                {

                    strSQL += " and a.Shipping_Id=" + ShippingDetailid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new SHIPPING_DETAIL();
                        item.Shipping_D_Id = Convert.ToInt32(dt.Rows[i]["Shipping_D_Id"].ToString());
                        item.Shipping_Id = Convert.ToInt32(dt.Rows[i]["Shipping_Id"].ToString());
                        item.Shipping_Header_Name = dt.Rows[i]["Shipping_Name"].ToString();
                        item.Shipping_D_Range = dt.Rows[i]["Shipping_D_Range"].ToString();
                        item.Shipping_D_Uname = dt.Rows[i]["Shipping_D_Uname"].ToString();
                        item.Shipping_D_Uprice = Convert.ToDecimal(dt.Rows[i]["Shipping_D_Uprice"].ToString());
                        item.Shipping_D_Listno = Convert.ToInt32(dt.Rows[i]["Shipping_D_Listno"].ToString());

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

        public void InsertShippingDetail(SHIPPING_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();
            SqlTransaction tran;

            tran = objConn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                //string strSQL = @"insert into SHIPPING_DETAIL(
                //                   [Shipping_Id]
                //                  ,[Shipping_D_Range]
                //                  ,[Shipping_D_Uname]
                //                  ,[Shipping_D_Uprice]
                //                  ,[Shipping_D_Listno]
                //                  ,[Shipping_D_CreateUser]
                //                  ,[Shipping_D_CreateDate]
                //                  ,[Shipping_D_Delete]

                //                    ) 
                //                    values({0},{1},{2},{3},{4},{5},{6},{7})";
                //strSQL = string.Format(strSQL,
                //        item.Shipping_Id
                //      , Utility.ReplaceString(item.Shipping_D_Range)
                //      , Utility.ReplaceString(item.Shipping_D_Uname)
                //      , item.Shipping_D_Uprice
                //      , item.Shipping_D_Listno
                //      , 0
                //      , "GetDate()"
                //      , 0
                //    );

                //DBHelper.Execute(strSQL, objConn);
                string strSQL = "Insert into SHIPPING_DETAIL (Shipping_Id,Shipping_D_Range,Shipping_D_Uname,Shipping_D_Uprice,Shipping_D_Listno,Shipping_D_CreateUser,Shipping_D_CreateDate,Shipping_D_Delete)"
                              + " values (@Shipping_Id,@Shipping_D_Range,@Shipping_D_Uname,@Shipping_D_Uprice,@Shipping_D_Listno,@Shipping_D_CreateUser,@Shipping_D_CreateDate,@Shipping_D_Delete)";

                cmd.CommandText = strSQL;
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Shipping_Id", SqlDbType.Int).Value = item.Shipping_Id;
                cmd.Parameters.Add("@Shipping_D_Range", SqlDbType.NVarChar, 100).Value = Library.DBString(item.Shipping_D_Range);
                cmd.Parameters.Add("@Shipping_D_Uname", SqlDbType.NVarChar, 50).Value = Library.DBString(item.Shipping_D_Uname);
                cmd.Parameters.Add("@Shipping_D_Uprice", SqlDbType.Decimal).Value = Library.DBDecimal(item.Shipping_D_Uprice);
                cmd.Parameters.Add("@Shipping_D_Listno", SqlDbType.SmallInt).Value = Library.DBInt(item.Shipping_D_Listno);
                cmd.Parameters.Add("@Shipping_D_CreateUser", SqlDbType.SmallInt).Value = Library.GBuserID;
                cmd.Parameters.Add("@Shipping_D_CreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Shipping_D_Delete", SqlDbType.Bit).Value = 0;
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

        public void UpdateShippingDetail(SHIPPING_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SHIPPING_DETAIL Set
                                    [Shipping_Id]={0}
                                  ,[Shipping_D_Range]={1}
                                  ,[Shipping_D_Uname]={2}
                                  ,[Shipping_D_Uprice]={3}
                                  ,[Shipping_D_Listno]={4}
                                  ,[Shipping_D_CreateUser]={5}
                                  ,[Shipping_D_CreateDate]={6}
                                    where Shipping_D_Id={7}";

                strSQL = string.Format(strSQL
                    , item.Shipping_Id
                    , Utility.ReplaceString(item.Shipping_D_Range)
                    , Utility.ReplaceString(item.Shipping_D_Uname)
                    , item.Shipping_D_Uprice
                    , item.Shipping_D_Listno
                    , item.Shipping_D_CreateUser
                    , "GetDate()"
                    , item.Shipping_D_Id);

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

        public void DeleteShippingDetail(SHIPPING_DETAIL item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SHIPPING_DETAIL Set 
                                Shipping_D_Delete=1 ,
                                Shipping_D_DeleteUser ={1} ,
                                Shipping_D_DeleteDate= {2}
                                where Shipping_D_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Shipping_D_Id,
                    1,// Shipping_DeleteUser
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

        #endregion -- SHIPPING_DETAIL--
    }
}