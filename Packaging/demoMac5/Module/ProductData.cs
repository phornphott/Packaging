using Dapper;
using demoMac5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demoMac5.Module
{
    public class ProductData
    {
        string msgErr = string.Empty;

        #region -- STG --
        public void GetSTG(out List<STG> ls, int STGid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<STG>();
            STG stg = new STG();
            try
            {

                strSQL = "select * FROM [dbo].[STG] where 0=0 ";
                if (STGid > 0)
                {

                    strSQL += " and STGid=" + STGid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        stg = new STG();
                        stg.STGid = Convert.ToInt32(dt.Rows[i]["STGid"].ToString());
                        stg.STGcode = dt.Rows[i]["STGcode"].ToString();
                        stg.STGdescT = dt.Rows[i]["STGdescT"].ToString();
                        stg.STGdescE = dt.Rows[i]["STGdescE"].ToString();
                        ls.Add(stg);
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

        public void InsertSTG(STG stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into STG (STGcode,STGdescT,STGdescE) 
                                    values({0},{1},{2})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(stg.STGcode.ToUpper())
                    , Utility.ReplaceString(stg.STGdescT)
                    , Utility.ReplaceString(stg.STGdescE ?? ""));

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

        public void UpdateSTG(STG stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update STG Set
                                    STGcode={1},
                                    STGdescT={2},
                                    STGdescE={3}
                                    where STGid={0}";

                strSQL = string.Format(strSQL
                    , stg.STGid
                  , Utility.ReplaceString(stg.STGcode.ToUpper())
                  , Utility.ReplaceString(stg.STGdescT)
                  , Utility.ReplaceString(stg.STGdescE));

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

        public void DeleteSTG(STG stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Delete  From STG
                                    where STGid={0}";

                strSQL = string.Format(strSQL
                    , stg.STGid);

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

        #endregion -- STG --


        #region -- Job--
        public void GetJob(out List<JOB> ls, int JOBid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<JOB>();
            JOB item = new JOB();
            try
            {

                //strSQL = "select ROW_NUMBER() OVER(order by jobcode) as JOBrow,case JOBhide when -1 then 1 Else 0 End as JOBhide_Chk,case JOBlock when -1 then 1 Else 0 End as JOBlock_Chk, * from JOB where 0=0 ";
                strSQL = "select ROW_NUMBER() OVER(order by jobcode) as JOBrow,1 as JOBautostk_Chk,-1 as JOBautostk, * from JOB where 0=0 ";
                
                //strSQL = "select Top 500 * FROM [dbo].[JOB] where 0=0 ";
                if (JOBid > 0)
                {

                    strSQL += " and JOBid=" + JOBid;
                }
                strSQL += " order by JOBcode";
                ls = objConn.Query<JOB>(strSQL).ToList();
                //DataTable dt = DBHelper.List(strSQL, objConn);

                //if (dt.Rows.Count > 0)
                //{

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //   {
                //        item = new JOB();
                //        item.JOBid = Convert.ToInt32(dt.Rows[i]["JOBid"].ToString());
                //        item.JOBcode = dt.Rows[i]["JOBcode"].ToString();
                //        item.JOBdescT = dt.Rows[i]["JOBdescT"].ToString();
                //        item.JOBdescE = dt.Rows[i]["JOBdescE"].ToString();
                //        item.JOBgroup = dt.Rows[i]["JOBgroup"].ToString();
                //        item.JOBhide = Convert.ToInt32(dt.Rows[i]["JOBhide"].ToString());
                //        item.JOBlock = Convert.ToInt32(dt.Rows[i]["JOBlock"].ToString());
                //        item.JOBhide_Chk = item.JOBhide ==0?false:true;
                //        item.JOBlock_Chk = item.JOBlock == 0 ? false : true;
                //        item.JOBrefWE = dt.Rows[i]["JOBrefWE"].ToString();
                //        item.JOBsortNE = dt.Rows[i]["JOBsortNE"].ToString();
                //        item.JOBsortNT = dt.Rows[i]["JOBsortNT"].ToString();
                //      //  item.JOBeditDT = dt.Rows[i]["JOBeditDT"]==DBNull.Value ? null : Convert.ToDateTime(dt.Rows[i]["JOBeditDT"].ToString());
                //        ls.Add(item);
                //    }
                //}
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

        public void InsertJob(JOB item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into JOB (
                                   JOBcode
                                   ,JOBgroup
                                   ,JOBdescT
                                   ,JOBdescE
                                   ,JOBhide
                                   ,JOBlock
                                   ,JOBrefWE
                                   ,JOBsortNT
                                   ,JOBsortNE
                                   ,JOBeditDT  ) 
                                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(item.JOBcode.ToUpper())
                    , Utility.ReplaceString(item.JOBgroup)
                    , Utility.ReplaceString(item.JOBdescT ?? "")
                    , Utility.ReplaceString(item.JOBdescE ?? "")
                    , item.JOBhide_Chk == true ? -1 : 0
                    , item.JOBlock_Chk == true ? -1 : 0
                    , Utility.ReplaceString(item.JOBrefWE ?? "")
                    , Utility.ReplaceString(item.JOBsortNT ?? "")
                    , Utility.ReplaceString(item.JOBsortNE ?? "")
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

        public void UpdateJob(JOB item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"    UPDATE JOB
                                       SET JOBcode = {1}
                                          ,JOBgroup = {2}
                                          ,JOBdescT =  {3}
                                          ,JOBdescE =  {4}
                                          ,JOBhide =  {5}
                                          ,JOBlock =  {6}
                                          ,JOBrefWE =  {7}
                                          ,JOBsortNT =  {8}
                                          ,JOBsortNE =  {9}
                                          ,JOBeditDT =  {10}
                                     WHERE JOBid= {0} ";



                strSQL = string.Format(strSQL
                              , item.JOBid
                              , Utility.ReplaceString(item.JOBcode.ToUpper())
                              , Utility.ReplaceString(item.JOBgroup)
                              , Utility.ReplaceString(item.JOBdescT ?? "")
                              , Utility.ReplaceString(item.JOBdescE ?? "")
                              , item.JOBhide_Chk == true ? -1 : 0
                              , item.JOBlock_Chk == true ? -1 : 0
                              , Utility.ReplaceString(item.JOBrefWE ?? "")
                              , Utility.ReplaceString(item.JOBsortNT ?? "")
                              , Utility.ReplaceString(item.JOBsortNE ?? "")
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

        public void DeleteJob(JOB item)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Delete  From JOB
                                    where JOBid={0}";

                strSQL = string.Format(strSQL
                    , item.JOBid);

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


        #region -- PER --
        public void GetPER(out List<PER> ls, int PERid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<PER>();
            PER stg = new PER();
            try
            {

                strSQL = "select * FROM [dbo].[PER] where 0=0 ";
                if (PERid > 0)
                {

                    strSQL += " and PERid=" + PERid;
                }
                strSQL += " order by PERcode";
                ls = objConn.Query<PER>(strSQL).ToList();
                //DataTable dt = DBHelper.List(strSQL, objConn);

                //if (dt.Rows.Count > 0)
                //{

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        stg = new PER();
                //        stg.PERid = Convert.ToInt32(dt.Rows[i]["PERid"].ToString());
                //        stg.PERcode = dt.Rows[i]["PERcode"].ToString();
                //        stg.PERdep = dt.Rows[i]["PERdep"].ToString();
                //        stg.PERtaxnos = dt.Rows[i]["PERtaxnos"].ToString();
                //        stg.PERnameT = dt.Rows[i]["PERnameT"].ToString();
                //        stg.PERnameE = dt.Rows[i]["PERnameE"].ToString();
                //        stg.PERbdate = dt.Rows[i]["PERbdate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["PERbdate"].ToString());
                //        stg.PERworkS = dt.Rows[i]["PERworkS"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["PERworkS"].ToString());
                //        stg.PERworkF = dt.Rows[i]["PERworkF"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["PERworkF"].ToString());
                //        stg.PERadd1 = dt.Rows[i]["PERadd1"].ToString();
                //        stg.PERadd2 = dt.Rows[i]["PERadd2"].ToString();
                //        stg.PERadd3 = dt.Rows[i]["PERadd3"].ToString();
                //        stg.PERtel = dt.Rows[i]["PERtel"].ToString();
                //        stg.PERpositn = dt.Rows[i]["PERpositn"].ToString();
                //        stg.PERstatus = Convert.ToInt32(dt.Rows[i]["PERstatus"].ToString());
                //        stg.PERnchild = Convert.ToInt32(dt.Rows[i]["PERnchild"].ToString());
                //        stg.PERcisstudy = Convert.ToInt32(dt.Rows[i]["PERcisstudy"].ToString());
                //        stg.PERnotstudy = Convert.ToInt32(dt.Rows[i]["PERnotstudy"].ToString());
                //        stg.PERsalary = Convert.ToDecimal(dt.Rows[i]["PERsalary"].ToString());
                //        stg.PERhide = Convert.ToInt32(dt.Rows[i]["PERhide"].ToString());
                //        stg.PERlock = Convert.ToInt32(dt.Rows[i]["PERlock"].ToString());
                //        stg.PERmemo = dt.Rows[i]["PERmemo"].ToString();
                //        stg.PEReditLK = dt.Rows[i]["PEReditLK"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["PEReditLK"].ToString());
                //        stg.PERrefWE = dt.Rows[i]["PERrefWE"].ToString();
                //        stg.PEReditDT = dt.Rows[i]["PEReditDT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["PEReditDT"].ToString());

                //        ls.Add(stg);
                //    }
                //}
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

        public void InsertPER(PER stg)
        {
            if (!Utility.IsDate(stg.PERbdate))
            {
                stg.PERbdate = DateTime.MinValue;
            }
            if (!Utility.IsDate(stg.PERworkS))
            {
                stg.PERworkS = DateTime.MinValue;
            }
            if (!Utility.IsDate(stg.PERworkF))
            {
                stg.PERworkF = DateTime.MinValue;
            }

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();

            try
            {
                string strSQL = "insert into PER WITH (UPDLOCK) (PERcode,PERdep,PERtaxnos,PERnameT,PERnameE,PERbdate,PERworkS,PERworkF"
                                + ",PERadd1,PERadd2,PERadd3,PERtel,PERpositn,PERstatus,PERnchild,PERcisstudy,PERnotstudy,PERsalary"
                                + ",PERhide,PERlock,PERmemo,PEReditLK,PERrefWE,PEReditDT)"
                                + " values (@PERcode,@PERdep,@PERtaxnos,@PERnameT,@PERnameE,@PERbdate,@PERworkS,@PERworkF"
                                + ",@PERadd1,@PERadd2,@PERadd3,@PERtel,@PERpositn,@PERstatus,@PERnchild,@PERcisstudy,@PERnotstudy,@PERsalary"
                                + ",@PERhide,@PERlock,@PERmemo,@PEReditLK,@PERrefWE,@PEReditDT)";



                cmd = new SqlCommand(strSQL, objConn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PERcode", SqlDbType.NVarChar, 15).Value = Utility.DBString(stg.PERcode.ToUpper());
                cmd.Parameters.Add("@PERdep", SqlDbType.NVarChar, 15).Value = Utility.DBString(stg.PERdep);
                cmd.Parameters.Add("@PERtaxnos", SqlDbType.NVarChar, 15).Value = Utility.DBString(stg.PERtaxnos);
                cmd.Parameters.Add("@PERnameT", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERnameT);
                cmd.Parameters.Add("@PERnameE", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERnameE);
                if ((stg.PERbdate == DateTime.MinValue) || (stg.PERbdate == DateTime.MaxValue))
                {
                    cmd.Parameters.Add("@PERbdate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PERbdate", SqlDbType.DateTime).Value = Utility.DBDateTime(stg.PERbdate);
                }
                if ((stg.PERworkS == DateTime.MinValue) || (stg.PERworkS == DateTime.MaxValue))
                {
                    cmd.Parameters.Add("@PERworkS", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PERworkS", SqlDbType.DateTime).Value = Utility.DBDateTime(stg.PERworkS);
                }
                if ((stg.PERworkF == DateTime.MinValue) || (stg.PERworkF == DateTime.MaxValue))
                {
                    cmd.Parameters.Add("@PERworkF", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PERworkF", SqlDbType.DateTime).Value = Utility.DBDateTime(stg.PERworkF);
                }
                cmd.Parameters.Add("@PERadd1", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERadd1);
                cmd.Parameters.Add("@PERadd2", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERadd2);
                cmd.Parameters.Add("@PERadd3", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERadd3);
                cmd.Parameters.Add("@PERtel", SqlDbType.NVarChar, 50).Value = Utility.DBString(stg.PERtel);
                cmd.Parameters.Add("@PERpositn", SqlDbType.NVarChar, 50).Value = Utility.DBString(stg.PERpositn);
                cmd.Parameters.Add("@PERstatus", SqlDbType.SmallInt).Value = stg.PERstatus;
                cmd.Parameters.Add("@PERnchild", SqlDbType.SmallInt).Value = stg.PERnchild;
                cmd.Parameters.Add("@PERcisstudy", SqlDbType.SmallInt).Value = stg.PERcisstudy;
                cmd.Parameters.Add("@PERnotstudy", SqlDbType.SmallInt).Value = stg.PERnotstudy;
                cmd.Parameters.Add("@PERsalary", SqlDbType.Money).Value = stg.PERsalary;
                cmd.Parameters.Add("@PERhide", SqlDbType.SmallInt).Value = stg.PERhide;
                cmd.Parameters.Add("@PERlock", SqlDbType.SmallInt).Value = stg.PERlock;
                cmd.Parameters.Add("@PERmemo", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERmemo);
                cmd.Parameters.Add("@PEReditLK", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@PERrefWE", SqlDbType.NVarChar, 512).Value = Utility.DBString(stg.PERrefWE);
                cmd.Parameters.Add("@PEReditDT", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.ExecuteNonQuery();
                //DBHelper.Execute(strSQL, objConn);

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

        public void UpdatePER(PER stg)
        {
            if (!Utility.IsDate(stg.PERbdate))
            {
                stg.PERbdate = DateTime.MinValue;
            }
            if (!Utility.IsDate(stg.PERworkS))
            {
                stg.PERworkS = DateTime.MinValue;
            }
            if (!Utility.IsDate(stg.PERworkF))
            {
                stg.PERworkF = DateTime.MinValue;
            }
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            SqlCommand cmd = objConn.CreateCommand();

            try
            {
                string strSQL = "update PER WITH (UPDLOCK) Set PERcode =@PERcode , PERdep=@PERdep, PERtaxnos=@PERtaxnos, PERnameT=@PERnameT, PERnameE=@PERnameE"
                                + ", PERbdate=@PERbdate, PERworkS=@PERworkS, PERworkF=@PERworkF, PERadd1=@PERadd1, PERadd2=@PERadd2, PERadd3=@PERadd3, PERtel=@PERtel"
                                + ", PERpositn=@PERpositn, PERstatus=@PERstatus, PERnchild=@PERnchild, PERcisstudy=@PERcisstudy, PERnotstudy=@PERnotstudy, PERsalary=@PERsalary"
                                + ", PERhide=@PERhide, PERlock=@PERlock, PERmemo=@PERmemo, PEReditLK=@PEReditLK, PERrefWE=@PERrefWE, PEReditDT=@PEReditDT"
                                + " where PERid=@PERid";

                cmd = new SqlCommand(strSQL, objConn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PERid", SqlDbType.Int).Value = stg.PERid;
                cmd.Parameters.Add("@PERcode", SqlDbType.NVarChar, 15).Value = Utility.DBString(stg.PERcode.ToUpper());
                cmd.Parameters.Add("@PERdep", SqlDbType.NVarChar, 15).Value = Utility.DBString(stg.PERdep);
                cmd.Parameters.Add("@PERtaxnos", SqlDbType.NVarChar, 15).Value = Utility.DBString(stg.PERtaxnos);
                cmd.Parameters.Add("@PERnameT", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERnameT);
                cmd.Parameters.Add("@PERnameE", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERnameE);
                if ((stg.PERbdate == DateTime.MinValue) || (stg.PERbdate == DateTime.MaxValue))
                {
                    cmd.Parameters.Add("@PERbdate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PERbdate", SqlDbType.DateTime).Value = Utility.DBDateTime(stg.PERbdate);
                }
                if ((stg.PERworkS == DateTime.MinValue) || (stg.PERworkS == DateTime.MaxValue))
                {
                    cmd.Parameters.Add("@PERworkS", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PERworkS", SqlDbType.DateTime).Value = Utility.DBDateTime(stg.PERworkS);
                }
                if ((stg.PERworkF == DateTime.MinValue) || (stg.PERworkF == DateTime.MaxValue))
                {
                    cmd.Parameters.Add("@PERworkF", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PERworkF", SqlDbType.DateTime).Value = Utility.DBDateTime(stg.PERworkF);
                }
                cmd.Parameters.Add("@PERadd1", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERadd1);
                cmd.Parameters.Add("@PERadd2", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERadd2);
                cmd.Parameters.Add("@PERadd3", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERadd3);
                cmd.Parameters.Add("@PERtel", SqlDbType.NVarChar, 50).Value = Utility.DBString(stg.PERtel);
                cmd.Parameters.Add("@PERpositn", SqlDbType.NVarChar, 50).Value = Utility.DBString(stg.PERpositn);
                cmd.Parameters.Add("@PERstatus", SqlDbType.SmallInt).Value = stg.PERstatus;
                cmd.Parameters.Add("@PERnchild", SqlDbType.SmallInt).Value = stg.PERnchild;
                cmd.Parameters.Add("@PERcisstudy", SqlDbType.SmallInt).Value = stg.PERcisstudy;
                cmd.Parameters.Add("@PERnotstudy", SqlDbType.SmallInt).Value = stg.PERnotstudy;
                cmd.Parameters.Add("@PERsalary", SqlDbType.Money).Value = stg.PERsalary;
                cmd.Parameters.Add("@PERhide", SqlDbType.SmallInt).Value = stg.PERhide;
                cmd.Parameters.Add("@PERlock", SqlDbType.SmallInt).Value = stg.PERlock;
                cmd.Parameters.Add("@PERmemo", SqlDbType.NVarChar, 250).Value = Utility.DBString(stg.PERmemo);
                cmd.Parameters.Add("@PEReditLK", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@PERrefWE", SqlDbType.NVarChar, 512).Value = Utility.DBString(stg.PERrefWE);
                cmd.Parameters.Add("@PEReditDT", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.ExecuteNonQuery();

                //DBHelper.Execute(strSQL, objConn);

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

        public void DeletePER(PER stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Delete  From PER
                                    where PERid={0}";

                strSQL = string.Format(strSQL
                    , stg.PERid);

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

        #endregion -- PER --



        #region -- DEG --
        public void GetDEG(out List<DEG> ls, int DEGid)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<DEG>();
            DEG stg = new DEG();
            try
            {

                strSQL = "select * FROM [dbo].[DEG] where 0=0 ";
                if (DEGid > 0)
                {

                    strSQL += " and DEGid=" + DEGid;
                }
                DataTable dt = DBHelper.List(strSQL, objConn);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        stg = new DEG();
                        stg.DEGid = Convert.ToInt32(dt.Rows[i]["DEGid"].ToString());
                        stg.DEGcode = dt.Rows[i]["DEGcode"].ToString();
                        stg.DEGdescT = dt.Rows[i]["DEGdescT"].ToString();
                        stg.DEGdescE = dt.Rows[i]["DEGdescE"].ToString();
                        ls.Add(stg);
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

        public void InsertDEG(DEG stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"insert into DEG (DEGcode,DEGdescT,DEGdescE) 
                                    values({0},{1},{2})";
                strSQL = string.Format(strSQL
                    , Utility.ReplaceString(stg.DEGcode.ToUpper())
                    , Utility.ReplaceString(stg.DEGdescT)
                    , Utility.ReplaceString(stg.DEGdescE ?? ""));

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

        public void UpdateDEG(DEG stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"update DEG Set
                                    DEGcode={1},
                                    DEGdescT={2},
                                    DEGdescE={3}
                                    where DEGid={0}";

                strSQL = string.Format(strSQL
                    , stg.DEGid
                  , Utility.ReplaceString(stg.DEGcode.ToUpper())
                  , Utility.ReplaceString(stg.DEGdescT)
                  , Utility.ReplaceString(stg.DEGdescE));

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

        public void DeleteDEG(DEG stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Delete  From DEG
                                    where DEGid={0}";

                strSQL = string.Format(strSQL
                    , stg.DEGid);

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

        #endregion -- DEG  --


        #region -- STK -- 

        public void GetSTK(out List<STK> ls, int id)
        {
            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<STK>();
            STK item = new STK();
            try
            {

                //strSQL = "select top 200 * FROM [dbo].[STK] where 0=0 ";
                strSQL = "select top 4000 ROW_NUMBER() OVER(order by STKcode) as STKrow, * FROM [dbo].[STK] where 0=0 ";
                if (id > 0)
                {
                    strSQL += " and STKid=" + id;
                }
                strSQL += " order by STKcode";

                ls = objConn.Query<STK>(strSQL).ToList();

                //DataTable dt = DBHelper.List(strSQL, objConn);

                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        item = new STK();
                //        item.STKid = Library.DBInt(dt.Rows[i]["STKid"]);
                //        item.STKcode = Library.DBString(dt.Rows[i]["STKcode"]);
                //        item.STKgroup = Library.DBString(dt.Rows[i]["STKgroup"]);
                //        item.STKcode2 = Library.DBString(dt.Rows[i]["STKcode2"]);
                //        item.STKdescT1 = Library.DBString(dt.Rows[i]["STKdescT1"]);
                //        item.STKdescT2 = Library.DBString(dt.Rows[i]["STKdescT2"]);
                //        item.STKdescT3 = Library.DBString(dt.Rows[i]["STKdescT3"]);
                //        item.STKdescE1 = Library.DBString(dt.Rows[i]["STKdescE1"]);
                //        item.STKdescE2 = Library.DBString(dt.Rows[i]["STKdescE2"]);
                //        item.STKdescE3 = Library.DBString(dt.Rows[i]["STKdescE3"]);
                //        item.STKmax = Library.DBDecimal(dt.Rows[i]["STKmax"]);
                //        item.STKmin = Library.DBDecimal(dt.Rows[i]["STKmin"]);
                //        item.STKunit1 = Library.DBInt(dt.Rows[i]["STKunit1"]);
                //        item.STKunit2 = Library.DBInt(dt.Rows[i]["STKunit2"]);
                //        item.STKconv1 = Library.DBDecimal(dt.Rows[i]["STKconv1"]);
                //        item.STKconv2 = Library.DBDecimal(dt.Rows[i]["STKconv2"]);
                //        item.STKsnsv = Library.DBInt(dt.Rows[i]["STKsnsv"]);
                //        item.STKuname0 = Library.DBString(dt.Rows[i]["STKuname0"]);
                //        item.STKuname1 = Library.DBString(dt.Rows[i]["STKuname1"]);
                //        item.STKuname2 = Library.DBString(dt.Rows[i]["STKuname2"]);
                //        item.STKuname3 = Library.DBString(dt.Rows[i]["STKuname3"]);
                //        item.STKuname4 = Library.DBString(dt.Rows[i]["STKuname4"]);
                //        item.STKuname5 = Library.DBString(dt.Rows[i]["STKuname5"]);
                //        item.STKqU1 = Library.DBDecimal(dt.Rows[i]["STKqU1"]);
                //        item.STKqU2 = Library.DBDecimal(dt.Rows[i]["STKqU2"]);
                //        item.STKqU3 = Library.DBDecimal(dt.Rows[i]["STKqU3"]);
                //        item.STKqU4 = Library.DBDecimal(dt.Rows[i]["STKqU4"]);
                //        item.STKqU5 = Library.DBDecimal(dt.Rows[i]["STKqU5"]);
                //        item.STKqE1 = Library.DBDecimal(dt.Rows[i]["STKqE1"]);
                //        item.STKqE2 = Library.DBDecimal(dt.Rows[i]["STKqE2"]);
                //        item.STKqE3 = Library.DBDecimal(dt.Rows[i]["STKqE3"]);
                //        item.STKqE4 = Library.DBDecimal(dt.Rows[i]["STKqE4"]);
                //        item.STKqE5 = Library.DBDecimal(dt.Rows[i]["STKqE5"]);
                //        item.STKqN1 = Library.DBInt(dt.Rows[i]["STKqN1"]);
                //        item.STKqN2 = Library.DBInt(dt.Rows[i]["STKqN2"]);
                //        item.STKqN3 = Library.DBInt(dt.Rows[i]["STKqN3"]);
                //        item.STKqN4 = Library.DBInt(dt.Rows[i]["STKqN4"]);
                //        item.STKqN5 = Library.DBInt(dt.Rows[i]["STKqN5"]);
                //        item.STKvat = Library.DBDecimal(dt.Rows[i]["STKvat"]);
                //        item.STKexpire = Library.DBInt(dt.Rows[i]["STKexpire"]);
                //        item.STKhide = Library.DBInt(dt.Rows[i]["STKhide"]);
                //        item.STKuse2 = Library.DBInt(dt.Rows[i]["STKuse2"]);
                //        item.STKu2name = Library.DBString(dt.Rows[i]["STKu2name"]);
                //        item.STKfx = Library.DBInt(dt.Rows[i]["STKfx"]);
                //        item.STKacP = Library.DBString(dt.Rows[i]["STKacP"]);
                //        item.STKacS = Library.DBString(dt.Rows[i]["STKacS"]);
                //        item.STKacC = Library.DBString(dt.Rows[i]["STKacC"]);
                //        item.STKlock = Library.DBInt(dt.Rows[i]["STKlock"]);
                //        item.STKmemo = Library.DBString(dt.Rows[i]["STKmemo"]);
                //        item.STKacC1 = Library.DBString(dt.Rows[i]["STKacC1"]);
                //        item.STKacC2 = Library.DBString(dt.Rows[i]["STKacC2"]);
                //        if (Library.IsDate(dt.Rows[i]["STKeditLK"]))
                //        {
                //            item.STKeditLK = Library.DBDateTime(dt.Rows[i]["STKeditLK"]);
                //        }
                //        else
                //        {
                //            item.STKeditLK = DateTime.Now;
                //        }

                //        item.STKrefWE = Library.DBString(dt.Rows[i]["STKrefWE"]);
                //        item.STKbarC1 = Library.DBString(dt.Rows[i]["STKbarC1"]);
                //        item.STKbarC2 = Library.DBString(dt.Rows[i]["STKbarC2"]);
                //        item.STKbarC3 = Library.DBString(dt.Rows[i]["STKbarC3"]);
                //        item.STKsortNT = Library.DBString(dt.Rows[i]["STKsortNT"]);
                //        item.STKsortNE = Library.DBString(dt.Rows[i]["STKsortNE"]);
                //        item.STKeditDT = Library.DBString(dt.Rows[i]["STKeditDT"]);
                //        item.STKstatus = Library.DBInt(dt.Rows[i]["STKstatus"]);
                //        item.STKsto = Library.DBString(dt.Rows[i]["STKsto"]);

                //        ls.Add(item);
                //    }
                //}
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

        public void GetAllProduct(out List<STK> ls)
        {
            string strSQL = string.Empty;
            ls = new List<STK>();
            try
            {
                using (var dbPackagingDB = new SqlConnection(ConfigurationManager.ConnectionStrings["PackagingDB"].ConnectionString))
                {
                    strSQL = "select ROW_NUMBER() OVER(order by STKcode) as STKrow,* FROM [dbo].[STK] order by STKcode;";
                    ls = dbPackagingDB.Query<STK>(strSQL).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
        }
        
        public void InsertSTK(STK item)
        {


            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"INSERT INTO [dbo].[STK]
           ([STKcode]
           ,[STKgroup]
           ,[STKcode2]
           ,[STKdescT1]
           ,[STKdescT2]
           ,[STKdescT3]
           ,[STKdescE1]
           ,[STKdescE2]
           ,[STKdescE3]
           ,[STKmax]
           ,[STKmin]
           ,[STKunit1]
           ,[STKunit2]
           ,[STKconv1]
           ,[STKconv2]
           ,[STKsnsv]
           ,[STKuname0]
           ,[STKuname1]
           ,[STKuname2]
           ,[STKuname3]
           ,[STKuname4]
           ,[STKuname5]
           ,[STKqU1]
           ,[STKqU2]
           ,[STKqU3]
           ,[STKqU4]
           ,[STKqU5]
           ,[STKqE1]
           ,[STKqE2]
           ,[STKqE3]
           ,[STKqE4]
           ,[STKqE5]
           ,[STKqN1]
           ,[STKqN2]
           ,[STKqN3]
           ,[STKqN4]
           ,[STKqN5]
           ,[STKvat]
           ,[STKexpire]
           ,[STKhide]
           ,[STKuse2]
           ,[STKu2name]
           ,[STKfx]
           ,[STKacP]
           ,[STKacS]
           ,[STKacC]
           ,[STKlock]
           ,[STKmemo]
           ,[STKacC1]
           ,[STKacC2]
           ,[STKeditLK]
           ,[STKrefWE]
           ,[STKbarC1]
           ,[STKbarC2]
           ,[STKbarC3]
           ,[STKsortNT]
           ,[STKsortNE]
           ,[STKeditDT]
           ,[STKstatus]
           ,[STKsto])VALUES( ";
                strSQL += Utility.ReplaceString(item.STKcode.ToUpper())
                   + "," + Utility.ReplaceString(item.STKgroup)
                   + "," + Utility.ReplaceString(item.STKcode2)
                   + "," + Utility.ReplaceString(item.STKdescT1)
                   + "," + Utility.ReplaceString(item.STKdescT2)
                   + "," + Utility.ReplaceString(item.STKdescT3)
                   + "," + Utility.ReplaceString(item.STKdescE1)
                   + "," + Utility.ReplaceString(item.STKdescE2)
                   + "," + Utility.ReplaceString(item.STKdescE3)
                   + "," + item.STKmax
                   + "," + item.STKmin
                   + "," + item.STKunit1
                   + "," + item.STKunit2
                   + "," + item.STKconv1
                   + "," + item.STKconv2
                   + "," + item.STKsnsv
                   + "," + Utility.ReplaceString(item.STKuname0)
                   + "," + Utility.ReplaceString(item.STKuname1)
                   + "," + Utility.ReplaceString(item.STKuname2)
                   + "," + Utility.ReplaceString(item.STKuname3)
                   + "," + Utility.ReplaceString(item.STKuname4)
                   + "," + Utility.ReplaceString(item.STKuname5)
                   + "," + item.STKqU1
                   + "," + item.STKqU2
                   + "," + item.STKqU3
                   + "," + item.STKqU4
                   + "," + item.STKqU5
                   + "," + item.STKqE1
                   + "," + item.STKqE2
                   + "," + item.STKqE3
                   + "," + item.STKqE4
                   + "," + item.STKqE5
                   + "," + item.STKqN1
                   + "," + item.STKqN2
                   + "," + item.STKqN3
                   + "," + item.STKqN4
                   + "," + item.STKqN5
                   + "," + item.STKvat
                   + "," + item.STKexpire
                   + "," + item.STKhide
                   + "," + item.STKuse2
                   + "," + Utility.ReplaceString(item.STKu2name)
                   + "," + item.STKfx
                   + "," + Utility.ReplaceString(item.STKacP)
                   + "," + Utility.ReplaceString(item.STKacS)
                   + "," + Utility.ReplaceString(item.STKacC)
                   + "," + item.STKlock
                   + "," + Utility.ReplaceString(item.STKmemo)
                   + "," + Utility.ReplaceString(item.STKacC1)
                   + "," + Utility.ReplaceString(item.STKacC2)
                   + "," + Utility.FormateDateTime(DateTime.Now)
                   + "," + Utility.ReplaceString(item.STKrefWE)
                   + "," + Utility.ReplaceString(item.STKbarC1)
                   + "," + Utility.ReplaceString(item.STKbarC2)
                   + "," + Utility.ReplaceString(item.STKbarC3)
                   + "," + Utility.ReplaceString(item.STKsortNT)
                   + "," + Utility.ReplaceString(item.STKsortNE)
                   + "," + Utility.ReplaceString(item.STKeditDT)
                   + "," + item.STKstatus
                   + "," + Utility.ReplaceString(item.STKsto)
                  + ")";


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

        public void AutosertSTK(STK item)
        {
            bool iExist = Library.CheckExistCode("STK", 0, item.STKcode);

            if (iExist)
            {
                return;
            }
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"INSERT INTO [dbo].[STK]
           ([STKcode]
           ,[STKgroup]
           ,[STKcode2]
           ,[STKdescT1]
           ,[STKdescT2]
           ,[STKdescT3]
           ,[STKdescE1]
           ,[STKdescE2]
           ,[STKdescE3]
           ,[STKmax]
           ,[STKmin]
           ,[STKunit1]
           ,[STKunit2]
           ,[STKconv1]
           ,[STKconv2]
           ,[STKsnsv]
           ,[STKuname0]
           ,[STKuname1]
           ,[STKuname2]
           ,[STKuname3]
           ,[STKuname4]
           ,[STKuname5]
           ,[STKqU1]
           ,[STKqU2]
           ,[STKqU3]
           ,[STKqU4]
           ,[STKqU5]
           ,[STKqE1]
           ,[STKqE2]
           ,[STKqE3]
           ,[STKqE4]
           ,[STKqE5]
           ,[STKqN1]
           ,[STKqN2]
           ,[STKqN3]
           ,[STKqN4]
           ,[STKqN5]
           ,[STKvat]
           ,[STKexpire]
           ,[STKhide]
           ,[STKuse2]
           ,[STKu2name]
           ,[STKfx]
           ,[STKacP]
           ,[STKacS]
           ,[STKacC]
           ,[STKlock]
           ,[STKmemo]
           ,[STKacC1]
           ,[STKacC2]
           ,[STKeditLK]
           ,[STKrefWE]
           ,[STKbarC1]
           ,[STKbarC2]
           ,[STKbarC3]
           ,[STKsortNT]
           ,[STKsortNE]
           ,[STKeditDT]
           ,[STKstatus]
           ,[STKautoCreate]
           ,[STKsto])VALUES( ";
                strSQL += Utility.ReplaceString(item.STKcode)
                   + "," + Utility.ReplaceString(item.STKgroup)
                   + "," + Utility.ReplaceString(item.STKcode2)
                   + "," + Utility.ReplaceString(item.STKdescT1)
                   + "," + Utility.ReplaceString(item.STKdescT2)
                   + "," + Utility.ReplaceString(item.STKdescT3)
                   + "," + Utility.ReplaceString(item.STKdescE1)
                   + "," + Utility.ReplaceString(item.STKdescE2)
                   + "," + Utility.ReplaceString(item.STKdescE3)
                   + "," + item.STKmax
                   + "," + item.STKmin
                   + "," + item.STKunit1
                   + "," + item.STKunit2
                   + "," + item.STKconv1
                   + "," + item.STKconv2
                   + "," + item.STKsnsv
                   + "," + Utility.ReplaceString(item.STKuname0)
                   + "," + Utility.ReplaceString(item.STKuname1)
                   + "," + Utility.ReplaceString(item.STKuname2)
                   + "," + Utility.ReplaceString(item.STKuname3)
                   + "," + Utility.ReplaceString(item.STKuname4)
                   + "," + Utility.ReplaceString(item.STKuname5)
                   + "," + item.STKqU1
                   + "," + item.STKqU2
                   + "," + item.STKqU3
                   + "," + item.STKqU4
                   + "," + item.STKqU5
                   + "," + item.STKqE1
                   + "," + item.STKqE2
                   + "," + item.STKqE3
                   + "," + item.STKqE4
                   + "," + item.STKqE5
                   + "," + item.STKqN1
                   + "," + item.STKqN2
                   + "," + item.STKqN3
                   + "," + item.STKqN4
                   + "," + item.STKqN5
                   + "," + item.STKvat
                   + "," + item.STKexpire
                   + "," + item.STKhide
                   + "," + item.STKuse2
                   + "," + Utility.ReplaceString(item.STKu2name)
                   + "," + item.STKfx
                   + "," + Utility.ReplaceString(item.STKacP)
                   + "," + Utility.ReplaceString(item.STKacS)
                   + "," + Utility.ReplaceString(item.STKacC)
                   + "," + item.STKlock
                   + "," + Utility.ReplaceString(item.STKmemo)
                   + "," + Utility.ReplaceString(item.STKacC1)
                   + "," + Utility.ReplaceString(item.STKacC2)
                   + "," + Utility.FormateDateTime(DateTime.Now)
                   + "," + Utility.ReplaceString(item.STKrefWE)
                   + "," + Utility.ReplaceString(item.STKbarC1)
                   + "," + Utility.ReplaceString(item.STKbarC2)
                   + "," + Utility.ReplaceString(item.STKbarC3)
                   + "," + Utility.ReplaceString(item.STKsortNT)
                   + "," + Utility.ReplaceString(item.STKsortNE)
                   + "," + Utility.ReplaceString(item.STKeditDT)
                   + "," + item.STKstatus
                   + "," + 1
                   + "," + Utility.ReplaceString(item.STKsto)
                  + ")";


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


        public void UpdateSTK(STK item)
        {
            //[STKunit1]={11},
            //[STKunit2]={12},
            //, item.STKunit1
            //, item.STKunit2
            item.STKstatus = 0;

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Update [dbo].[STK] Set
                    [STKcode]={1},
                    [STKgroup]={2},
                    [STKcode2]={3},
                    [STKdescT1]={4},
                    [STKdescT2]={5},
                    [STKdescT3]={6},
                    [STKdescE1]={7},
                    [STKdescE2]={8},
                    [STKdescE3]={9},  
                    [STKmin]={10},
                    [STKconv1]={11},
                    [STKconv2]={12},
                    [STKsnsv]={13},
                    [STKuname0]={14},
                    [STKuname1]={15},
                    [STKuname2]={16},
                    [STKuname3]={17},
                    [STKuname4]={18},
                    [STKuname5]={19},
                    [STKqU1]={20},
                    [STKqU2]={21},
                    [STKqU3]={22},
                    [STKqU4]={23},
                    [STKqU5]={24},
                    [STKqE1]={25},
                    [STKqE2]={26},
                    [STKqE3]={27},
                    [STKqE4]={28},
                    [STKqE5]={29},
                    [STKqN1]={30},
                    [STKqN2]={31},
                    [STKqN3]={32},
                    [STKqN4]={33},
                    [STKqN5]={34},
                    [STKvat]={35},
                    [STKexpire]={36},
                    [STKhide]={37},
                    [STKuse2]={38},
                    [STKu2name]={39},
                    [STKfx]={40},
                    [STKacP]={41},
                    [STKacS]={52},
                    [STKacC]={43},
                    [STKlock]={44},
                    [STKmemo]={45},
                    [STKacC1]={46},
                    [STKacC2]={47},
                    [STKeditLK]={48},
                    [STKrefWE]={49},
                    [STKbarC1]={50},
                    [STKbarC2]={51},
                    [STKbarC3]={52},
                    [STKsortNT]={53},
                    [STKsortNE]={54},
                    [STKeditDT]={55},
                    [STKstatus]={56},
                    [STKsto]={57},
                    [STKmax]={58}
                    where STKid={0}";

                strSQL = string.Format(strSQL
                    , item.STKid
                    , Utility.ReplaceString(item.STKcode.ToUpper())
                  , Utility.ReplaceString(item.STKgroup)
                  , Utility.ReplaceString(item.STKcode2)
                  , Utility.ReplaceString(item.STKdescT1)
                  , Utility.ReplaceString(item.STKdescT2)
                  , Utility.ReplaceString(item.STKdescT3)
                  , Utility.ReplaceString(item.STKdescE1)
                  , Utility.ReplaceString(item.STKdescE2)
                  , Utility.ReplaceString(item.STKdescE3)
                  , item.STKmin
                  , item.STKconv1
                  , item.STKconv2
                  , item.STKsnsv
                  , Utility.ReplaceString(item.STKuname0)
                  , Utility.ReplaceString(item.STKuname1)
                  , Utility.ReplaceString(item.STKuname2)
                  , Utility.ReplaceString(item.STKuname3)
                  , Utility.ReplaceString(item.STKuname4)
                  , Utility.ReplaceString(item.STKuname5)
                  , item.STKqU1
                  , item.STKqU2
                  , item.STKqU3
                  , item.STKqU4
                  , item.STKqU5
                  , item.STKqE1
                  , item.STKqE2
                  , item.STKqE3
                  , item.STKqE4
                  , item.STKqE5
                  , item.STKqN1
                  , item.STKqN2
                  , item.STKqN3
                  , item.STKqN4
                  , item.STKqN5
                  , item.STKvat
                  , item.STKexpire
                  , item.STKhide
                  , item.STKuse2
                  , Utility.ReplaceString(item.STKu2name)
                  , item.STKfx
                  , Utility.ReplaceString(item.STKacP)
                  , Utility.ReplaceString(item.STKacS)
                  , Utility.ReplaceString(item.STKacC)
                  , item.STKlock
                  , Utility.ReplaceString(item.STKmemo)
                  , Utility.ReplaceString(item.STKacC1)
                  , Utility.ReplaceString(item.STKacC2)
                  , Utility.FormateDateTime(DateTime.Now)
                  , Utility.ReplaceString(item.STKrefWE)
                  , Utility.ReplaceString(item.STKbarC1)
                  , Utility.ReplaceString(item.STKbarC2)
                  , Utility.ReplaceString(item.STKbarC3)
                  , Utility.ReplaceString(item.STKsortNT)
                  , Utility.ReplaceString(item.STKsortNE)
                  , Utility.ReplaceString(item.STKeditDT)
                  , item.STKstatus
                  , Utility.ReplaceString(item.STKsto)
                  , item.STKmax
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


        public void DeleteSTK(STK stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Delete  From [dbo].[STK]
                                    where STKid={0}";

                strSQL = string.Format(strSQL
                    , stg.STKid);

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
        #endregion -- STK -- 


    }
}