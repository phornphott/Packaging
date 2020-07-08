
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;

namespace demoMac5.Module
{
    public class ShippingHeaderData
    {
        string msgErr = string.Empty;

        #region -- SHIPPING_HEADER--
        public void GetShippingHeader(out List<SHIPPING_HEADER> ls, int ShippingHeaderid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<SHIPPING_HEADER>();
            SHIPPING_HEADER item = new SHIPPING_HEADER();
            try
            {

                strSQL = "select * FROM [dbo].[SHIPPING_HEADER] where 0=0 and Shipping_Delete=0 ";
                if (ShippingHeaderid > 0)
                {

                    strSQL += " and Shipping_Id=" + ShippingHeaderid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new SHIPPING_HEADER();
                        item.Shipping_Id = Convert.ToInt32(dt.Rows[i]["Shipping_Id"].ToString());
                        item.Shipping_Name = dt.Rows[i]["Shipping_Name"].ToString();
                        item.Shipping_Use = Convert.ToBoolean(dt.Rows[i]["Shipping_Use"].ToString());
                        item.Shipping_UseDate = Convert.ToBoolean(dt.Rows[i]["Shipping_UseDate"].ToString());
                        item.Shipping_DateStart = Convert.ToDateTime(dt.Rows[i]["Shipping_DateStart"].ToString());
                        item.Shipping_DateEnd = Convert.ToDateTime(dt.Rows[i]["Shipping_DateEnd"].ToString());
                        item.Shipping_DateStart_Input = item.Shipping_DateStart.ToShortDateString();
                        item.Shipping_DateEnd_Input = item.Shipping_DateEnd.ToShortDateString();
                        item.Shipping_Desc = dt.Rows[i]["Shipping_Desc"].ToString();
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

        public void InsertShippingHeader(SHIPPING_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into SHIPPING_HEADER(
                                   Shipping_Name
                                   ,Shipping_Use
                                   ,Shipping_UseDate
                                   ,Shipping_DateStart
                                   ,Shipping_DateEnd
                                   ,Shipping_Desc
                                   ,Shipping_CreateUser	
                                   ,Shipping_CreateDate	
                                   ,Shipping_Delete
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Shipping_Name)
                    , item.Shipping_Use == true ? -1 : 0
                    , item.Shipping_UseDate == true ? -1 : 0
                    , Utility.FormateDateTime(item.Shipping_DateStart)
                    , Utility.FormateDateTime(item.Shipping_DateEnd)
                    , Utility.ReplaceString(item.Shipping_Desc ?? "")
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

        public void UpdateShippingHeader(SHIPPING_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SHIPPING_HEADER Set
                                    Shipping_Name={1},
                                    Shipping_Use={2},
                                    Shipping_UseDate={3},
                                    Shipping_DateStart={4},
                                    Shipping_DateEnd={5},
                                     Shipping_Desc={6},
                                    Shipping_EditUser=0,
                                    Shipping_EditDate=GetDate()
                                    where Shipping_Id={0}";

                strSQL = string.Format(strSQL
                    , item.Shipping_Id
                    , Utility.ReplaceString(item.Shipping_Name)
                   , item.Shipping_Use == true ? -1 : 0
                    , item.Shipping_UseDate == true ? -1 : 0
                    , Utility.FormateDate(item.Shipping_DateStart)
                    , Utility.FormateDate(item.Shipping_DateEnd)
                    , Utility.ReplaceString(item.Shipping_Desc));

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

        public void DeleteShippingHeader(SHIPPING_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update SHIPPING_HEADER Set 
Shipping_Delete=1 , Shipping_DeleteUser ={1} ,Shipping_DeleteDate= {2}
                                    where Shipping_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Shipping_Id,
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

        #endregion -- SHIPPING_HEADER--
    }
}