using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class ClipBoardData
    {


        string msgErr = string.Empty;

        #region -- ClipBoard--
        public void GetClipBoard(out List<ClipBoard> ls, int ClipBoardid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<ClipBoard>();
            ClipBoard item = new ClipBoard();
            try
            {

                strSQL = @" SELECT [Clipboard_Id]
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
                              ,[Handle_Use]
                              ,[Handle_Quantity]
                              ,[Handle_Uprice]
                              ,[Tag_Use]
                              ,[Tag_Uprice]
                              ,[Sewing_Use]
                              ,[Sewing_Desc]
                              ,[Sewing_Uprice]
                              ,[Eyelet_Use]
                              ,[Eyelet_Uprice]
                              ,[Bell_Use]
                              ,[Bell_Uprice]
                              ,[Bagin_Use2]
                              ,[Bagin_Uprice]
                              ,[Conversion]
                              ,[Distance]
                              ,[Format_Saleprice]
                              ,[SalepricePerUnit]
                              ,[Total_Weight]
                              ,[Profitperunit]
                              ,[Note1]
                              ,[Note2]
                              ,[Note3]
                              ,[Note4]
                              ,[Clipboard_CreateUser]
                              ,[Clipboard_CreateDate]
                              ,[Clipboard_EditUser]
                              ,[Clipboard_EditDate]
                              ,[Clipboard_Delete]
                              ,[Clipboard_DeleteUser]
                              ,[Clipboard_DeleteDate]
                      FROM [dbo].[CLIPBOARD] where 0=0";
                if (ClipBoardid > 0)
                {

                    strSQL += " and Clipboard_Id=" + ClipBoardid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard();
                        item.Clipboard_Id = Convert.ToInt32(dt.Rows[i]["Clipboard_Id"].ToString());
                        item.Clipboard_Nos = dt.Rows[i]["Clipboard_Nos"].ToString();
                        item.Clipboard_Date = Convert.ToDateTime(dt.Rows[i]["Clipboard_Date"].ToString());
                        //item.Clipboard_Date = Convert.ToDateTime(dt.Rows[i]["Clipboard_Date"]);
                        item.Clipboard_Date_Str = item.Clipboard_Date.ToShortDateString();
                        item.Clipboard_Quantity = Convert.ToDecimal(dt.Rows[i]["Clipboard_Quantity"].ToString());
                        item.Delivery_Id = Convert.ToInt32(dt.Rows[i]["Delivery_Id"].ToString());
                        item.Clipboard_Delivery_Desc = dt.Rows[i]["Clipboard_Delivery_Desc"].ToString();
                        item.Clipboard_Desc = dt.Rows[i]["Clipboard_Desc"].ToString();
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
                        item.Bagin_Use_Text = Convert.ToBoolean(dt.Rows[i]["Bagin_Use"].ToString());
                        item.Bagin_Use = Convert.ToBoolean(dt.Rows[i]["Bagin_Use"].ToString()) == true ? 1 : 0;
                        item.Bagin_Micron = Convert.ToDecimal(dt.Rows[i]["Bagin_Micron"].ToString());
                        item.Bagin_Weight = Convert.ToDecimal(dt.Rows[i]["Bagin_Weight"].ToString());
                        item.Plastic_Use_Text = Convert.ToBoolean(dt.Rows[i]["Plastic_Use"].ToString());
                        item.Plastic_Use = Convert.ToBoolean(dt.Rows[i]["Plastic_Use"].ToString()) == true ? 1 : 0;
                        item.Plastic_Quantity = Convert.ToInt32(dt.Rows[i]["Plastic_Quantity"].ToString());
                        item.Plastic_Micron = Convert.ToDecimal(dt.Rows[i]["Plastic_Micron"].ToString());
                        item.Plastic_Weight = Convert.ToDecimal(dt.Rows[i]["Plastic_Weight"].ToString());
                        item.Gravure_Use = Convert.ToBoolean(dt.Rows[i]["Gravure_Use"].ToString()) == true ? 1 : 0; 
                        item.Gravure_Use_Text = Convert.ToBoolean(dt.Rows[i]["Gravure_Use"].ToString());
                        item.Gravure_Quantity = Convert.ToInt32(dt.Rows[i]["Gravure_Quantity"].ToString());
                        item.Gravure_Micron = Convert.ToDecimal(dt.Rows[i]["Gravure_Micron"].ToString());
                        item.Gravure_Weight = Convert.ToDecimal(dt.Rows[i]["Gravure_Weight"].ToString());
                        item.Print_Flexo_Use = Convert.ToBoolean(dt.Rows[i]["Print_Flexo_Use"].ToString()) == true ? 1 : 0;
                        item.Print_Flexo_Use_Text = Convert.ToBoolean(dt.Rows[i]["Print_Flexo_Use"].ToString());
                        item.Print_Flexo_Quantity = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Quantity"].ToString());
                        item.Print_Flexo_Print1 = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Print1"].ToString());
                        item.Print_Flexo_Print2 = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Print2"].ToString());
                        item.Print_Flexo_Area = Convert.ToDecimal(dt.Rows[i]["Print_Flexo_Area"].ToString());
                        item.Print_Gravure_Use = Convert.ToBoolean(dt.Rows[i]["Print_Gravure_Use"].ToString()) == true ? 1 : 0;
                        item.Print_Gravure_Use_Text = Convert.ToBoolean(dt.Rows[i]["Print_Gravure_Use"].ToString());
                        item.Print_Gravure_Area = Convert.ToDecimal(dt.Rows[i]["Print_Gravure_Area"].ToString());
                        item.Plastic_PP = Convert.ToDecimal(dt.Rows[i]["Plastic_PP"].ToString());
                        item.Plastic_PE = Convert.ToDecimal(dt.Rows[i]["Plastic_PE"].ToString());
                        item.Plastic_Coat = Convert.ToDecimal(dt.Rows[i]["Plastic_Coat"].ToString());
                        item.Plastic_Pigment = Convert.ToDecimal(dt.Rows[i]["Plastic_Pigment"].ToString());
                        item.Handle_Use = Convert.ToBoolean(dt.Rows[i]["Handle_Use"].ToString()) == true ? 1 : 0;
                        item.Handle_Quantity = Convert.ToDecimal(dt.Rows[i]["Handle_Quantity"].ToString());
                        item.Handle_Uprice = Convert.ToDecimal(dt.Rows[i]["Handle_Uprice"].ToString());
                        item.Tag_Use = Convert.ToBoolean(dt.Rows[i]["Tag_Use"].ToString()) == true ? 1 : 0;
                        item.Tag_Use_Text = Convert.ToBoolean(dt.Rows[i]["Tag_Use"].ToString());
                        item.Tag_Uprice = Convert.ToDecimal(dt.Rows[i]["Tag_Uprice"].ToString());
                        item.Sewing_Use = Convert.ToBoolean(dt.Rows[i]["Sewing_Use"].ToString()) == true ? 1 : 0;
                        item.Sewing_Desc = dt.Rows[i]["Sewing_Desc"].ToString();
                        item.Sewing_Uprice = Convert.ToDecimal(dt.Rows[i]["Sewing_Uprice"].ToString());
                        item.Eyelet_Use = Convert.ToBoolean(dt.Rows[i]["Eyelet_Use"].ToString()) == true ? 1 : 0;
                        item.Eyelet_Use_Text = Convert.ToBoolean(dt.Rows[i]["Eyelet_Use"].ToString());
                        item.Eyelet_Uprice = Convert.ToDecimal(dt.Rows[i]["Eyelet_Uprice"].ToString());
                        item.Bell_Use = Convert.ToBoolean(dt.Rows[i]["Bell_Use"].ToString()) == true ? 1 : 0;
                        item.Bell_Use_Text = Convert.ToBoolean(dt.Rows[i]["Bell_Use"].ToString());
                        item.Bell_Uprice = Convert.ToDecimal(dt.Rows[i]["Bell_Uprice"].ToString());
                        item.Bagin_Use2 = Convert.ToBoolean(dt.Rows[i]["Bagin_Use2"].ToString()) == true ? 1 : 0;
                        item.Bagin_Uprice = Convert.ToDecimal(dt.Rows[i]["Bagin_Uprice"].ToString());
                        item.Conversion = Convert.ToDecimal(dt.Rows[i]["Conversion"].ToString());
                        item.Distance = Convert.ToDecimal(dt.Rows[i]["Distance"].ToString());
                        item.Format_Saleprice = Convert.ToInt32(dt.Rows[i]["Format_Saleprice"].ToString());
                        item.SalepricePerUnit = Convert.ToDecimal(dt.Rows[i]["SalepricePerUnit"].ToString());
                        item.Total_Weight = Convert.ToDecimal(dt.Rows[i]["Total_Weight"].ToString());
                        item.Profitperunit = Convert.ToDecimal(dt.Rows[i]["Profitperunit"].ToString());
                        item.Note1 = dt.Rows[i]["Note1"].ToString();
                        item.Note2 = dt.Rows[i]["Note2"].ToString();
                        item.Note3 = dt.Rows[i]["Note3"].ToString();
                        item.Note4 = dt.Rows[i]["Note4"].ToString();
                        item.Clipboard_CreateUser = Convert.ToInt32(dt.Rows[i]["Clipboard_CreateUser"].ToString());
                        item.Clipboard_CreateDate = Convert.ToDateTime(dt.Rows[i]["Clipboard_CreateDate"].ToString());
                      
                        ls.Add(item);
                    }
                }
                else
                {
                    string Xno = Library.GetRunVoucher(0, 0, "", DateTime.Now.Year, DateTime.Now.Month);
                    if (Xno.Length > 0)
                    {
                        Xno = Library.SequenceStr(Xno);

                        while (Library.CheckExistCode("CLIPBOARD", 0, Xno) == true)
                        {
                            Xno = Library.SequenceStr(Xno);
                        }

                    }
                    else
                    {
                        int Xyear = DateTime.Now.Year;
                        string Xmont = DateTime.Now.Month.ToString();
                        if (DateTime.Now.Month < 10) Xmont = "0" + DateTime.Now.Month.ToString();
                        //if (Xyear < 2500) Xyear += 543;
                        Xno = Xyear.ToString().Substring(2, 2) + Xmont + "-0001";
                    }
                    item = new ClipBoard();
                    item.Clipboard_Nos = Xno;
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


        public void GetLastClipBoard(out List<ClipBoard> ls, int ClipBoardid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<ClipBoard>();
            ClipBoard item = new ClipBoard();
            try
            {
                string Xno = Library.GetRunVoucher(0, 0, "", DateTime.Now.Year, DateTime.Now.Month);
                if (Xno.Length > 0)
                {
                    Xno = Library.SequenceStr(Xno);

                    while (Library.CheckExistCode("CLIPBOARD", ClipBoardid, Xno) == true)
                    {
                        Xno = Library.SequenceStr(Xno);
                    }
                }
                else
                {
                    int Xyear = DateTime.Now.Year;
                    string Xmont = DateTime.Now.Month.ToString();
                    if (DateTime.Now.Month < 10) Xmont = "0" + DateTime.Now.Month.ToString();
                    //if (Xyear < 2500) Xyear += 543;
                    Xno = Xyear.ToString().Substring(2, 2) + Xmont + "-0001";
                }
                item = new ClipBoard();
                item.Clipboard_Nos = Xno;
                item.Clipboard_Date = Convert.ToDateTime(DateTime.Now.ToString());
                item.Clipboard_Date_Str = DateTime.Now.ToShortDateString();
                ls.Add(item);
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

        public void InsertClipboard(ClipBoard item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string strSQL = @"
                            INSERT INTO [dbo].[CLIPBOARD]
                                       ([Clipboard_Nos]
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
                                       ,[Clipboard_CreateUser]
                                       ,[Clipboard_CreateDate]
                                     )
     VALUES
           ("+ Utility.ReplaceString(item.Clipboard_Nos)+
           ","+ Utility.FormateDate(item.Clipboard_Date)+
           "," +item.Clipboard_Quantity+
           ","+item.Delivery_Id+
           ","+ Utility.ReplaceString(item.Clipboard_Delivery_Desc)+
           ","+ Utility.ReplaceString( item.Clipboard_Desc) +
           "," +item.Bag_Width+
           ","+item.Bag_Width_Add+
           ","+item.Bag_Lenght+
           ","+item.Bag_Lenght_Add+
           ","+item.Warpyarn_Denier+
           ","+item.Warpyarn_Mech+
           ","+item.Warpyarn_Width+
           ","+item.Fillingyarn_Denier+
           ","+item.Fillingyarn_Mech+
           ","+item.Fillingyarn_Width+
           ","+item.Bag_Weight+
           ","+item.Bagin_Use+
           ","+item.Bagin_Micron+
           ","+item.Bagin_Weight+
           ","+item.Plastic_Use+
           ","+item.Plastic_Quantity+
           ","+item.Plastic_Micron+
           ","+item.Plastic_Weight+
           ","+item.Gravure_Use+
           ","+item.Gravure_Quantity+
           ","+item.Gravure_Micron+
           ","+item.Gravure_Weight+
           ","+item.Print_Flexo_Use+
           ","+item.Print_Flexo_Quantity+
           ","+item.Print_Flexo_Print1+
           ","+item.Print_Flexo_Print2+
           ","+item.Print_Flexo_Area+
           ","+item.Print_Gravure_Use+
           ","+item.Print_Gravure_Area+
           ","+item.Plastic_PP+
           ","+item.Plastic_PE+
           ","+item.Plastic_Coat+
           ","+item.Plastic_Pigment+
           ","+item.Handle_Quantity+
           ","+item.Handle_Uprice+
           ","+item.Tag_Use+
           ","+item.Tag_Uprice+
           "," + Utility.ReplaceString(item.Sewing_Desc)+
           "," + item.Sewing_Uprice+
           ","+item.Eyelet_Use+
           ","+item.Eyelet_Uprice+
           ","+item.Bell_Use+
           ","+item.Bell_Uprice+
           ","+item.Conversion+
           ","+item.Distance+
           ","+item.Format_Saleprice+
           ","+item.SalepricePerUnit+
           ","+item.Total_Weight+
           ","+item.Profitperunit+
           ","+item.Clipboard_CreateUser+
           ", GetDate()" + ")";
              


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


        public void UpdateClipboard(ClipBoard item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string strSQL = @"
                            update [dbo].[CLIPBOARD] set
                                        [Clipboard_Nos]={1}
                                       ,[Clipboard_Date]={2}
                                       ,[Clipboard_Quantity]={3}
                                       ,[Delivery_Id]={4}
                                       ,[Clipboard_Delivery_Desc]={5}
                                       ,[Clipboard_Desc]={6}
                                       ,[Bag_Width]={7}
                                       ,[Bag_Width_Add]={8}
                                       ,[Bag_Lenght]={9}
                                       ,[Bag_Lenght_Add]={10}
                                       ,[Warpyarn_Denier]={11}
                                       ,[Warpyarn_Mech]={12}
                                       ,[Warpyarn_Width]={13}
                                       ,[Fillingyarn_Denier]={14}
                                       ,[Fillingyarn_Mech]={15}
                                       ,[Fillingyarn_Width]={16}
                                       ,[Bag_Weight]={17}
                                       ,[Bagin_Use]={18}
                                       ,[Bagin_Micron]={19}
                                       ,[Bagin_Weight]={20}
                                       ,[Plastic_Use]={21}
                                       ,[Plastic_Quantity]={22}
                                       ,[Plastic_Micron]={23}
                                       ,[Plastic_Weight]={24}
                                       ,[Gravure_Use]={25}
                                       ,[Gravure_Quantity]={26}
                                       ,[Gravure_Micron]={27}
                                       ,[Gravure_Weight]={28}
                                       ,[Print_Flexo_Use]={29}
                                       ,[Print_Flexo_Quantity]={30}
                                       ,[Print_Flexo_Print1]={31}
                                       ,[Print_Flexo_Print2]={32}
                                       ,[Print_Flexo_Area]={33}
                                       ,[Print_Gravure_Use]={34}
                                       ,[Print_Gravure_Area]={35}
                                       ,[Plastic_PP]={36}
                                       ,[Plastic_PE]={37}
                                       ,[Plastic_Coat]={38}
                                       ,[Plastic_Pigment]={39}
                                       ,[Handle_Quantity]={40}
                                       ,[Handle_Uprice]={41}
                                       ,[Tag_Use]={42}
                                       ,[Tag_Uprice]={43}
                                       ,[Sewing_Desc]={44}
                                       ,[Sewing_Uprice]={45}
                                       ,[Eyelet_Use]={46}
                                       ,[Eyelet_Uprice]={47}
                                       ,[Bell_Use]={48}
                                       ,[Bell_Uprice]={49}
                                       ,[Conversion]={50}
                                       ,[Distance]={51}
                                       ,[Format_Saleprice]={52}
                                       ,[SalepricePerUnit]={53}
                                       ,[Total_Weight]={54}
                                       ,[Profitperunit]={55}
                                       ,[Clipboard_EditUser]={56}
                                       ,[Clipboard_EditDate]={57}
                                     Where [Clipboard_Id]={0} ";

                                strSQL = string.Format(strSQL,
                                    item.Clipboard_Id,
                                    Utility.ReplaceString(item.Clipboard_Nos) ,
                                    Utility.FormateDate(item.Clipboard_Date) ,
                                    item.Clipboard_Quantity ,
                                    item.Delivery_Id ,
                                    Utility.ReplaceString(item.Clipboard_Delivery_Desc) ,
                                    Utility.ReplaceString(item.Clipboard_Desc) ,
                                    item.Bag_Width ,
                                    item.Bag_Width_Add ,
                                    item.Bag_Lenght ,
                                    item.Bag_Lenght_Add ,
                                    item.Warpyarn_Denier ,
                                    item.Warpyarn_Mech ,
                                    item.Warpyarn_Width ,
                                    item.Fillingyarn_Denier ,
                                    item.Fillingyarn_Mech ,
                                    item.Fillingyarn_Width ,
                                    item.Bag_Weight ,
                                    item.Bagin_Use ,
                                    item.Bagin_Micron ,
                                    item.Bagin_Weight ,
                                    item.Plastic_Use ,
                                    item.Plastic_Quantity ,
                                    item.Plastic_Micron ,
                                    item.Plastic_Weight ,
                                    item.Gravure_Use ,
                                    item.Gravure_Quantity ,
                                    item.Gravure_Micron ,
                                    item.Gravure_Weight ,
                                    item.Print_Flexo_Use ,
                                    item.Print_Flexo_Quantity ,
                                    item.Print_Flexo_Print1 ,
                                    item.Print_Flexo_Print2 ,
                                    item.Print_Flexo_Area ,
                                    item.Print_Gravure_Use ,
                                    item.Print_Gravure_Area ,
                                    item.Plastic_PP ,
                                    item.Plastic_PE ,
                                    item.Plastic_Coat ,
                                    item.Plastic_Pigment ,
                                    item.Handle_Quantity ,
                                    item.Handle_Uprice ,
                                    item.Tag_Use ,
                                    item.Tag_Uprice ,
                                    Utility.ReplaceString(item.Sewing_Desc) ,
                                    item.Sewing_Uprice ,
                                    item.Eyelet_Use ,
                                    item.Eyelet_Uprice ,
                                    item.Bell_Use ,
                                    item.Bell_Uprice ,
                                    item.Conversion ,
                                    item.Distance ,
                                    item.Format_Saleprice ,
                                    item.SalepricePerUnit ,
                                    item.Total_Weight ,
                                    item.Profitperunit ,
                                    item.Clipboard_CreateUser ,
                                    "GetDate()" );



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


        public void RecalculateClipBoard(out List<ClipBoard> ls, DateTime ClipBoardDate,int ProvinceID)
        {
            DateTime Gdate = DateTime.Now;

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<ClipBoard>();
            ClipBoard item = new ClipBoard();
            try
            {
                if (Library.IsDate(ClipBoardDate)) Gdate = ClipBoardDate;

                //Get Plastic

                strSQL = @" SELECT [Clipboard_Id]
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
                              ,[Clipboard_CreateUser]
                              ,[Clipboard_CreateDate]
                              ,[Clipboard_EditUser]
                              ,[Clipboard_EditDate]
                              ,[Clipboard_Delete]
                              ,[Clipboard_DeleteUser]
                              ,[Clipboard_DeleteDate]
                      FROM [dbo].[CLIPBOARD] where 0=0";
                //if (ClipBoardid > 0)
                //{

                //    strSQL += " and Clipboard_Id=" + ClipBoardid;
                //}
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard();
                        item.Clipboard_Id = Convert.ToInt32(dt.Rows[i]["Clipboard_Id"].ToString());
                        item.Clipboard_Nos = dt.Rows[i]["Clipboard_Nos"].ToString();
                        item.Clipboard_Date = Convert.ToDateTime(dt.Rows[i]["Clipboard_Date"].ToString());
                        //item.Clipboard_Date = Convert.ToDateTime(dt.Rows[i]["Clipboard_Date"]);
                        item.Clipboard_Date_Str = item.Clipboard_Date.ToShortDateString();
                        item.Clipboard_Quantity = Convert.ToDecimal(dt.Rows[i]["Clipboard_Quantity"].ToString());
                        item.Delivery_Id = Convert.ToInt32(dt.Rows[i]["Delivery_Id"].ToString());
                        item.Clipboard_Delivery_Desc = dt.Rows[i]["Clipboard_Delivery_Desc"].ToString();
                        item.Clipboard_Desc = dt.Rows[i]["Clipboard_Desc"].ToString();
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
                        item.Bagin_Use_Text = Convert.ToBoolean(dt.Rows[i]["Bagin_Use"].ToString());
                        item.Bagin_Use = Convert.ToBoolean(dt.Rows[i]["Bagin_Use"].ToString()) == true ? 1 : 2;
                        item.Bagin_Micron = Convert.ToDecimal(dt.Rows[i]["Bagin_Micron"].ToString());
                        item.Bagin_Weight = Convert.ToDecimal(dt.Rows[i]["Bagin_Weight"].ToString());
                        item.Plastic_Use_Text = Convert.ToBoolean(dt.Rows[i]["Plastic_Use"].ToString());
                        item.Plastic_Use = Convert.ToBoolean(dt.Rows[i]["Plastic_Use"].ToString()) == true ? 1 : 2;
                        item.Plastic_Quantity = Convert.ToInt32(dt.Rows[i]["Plastic_Quantity"].ToString());
                        item.Plastic_Micron = Convert.ToDecimal(dt.Rows[i]["Plastic_Micron"].ToString());
                        item.Plastic_Weight = Convert.ToDecimal(dt.Rows[i]["Plastic_Weight"].ToString());
                        item.Gravure_Use = Convert.ToBoolean(dt.Rows[i]["Gravure_Use"].ToString()) == true ? 1 : 2;
                        item.Gravure_Use_Text = Convert.ToBoolean(dt.Rows[i]["Gravure_Use"].ToString());
                        item.Gravure_Quantity = Convert.ToInt32(dt.Rows[i]["Gravure_Quantity"].ToString());
                        item.Gravure_Micron = Convert.ToDecimal(dt.Rows[i]["Gravure_Micron"].ToString());
                        item.Gravure_Weight = Convert.ToDecimal(dt.Rows[i]["Gravure_Weight"].ToString());
                        item.Print_Flexo_Use = Convert.ToBoolean(dt.Rows[i]["Print_Flexo_Use"].ToString()) == true ? 1 : 2;
                        item.Print_Flexo_Use_Text = Convert.ToBoolean(dt.Rows[i]["Print_Flexo_Use"].ToString());
                        item.Print_Flexo_Quantity = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Quantity"].ToString());
                        item.Print_Flexo_Print1 = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Print1"].ToString());
                        item.Print_Flexo_Print2 = Convert.ToInt32(dt.Rows[i]["Print_Flexo_Print2"].ToString());
                        item.Print_Flexo_Area = Convert.ToDecimal(dt.Rows[i]["Print_Flexo_Area"].ToString());
                        item.Print_Gravure_Use_Text = Convert.ToBoolean(dt.Rows[i]["Print_Gravure_Use"].ToString());
                        item.Print_Gravure_Area = Convert.ToDecimal(dt.Rows[i]["Print_Gravure_Area"].ToString());
                        item.Plastic_PP = Convert.ToDecimal(dt.Rows[i]["Plastic_PP"].ToString());
                        item.Plastic_PE = Convert.ToDecimal(dt.Rows[i]["Plastic_PE"].ToString());
                        item.Plastic_Coat = Convert.ToDecimal(dt.Rows[i]["Plastic_Coat"].ToString());
                        item.Plastic_Pigment = Convert.ToDecimal(dt.Rows[i]["Plastic_Pigment"].ToString());
                        item.Handle_Quantity = Convert.ToDecimal(dt.Rows[i]["Handle_Quantity"].ToString());
                        item.Handle_Uprice = Convert.ToDecimal(dt.Rows[i]["Handle_Uprice"].ToString());
                        item.Tag_Use_Text = Convert.ToBoolean(dt.Rows[i]["Tag_Use"].ToString());
                        item.Tag_Uprice = Convert.ToDecimal(dt.Rows[i]["Tag_Uprice"].ToString());
                        item.Sewing_Desc = dt.Rows[i]["Sewing_Desc"].ToString();
                        item.Sewing_Uprice = Convert.ToDecimal(dt.Rows[i]["Sewing_Uprice"].ToString());
                        item.Eyelet_Use_Text = Convert.ToBoolean(dt.Rows[i]["Eyelet_Use"].ToString());
                        item.Eyelet_Uprice = Convert.ToDecimal(dt.Rows[i]["Eyelet_Uprice"].ToString());
                        item.Bell_Use_Text = Convert.ToBoolean(dt.Rows[i]["Bell_Use"].ToString());
                        item.Bell_Uprice = Convert.ToDecimal(dt.Rows[i]["Bell_Uprice"].ToString());
                        item.Conversion = Convert.ToDecimal(dt.Rows[i]["Conversion"].ToString());
                        item.Distance = Convert.ToDecimal(dt.Rows[i]["Distance"].ToString());
                        item.Format_Saleprice = Convert.ToInt32(dt.Rows[i]["Format_Saleprice"].ToString());
                        item.SalepricePerUnit = Convert.ToDecimal(dt.Rows[i]["SalepricePerUnit"].ToString());
                        item.Total_Weight = Convert.ToDecimal(dt.Rows[i]["Total_Weight"].ToString());
                        item.Profitperunit = Convert.ToDecimal(dt.Rows[i]["Profitperunit"].ToString());
                        item.Clipboard_CreateUser = Convert.ToInt32(dt.Rows[i]["Clipboard_CreateUser"].ToString());
                        item.Clipboard_CreateDate = Convert.ToDateTime(dt.Rows[i]["Clipboard_CreateDate"].ToString());

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

        public void GetCodeBagin2ClipBoard(out List<ClipBoard_Bagin2> ls, DateTime Gdate)
        {
            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlDataAdapter da;
            DataTable dt;
            DateTime Xdate;

            ls = new List<ClipBoard_Bagin2>();
            ClipBoard_Bagin2 item = new ClipBoard_Bagin2();
            try
            {

                Xdate = DateTime.Now;
                if (Library.IsDate(Gdate)) Xdate = Gdate;
                strSQL = " select b.* FROM [dbo].[SEWING_OTHER] b  inner join [dbo].[SEWING_HEADER] a on b.Sewing_Id=a.Sewing_Id  where b.Sewing_O_Desc like '%สวมถุงใน%' and (@Sewing_DateStart >= a.Sewing_DateStart and @Sewing_DateEnd <= a.Sewing_DateEnd) and b.Sewing_O_Delete=0 order by b.Sewing_O_Id";

                da = new SqlDataAdapter(strSQL, objConn);
                da.SelectCommand.CommandTimeout = 300;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.Add("@Sewing_DateStart", SqlDbType.DateTime).Value = Xdate;
                da.SelectCommand.Parameters.Add("@Sewing_DateEnd", SqlDbType.DateTime).Value = Xdate;
                dt = new DataTable("Bell");
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard_Bagin2();
                        item.Cost_E_Id = Convert.ToInt32(dt.Rows[i]["Sewing_D_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Sewing_Id"].ToString());
                        item.Bagin2_Id = Library.DBInt(dt.Rows[i]["Sewing_D_Code"]);
                        item.Bagin2_Desc = dt.Rows[i]["Sewing_D_Desc"].ToString();
                        item.Bagin2_Uprice = Library.DBDecimal(dt.Rows[i]["Sewing_D_Uprice"]);
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

        public void GetCodeBellClipBoard(out List<ClipBoard_Bell> ls, DateTime Gdate)
        {
            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlDataAdapter da;
            DataTable dt;
            DateTime Xdate;

            ls = new List<ClipBoard_Bell>();
            ClipBoard_Bell item = new ClipBoard_Bell();
            try
            {

                Xdate = DateTime.Now;
                if (Library.IsDate(Gdate)) Xdate = Gdate;
                strSQL = " select b.* FROM [dbo].[SEWING_OTHER] b  inner join [dbo].[SEWING_HEADER] a on b.Sewing_Id=a.Sewing_Id  where b.Sewing_O_Desc like '%เบล%' and (@Sewing_DateStart >= a.Sewing_DateStart and @Sewing_DateEnd <= a.Sewing_DateEnd) and b.Sewing_O_Delete=0 order by b.Sewing_O_Id";

                da = new SqlDataAdapter(strSQL, objConn);
                da.SelectCommand.CommandTimeout = 300;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.Add("@Sewing_DateStart", SqlDbType.DateTime).Value = Xdate;
                da.SelectCommand.Parameters.Add("@Sewing_DateEnd", SqlDbType.DateTime).Value = Xdate;
                dt = new DataTable("Bell");
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard_Bell();
                        item.Cost_E_Id = Convert.ToInt32(dt.Rows[i]["Sewing_O_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Sewing_Id"].ToString());
                        item.Bell_Id = Library.DBInt(dt.Rows[i]["Sewing_O_Code"]);
                        item.Bell_Desc = dt.Rows[i]["Sewing_O_Desc"].ToString();
                        item.Bell_Uprice = Library.DBDecimal(dt.Rows[i]["Sewing_O_Uprice"]);
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

        public void GetCodeEyeletClipBoard(out List<ClipBoard_Eyelet> ls, DateTime Gdate)
        {
            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlDataAdapter da;
            DataTable dt;
            DateTime Xdate;

            ls = new List<ClipBoard_Eyelet>();
            ClipBoard_Eyelet item = new ClipBoard_Eyelet();
            try
            {

                Xdate = DateTime.Now;
                if (Library.IsDate(Gdate)) Xdate = Gdate;
                strSQL = " select b.* FROM [dbo].[SEWING_OTHER] b  inner join [dbo].[SEWING_HEADER] a on b.Sewing_Id=a.Sewing_Id  where b.Sewing_O_Desc like '%เจาะตาไก่%' and (@Sewing_DateStart >= a.Sewing_DateStart and @Sewing_DateEnd <= a.Sewing_DateEnd) and b.Sewing_O_Delete=0 order by b.Sewing_O_Id";

                da = new SqlDataAdapter(strSQL, objConn);
                da.SelectCommand.CommandTimeout = 300;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.Add("@Sewing_DateStart", SqlDbType.DateTime).Value = Xdate;
                da.SelectCommand.Parameters.Add("@Sewing_DateEnd", SqlDbType.DateTime).Value = Xdate;
                dt = new DataTable("Eyelet");
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard_Eyelet();
                        item.Cost_E_Id = Convert.ToInt32(dt.Rows[i]["Sewing_O_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Sewing_Id"].ToString());
                        item.Eyelet_Id = Library.DBInt(dt.Rows[i]["Sewing_O_Code"]);
                        item.Eyelet_Desc = dt.Rows[i]["Sewing_O_Desc"].ToString();
                        item.Eyelet_Uprice = Library.DBDecimal(dt.Rows[i]["Sewing_O_Uprice"]);
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

        public void GetCodeHandleClipBoard(out List<ClipBoard_Handle> ls, DateTime Gdate)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlDataAdapter da;
            DataTable dt;
            DateTime Xdate;

            ls = new List<ClipBoard_Handle>();
            ClipBoard_Handle item = new ClipBoard_Handle();
            try
            {

                Xdate = DateTime.Now;
                if (Library.IsDate(Gdate)) Xdate = Gdate;
                //strSQL = " select b.* FROM [dbo].[COST_EQUIPMENT] b  inner join [dbo].[COST_HEADER] a on b.Cost_Id=a.Cost_Id  where b.Cost_E_Desc like '%หูหิ้ว%' and (@Cost_DateStart >= a.Cost_DateStart and @Cost_DateEnd <= a.Cost_DateEnd) and b.Cost_E_Delete=0 order by b.Cost_E_Id";
                strSQL = " select b.* FROM [dbo].[COST_EQUIPMENT] b  inner join [dbo].[COST_HEADER] a on b.Cost_Id=a.Cost_Id  where b.Cost_E_Desc like '%หูหิ้ว%' and (@Cost_DateStart >= a.Cost_DateStart and @Cost_DateEnd  <= a.Cost_DateEnd) and b.Cost_E_Delete=0 order by b.Cost_E_Id";

                da = new SqlDataAdapter(strSQL, objConn);
                da.SelectCommand.CommandTimeout = 300;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.Add("@Cost_DateStart", SqlDbType.DateTime).Value = Xdate;
                da.SelectCommand.Parameters.Add("@Cost_DateEnd", SqlDbType.DateTime).Value = Xdate;
                dt = new DataTable("Handle");
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard_Handle();
                        item.Cost_E_Id = Convert.ToInt32(dt.Rows[i]["Cost_E_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Cost_Id"].ToString());
                        item.Handle_Id = Library.DBInt(dt.Rows[i]["Cost_E_Code"]);
                        item.Handle_Desc = dt.Rows[i]["Cost_E_Desc"].ToString();
                        item.Handle_Uprice = Library.DBDecimal(dt.Rows[i]["Cost_E_Uprice"]);
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

        public void GetCodeTagClipBoard(out List<ClipBoard_Tag> ls, DateTime Gdate)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlDataAdapter da;
            DataTable dt;
            DateTime Xdate;

            ls = new List<ClipBoard_Tag>();
            ClipBoard_Tag item = new ClipBoard_Tag();
            try
            {

                Xdate = DateTime.Now;
                if (Library.IsDate(Gdate)) Xdate = Gdate;
                //strSQL = " select b.* FROM [dbo].[COST_EQUIPMENT] b  inner join [dbo].[COST_HEADER] a on b.Cost_Id=a.Cost_Id  where b.Cost_E_Desc like '%หูหิ้ว%' and (@Cost_DateStart >= a.Cost_DateStart and @Cost_DateEnd <= a.Cost_DateEnd) and b.Cost_E_Delete=0 order by b.Cost_E_Id";
                strSQL = " select b.* FROM [dbo].[COST_EQUIPMENT] b  inner join [dbo].[COST_HEADER] a on b.Cost_Id=a.Cost_Id  where b.Cost_E_Desc like '%tag%' and (@Cost_DateStart >= a.Cost_DateStart and @Cost_DateEnd <= a.Cost_DateEnd) and b.Cost_E_Delete=0 order by b.Cost_E_Id";

                da = new SqlDataAdapter(strSQL, objConn);
                da.SelectCommand.CommandTimeout = 300;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.Add("@Cost_DateStart", SqlDbType.DateTime).Value = Xdate;
                da.SelectCommand.Parameters.Add("@Cost_DateEnd", SqlDbType.DateTime).Value = Xdate;
                dt = new DataTable("Handle");
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard_Tag();
                        item.Cost_E_Id = Convert.ToInt32(dt.Rows[i]["Cost_E_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Cost_Id"].ToString());
                        item.Tag_Id = Library.DBInt(dt.Rows[i]["Cost_E_Code"]);
                        item.Tag_Desc = dt.Rows[i]["Cost_E_Desc"].ToString();
                        item.Tag_Uprice = Library.DBDecimal(dt.Rows[i]["Cost_E_Uprice"]);
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

        public void GetCodeSewingClipBoard(out List<ClipBoard_Sewing> ls, DateTime Gdate)
        {
            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlDataAdapter da;
            DataTable dt;
            DateTime Xdate;

            ls = new List<ClipBoard_Sewing>();
            ClipBoard_Sewing item = new ClipBoard_Sewing();
            try
            {

                Xdate = DateTime.Now;
                if (Library.IsDate(Gdate)) Xdate = Gdate;
                strSQL = " select b.* FROM [dbo].[SEWING_DETAIL] b  inner join [dbo].[SEWING_HEADER] a on b.Sewing_Id=a.Sewing_Id  where b.Sewing_D_Desc like '%งานเย็บ%' and (@Sewing_DateStart >= a.Sewing_DateStart and @Sewing_DateEnd <= a.Sewing_DateEnd) and b.Sewing_D_Delete=0 order by b.Sewing_D_Id";

                da = new SqlDataAdapter(strSQL, objConn);
                da.SelectCommand.CommandTimeout = 300;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.Add("@Sewing_DateStart", SqlDbType.DateTime).Value = Xdate;
                da.SelectCommand.Parameters.Add("@Sewing_DateEnd", SqlDbType.DateTime).Value = Xdate;
                dt = new DataTable("Sewing");
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new ClipBoard_Sewing();
                        item.Cost_E_Id = Convert.ToInt32(dt.Rows[i]["Sewing_D_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Sewing_Id"].ToString());
                        item.Sewing_Id = Library.DBInt(dt.Rows[i]["Sewing_D_Code"]);
                        item.Sewing_Desc = dt.Rows[i]["Sewing_D_Desc"].ToString();
                        item.Sewing_Uprice = Library.DBDecimal(dt.Rows[i]["Sewing_D_Uprice"]);
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
        #endregion
    }
}