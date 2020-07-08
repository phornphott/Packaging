using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class SalesRequestionData
    {


        string msgErr = string.Empty;

        public void GetClipBoard(out List<ClipBoard> ls)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ClipBoard item;
           ls = new List<ClipBoard>();
            try
            {

                strSQL = @"
                            SELECT a.*
                              FROM[dbo].[CLIPBOARD] a
                             Left Join [dbo].[SALES_REQUISITION] b on a.Clipboard_Nos = b.Reference_Clipboard_Nos
                              where a.Clipboard_Nos not in (select [Reference_Clipboard_Nos]  From [dbo].[SALES_REQUISITION] )";
             
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard();
                        item.Clipboard_Id = Convert.ToInt32(dt.Rows[i]["Clipboard_Id"].ToString());
                        item.Clipboard_Nos = dt.Rows[i]["Clipboard_Nos"].ToString();
                        item.Clipboard_Date = Convert.ToDateTime(dt.Rows[i]["Clipboard_Date"].ToString());
                        //item.Clipboard_Date_Text = item.Clipboard_Date.ToString(@"dd/MM/yyyy");
                        item.Clipboard_Quantity = Convert.ToDecimal(dt.Rows[i]["Clipboard_Quantity"].ToString());
                        item.Delivery_Id = Convert.ToInt32(dt.Rows[i]["Delivery_Id"].ToString());
                        item.Clipboard_Delivery_Desc = dt.Rows[i]["Clipboard_Delivery_Desc"].ToString();
                        item.Clipboard_Desc = dt.Rows[i]["Clipboard_Desc"].ToString();
                
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

        public void LoadClipBoard(List<int> item)
        {
            string clibID = "";
            if (item != null) {
                for (int i = 0; i < item.Count; i++)
                {
                    if (i != 0) {
                        clibID += ",";
                    }
                    clibID += item[i];
                }
            }
            string SalesText = "";
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @" INSERT INTO [dbo].[SALES_REQUISITION]
                               ([Sales_Nos]
                               ,[PERid]
                               ,[DEBid]
                               ,[Reference_Clipboard_Id]
                               ,[Reference_Clipboard_Nos]
                               ,[Sales_Date]
                               ,[Sales_Quantity]
                               ,[Delivery_Id]
                               ,[Sales_Delivery_Desc]
                               ,[Sales_Desc]
                               ,[Bag_Width]
                               ,[Bag_Width_Add]
                               ,[Bag_Lenght]
                               ,[Bag_Lenght_Add]
                               ,[Warpyarn_Denier]
                               ,[Warpyarn_Mech]
                               ,[Warpyarn_Width]
                               ,[Fillingyarn_Denier]
                               ,[Fillingyarn_Mech]
                               ,[Fillingyarn_Width]
                               ,[Bag_Weight]
                               ,[Bagin_Use]
                               ,[Bagin_Micron]
                               ,[Bagin_Weight]
                               ,[Plastic_Use]
                               ,[Plastic_Quantity]
                               ,[Plastic_Micron]
                               ,[Plastic_Weight]
                               ,[Gravure_Use]
                               ,[Gravure_Quantity]
                               ,[Gravure_Micron]
                               ,[Gravure_Weight]
                               ,[Print_Flexo_Use]
                               ,[Print_Flexo_Quantity]
                               ,[Print_Flexo_Print1]
                               ,[Print_Flexo_Print2]
                               ,[Print_Flexo_Area]
                               ,[Print_Gravure_Use]
                               ,[Print_Gravure_Area]
                               ,[Plastic_PP]
                               ,[Plastic_PE]
                               ,[Plastic_Coat]
                               ,[Plastic_Pigment]
                               ,[Handle_Quantity]
                               ,[Handle_Uprice]
                               ,[Tag_Use]
                               ,[Tag_Uprice]
                               ,[Sewing_Desc]
                               ,[Sewing_Uprice]
                               ,[Eyelet_Use]
                               ,[Eyelet_Uprice]
                               ,[Bell_Use]
                               ,[Bell_Uprice]
                               ,[Conversion]
                               ,[Distance]
                               ,[Format_Saleprice]
                               ,[SalepricePerUnit]
                               ,[Total_Weight]
                               ,[Profitperunit]
                               ,[Sales_Status]
                               ,[ApproveBy]
                               ,[Sales_CreateUser]
                               ,[Sales_CreateDate]
                            )
                         select 
                             " + "'RQ-" + DateTime.Now.ToString(@"yyyMMddHHmmss")+"' "
                              + @",0
                              ,0
                              ,[Clipboard_Id]
                              ,[Clipboard_Nos]
                              ,[Clipboard_Date]
                              ,[Clipboard_Quantity]
                              ,[Delivery_Id]
                              ,[Clipboard_Delivery_Desc]
                              ,[Clipboard_Desc]
                              ,[Bag_Width]
                              ,[Bag_Width_Add]
                              ,[Bag_Lenght]
                              ,[Bag_Lenght_Add]
                              ,[Warpyarn_Denier]
                              ,[Warpyarn_Mech]
                              ,[Warpyarn_Width]
                              ,[Fillingyarn_Denier]
                              ,[Fillingyarn_Mech]
                              ,[Fillingyarn_Width]
                              ,[Bag_Weight]
                              ,[Bagin_Use]
                              ,[Bagin_Micron]
                              ,[Bagin_Weight]
                              ,[Plastic_Use]
                              ,[Plastic_Quantity]
                              ,[Plastic_Micron]
                              ,[Plastic_Weight]
                              ,[Gravure_Use]
                              ,[Gravure_Quantity]
                              ,[Gravure_Micron]
                              ,[Gravure_Weight]
                              ,[Print_Flexo_Use]
                              ,[Print_Flexo_Quantity]
                              ,[Print_Flexo_Print1]
                              ,[Print_Flexo_Print2]
                              ,[Print_Flexo_Area]
                              ,[Print_Gravure_Use]
                              ,[Print_Gravure_Area]
                              ,[Plastic_PP]
                              ,[Plastic_PE]
                              ,[Plastic_Coat]
                              ,[Plastic_Pigment]
                              ,[Handle_Quantity]
                              ,[Handle_Uprice]
                              ,[Tag_Use]
                              ,[Tag_Uprice]
                              ,[Sewing_Desc]
                              ,[Sewing_Uprice]
                              ,[Eyelet_Use]
                              ,[Eyelet_Uprice]
                              ,[Bell_Use]
                              ,[Bell_Uprice]
                              ,[Conversion]
                              ,[Distance]
                              ,[Format_Saleprice]
                              ,[SalepricePerUnit]
                              ,[Total_Weight]
                              ,[Profitperunit] 
                              ,0
                              ,0
                              ,0
                              ,GetDate()
                    From [dbo].[CLIPBOARD] where Clipboard_Id in ( " + clibID + ");";

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



        #region -- SalesRequestion--
        public void GetSalesRequestion(out List<SalesRequestion> ls, int SaleId)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<SalesRequestion>();
            SalesRequestion item = new SalesRequestion();
            try
            {

                strSQL = @"SELECT 
                       [Sales_Id]
                      ,[Sales_Nos]
                      ,[PERid]
                      ,[DEBid]
                      ,[Reference_Clipboard_Id]
                      ,[Reference_Clipboard_Nos]
                      ,[Sales_Date]
                      ,[Sales_Quantity]
                      ,[Delivery_Id]
                      ,[Sales_Delivery_Desc]
                      ,[Sales_Desc]
                      ,[Bag_Width]
                      ,[Bag_Width_Add]
                      ,[Bag_Lenght]
                      ,[Bag_Lenght_Add]
                      ,[Warpyarn_Denier]
                      ,[Warpyarn_Mech]
                      ,[Warpyarn_Width]
                      ,[Fillingyarn_Denier]
                      ,[Fillingyarn_Mech]
                      ,[Fillingyarn_Width]
                      ,[Bag_Weight]
                      ,[Bagin_Use]
                      ,[Bagin_Micron]
                      ,[Bagin_Weight]
                      ,[Plastic_Use]
                      ,[Plastic_Quantity]
                      ,[Plastic_Micron]
                      ,[Plastic_Weight]
                      ,[Gravure_Use]
                      ,[Gravure_Quantity]
                      ,[Gravure_Micron]
                      ,[Gravure_Weight]
                      ,[Print_Flexo_Use]
                      ,[Print_Flexo_Quantity]
                      ,[Print_Flexo_Print1]
                      ,[Print_Flexo_Print2]
                      ,[Print_Flexo_Area]
                      ,[Print_Gravure_Use]
                      ,[Print_Gravure_Area]
                      ,[Plastic_PP]
                      ,[Plastic_PE]
                      ,[Plastic_Coat]
                      ,[Plastic_Pigment]
                      ,[Handle_Quantity]
                      ,[Handle_Uprice]
                      ,[Tag_Use]
                      ,[Tag_Uprice]
                      ,[Sewing_Desc]
                      ,[Sewing_Uprice]
                      ,[Eyelet_Use]
                      ,[Eyelet_Uprice]
                      ,[Bell_Use]
                      ,[Bell_Uprice]
                      ,[Conversion]
                      ,[Distance]
                      ,[Format_Saleprice]
                      ,[SalepricePerUnit]
                      ,[Total_Weight]
                      ,[Profitperunit]
                      ,[Sales_Status]
                      ,[ApproveBy]
                      ,[Sales_CreateUser]
                      ,[Sales_CreateDate]
                      ,[Sales_EditUser]
                      ,[Sales_EditDate]
                      ,[Sales_Delete]
                      ,[Sales_DeleteUser]
                      ,[Sales_DeleteDate]
                  FROM [PackagingDB].[dbo].[SALES_REQUISITION]
                  WHERE 0 = 0
                ";

                if (SaleId > 0)
                {

                    strSQL += " and Sales_Id=" + SaleId;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new SalesRequestion();
                        item.Sales_Id = Convert.ToInt32(dt.Rows[i]["Sales_Id"].ToString());
                        item.Sales_Nos = dt.Rows[i]["Sales_Nos"].ToString();
                        item.PERid = Convert.ToInt32(dt.Rows[i]["PERid"].ToString());
                        item.DEBid = Convert.ToInt32(dt.Rows[i]["DEBid"].ToString());
                        item.Reference_Clipboard_Id = Convert.ToInt32(dt.Rows[i]["Reference_Clipboard_Id"].ToString());
                        item.Reference_Clipboard_Nos = dt.Rows[i]["Reference_Clipboard_Nos"].ToString();
                        item.Sales_Date = Convert.ToDateTime(dt.Rows[i]["Sales_Date"].ToString());
                        item.Sales_Date_Text = Convert.ToDateTime(dt.Rows[i]["Sales_Date"]).ToString(@"dd/MM/yyy");
                        item.Sales_Quantity = Convert.ToDecimal(dt.Rows[i]["Sales_Quantity"].ToString());
                        item.Delivery_Id = Convert.ToInt32(dt.Rows[i]["Delivery_Id"].ToString());
                        item.Sales_Delivery_Desc = dt.Rows[i]["Sales_Delivery_Desc"].ToString();
                        item.Sales_Desc = dt.Rows[i]["Sales_Desc"].ToString();
                        item.Bag_Width = Convert.ToDecimal(dt.Rows[i]["Bag_Width"].ToString());
                        item.Bag_Width_Add = Convert.ToDecimal(dt.Rows[i]["Bag_Width_Add"].ToString());
                        item.Bag_Lenght = Convert.ToDecimal(dt.Rows[i]["Bag_Lenght"].ToString());
                        item.Bag_Lenght_Add = Convert.ToDecimal(dt.Rows[i]["Bag_Lenght_Add"].ToString());
                        item.Warpyarn_Denier = Convert.ToDecimal(dt.Rows[i]["Warpyarn_Denier"].ToString());
                        item.Warpyarn_Mech = Convert.ToDecimal(dt.Rows[i]["Warpyarn_Mech"].ToString());
                        item.Warpyarn_Width = Convert.ToDecimal(dt.Rows[i]["Warpyarn_Width"].ToString());
                        item.Fillingyarn_Denier = Convert.ToDecimal(dt.Rows[i]["Fillingyarn_Denier"].ToString());
                        item.Fillingyarn_Mech = Convert.ToDecimal(dt.Rows[i]["Fillingyarn_Mech"].ToString());
                        item.Fillingyarn_Width = Convert.ToDecimal(dt.Rows[i]["Fillingyarn_Width"].ToString());
                        item.Bag_Weight = Convert.ToDecimal(dt.Rows[i]["Bag_Weight"].ToString());
                        item.Bagin_Use = Convert.ToBoolean(dt.Rows[i]["Bagin_Use"].ToString());
                        item.Bagin_Micron = Convert.ToDecimal(dt.Rows[i]["Bagin_Micron"].ToString());
                        item.Bagin_Weight = Convert.ToDecimal(dt.Rows[i]["Bagin_Weight"].ToString());
                        item.Plastic_Use = Convert.ToBoolean(dt.Rows[i]["Plastic_Use"].ToString());
                        item.Plastic_Quantity = Convert.ToInt32(dt.Rows[i]["Plastic_Quantity"].ToString());
                        item.Plastic_Micron = Convert.ToDecimal(dt.Rows[i]["Plastic_Micron"].ToString());
                        item.Plastic_Weight = Convert.ToDecimal(dt.Rows[i]["Plastic_Weight"].ToString());
                        item.Gravure_Use = Convert.ToBoolean(dt.Rows[i]["Gravure_Use"].ToString());
                        item.Gravure_Quantity = Convert.ToInt32(dt.Rows[i]["Gravure_Quantity"].ToString());
                        item.Gravure_Micron = Convert.ToDecimal(dt.Rows[i]["Gravure_Micron"].ToString());
                        item.Gravure_Weight = Convert.ToDecimal(dt.Rows[i]["Gravure_Weight"].ToString());
                        item.Print_Flexo_Use = Convert.ToBoolean(dt.Rows[i]["Print_Flexo_Use"].ToString());
                        item.Print_Flexo_Quantity = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Quantity"].ToString());
                        item.Print_Flexo_Print1 = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Print1"].ToString());
                        item.Print_Flexo_Print2 = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Print2"].ToString());
                        item.Print_Flexo_Area = Convert.ToDecimal(dt.Rows[i]["Print_Flexo_Area"].ToString());
                        item.Print_Gravure_Use = Convert.ToBoolean(dt.Rows[i]["Print_Gravure_Use"].ToString());
                        item.Print_Gravure_Area = Convert.ToDecimal(dt.Rows[i]["Print_Gravure_Area"].ToString());
                        item.Plastic_PP = Convert.ToDecimal(dt.Rows[i]["Plastic_PP"].ToString());
                        item.Plastic_PE = Convert.ToDecimal(dt.Rows[i]["Plastic_PE"].ToString());
                        item.Plastic_Coat = Convert.ToDecimal(dt.Rows[i]["Plastic_Coat"].ToString());
                        item.Plastic_Pigment = Convert.ToDecimal(dt.Rows[i]["Plastic_Pigment"].ToString());
                        item.Handle_Quantity = Convert.ToInt32(dt.Rows[i]["Handle_Quantity"].ToString());
                        item.Handle_Uprice = Convert.ToDecimal(dt.Rows[i]["Handle_Uprice"].ToString());
                        item.Tag_Use = Convert.ToBoolean(dt.Rows[i]["Tag_Use"].ToString());
                        item.Tag_Uprice = Convert.ToDecimal(dt.Rows[i]["Tag_Uprice"].ToString());
                        item.Sewing_Desc = dt.Rows[i]["Sewing_Desc"].ToString();
                        item.Sewing_Uprice = Convert.ToDecimal(dt.Rows[i]["Sewing_Uprice"].ToString());
                        item.Eyelet_Use = Convert.ToBoolean(dt.Rows[i]["Eyelet_Use"].ToString());
                        item.Eyelet_Uprice = Convert.ToDecimal(dt.Rows[i]["Eyelet_Uprice"].ToString());
                        item.Bell_Use = Convert.ToBoolean(dt.Rows[i]["Bell_Use"].ToString());
                        item.Bell_Uprice = Convert.ToDecimal(dt.Rows[i]["Bell_Uprice"].ToString());
                        item.Conversion = Convert.ToDecimal(dt.Rows[i]["Conversion"].ToString());
                        item.Distance = Convert.ToDecimal(dt.Rows[i]["Distance"].ToString());
                        item.Format_Saleprice = Convert.ToInt32(dt.Rows[i]["Format_Saleprice"].ToString());
                        item.SalepricePerUnit = Convert.ToDecimal(dt.Rows[i]["SalepricePerUnit"].ToString());
                        item.Total_Weight = Convert.ToDecimal(dt.Rows[i]["Total_Weight"].ToString());
                        item.Profitperunit = Convert.ToDecimal(dt.Rows[i]["Profitperunit"].ToString());
                        item.Sales_Status = Convert.ToInt32(dt.Rows[i]["Sales_Status"].ToString());
                        item.ApproveBy = Convert.ToInt32(dt.Rows[i]["ApproveBy"].ToString());
                    
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
        #endregion  -- SalesRequestion--
    }
}