using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class USR
    {
        public int USR_Id { get; set; }
        public string USR_Code { get; set; }
        public string USR_NameT { get; set; }
        public string USR_NameE { get; set; }
        public string USR_Pwd { get; set; }
        public string USR_Pwd_Old { get; internal set; }
        public int USR_Level { get; set; }
        public string USR_Email { get; set; }
        public int USR_Lock { get; set; }
        public DateTime USR_LockDT { get; set; }
        public int USR_CreateUser { get; set; }
        public DateTime USR_CreateDate { get; set; }
        public int USR_EditUser { get; set; }
        public DateTime USR_EditDate { get; set; }
        public int USR_Delete { get; set; }
        public int USR_DeleteUser { get; set; }
        public DateTime USR_DeleteDate { get; set; }
   
    }


    public class USM {


        public int USM_Id { get; set; }
        public int USR_id { get; set; }
        public string USMs1 { get; set; }
        public string USMs2 { get; set; }
        public string USMs3 { get; set; }
        public string USMs4 { get; set; }
        public string USMs5 { get; set; }
    }
}