using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class ClipBoard
    {
        public int Clipboard_Id { get; set; }
        public string Clipboard_Nos { get; set; }
        public DateTime Clipboard_Date { get; set; }
        public string Clipboard_Date_Text
        {
            get
            {
                return Clipboard_Date == DateTime.MinValue ? null : Clipboard_Date.ToString("yyyy-MM-dd");
                //return Clipboard_Date == DateTime.MinValue ? null : Clipboard_Date.ToString("dd/MM/yyyy");
            }
        }
        public string Clipboard_Date_Str { get; set; }
        public decimal Clipboard_Quantity { get; set; }
        public int Delivery_Id { get; set; }
        public string Clipboard_Delivery_Desc { get; set; }
        public string Clipboard_Desc { get; set; }
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
        public int Bagin_Use { get; set; }
        public bool Bagin_Use_Text { get; set; }
        public decimal Bagin_Micron { get; set; }
        public decimal Bagin_Weight { get; set; }
        public int Plastic_Use { get; set; }
        public bool Plastic_Use_Text { get; set; }
        public int Plastic_Quantity { get; set; }
        public decimal Plastic_Micron { get; set; }
        public decimal Plastic_Weight { get; set; }
        public int Gravure_Use { get; set; }
        public bool Gravure_Use_Text { get; set; }
        public int Gravure_Quantity { get; set; }
        public decimal Gravure_Micron { get; set; }
        public decimal Gravure_Weight { get; set; }
        public int Print_Flexo_Use { get; set; }
        public bool Print_Flexo_Use_Text { get; set; }
        public int Print_Flexo_Quantity { get; set; }
        public int Print_Flexo_Print1 { get; set; }
        public int Print_Flexo_Print2 { get; set; }
        public decimal Print_Flexo_Area { get; set; }
        public int Print_Gravure_Use { get; set; }
        public bool Print_Gravure_Use_Text { get; set; }
        public decimal Print_Gravure_Area { get; set; }
        public decimal Plastic_PP { get; set; }
        public decimal Plastic_PE { get; set; }
        public decimal Plastic_Coat { get; set; }
        public decimal Plastic_Pigment { get; set; }
        public int Handle_Use { get; set; }
        public decimal Handle_Quantity { get; set; }
        public decimal Handle_Uprice { get; set; }
        public int Tag_Use { get; set; }
        public bool Tag_Use_Text { get; set; }
        public decimal Tag_Uprice { get; set; }
        public int Sewing_Use { get; set; }
        public string Sewing_Desc { get; set; }
        public decimal Sewing_Uprice { get; set; }
        public int Eyelet_Use { get; set; }
        public bool Eyelet_Use_Text { get; set; }
        public decimal Eyelet_Uprice { get; set; }
        public int Bell_Use { get; set; }
        public bool Bell_Use_Text { get; set; }
        public decimal Bell_Uprice { get; set; }
        public int Bagin_Use2 { get; set; }
        public decimal Bagin_Uprice { get; set; }
        public decimal Conversion { get; set; }
        public decimal Distance { get; set; }
        public int Format_Saleprice { get; set; }
        public decimal SalepricePerUnit { get; set; }
        public decimal Total_Weight { get; set; }
        public decimal Profitperunit { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public int Clipboard_CreateUser { get; set; }
        public DateTime Clipboard_CreateDate { get; set; }
        public int Clipboard_EditUser { get; set; }
        public DateTime Clipboard_EditDate { get; set; }
        public int Clipboard_Delete { get; set; }
        public int Clipboard_DeleteUser { get; set; }
        public DateTime Clipboard_DeleteDate { get; set; }
     }

    public class ObjClipBoard
    {
        public List<ClipBoard_Handle> ListHandle { get; set; }
        public List<ClipBoard_Tag> ListTag { get; set; }
        public List<ClipBoard_Sewing> ListSewing { get; set; }
        public List<ClipBoard_Bagin2> ListBagin2 { get; set; }
        public List<ClipBoard_Bell> ListBell { get; set; }
        public List<ClipBoard_Eyelet> ListEyelet { get; set; }
    }

    public class ClipBoard_Handle
    {
        public int Cost_Id { get; set; }
        public int Cost_E_Id { get; set; }
        public int Handle_Id { get; set; }
        public string Handle_Desc { get; set; }
        public decimal Handle_Uprice { get; set; }

    }

    public class ClipBoard_Tag
    {
        public int Cost_Id { get; set; }
        public int Cost_E_Id { get; set; }
        public int Tag_Id { get; set; }
        public string Tag_Desc { get; set; }
        public decimal Tag_Uprice { get; set; }

    }

    public class ClipBoard_Sewing
    {
        public int Cost_Id { get; set; }
        public int Cost_E_Id { get; set; }
        public int Sewing_Id { get; set; }
        public string Sewing_Desc { get; set; }
        public decimal Sewing_Uprice { get; set; }

    }

    public class ClipBoard_Bagin2
    {
        public int Cost_Id { get; set; }
        public int Cost_E_Id { get; set; }
        public int Bagin2_Id { get; set; }
        public string Bagin2_Desc { get; set; }
        public decimal Bagin2_Uprice { get; set; }

    }

    public class ClipBoard_Bell
    {
        public int Cost_Id { get; set; }
        public int Cost_E_Id { get; set; }
        public int Bell_Id { get; set; }
        public string Bell_Desc { get; set; }
        public decimal Bell_Uprice { get; set; }

    }

    public class ClipBoard_Eyelet
    {
        public int Cost_Id { get; set; }
        public int Cost_E_Id { get; set; }
        public int Eyelet_Id { get; set; }
        public string Eyelet_Desc { get; set; }
        public decimal Eyelet_Uprice { get; set; }

    }
}