using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class MSew
    {

        public int Sew_Id { get; set; }
        public string Sew_Code { get; set; }
        public string Sew_NameT { get; set; }
        public string Sew_NameE { get; set; }
        public string Sew_Uname { get; set; }
        public string Sew_UnamePrice { get; set; }
        public int Sew_CreateUser { get; set; }
        public DateTime Sew_CreateDate { get; set; }
        public int Sew_EditUser { get; set; }
        public DateTime Sew_EditDate { get; set; }
        public int Sew_Delete { get; set; }
        public int Sew_DeleteUser { get; set; }
        public DateTime Sew_DeleteDate { get; set; }
    }
}