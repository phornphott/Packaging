using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class ProvinceData
    {

        string msgErr = string.Empty;

        public void GetProvince(out List<Province> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<Province>();
            Province item = new Province();
            try
            {

                strSQL = @"SELECT  [Province_ID]
                          ,[Province_Name]
                           ,[Province_Distance]
                          FROM [dbo].[PROVINCE] where 0=0";
                if (id > 0) {
                    strSQL += " and [Province_ID]=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new Province();
                        item.PROVINCE_ID = Convert.ToInt32(dt.Rows[i]["Province_ID"].ToString());
                        item.PROVINCE_NAME = dt.Rows[i]["Province_Name"].ToString();
                        item.DISTANCE = Convert.ToInt32(dt.Rows[i]["Province_Distance"].ToString());
                        
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




        public void Insert_Province(Province item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"INSERT INTO [dbo].[PROVINCE]
                                   ,[Province_Name]
                                   ,[Province_Distance])
                                     VALUES
                                           ({0},{1});";
                strSQL = string.Format(strSQL
                                , Utility.ReplaceString(item.PROVINCE_NAME ?? "")
                                ,item.DISTANCE 
                                
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

        public void Update_Province(Province item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update Province Set
                                   [Province_Name]={1}
                                   ,[Province_Distance]={2}
                                where PROVINCE_ID={0}";
                strSQL = string.Format(strSQL
                                       , item.PROVINCE_ID
                                       , Utility.ReplaceString(item.PROVINCE_NAME ?? "")
                                       , item.DISTANCE
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

        public void Delete_Province(Province stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Delete  From Province
                                    where Province_ID={0}";

                strSQL = string.Format(strSQL
                    , stg.PROVINCE_ID);

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
    }
}