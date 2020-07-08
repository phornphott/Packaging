using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;
using Dapper;

namespace demoMac5.Module
{
    public class CostHeaderData
    {
        string msgErr = string.Empty;

        #region -- COST_HEADER--
        public void GetCostHeader(out List<COST_HEADER> ls, int CostHeaderid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<COST_HEADER>();
            COST_HEADER item= new COST_HEADER();
            try
            {

                strSQL = "select * FROM [dbo].[COST_HEADER] where 0=0 and Cost_Delete=0 ";
                if (CostHeaderid > 0)
                {

                    strSQL += " and Cost_Id=" + CostHeaderid;
                }
                //ls = objConn.Query<COST_HEADER>(strSQL).ToList();
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new COST_HEADER();
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Cost_Id"].ToString());
                        item.Cost_Name = dt.Rows[i]["Cost_Name"].ToString();
                        item.Cost_Use = Convert.ToBoolean(dt.Rows[i]["Cost_Use"].ToString());
                        item.Cost_UseDate = Convert.ToBoolean(dt.Rows[i]["Cost_UseDate"].ToString());
                        item.Cost_DateStart = Convert.ToDateTime(dt.Rows[i]["Cost_DateStart"].ToString());
                        item.Cost_DateEnd = Convert.ToDateTime(dt.Rows[i]["Cost_DateEnd"].ToString());
                        item.Cost_DateStart_Input = item.Cost_DateStart.ToShortDateString();
                        item.Cost_DateEnd_Input = item.Cost_DateEnd.ToShortDateString();
                        item.Cost_Desc = dt.Rows[i]["Cost_Desc"].ToString();
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

        public void InsertCostHeader(COST_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into COST_HEADER(
                                   Cost_Name
                                   ,Cost_Use
                                   ,Cost_UseDate
                                   ,Cost_DateStart
                                   ,Cost_DateEnd
                                   ,Cost_Desc
                                   ,Cost_CreateUser	
                                   ,Cost_CreateDate	
                                   ,Cost_Delete
                                    ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Cost_Name)
                    , item.Cost_Use == true ? -1 : 0
                    , item.Cost_UseDate == true ? -1 : 0
                    , Utility.FormateDateTime(item.Cost_DateStart)
                    , Utility.FormateDateTime(item.Cost_DateEnd)
                    , Utility.ReplaceString(item.Cost_Desc ?? "")
                    , Library.GBuserID
                    ,"GetDate()"
                    ,0
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

        public void UpdateCostHeader(COST_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_HEADER Set
                                    Cost_Name={1},
                                    Cost_Use={2},
                                    Cost_UseDate={3},
                                    Cost_DateStart={4},
                                    Cost_DateEnd={5},
                                     Cost_Desc={6},
                                    Cost_EditUser=0,
                                    Cost_EditDate=GetDate()
                                    where Cost_Id={0}";

                strSQL = string.Format(strSQL
                    , item.Cost_Id
                    , Utility.ReplaceString(item.Cost_Name)
                   , item.Cost_Use == true ? -1 : 0
                    , item.Cost_UseDate == true ? -1 : 0
                    , Utility.FormateDate(item.Cost_DateStart)
                    , Utility.FormateDate(item.Cost_DateEnd)
                    , Utility.ReplaceString(item.Cost_Desc));

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

        public void DeleteCostHeader(COST_HEADER item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_HEADER Set 
Cost_Delete=1 , Cost_DeleteUser ={1} ,Cost_DeleteDate= {2}
                                    where Cost_Id={0}";

                strSQL = string.Format(strSQL , 
                    item.Cost_Id,
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

        #endregion -- COST_HEADER--
    }
}