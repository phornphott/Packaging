using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class SHIPPING_HEADER
    {
        public int Shipping_Id { get; set; }
        public string Shipping_Name { get; set; }
        public bool Shipping_Use { get; set; }
        public bool Shipping_UseDate { get; set; }
        public string Shipping_DateStart_Input { get; set; }
        public string Shipping_DateEnd_Input { get; set; }
        public DateTime Shipping_DateStart { get; set; }
        public string Shipping_DateStart_Text
        {
            get
            {
                return Shipping_DateStart == DateTime.MinValue ? null : Shipping_DateStart.ToString("yyyy-MM-dd");
            }
        }
        public DateTime Shipping_DateEnd { get; set; }
        public string Shipping_DateEnd_Text
        {
            get
            {
                return Shipping_DateEnd == DateTime.MinValue ? null : Shipping_DateEnd.ToString("yyyy-MM-dd");
            }
        }
        public string Shipping_Desc { get; set; }
        public int Shipping_CreateUser { get; set; }
        public DateTime Shipping_CreateDate { get; set; }
        public int Shipping_EditUser { get; set; }
        public DateTime Shipping_EditDate { get; set; }
        public int Shipping_Delete { get; set; }
        public int Shipping_DeleteUser { get; set; }
        public DateTime Shipping_DeleteDate { get; set; }

    }

    public class SHIPPING_DETAIL
    {
        public int Shipping_D_Id { get; set; }
        public int Shipping_Id { get; set; }
        public string Shipping_Header_Name { get; set; }
        public string Shipping_D_Range { get; set; }
        public string Shipping_D_Uname { get; set; }
        public decimal Shipping_D_Uprice { get; set; }
        public int Shipping_D_Listno { get; set; }
        public int Shipping_D_CreateUser { get; set; }
        public DateTime Shipping_D_CreateDate { get; set; }
        public int Shipping_D_EditUser { get; set; }
        public DateTime Shipping_D_EditDate { get; set; }
        public int Shipping_D_Delete { get; set; }
        public int Shipping_D_DeleteUser { get; set; }
        public DateTime Shipping_D_DeleteDate { get; set; }

    }


}