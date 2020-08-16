using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    
    public class DEG
    {
        public int DEGid { get; set; }
        public string DEGcode { get; set; }
        public string DEGdescT { get; set; }
        public string DEGdescE { get; set; }
    }

    public class STG
    {
        public int STGid { get; set; }
        public string STGcode { get; set; }
        public string STGdescT { get; set; }
        public string STGdescE { get; set; }
    }

    public class JOB
    {
        public int JOBrow { get; set; }
        public int JOBid { get; set; }
        public string JOBcode { get; set; }
        public string JOBgroup { get; set; }
        public string JOBdescT { get; set; }
        public string JOBdescE { get; set; }
        public int JOBhide { get; set; }
        public int JOBlock { get; set; }
        public string JOBrefWE { get; set; }
        public string JOBsortNT { get; set; }
        public string JOBsortNE { get; set; }
        public DateTime? JOBeditDT { get; set; }
        public string JOBeditDT_Text
        {
            get
            {
                return JOBeditDT==null? null : Convert.ToDateTime(JOBeditDT).ToString(@"dd-MM-yyyy");
            }
        }

        public bool JOBlock_Chk { get; set; }
        public bool JOBhide_Chk { get; set; }

        public int JOBautostk { get; set; }
        public bool JOBautostk_Chk { get; set; }
    }

    public class PER
    {

        public int PERid { get; set; }
        public string PERcode { get; set; }
        public string PERdep { get; set; }
        public string PERtaxnos { get; set; }
        public string PERnameT { get; set; }
        public string PERnameE { get; set; }
        public DateTime PERbdate { get; set; }
        public string PERbdate_Input { get; set; }
        public string PERbdate_Text
        {
            get
            {
                return PERbdate == DateTime.MinValue ? null : PERbdate.ToString("yyyy-MM-dd");
            }
            set { }
        }
        public DateTime PERworkS { get; set; }
        public string PERworkS_Input { get; set; }
        public string PERworkS_Text
        {
            get
            {
                return PERworkS == DateTime.MinValue ? null : PERworkS.ToString("yyyy-MM-dd");
            }
            set { }
        }
        public DateTime PERworkF { get; set; }
        public string PERworkF_Input { get; set; }
        public string PERworkF_Text
        {
            get
            {
                return PERworkF == DateTime.MinValue ? null : PERworkF.ToString("yyyy-MM-dd");
            }
            set { }
        }
        public DateTime PEReditLK { get; set; }
        public string PEReditLK_Input { get; set; }
        public string PEReditLK_Text
        {
            get
            {
                return PEReditLK == DateTime.MinValue ? null : PEReditLK.ToString("yyyy-MM-dd");
            }
        }
        public string PERadd1 { get; set; }
        public string PERadd2 { get; set; }
        public string PERadd3 { get; set; }
        public string PERtel { get; set; }
        public string PERpositn { get; set; }
        public int PERstatus { get; set; }
        public int PERnchild { get; set; }
        public int PERcisstudy { get; set; }
        public int PERnotstudy { get; set; }
        public decimal PERsalary { get; set; }
        public int PERhide { get; set; }
        public int PERlock { get; set; }
        public string PERmemo { get; set; }
     
        public string PERrefWE { get; set; }
        public DateTime PEReditDT { get; set; }
        public string PEReditDT_Input { get; set; }
        public string PEReditDT_Text
        {
            get
            {
                return PEReditDT==null ? "" : PEReditDT.ToShortDateString();
            }
        }
    }


    public class STK {
        public int STKrow { get; set; }
        public int STKid { get; set;}
        public string STKcode { get; set;}
        public string STKgroup { get; set;}
        public string STKcode2 { get; set;}
        public string STKdescT1 { get; set;}
        public string STKdescT2 { get; set;}
        public string STKdescT3 { get; set;}
        public string STKdescE1 { get; set;}
        public string STKdescE2 { get; set;}
        public string STKdescE3 { get; set;}
        public decimal STKmax { get; set;}
        public decimal STKmin { get; set;}
        public int STKunit1 { get; set;}
        public int STKunit2 { get; set;}
        public decimal STKconv1 { get; set;}
        public decimal STKconv2 { get; set;}
        public int STKsnsv { get; set;}
        public string STKuname0 { get; set;}
        public string STKuname1 { get; set;}
        public string STKuname2 { get; set;}
        public string STKuname3 { get; set;}
        public string STKuname4 { get; set;}
        public string STKuname5 { get; set;}
        public decimal STKqU1 { get; set;}
        public decimal STKqU2 { get; set;}
        public decimal STKqU3 { get; set;}
        public decimal STKqU4 { get; set;}
        public decimal STKqU5 { get; set;}
        public decimal STKqE1 { get; set;}
        public decimal STKqE2 { get; set;}
        public decimal STKqE3 { get; set;}
        public decimal STKqE4 { get; set;}
        public decimal STKqE5 { get; set;}
        public int STKqN1 { get; set;}
        public int STKqN2 { get; set;}
        public int STKqN3 { get; set;}
        public int STKqN4 { get; set;}
        public int STKqN5 { get; set;}
        public decimal STKvat { get; set;}
        public int STKexpire { get; set;}
        public int STKhide { get; set;}
        public int STKuse2 { get; set;}
        public string STKu2name { get; set;}
        public int STKfx { get; set;}
        public string STKacP { get; set;}
        public string STKacS { get; set;}
        public string STKacC { get; set;}
        public int STKlock { get; set;}
        public string STKmemo { get; set;}
        public string STKacC1 { get; set;}
        public string STKacC2 { get; set;}
        public DateTime STKeditLK { get; set;}
        public string STKrefWE { get; set;}
        public string STKbarC1 { get; set;}
        public string STKbarC2 { get; set;}
        public string STKbarC3 { get; set;}
        public string STKsortNT { get; set;}
        public string STKsortNE { get; set;}
        public string STKeditDT { get; set;}
        public int STKstatus { get; set; }
        public string STKsto { get; set; }
    }


   
}