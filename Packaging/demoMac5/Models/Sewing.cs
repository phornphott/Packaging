using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    //ค่าจ้างเย็บด้าย
    public class SEWING_HEADER
    {
        public int Sewing_Id { get; set; }
        public string Sewing_Name { get; set; }
        public bool Sewing_Use { get; set; }
        public bool Sewing_UseDate { get; set; }
        public DateTime Sewing_DateStart { get; set; }
        public string Sewing_DateStart_Text
        {
            get
            {
                return Sewing_DateStart == DateTime.MinValue ? null : Sewing_DateStart.ToString("yyyy-MM-dd");
            }
        }
        public DateTime Sewing_DateEnd { get; set; }
        public string Sewing_DateEnd_Text
        {
            get
            {
                return Sewing_DateEnd == DateTime.MinValue ? null : Sewing_DateEnd.ToString("yyyy-MM-dd");
            }
        }
        public string Sewing_DateStart_Input { get; set; }
        public string Sewing_DateEnd_Input { get; set; }
        public string Sewing_Desc { get; set; }
        public int Sewing_CreateUser { get; set; }
        public DateTime Sewing_CreateDate { get; set; }
        public int Sewing_EditUser { get; set; }
        public DateTime Sewing_EditDate { get; set; }
        public int Sewing_Delete { get; set; }
        public int Sewing_DeleteUser { get; set; }
        public DateTime Sewing_DeleteDate { get; set; }

    }

    public class SEWING_DETAIL {

       public int Sewing_D_Id { get; set; }
        public int Sewing_Id { get; set; }
        public int Sew_Id { get; set; }
         public string Sewing_Header_Name { get; set; }
        public string Sewing_D_Code { get; set; }
        public string Sewing_D_Desc { get; set; }
        public string Sewing_D_Uname { get; set; }
        public decimal Sewing_D_Uprice { get; set; }
        public string Sewing_D_Memo { get; set; }
        public int Sewing_D_Listno { get; set; }
        public int Sewing_D_CreateUser { get; set; }
        public DateTime Sewing_D_CreateDate { get; set; }
        public int Sewing_D_EditUser { get; set; }
        public DateTime Sewing_D_EditDate { get; set; }
        public int Sewing_D_Delete { get; set; }
        public int Sewing_D_DeleteUser { get; set; }
        public DateTime Sewing_D_DeleteDate { get; set; }



    }

    public class SEWING_OTHER {

        public int  Sewing_O_Id { get; set; }
        public int Sewing_Id { get; set; }
        public int Sew_Id { get; set; }
        public string Sewing_Header_Name { get; set; }
        public string Sewing_O_Code { get; set; }
        public string Sewing_O_Desc { get; set; }
        public string Sewing_O_Uname { get; set; }

        public decimal Sewing_O_Uprice { get; set; }
        public string Sewing_O_Memo { get; set; }
        public int Sewing_O_Listno { get; set; }
        public int Sewing_O_CreateUser { get; set; }
        public DateTime Sewing_O_CreateDate { get; set; }
        public int Sewing_O_EditUser { get; set; }
        public DateTime Sewing_O_EditDate { get; set; }
        public int Sewing_O_Delete { get; set; }
        public int Sewing_O_DeleteUser { get; set; }
        public DateTime Sewing_O_DeleteDate { get; set; }


    }

}