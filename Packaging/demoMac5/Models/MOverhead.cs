using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class MOverhead
    {

        public int Overhead_Id { get; set; }
        public string Overhead_Code { get; set; }
        public string Overhead_NameT { get; set; }
        public string Overhead_NameE { get; set; }
        public string Overhead_Uname { get; set; }
        public int Overhead_CreateUser { get; set; }
        public DateTime Overhead_CreateDate { get; set; }
        public int Overhead_EditUser { get; set; }
        public DateTime Overhead_EditDate { get; set; }
        public int Overhead_Delete { get; set; }
        public int Overhead_DeleteUser { get; set; }
        public DateTime Overhead_DeleteDate { get; set; }
    }
}