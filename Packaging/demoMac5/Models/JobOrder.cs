﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class JobOrder
    {

        public int Job_Id { get; set; }
        public string Job_Nos { get; set; }
        public DateTime Job_Date { get; set; }
        public DateTime Job_MfgDate { get; set; }
        public DateTime Job_DeliveryDate { get; set; }
        public int JOBid { get; set; }
        public int PERid { get; set; }
        public int DEBid { get; set; }
        public int STKid { get; set; }
        public string Job_Product { get; set; }
        public string Job_Mark { get; set; }
        public int Reference_PO_Id { get; set; }
        public string Reference_PO_Nos { get; set; }
        public decimal Job_Quantity { get; set; }
        public int Delivery_Id { get; set; }
        public string Job_Delivery_Desc { get; set; }
        public string Job_Desc { get; set; }
        public decimal Bag_Width { get; set; }
        public decimal Bag_Width_Add { get; set; }
        public decimal Bag_Lenght { get; set; }
        public decimal Bag_Lenght_Add { get; set; }
        public decimal Bag_Height { get; set; }
        public decimal Warpyarn_Denier { get; set; }
        public decimal Warpyarn_Mech { get; set; }
        public decimal Warpyarn_Width { get; set; }
        public decimal Fillingyarn_Denier { get; set; }
        public decimal Fillingyarn_Mech { get; set; }
        public decimal Fillingyarn_Width { get; set; }
        public decimal Bag_Weight { get; set; }
        public decimal Bag_Weight_Plus { get; set; }
        public decimal Bag_Weight_Minimum { get; set; }
        public decimal Bag_Special { get; set; }
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
        public decimal Print_Flexo_Print1 { get; set; }
        public decimal Print_Flexo_Print2 { get; set; }
        public decimal Print_Flexo_Area { get; set; }
        public bool Print_Gravure_Use { get; set; }
        public decimal Print_Gravure_Area { get; set; }
        public string Print_Special { get; set; }
        public decimal Plastic_PP { get; set; }
        public decimal Plastic_PE { get; set; }
        public string Plastic_Coat { get; set; }
        public string Plastic_Pigment { get; set; }
        public string Handle_Quantity { get; set; }
        public string Handle_Uprice { get; set; }
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
        public decimal Format_Saleprice { get; set; }
        public decimal SalepricePerUnit { get; set; }
        public decimal Cost_Plastic_PP { get; set; }
        public decimal Cost_Plastic_PE { get; set; }
        public decimal Cost_Plastic_Coat { get; set; }
        public decimal Cost_Plastic_Pigment { get; set; }
        public decimal Cost_Print { get; set; }
        public decimal Cost_Print_OPP { get; set; }
        public decimal Cost_Handle_Uprice { get; set; }
        public decimal Cost_Tag_Uprice { get; set; }
        public decimal Cost_Sewing_Uprice { get; set; }
        public decimal Cost_Eyelet_Uprice { get; set; }
        public decimal Cost_Bell_Uprice { get; set; }
        public decimal Cost_Conversion { get; set; }
        public decimal Cost_Conversion_Coat { get; set; }
        public decimal Cost_Shipping { get; set; }
        public decimal Cost_Commission { get; set; }
        public decimal Cost_Product { get; set; }
        public decimal MinimumPrice { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Total_Weight { get; set; }
        public decimal Profitperunit { get; set; }
        public int Job_CreateUser { get; set; }
        public DateTime Job_CreateDate { get; set; }
        public int Job_EditUser { get; set; }
        public DateTime Job_EditDate { get; set; }
        public int Job_Delete { get; set; }
        public int Job_DeleteUser { get; set; }
        public DateTime Job_DeleteDate { get; set; }
    }
}