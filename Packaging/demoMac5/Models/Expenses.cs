using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class EXPENSES_HEADER
    {

        public int Expenses_Id { get; set; }
        public string Expenses_Name { get; set; }
        public bool Expenses_Use { get; set; }
        public bool Expenses_UseDate { get; set; }
        public DateTime Expenses_DateStart { get; set; }
        public string Expenses_DateStart_Text
        {
            get
            {
                return Expenses_DateStart == DateTime.MinValue ? null : Expenses_DateStart.ToString("yyyy-MM-dd");
            }
        }
        public DateTime Expenses_DateEnd { get; set; }
        public string Expenses_DateEnd_Text
        {
            get
            {
                return Expenses_DateEnd == DateTime.MinValue ? null : Expenses_DateEnd.ToString("yyyy-MM-dd");
            }
        }
        public string Expenses_DateStart_Input { get; set; }
        public string Expenses_DateEnd_Input { get; set; }
        public string Expenses_Desc { get; set; }
        public string Expenses_CreateUser { get; set; }
        public string Expenses_CreateDate { get; set; }
        public string Expenses_EditUser { get; set; }
        public string Expenses_EditDate { get; set; }
        public string Expenses_Delete { get; set; }
        public string Expenses_DeleteUser { get; set; }
        public string Expenses_DeleteDate { get; set; }

    }


    public class EXPENSES_DETAIL
    {

        public int Expenses_D_Id { get; set; }
        public int Expenses_Id { get; set; }
        public int Expense_Id { get; set; }
        public string Expenses_Header_Name { get; set; }
        public string Expenses_D_Code { get; set; }
        public string Expenses_D_Desc { get; set; }
        public string Expenses_D_Uname { get; set; }
        public decimal Expenses_D_Uprice { get; set; }
        public string Expenses_D_Memo { get; set; }
        public int Expenses_D_Listno { get; set; }
        public int Expenses_D_CreateUser { get; set; }
        public DateTime Expenses_D_CreateDate { get; set; }
        public int Expenses_D_EditUser { get; set; }
        public DateTime Expenses_D_EditDate { get; set; }
        public int Expenses_D_Delete { get; set; }
        public int Expenses_D_DeleteUser { get; set; }
        public DateTime Expenses_D_DeleteDate { get; set; }



    }
}