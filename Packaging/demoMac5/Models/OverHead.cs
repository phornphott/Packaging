using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class OVERHEAD_HEADER
    {
        public int Overhead_Id { get; set; }
        public string Overhead_Name { get; set; }
        public bool Overhead_Use { get; set; }
        public bool Overhead_UseDate { get; set; }
        public string Overhead_DateStart_Input { get; set; }
        public string Overhead_DateEnd_Input { get; set; }
        public DateTime Overhead_DateStart { get; set; }
        public string Overhead_DateStart_Text
        {
            get
            {
                return Overhead_DateStart == DateTime.MinValue ? null : Overhead_DateStart.ToString("yyyy-MM-dd");
            }
        }
        public DateTime Overhead_DateEnd { get; set; }
        public string Overhead_DateEnd_Text
        {
            get
            {
                return Overhead_DateEnd == DateTime.MinValue ? null : Overhead_DateEnd.ToString("yyyy-MM-dd");
            }
        }
        public string Overhead_Desc { get; set; }
        public int Overhead_CreateUser { get; set; }
        public DateTime Overhead_CreateDate { get; set; }
        public int Overhead_EditUser { get; set; }
        public DateTime Overhead_EditDate { get; set; }
        public int Overhead_Delete { get; set; }
        public int Overhead_DeleteUser { get; set; }
        public DateTime Overhead_DeleteDate { get; set; }

    }

    public class OVERHEAD_DETAIL
    {

        public int Overhead_D_Id { get; set; }
        public int Overhead_Id { get; set; }
        public int Deparment_Id { get; set; }
        public string Overhead_Header_Name { get; set; }
        public string Overhead_D_Code { get; set; }
        public string Overhead_D_Desc { get; set; }
        public string Overhead_D_Uname { get; set; }
        public decimal Overhead_D_Uprice { get; set; }
        public string Overhead_D_Memo { get; set; }
        public int Overhead_D_Listno { get; set; }
        public int Overhead_D_CreateUser { get; set; }
        public DateTime Overhead_D_CreateDate { get; set; }
        public int Overhead_D_EditUser { get; set; }
        public DateTime Overhead_D_EditDate { get; set; }
        public int Overhead_D_Delete { get; set; }
        public int Overhead_D_DeleteUser { get; set; }
        public DateTime Overhead_D_DeleteDate { get; set; }



    }
}