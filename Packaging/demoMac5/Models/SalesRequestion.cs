using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class SalesRequestion
    {
        public int  Sales_Id { get; set; }
        public string Sales_Nos { get; set; }
        public int PERid { get; set; }
        public int DEBid { get; set; }
        public int Reference_Clipboard_Id { get; set; }
        public string Reference_Clipboard_Nos { get; set; }
        public DateTime Sales_Date { get; set; }
        public decimal Sales_Quantity { get; set; }
        public int Delivery_Id { get; set; }
        public string Sales_Delivery_Desc { get; set; }
        public string Sales_Desc { get; set; }
        public decimal Bag_Width { get; set; }
        public decimal Bag_Width_Add { get; set; }
        public decimal Bag_Lenght { get; set; }
        public decimal Bag_Lenght_Add { get; set; }
        public decimal Warpyarn_Denier { get; set; }
        public decimal Warpyarn_Mech { get; set; }
        public decimal Warpyarn_Width { get; set; }
        public decimal Fillingyarn_Denier { get; set; }
        public decimal Fillingyarn_Mech { get; set; }
        public decimal Fillingyarn_Width { get; set; }
        public decimal Bag_Weight { get; set; }
        public bool Bagin_Use { get; set; }
        public decimal Bagin_Micron { get; set; }
        public decimal Bagin_Weight { get; set; }
        public bool Plastic_Use { get; set; }
        public int Plastic_Quantity { get; set; }
        public decimal Plastic_Micron { get; set; }
        public decimal Plastic_Weight { get; set; }
        public bool Gravure_Use { get; set; }
        public int Gravure_Quantity { get; set; }
        public decimal Gravure_Micron { get; set; }
        public decimal Gravure_Weight { get; set; }
        public bool Print_Flexo_Use { get; set; }
        public int Print_Flexo_Quantity { get; set; }
        public int Print_Flexo_Print1 { get; set; }
        public int Print_Flexo_Print2 { get; set; }
        public decimal Print_Flexo_Area { get; set; }
        public bool Print_Gravure_Use { get; set; }
        public decimal Print_Gravure_Area { get; set; }
        public decimal Plastic_PP { get; set; }
        public decimal Plastic_PE { get; set; }
        public decimal Plastic_Coat { get; set; }
        public decimal Plastic_Pigment { get; set; }
        public int Handle_Quantity { get; set; }
        public decimal Handle_Uprice { get; set; }
        public bool Tag_Use { get; set; }
        public decimal Tag_Uprice { get; set; }
        public string Sewing_Desc { get; set; }
        public decimal Sewing_Uprice { get; set; }
        public bool Eyelet_Use { get; set; }
        public decimal Eyelet_Uprice { get; set; }
        public bool Bell_Use { get; set; }
        public decimal Bell_Uprice { get; set; }
        public decimal Conversion { get; set; }
        public decimal Distance { get; set; }
        public int Format_Saleprice { get; set; }
        public decimal SalepricePerUnit { get; set; }
        public decimal Total_Weight { get; set; }
        public decimal Profitperunit { get; set; }
        public int Sales_Status { get; set; }
        public int ApproveBy { get; set; }
        public int Sales_CreateUser { get; set; }
        public DateTime Sales_CreateDate { get; set; }
        public int Sales_EditUser { get; set; }
        public DateTime Sales_EditDate { get; set; }
        public bool Sales_Delete { get; set; }
        public int Sales_DeleteUser { get; set; }
        public DateTime Sales_DeleteDate { get; set; }
        public string Sales_Date_Text { get; internal set; }
    }
}