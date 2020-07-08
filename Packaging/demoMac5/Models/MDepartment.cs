using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class MDepartment
    {
        public int Department_Id { get; set; }
        public string Department_Code { get; set; }
        public string Department_NameT { get; set; }
        public string Department_NameE { get; set; }
        public string Department_Uname { get; set; }
        public int Department_CreateUser { get; set; }
        public DateTime Department_CreateDate { get; set; }
        public int Department_EditUser { get; set; }
        public DateTime Department_EditDate { get; set; }
        public int Department_Delete { get; set; }
        public int Department_DeleteUser { get; set; }
        public DateTime Department_DeleteDate { get; set; }

    }
}