using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demoMac5.Models
{
    public class COST_HEADER
    {

        public int Cost_Id { get; set; }
        public string Cost_Name { get; set; }       
        public bool Cost_Use { get; set; }
        public bool Cost_UseDate { get; set; }
        public bool Cost_Use_Output { get; set; }
        public bool Cost_UseDate_Output { get; set; }
        
        public DateTime Cost_DateStart { get; set; }
        public string Cost_DateStart_Text
        {
            get
            {
                return Cost_DateStart == DateTime.MinValue ? null : Cost_DateStart.ToString("yyyy-MM-dd");
            }
        }
        public DateTime Cost_DateEnd { get; set; }
        public string Cost_DateEnd_Text
        {
            get
            {
                return Cost_DateEnd == DateTime.MinValue ? null : Cost_DateEnd.ToString("yyyy-MM-dd");
            }
        }
        public string Cost_DateStart_Input { get; set; }
        public string Cost_DateEnd_Input { get; set; }
        public string Cost_Desc { get; set; }
        public int Cost_CreateUser { get; set; }
        public DateTime Cost_CreateDate { get; set; }
        public int Cost_EditUser { get; set; }
        public DateTime Cost_EditDate { get; set; }
        public int Cost_Delete { get; set; }
        public int Cost_DeleteUser { get; set; }
        public DateTime Cost_DeleteDate { get; set; }

    }



    public class COST_PLASTIC
    {

        public int Cost_P_Id { get; set; }
        public int Cost_Id { get; set; }
        public string Cost_Header_Name { get; set; }
        public int Plastic_Id { get; set; }
        public string Plastic_Name { get; set; }
        public string Cost_P_Code { get; set; }
        public string Cost_P_Desc { get; set; }
        public string Cost_P_Uname { get; set; }
        public decimal Cost_P_Uprice { get; set; }
        public string Cost_P_Memo { get; set; }
        public int Cost_P_Listno { get; set; }
        public int Cost_P_CreateUser { get; set; }
        public DateTime Cost_P_CreateDate { get; set; }
        public int Cost_P_EditUser { get; set; }
        public DateTime Cost_P_EditDate { get; set; }
        public int Cost_P_Delete { get; set; }
        public int Cost_P_DeleteUser { get; set; }
        public DateTime Cost_P_DeleteDate { get; set; }

    }


    public class COST_PRINT
    {

        public int Cost_P_Id { get; set; }
        public int Cost_Id { get; set; }
        public string Cost_Header_Name { get; set; }
        public int Print_Id { get; set; }
        public string Cost_P_Code { get; set; }
        public string Cost_P_Desc { get; set; }
        public string Cost_P_Uname { get; set; }
        public decimal Cost_P_UpriceR1 { get; set; }
        public decimal Cost_P_UpriceR2 { get; set; }
        public decimal Cost_P_UpriceR3 { get; set; }
        public string Cost_P_Memo { get; set; }
        public int Cost_P_Listno { get; set; }
        public int Cost_P_CreateUser { get; set; }
        public DateTime Cost_P_CreateDate { get; set; }
        public int Cost_P_EditUser { get; set; }
        public DateTime Cost_P_EditDate { get; set; }
        public int Cost_P_Delete { get; set; }
        public int Cost_P_DeleteUser { get; set; }
        public DateTime Cost_P_DeleteDate { get; set; }

    }

    public class COST_EQUIPMENT
    {

        public int Cost_E_Id { get; set; }
        public int Cost_Id { get; set; }
        public string Cost_Header_Name { get; set; }
        public int EQUIPMENT_Id { get; set; }
        public string Cost_E_Code { get; set; }
        public string Cost_E_Desc { get; set; }
        public string Cost_E_Uname { get; set; }
        public decimal Cost_E_Uprice { get; set; }
        public string Cost_E_Memo { get; set; }
        public int Cost_E_Listno { get; set; }
        public int Cost_E_CreateUser { get; set; }
        public DateTime Cost_E_CreateDate { get; set; }
        public int Cost_E_EditUser { get; set; }
        public DateTime Cost_E_EditDate { get; set; }
        public int Cost_E_Delete { get; set; }
        public int Cost_E_DeleteUser { get; set; }
        public DateTime Cost_E_DeleteDate { get; set; }

    }
    public class COST_PRINT_ADD1
    {

        public int Cost_P_Id { get; set; }
        public int Cost_Id { get; set; }
        public string Cost_Header_Name { get; set; }
        public string Cost_P_Range { get; set; }
        public string Cost_P_Uname { get; set; }
        public decimal Cost_P_Uprice { get; set; }
        public int Cost_P_Listno { get; set; }
        public int Cost_P_CreateUser { get; set; }
        public DateTime Cost_P_CreateDate { get; set; }
        public int Cost_P_EditUser { get; set; }
        public DateTime Cost_P_EditDate { get; set; }
        public int Cost_P_Delete { get; set; }
        public int Cost_P_DeleteUser { get; set; }
        public DateTime Cost_P_DeleteDate { get; set; }

    }
    public class COST_PRINT_ADD2
    {
        public int Cost_P_Id { get; set; }
        public int Cost_Id { get; set; }
        public string Cost_Header_Name { get; set; }
        public int Print_Id { get; set; }
        public string Cost_P_Code { get; set; }
        public string Cost_P_Desc { get; set; }
        public string Cost_P_Uname { get; set; }
        public decimal Cost_P_UpriceR1 { get; set; }
        public decimal Cost_P_UpriceR2 { get; set; }
        public decimal Cost_P_UpriceR3 { get; set; }
        public string Cost_P_Memo { get; set; }
        public int Cost_P_Listno { get; set; }
        public int Cost_P_CreateUser { get; set; }
        public DateTime Cost_P_CreateDate { get; set; }
        public int Cost_P_EditUser { get; set; }
        public DateTime Cost_P_EditDate { get; set; }
        public int Cost_P_Delete { get; set; }
        public int Cost_P_DeleteUser { get; set; }
        public DateTime Cost_P_DeleteDate { get; set; }

    }




}