using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
  
    public class CostEquipmentData
    {
        string msgErr = string.Empty;

        #region -- COST_EQUIPMENT--
        public void GetCostEquipment(out List<COST_EQUIPMENT> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<COST_EQUIPMENT>();
            COST_EQUIPMENT item = new COST_EQUIPMENT();
            try
            {

                strSQL = @" select e.*,me.Equipment_NameT,b.Cost_Name  FROM [dbo].[COST_EQUIPMENT] e
                        left join[dbo].[M_EQUIPMENT] me on e.EQUIPMENT_Id=me.Equipment_Id
                         left join[dbo].[COST_HEADER] b on e.Cost_Id=b.Cost_Id
                            where 0=0 and e.Cost_E_Delete=0";
                if (id > 0)
                {

                    strSQL += " and e.Cost_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new COST_EQUIPMENT();
                        item.Cost_E_Id = Convert.ToInt32(dt.Rows[i]["Cost_E_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Cost_Id"].ToString());
                        item.Cost_Header_Name = dt.Rows[i]["Cost_Name"].ToString();
                        item.EQUIPMENT_Id = Convert.ToInt32(dt.Rows[i]["EQUIPMENT_Id"].ToString());
                        item.Cost_E_Code = dt.Rows[i]["Cost_E_Code"].ToString();
                        item.Cost_E_Desc = dt.Rows[i]["Cost_E_Desc"].ToString();
                        item.Cost_E_Uname = dt.Rows[i]["Cost_E_Uname"].ToString();
                        item.Cost_E_Uprice = Convert.ToDecimal(dt.Rows[i]["Cost_E_Uprice"].ToString());
                        item.Cost_E_Memo = dt.Rows[i]["Cost_E_Memo"].ToString();
                        item.Cost_E_Listno = i + 1;
                      
                        ls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();

            }

        }

        public void InsertCostEquipment(COST_EQUIPMENT item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into COST_EQUIPMENT(
                                   [Cost_Id]
                                  ,[EQUIPMENT_Id]
                                  ,[Cost_E_Code]
                                  ,[Cost_E_Desc]
                                  ,[Cost_E_Uname]
                                  ,[Cost_E_Uprice]
                                  ,[Cost_E_Memo]
                                  ,[Cost_E_Listno]
                                  ,[Cost_E_CreateUser]
                                  ,[Cost_E_CreateDate]
                                  ,[Cost_E_Delete]
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})";
                strSQL = string.Format(strSQL,
                        item.Cost_Id
                      , item.EQUIPMENT_Id
                      , Utility.ReplaceString( item.Cost_E_Code)
                      , Utility.ReplaceString(item.Cost_E_Desc)
                      , Utility.ReplaceString(item.Cost_E_Uname)
                      , item.Cost_E_Uprice
                      , Utility.ReplaceString(item.Cost_E_Memo)
                      , item.Cost_E_Listno
                      , 0
                      , "GetDate()"
                      , 0
                    );

                DBHelper.Execute(strSQL, objConn);

            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
        }

        public void UpdateCostEquipment(COST_EQUIPMENT item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_EQUIPMENT Set
                                     Cost_Id={0}
                                    ,EQUIPMENT_Id={1}
                                    ,Cost_E_Code={2}
                                    ,Cost_E_Desc={3}
                                    ,Cost_E_Uname={4}
                                    ,Cost_E_Uprice={5}
                                    ,Cost_E_Memo={6}
                                    ,Cost_E_Listno={7}
                                    ,Cost_E_EditUser=0
                                    ,Cost_E_EditDate=GetDate()
                                    where Cost_E_Id={8}";

                strSQL = string.Format(strSQL
                    , item.Cost_Id
                    , item.EQUIPMENT_Id
                    , Utility.ReplaceString(item.Cost_E_Code)
                    , Utility.ReplaceString(item.Cost_E_Desc)
                    , Utility.ReplaceString(item.Cost_E_Uname)
                    , item.Cost_E_Uprice
                    , Utility.ReplaceString(item.Cost_E_Memo)
                    , item.Cost_E_Listno
                    ,item.Cost_E_Id);

                DBHelper.Execute(strSQL, objConn);

            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
        }

        public void DeleteCostEquipment(COST_EQUIPMENT item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_EQUIPMENT Set 
                                Cost_E_Delete=1 ,
                                Cost_E_DeleteUser ={1} ,
                                Cost_E_DeleteDate= {2}
                                where Cost_E_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Cost_E_Id,
                    1,// Cost_DeleteUser
                    "GetDate()");

                DBHelper.Execute(strSQL, objConn);

            }
            catch (Exception ex)
            {

                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                objConn.Close();
            }
        }

        #endregion -- COST_EQUIPMENT--
    }
}