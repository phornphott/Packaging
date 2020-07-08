using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class PurchaseOrderData
    {

        string msgErr = string.Empty;

        public void GetSalesRequest (out List<SalesRequestion> ls)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SalesRequestion item;
            ls = new List<SalesRequestion>();
            try
            {

                strSQL = @"
                            SELECT a.*
                              FROM[dbo].[SALES_REQUISITION] a
                             Left Join [dbo].[PURCHASE_ORDER] b on a.[Reference_Clipboard_Nos] = b.[Reference_Sales_Nos]
                              where a.[Reference_Clipboard_Nos] not in (select [Reference_Sales_Nos]  From [dbo].[PURCHASE_ORDER] ) ";

                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new SalesRequestion();
                        item.Sales_Id = Convert.ToInt32(dt.Rows[i]["Sales_Id"].ToString());
                        item.Sales_Nos = dt.Rows[i]["Sales_Nos"].ToString();
                        item.Sales_Date = Convert.ToDateTime(dt.Rows[i]["Sales_Date"].ToString());
                        item.Sales_Date_Text = item.Sales_Date.ToString(@"dd/MM/yyyy");
                        item.Sales_Quantity = Convert.ToDecimal(dt.Rows[i]["Sales_Quantity"].ToString());
                        item.Delivery_Id = Convert.ToInt32(dt.Rows[i]["Delivery_Id"].ToString());
                        item.Sales_Delivery_Desc = dt.Rows[i]["Sales_Delivery_Desc"].ToString();
                        item.Sales_Desc = dt.Rows[i]["Sales_Desc"].ToString();

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

        public void GetPurchaseOrder(out List<PurchaseOrder> ls,int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            PurchaseOrder item;
            ls = new List<PurchaseOrder>();
            try
            {

                strSQL = @" SELECT     [Purchase_Id]
                                      ,[Purchase_Nos]
                                      ,[PERid]
                                      ,[DEBid]
                                      ,[STKid]
                                      ,[JOBid]
                                      ,[Reference_Sales_Id]
                                      ,[Reference_Sales_Nos]
                                      ,[Purchase_Date]
                                      ,[Purchase_Quantity]
                                      ,[Delivery_Id]
                                      ,[Purchase_Delivery_Desc]
                                      ,[Purchase_Desc]
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
                                      ,[Cost_Plastic_PP]
                                      ,[Cost_Plastic_PE]
                                      ,[Cost_Plastic_Coat]
                                      ,[Cost_Plastic_Pigment]
                                      ,[Cost_Print]
                                      ,[Cost_Print_OPP]
                                      ,[Cost_Handle_Uprice]
                                      ,[Cost_Tag_Uprice]
                                      ,[Cost_Sewing_Uprice]
                                      ,[Cost_Eyelet_Uprice]
                                      ,[Cost_Bell_Uprice]
                                      ,[Cost_Conversion]
                                      ,[Cost_Conversion_Coat]
                                      ,[Cost_Shipping]
                                      ,[Cost_Commission]
                                      ,[Cost_Product]
                                      ,[MinimumPrice]
                                      ,[Price]
                                      ,[VAT]
                                      ,[NetPrice]
                                      ,[Total_Weight]
                                      ,[Profitperunit]
                                      ,[Purchase_Status]
                                      ,[Purchase_CreateUser]
                                      ,[Purchase_CreateDate]
                                      ,[Purchase_EditUser]
                                      ,[Purchase_EditDate]
                                      ,[Purchase_Delete]
                                      ,[Purchase_DeleteUser]
                                      ,[Purchase_DeleteDate]
                                  FROM [PackagingDB].[dbo].[PURCHASE_ORDER]  where 0=0 ";

                if (id > 0)
                {
                    strSQL += " and  [Purchase_Id] = " + id;

                }         

                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new PurchaseOrder();

                        item.Purchase_Id = Convert.ToInt32(dt.Rows[i]["Purchase_Id"].ToString());
                        item.Purchase_Nos = dt.Rows[i]["Purchase_Nos"].ToString();
                        item.PERid = Convert.ToInt32(dt.Rows[i]["PERid"].ToString());
                        item.DEBid = Convert.ToInt32(dt.Rows[i]["DEBid"].ToString());
                        item.STKid = Convert.ToInt32(dt.Rows[i]["STKid"].ToString());
                        item.JOBid = Convert.ToInt32(dt.Rows[i]["JOBid"].ToString());
                        item.Reference_Sales_Id = Convert.ToInt32(dt.Rows[i]["Reference_Sales_Id"].ToString());
                        item.Reference_Sales_Nos = dt.Rows[i]["Reference_Sales_Nos"].ToString();
                        item.Purchase_Date = Convert.ToDateTime(dt.Rows[i]["Purchase_Date"].ToString());
                        item.Purchase_Date_Text = Convert.ToDateTime(dt.Rows[i]["Purchase_Date"]).ToString(@"dd/MM/yyy");
                        item.Purchase_Quantity = Convert.ToInt32(dt.Rows[i]["Purchase_Quantity"].ToString());
                        item.Delivery_Id = Convert.ToInt32(dt.Rows[i]["Delivery_Id"].ToString());
                        item.Purchase_Delivery_Desc = dt.Rows[i]["Purchase_Delivery_Desc"].ToString();
                        item.Purchase_Desc = dt.Rows[i]["Purchase_Desc"].ToString();
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
                        item.Cost_Plastic_PP = Convert.ToDecimal(dt.Rows[i]["Cost_Plastic_PP"] == DBNull.Value ? 0 : dt.Rows[i]["Cost_Plastic_PP"]);
                        item.Cost_Plastic_PE = Convert.ToDecimal(dt.Rows[i]["Cost_Plastic_PE"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Plastic_PE"]);
                        item.Cost_Plastic_Coat = Convert.ToDecimal(dt.Rows[i]["Cost_Plastic_Coat"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Plastic_Coat"]);
                        item.Cost_Plastic_Pigment = Convert.ToDecimal(dt.Rows[i]["Cost_Plastic_Pigment"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Plastic_Pigment"]);
                        item.Cost_Print = Convert.ToDecimal(dt.Rows[i]["Cost_Print"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Print"]);
                        item.Cost_Print_OPP = Convert.ToDecimal(dt.Rows[i]["Cost_Print_OPP"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Print_OPP"]);
                        item.Cost_Handle_Uprice = Convert.ToDecimal(dt.Rows[i]["Cost_Handle_Uprice"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Handle_Uprice"]);
                        item.Cost_Tag_Uprice = Convert.ToDecimal(dt.Rows[i]["Cost_Tag_Uprice"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Tag_Uprice"]);
                        item.Cost_Sewing_Uprice = Convert.ToDecimal(dt.Rows[i]["Cost_Sewing_Uprice"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Sewing_Uprice"]);
                        item.Cost_Eyelet_Uprice = Convert.ToDecimal(dt.Rows[i]["Cost_Eyelet_Uprice"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Eyelet_Uprice"]);
                        item.Cost_Bell_Uprice = Convert.ToDecimal(dt.Rows[i]["Cost_Bell_Uprice"] == DBNull.Value ? 0 : dt.Rows[i]["Cost_Bell_Uprice"]);
                        item.Cost_Conversion = Convert.ToDecimal(dt.Rows[i]["Cost_Conversion"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Conversion"]);
                        item.Cost_Conversion_Coat = Convert.ToDecimal(dt.Rows[i]["Cost_Conversion_Coat"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Conversion_Coat"]);
                        item.Cost_Shipping = Convert.ToDecimal(dt.Rows[i]["Cost_Shipping"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Shipping"]);
                        item.Cost_Commission = Convert.ToDecimal(dt.Rows[i]["Cost_Commission"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Commission"]);
                        item.Cost_Product = Convert.ToDecimal(dt.Rows[i]["Cost_Product"]  == DBNull.Value ? 0 : dt.Rows[i]["Cost_Product"]);
                        item.MinimumPrice = Convert.ToDecimal(dt.Rows[i]["MinimumPrice"]  == DBNull.Value ? 0 : dt.Rows[i]["MinimumPrice"]);
                        item.Price = Convert.ToDecimal(dt.Rows[i]["Price"]  == DBNull.Value ? 0 : dt.Rows[i]["Price"]);
                        item.VAT = Convert.ToDecimal(dt.Rows[i]["VAT"]  == DBNull.Value ? 0 : dt.Rows[i]["VAT"]);
                        item.NetPrice = Convert.ToDecimal(dt.Rows[i]["NetPrice"] == DBNull.Value ? 0 : dt.Rows[i]["NetPrice"]);
                        item.Total_Weight = Convert.ToDecimal(dt.Rows[i]["Total_Weight"]  == DBNull.Value ? 0 : dt.Rows[i]["Total_Weight"]);
                        item.Profitperunit = Convert.ToDecimal(dt.Rows[i]["Profitperunit"]  == DBNull.Value ? 0 : dt.Rows[i]["Profitperunit"]);
                        item.Purchase_Status = Convert.ToInt32(dt.Rows[i]["Purchase_Status"].ToString());
                       


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

        public void LoadPurchaseOrder(List<int> item)
        {
            string id = "";
            if (item.Count > 0)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    if (i != 0)
                    {
                        id += ",";
                    }
                    id += item[i];
                }
            }

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @" INSERT INTO [dbo].[PURCHASE_ORDER]
                               ([Purchase_Nos]
                               ,[PERid]
                               ,[DEBid]
                               ,[STKid]
                               ,[JOBid]
                               ,[Reference_Sales_Id]
                               ,[Reference_Sales_Nos]
                               ,[Purchase_Date]
                               ,[Purchase_Quantity]
                               ,[Delivery_Id]
                               ,[Purchase_Delivery_Desc]
                               ,[Purchase_Desc]
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
                               ,[Purchase_Status]
                               ,[Purchase_CreateUser]
                               ,[Purchase_CreateDate]
                            )
                         select 
                             " + "'PR-" + DateTime.Now.ToString(@"yyyMMddHHmmss") + "' "
                              + @",0
                              ,0
                              ,0 
                              ,0
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
                              ,0
                              ,0
                              ,GetDate()
                    From [dbo].[SALES_REQUISITION] where [Sales_Id] in ( " + id + ");";

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

    }
}