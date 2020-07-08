using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demoMac5.Models;
using System.Data;


namespace demoMac5.Module
{

    public class CostPlasticData
    {
        string msgErr = string.Empty;

        #region -- COST_PLASTIC--
        public void GetCostPlastic(out List<COST_PLASTIC> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<COST_PLASTIC>();
            COST_PLASTIC item = new COST_PLASTIC();
            try
            {

                strSQL =@"select a.*,b.Cost_Name ,c.Plastic_NameT FROM [dbo].[COST_PLASTIC] a  
                            left join[dbo].[COST_HEADER] b on a.Cost_Id=b.Cost_Id
                            left join[dbo].[M_PLASTIC] c on a.Plastic_Id=c.Plastic_Id 
                            where 0=0 ";
                if (id > 0)
                {

                    strSQL += " and a.Cost_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new COST_PLASTIC(); 
                         item.Cost_P_Id = Convert.ToInt32(dt.Rows[i]["Cost_P_Id"].ToString());
                        item.Cost_Id = Convert.ToInt32(dt.Rows[i]["Cost_Id"].ToString());
                        item.Cost_Header_Name = dt.Rows[i]["Cost_Name"].ToString();
                        item.Plastic_Id= Convert.ToInt32(dt.Rows[i]["Plastic_Id"].ToString());
                        item.Plastic_Name = dt.Rows[i]["Plastic_NameT"].ToString();
                        item.Cost_P_Code = dt.Rows[i]["Cost_P_Code"].ToString();
                        item.Cost_P_Desc= dt.Rows[i]["Cost_P_Desc"].ToString();
                        item.Cost_P_Uname= dt.Rows[i]["Cost_P_Uname"].ToString();
                        item.Cost_P_Uprice = Convert.ToDecimal(  dt.Rows[i]["Cost_P_Uprice"].ToString());
                        item.Cost_P_Memo = dt.Rows[i]["Cost_P_Memo"].ToString();
                        item.Cost_P_Listno = i + 1;
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

        public void InsertCostPlastic(COST_PLASTIC item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into COST_PLASTIC(
                                   [Cost_Id]
                                  ,[Plastic_Id]
                                  ,[Cost_P_Code]
                                  ,[Cost_P_Desc]
                                  ,[Cost_P_Uname]
                                  ,[Cost_P_Uprice]
                                  ,[Cost_P_Memo]
                                  ,[Cost_P_Listno]
                                  ,[Cost_P_CreateUser]
                                  ,[Cost_P_CreateDate]
                                   ,Cost_P_Delete) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})";
                strSQL = string.Format(strSQL
                     , item.Cost_Id
                     , item.Plastic_Id
                    , Utility.ReplaceString(item.Cost_P_Code)
                    , Utility.ReplaceString(item.Cost_P_Desc)
                    , Utility.ReplaceString(item.Cost_P_Uname)
                    , item.Cost_P_Uprice
                    , Utility.ReplaceString(item.Cost_P_Memo)
                    , item.Cost_P_Listno
                    , 0
                    , "GetDate()"
                    ,0);
                

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

        public void UpdateCostPlastic(COST_PLASTIC item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_PLASTIC Set
                                    Cost_Id={0}
                                   ,Plastic_Id={1}
                                   ,Cost_P_Code={2}
                                   ,Cost_P_Desc={3}
                                   ,Cost_P_Uname={4}
                                   ,Cost_P_Uprice={5}
                                   ,Cost_P_Memo={6}
                                   ,Cost_P_Listno={7}
                                   ,Cost_P_EditUser={8}
                                   ,Cost_P_EditDate={9}
                                    where Cost_P_Id={10}";

                strSQL = string.Format(strSQL
                                 , item.Cost_Id
                                 , item.Plastic_Id
                                , Utility.ReplaceString(item.Cost_P_Code)
                                , Utility.ReplaceString(item.Cost_P_Desc)
                                , Utility.ReplaceString(item.Cost_P_Uname)
                                , item.Cost_P_Uprice
                                , Utility.ReplaceString(item.Cost_P_Memo)
                                , item.Cost_P_Listno
                                , 0
                                , "GetDate()"
                                ,item.Cost_P_Id);

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

        public void DeleteCostPlastic(COST_PLASTIC item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update COST_PLASTIC Set 
                                   Cost_P_Delete=1 
                                 , Cost_P_DeleteUser ={1} 
                                  ,Cost_P_DeleteDate= {2}
                                    where Cost_P_Id={0}";

                strSQL = string.Format(strSQL,
                    item.Cost_P_Id,
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

        #endregion -- COST_PLASTIC--
    }
}