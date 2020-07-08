using Dapper;
using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class MaterialData
    {

        string msgErr = string.Empty;

        #region -- MPlastic --
        public void GetMPlastic(out List<MPlastic> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<MPlastic>();
            MPlastic item = new MPlastic();
            try
            {

                strSQL = "select * FROM [dbo].[M_PLASTIC] where 0=0 and [Plastic_Delete]=0";
                if (id > 0)
                {

                    strSQL += " and [Plastic_Id]=" + id;
                }

                //ls = objConn.Query<MPlastic>(strSQL).ToList();

                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new MPlastic();
                        item.Plastic_Id = Convert.ToInt32(dt.Rows[i]["Plastic_Id"].ToString());
                        item.Plastic_Code = dt.Rows[i]["Plastic_Code"].ToString();
                        item.Plastic_NameT = dt.Rows[i]["Plastic_NameT"].ToString();
                        item.Plastic_NameE = dt.Rows[i]["Plastic_NameE"].ToString();
                        item.Plastic_Uname = dt.Rows[i]["Plastic_Uname"].ToString();
                        item.Plastic_UnamePrice = "บาท/" + dt.Rows[i]["Plastic_Uname"].ToString();
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

        public void InsertMPlastic(MPlastic item)
        {
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            //SqlCommand cmd = objConn.CreateCommand();
            try
            {
                string strSQL = @"INSERT INTO [dbo].[M_PLASTIC]
                                   ([Plastic_Code]
                                   ,[Plastic_NameT]
                                   ,[Plastic_NameE]
                                   ,[Plastic_Uname]
                                   ,[Plastic_CreateUser]
                                   ,[Plastic_CreateDate]
                                   ,[Plastic_Delete])values({0},{1},{2},{3},{4},{5},0)";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Plastic_Code.ToUpper())
                    , Utility.ReplaceString(item.Plastic_NameT)
                    , Utility.ReplaceString(item.Plastic_NameE)
                    , Utility.ReplaceString(item.Plastic_Uname)
                    , item.Plastic_CreateUser
                     , Utility.FormateDateTime(DateTime.Now));

                DBHelper.Execute(strSQL, objConn);


                //string strSQL = "INSERT INTO [dbo].[M_PLASTIC] ([Plastic_Code],[Plastic_NameT],[Plastic_NameE],[Plastic_Uname],[Plastic_CreateUser],[Plastic_CreateDate],[Plastic_Delete])"
                //              + "values (@Plastic_Code,@Plastic_NameT,@Plastic_NameE,@Plastic_Uname,@Plastic_CreateUser,@Plastic_CreateDate,@Plastic_Delete)";

                //cmd.CommandText = strSQL;
                //cmd.CommandTimeout = 60;
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Clear();
                //cmd.Parameters.Add("@id", SqlDbType.Int, 4).Value = V_id;
                //cmd.Parameters.Add("@GoodsIssued_Detail_Delete", SqlDbType.Bit).Value = true;
                //cmd.Transaction = tran;
                //cmd.ExecuteNonQuery();
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

        public void UpdateMPlastic(MPlastic item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Update  [dbo].[M_PLASTIC] Set
                                    [Plastic_Code]={0}
                                   ,[Plastic_NameT]={1}
                                   ,[Plastic_NameE]={2}
                                   ,[Plastic_Uname]={3}
                                   ,[Plastic_EditUser]={4}
                                   ,[Plastic_EditDate]={5}
                            where [Plastic_Id]={6} ";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Plastic_Code.ToUpper())
                    , Utility.ReplaceString(item.Plastic_NameT)
                    , Utility.ReplaceString(item.Plastic_NameE)
                    , Utility.ReplaceString(item.Plastic_Uname)
                    , item.Plastic_EditUser
                    , Utility.FormateDateTime(DateTime.Now)
                    ,item.Plastic_Id);

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


        public void DeleteMPlastic(MPlastic item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Update  [dbo].[M_PLASTIC] Set
                                        [Plastic_Delete]={0}
                                       ,[Plastic_DeleteUser]={1}
                                       ,[Plastic_DeleteDate]={2}
                            where [Plastic_Id]={3} ";
                strSQL = string.Format(strSQL
                    , 1
                    , item.Plastic_DeleteUser
                    , Utility.FormateDateTime(DateTime.Now)
                    , item.Plastic_Id);

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
        #endregion -- MPlastic --


        #region --  MPrint  --

        public void GetMPrint(out List<MPrint> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<MPrint>();
            MPrint item = new MPrint();
            try
            {

                strSQL = "select * FROM [dbo].[M_Print] where 0=0 and [Print_Delete]=0";
                if (id > 0)
                {

                    strSQL += " and [Print_Id]=" + id;
                }
                //ls = objConn.Query<MPrint>(strSQL).ToList();

                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new MPrint();
                        item.Print_Id = Convert.ToInt32(dt.Rows[i]["Print_Id"].ToString());
                        item.Print_Code = dt.Rows[i]["Print_Code"].ToString();
                        item.Print_NameT = dt.Rows[i]["Print_NameT"].ToString();
                        item.Print_NameE = dt.Rows[i]["Print_NameE"].ToString();
                        item.Print_Uname = dt.Rows[i]["Print_Uname"].ToString();
                        item.Print_UnamePrice ="บาท/" + dt.Rows[i]["Print_Uname"].ToString();
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


        public void InsertMPrint(MPrint item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"INSERT INTO [dbo].[M_PRINT]
                                   ([Print_Code]
                                   ,[Print_NameT]
                                   ,[Print_NameE]
                                   ,[Print_Uname]
                                   ,[Print_CreateUser]
                                   ,[Print_CreateDate] 
                                    ,[Print_Delete])values({0},{1},{2},{3},{4},{5},0)";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Print_Code.ToUpper())
                    , Utility.ReplaceString(item.Print_NameT)
                    , Utility.ReplaceString(item.Print_NameE)
                    , Utility.ReplaceString(item.Print_Uname)
                    , item.Print_CreateUser
                     , Utility.FormateDateTime(DateTime.Now));

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

        public void UpdateMPrint(MPrint item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Update  [dbo].[M_Print] Set
                                    [Print_Code]={0}
                                   ,[Print_NameT]={1}
                                   ,[Print_NameE]={2}
                                   ,[Print_Uname]={3}
                                   ,[Print_EditUser]={4}
                                   ,[Print_EditDate]={5}
                            where [Print_Id]={6} ";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Print_Code.ToUpper())
                    , Utility.ReplaceString(item.Print_NameT)
                    , Utility.ReplaceString(item.Print_NameE)
                    , Utility.ReplaceString(item.Print_Uname)
                    , item.Print_EditUser
                    , Utility.FormateDateTime(DateTime.Now)
                    , item.Print_Id);

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

        public void DeleteMPrint(MPrint item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Update  [dbo].[M_Print] Set
                                        [Print_Delete]={0}
                                       ,[Print_DeleteUser]={1}
                                       ,[Print_DeleteDate]={2}
                            where [Print_Id]={3} ";
                strSQL = string.Format(strSQL
                    , 1
                    , item.Print_DeleteUser
                    , Utility.FormateDateTime(DateTime.Now)
                    , item.Print_Id);

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
        #endregion


        #region --  MEquipment  --

        public void GetMEquipment(out List<MEquipment> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<MEquipment>();
            MEquipment item = new MEquipment();
            try
            {

                strSQL = "select * FROM [dbo].[M_Equipment] where 0=0 and [Equipment_Delete]=0 ";
                if (id > 0)
                {

                    strSQL += " and [Equipment_Id]=" + id;
                }
                //ls = objConn.Query<MEquipment>(strSQL).ToList();

                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new MEquipment();
                        item.Equipment_Id = Convert.ToInt32(dt.Rows[i]["Equipment_Id"].ToString());
                        item.Equipment_Code = dt.Rows[i]["Equipment_Code"].ToString();
                        item.Equipment_NameT = dt.Rows[i]["Equipment_NameT"].ToString();
                        item.Equipment_NameE = dt.Rows[i]["Equipment_NameE"].ToString();
                        item.Equipment_Uname = dt.Rows[i]["Equipment_Uname"].ToString();
                        item.Equipment_UnamePrice = "บาท/" + dt.Rows[i]["Equipment_Uname"].ToString();
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


        public void InsertMEquipment(MEquipment item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"INSERT INTO [dbo].[M_Equipment]
                                   ([Equipment_Code]
                                   ,[Equipment_NameT]
                                   ,[Equipment_NameE]
                                   ,[Equipment_Uname]
                                   ,[Equipment_CreateUser]
                                   ,[Equipment_CreateDate]
                                   ,[Equipment_Delete])values({0},{1},{2},{3},{4},{5},0)";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Equipment_Code.ToUpper())
                    , Utility.ReplaceString(item.Equipment_NameT)
                    , Utility.ReplaceString(item.Equipment_NameE)
                    , Utility.ReplaceString(item.Equipment_Uname)
                    , item.Equipment_CreateUser
                     , Utility.FormateDateTime(DateTime.Now));

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

        public void UpdateMEquipment(MEquipment item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Update  [dbo].[M_Equipment] Set
                                    [Equipment_Code]={0}
                                   ,[Equipment_NameT]={1}
                                   ,[Equipment_NameE]={2}
                                   ,[Equipment_Uname]={3}
                                   ,[Equipment_EditUser]={4}
                                   ,[Equipment_EditDate]={5}
                            where [Equipment_Id]={6} ";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.Equipment_Code.ToUpper())
                    , Utility.ReplaceString(item.Equipment_NameT)
                    , Utility.ReplaceString(item.Equipment_NameE)
                    , Utility.ReplaceString(item.Equipment_Uname)
                    , item.Equipment_EditUser
                    , Utility.FormateDateTime(DateTime.Now)
                    , item.Equipment_Id);

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
        public void DeleteMEquipment(MEquipment item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Update  [dbo].[M_Equipment] Set
                                        [Equipment_Delete]={0}
                                       ,[Equipment_DeleteUser]={1}
                                       ,[Equipment_DeleteDate]={2}
                            where [Equipment_Id]={3} ";
                strSQL = string.Format(strSQL
                    , 1
                    , item.Equipment_DeleteUser
                    , Utility.FormateDateTime(DateTime.Now)
                    , item.Equipment_Id);

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

        #endregion
    }
}