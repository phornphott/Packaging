using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{

        public class MPrint
        {
            public int Print_Id { get; set; }
            public string Print_Code { get; set; }
            public string Print_NameT { get; set; }
            public string Print_NameE { get; set; }
            public string Print_Uname { get; set; }
            public string Print_UnamePrice { get; set; }
            public int Print_CreateUser { get; set; }
            public DateTime Print_CreateDate { get; set; }
            public int Print_EditUser { get; set; }
            public DateTime Print_EditDate { get; set; }
            public int? Print_Delete { get; set; }
            public int Print_DeleteUser { get; set; }
            public DateTime Print_DeleteDate { get; set; }

        }
        public class MPlastic
        {
            public int Plastic_Id { get; set; }
            public string Plastic_Code { get; set; }
            public string Plastic_NameT { get; set; }
            public string Plastic_NameE { get; set; }
            public string Plastic_Uname { get; set; }
            public string Plastic_UnamePrice { get; set; }
            public int Plastic_CreateUser { get; set; }
            public DateTime Plastic_CreateDate { get; set; }
            public int Plastic_EditUser { get; set; }
            public DateTime Plastic_EditDate { get; set; }
            public int? Plastic_Delete { get; set; }
            public int Plastic_DeleteUser { get; set; }
            public DateTime Plastic_DeleteDate { get; set; }

        }
        public class MEquipment
        {

            public int  Equipment_Id { get; set; }
            public string Equipment_Code { get; set; }
            public string Equipment_NameT { get; set; }
            public string Equipment_NameE { get; set; }
            public string Equipment_Uname { get; set; }
            public string Equipment_UnamePrice { get; set; }
            public int Equipment_CreateUser { get; set; }
            public DateTime Equipment_CreateDate { get; set; }
            public int Equipment_EditUser { get; set; }
            public DateTime Equipment_EditDate { get; set; }
            public int Equipment_Delete { get; set; }
            public int Equipment_DeleteUser { get; set; }
            public DateTime Equipment_DeleteDate { get; set; }
        }

 
}