using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class MExpense
    {

        public int Expense_Id { get; set; }
        public string Expense_Code { get; set; }
        public string Expense_NameT { get; set; }
        public string Expense_NameE { get; set; }
        public string Expense_Uname { get; set; }
        public string Expense_UnamePrice
        {
            get
            {
                return "บาท/กก.";
            }
        }
        public int Expense_CreateUser { get; set; }
        public DateTime Expense_CreateDate { get; set; }
        public int Expense_EditUser { get; set; }
        public DateTime Expense_EditDate { get; set; }
        public int Expense_Delete { get; set; }
        public int Expense_DeleteUser { get; set; }
        public DateTime Expense_DeleteDate { get; set; }
    }
}