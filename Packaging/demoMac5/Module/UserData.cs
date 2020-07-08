using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class UserData
    {

        string msgErr = string.Empty;

        #region --- Authorization ----
        public bool GetAuthorization(out USR item , string UserName , string Password)
        {
            bool checkUSR = false;
            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
        
            try
            {

                strSQL = @"select * FROM [dbo].[USR] where 0=0 
               and  [USR_Code]= '" + UserName +"' " 
               + " and  [USR_Pwd]='"+ Utility.HashPassword(Password) + "'";
                 item = new USR();
                DataTable dt = DBHelper.List(strSQL, objConn);
                if (dt.Rows.Count == 1)
                {
                    checkUSR = true;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new USR();
                        item.USR_Id = Convert.ToInt32(dt.Rows[i]["USR_Id"].ToString());
                        item.USR_Code = dt.Rows[i]["USR_Code"].ToString();
                        item.USR_NameT = dt.Rows[i]["USR_NameT"].ToString();
                        item.USR_NameE = dt.Rows[i]["USR_NameE"].ToString();
                        item.USR_Pwd = dt.Rows[i]["USR_Pwd"].ToString();
                        item.USR_Pwd_Old = dt.Rows[i]["USR_Pwd"].ToString();
                        item.USR_Level = Convert.ToInt32(dt.Rows[i]["USR_Level"].ToString());
                        item.USR_Email = dt.Rows[i]["USR_Email"].ToString();
                        
                    }
                    return checkUSR;
                }
                else {
                    checkUSR = false;
                    return checkUSR;
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

        #endregion --- Authorization ----

        #region -- USR--
        public void GetUSR(out List<USR> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<USR>();
            USR item = new USR();
            try
            {

                strSQL = "select * FROM [dbo].[USR] where 0=0 ";
                if (id > 0)
                {

                    strSQL += " and USR_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new USR();
                        item.USR_Id = Convert.ToInt32(dt.Rows[i]["USR_Id"].ToString());
                        item.USR_Code = dt.Rows[i]["USR_Code"].ToString();
                        item.USR_NameT = dt.Rows[i]["USR_NameT"].ToString();
                        item.USR_NameE = dt.Rows[i]["USR_NameE"].ToString();
                        item.USR_Pwd = dt.Rows[i]["USR_Pwd"].ToString();
                        item.USR_Pwd_Old = dt.Rows[i]["USR_Pwd"].ToString();
                        item.USR_Level = Convert.ToInt32(dt.Rows[i]["USR_Level"].ToString());
                        item.USR_Email = dt.Rows[i]["USR_Email"].ToString();
                        
               
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



        public void InsertUSR(USR item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"INSERT INTO [dbo].[USR]
                                               ([USR_Code]
                                               ,[USR_NameT]
                                               ,[USR_NameE]
                                               ,[USR_Pwd]
                                               ,[USR_Level]
                                               ,[USR_Email]
                                               ,[USR_CreateUser]
                                               ,[USR_CreateDate]
                                               ,[USR_Delete] )
                     VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                strSQL = string.Format(strSQL
                      , Utility.ReplaceString(item.USR_Code)
                     , Utility.ReplaceString(item.USR_NameT)
                     , Utility.ReplaceString(item.USR_NameE)
                     , Utility.ReplaceString(Utility.HashPassword(item.USR_Pwd))
                     , item.USR_Level
                     , Utility.ReplaceString(item.USR_Email)
                     , item.USR_CreateUser
                     , "GetDate()"
                     ,  0
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


        public void UpdateUSR(USR item)
        {
            List<USR> usr;
            GetUSR(out usr, item.USR_Id);
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @" UPDATE [dbo].[USR]
                                   SET [USR_Code] = {1}
                                      ,[USR_NameT] ={2}
                                      ,[USR_NameE] = {3}
                                      ,[USR_Pwd] = {4}
                                      ,[USR_Level] = {5}
                                      ,[USR_Email] = {6}
                                      ,[USR_EditUser] ={7}
                                      ,[USR_EditDate] = {8}
                                 WHERE [USR_Id]={0} ";
                strSQL = string.Format(strSQL
                    , item.USR_Id
                    , Utility.ReplaceString(item.USR_Code)
                    , Utility.ReplaceString(item.USR_NameT)
                    , Utility.ReplaceString(item.USR_NameE)
                    , Utility.ReplaceString(item.USR_Pwd == usr[0].USR_Pwd ? usr[0].USR_Pwd : Utility.HashPassword(item.USR_Pwd))
                    , item.USR_Level
                    , Utility.ReplaceString(item.USR_Email)
                    , item.USR_EditUser
                    , "GetDate()"
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

        
        public void DeleteUSR(USR item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @" UPDATE [dbo].[USR]
                                   SET    [USR_Delete] = {1}
                                          ,[USR_DeleteUser] = {2}
                                          ,[USR_DeleteDate] = {3}
                                 WHERE [USR_Id]={0} ";
                strSQL = string.Format(strSQL
                    , item.USR_Id
                    , -1
                    , item.USR_DeleteUser
                    , "GetDate()"
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
        #endregion -- USR--


        #region ---  USM --- 

        public void GetUSM(out List<USM> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<USM>();
            USM item = new USM();
            try
            {

                strSQL = "select * FROM [dbo].[USM] where 0=0 ";
                if (id > 0)
                {

                    strSQL += " and USM_Id=" + id;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new USM();
                        item.USM_Id = Convert.ToInt32(dt.Rows[i]["USM_Id"].ToString());
                        item.USR_id = Convert.ToInt32(dt.Rows[i]["USR_id"].ToString());
                        item.USMs1 = dt.Rows[i]["USMs1"].ToString();
                        item.USMs2 = dt.Rows[i]["USMs2"].ToString();
                        item.USMs3 = dt.Rows[i]["USMs3"].ToString();
                        item.USMs4 = dt.Rows[i]["USMs4"].ToString();
                        item.USMs5 = dt.Rows[i]["USMs5"].ToString();
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
        public void InsertUSM(USM item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"INSERT INTO [dbo].[USM](
                                  [USR_id]
                                  ,[USMs1]
                                  ,[USMs2]
                                  ,[USMs3]
                                  ,[USMs4]
                                  ,[USMs5] )
                                 VALUES({0},{1},{2},{3},{4},{5})";
                strSQL = string.Format(strSQL
                      ,item.USR_id
                     , Utility.ReplaceString(item.USMs1)
                     , Utility.ReplaceString(item.USMs2)
                     , Utility.ReplaceString(item.USMs3)
                     , Utility.ReplaceString(item.USMs4)
                     , Utility.ReplaceString(item.USMs5)
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



        public void UpdateUSM(USM item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @" UPDATE [dbo].[USR]
                                   SET     [USR_id]={1}
                                          ,[USMs1]={2}
                                          ,[USMs2]={3}
                                          ,[USMs3]={4}
                                          ,[USMs4]={5}
                                          ,[USMs5]={6}
                                 WHERE [USM_Id]={0} ";

                strSQL = string.Format(strSQL
                    , item.USM_Id
                    , item.USR_id
                    , Utility.ReplaceString(item.USMs1)
                    , Utility.ReplaceString(item.USMs2)
                    , Utility.ReplaceString(item.USMs3)
                    , Utility.ReplaceString(item.USMs4)
                    , Utility.ReplaceString(item.USMs5)
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
        
        #endregion ---  USM --- 
    }

}