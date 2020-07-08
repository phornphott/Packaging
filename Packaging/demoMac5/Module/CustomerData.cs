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
    public class CustomerData {

        string msgErr = string.Empty;
        public void GetDEB(out List<DEB> ls, int id)
        {

            string strSQL = string.Empty;
            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            ls = new List<DEB>();
            DEB item = new DEB();
            try
            {

                strSQL = @"SELECT top 200 p.*  FROM [dbo].[DEB] p  where 0=0 ";


                if (id > 0) {

                    strSQL += " and p.DEBid="+id;
                }
                ls = objConn.Query<DEB>(strSQL).ToList();

                //DataTable dt = DBHelper.List(strSQL, objConn);

                //if (dt.Rows.Count > 0)

                //{

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        item = new DEB();
                //        item.DEBid = Convert.ToInt32(dt.Rows[i]["DEBid"].ToString());
                //        item.DEBcode = dt.Rows[i]["DEBcode"]==DBNull.Value?"":dt.Rows[i]["DEBcode"].ToString();
                //        item.DEBgroup = dt.Rows[i]["DEBgroup"] == DBNull.Value ? "" : dt.Rows[i]["DEBgroup"].ToString();
                //        item.DEBnameT = dt.Rows[i]["DEBnameT"] == DBNull.Value ? "" : dt.Rows[i]["DEBnameT"].ToString();
                //        item.DEBnameE = dt.Rows[i]["DEBnameE"] == DBNull.Value ? "" : dt.Rows[i]["DEBnameE"].ToString();
                //        item.DEBcontactT = dt.Rows[i]["DEBcontactT"] == DBNull.Value ? "" : dt.Rows[i]["DEBcontactT"].ToString();
                //        item.DEBcontactE = dt.Rows[i]["DEBcontactE"] == DBNull.Value ? "" : dt.Rows[i]["DEBcontactE"].ToString();
                //        item.DEBadd1AT = dt.Rows[i]["DEBadd1AT"] == DBNull.Value ? "" : dt.Rows[i]["DEBadd1AT"].ToString();
                //        item.DEBadd2AT = dt.Rows[i]["DEBadd2AT"] == DBNull.Value ? "" : dt.Rows[i]["DEBadd2AT"].ToString();
                //        item.DEBadd3AT = dt.Rows[i]["DEBadd3AT"] == DBNull.Value ? "" : dt.Rows[i]["DEBadd3AT"].ToString();
                //        item.DEBadd1AE = dt.Rows[i]["DEBadd1AE"] == DBNull.Value ? "" : dt.Rows[i]["DEBadd1AE"].ToString();
                //        item.DEBadd2AE = dt.Rows[i]["DEBadd2AE"] == DBNull.Value ? "" : dt.Rows[i]["DEBadd2AE"].ToString();
                //        item.DEBadd3AE = dt.Rows[i]["DEBadd3AE"] == DBNull.Value ? "" : dt.Rows[i]["DEBadd3AE"].ToString();
                //        item.DEBtel = dt.Rows[i]["DEBtel"] == DBNull.Value ? "" : dt.Rows[i]["DEBtel"].ToString();
                //        item.DEBzone = dt.Rows[i]["DEBzone"] == DBNull.Value ? "" : dt.Rows[i]["DEBzone"].ToString();
                //        item.DEBgrade = dt.Rows[i]["DEBgrade"] == DBNull.Value ? "" : dt.Rows[i]["DEBgrade"].ToString();
                //        item.DEBlimit = dt.Rows[i]["DEBlimit"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBlimit"].ToString());
                //        item.DEBtaxclass = dt.Rows[i]["DEBtaxclass"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBtaxclass"].ToString());
                //        item.DEBgoodsDef = dt.Rows[i]["DEBgoodsDef"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBgoodsDef"].ToString());
                //        item.DEBcreditTerm = dt.Rows[i]["DEBcreditTerm"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBcreditTerm"].ToString());
                //        item.DEBpaytype = dt.Rows[i]["DEBpaytype"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBpaytype"].ToString());
                //        item.DEBbgrtype = dt.Rows[i]["DEBbgrtype"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBbgrtype"].ToString());
                //        item.DEBbgrday = dt.Rows[i]["DEBbgrday"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBbgrday"].ToString());
                //  //      item.DEBdate = Convert.ToDateTime(dt.Rows[i]["DEBdate"].ToString());
                //        item.DEBhide = dt.Rows[i]["DEBhide"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBhide"].ToString());
                //        item.DEBfax = dt.Rows[i]["DEBadd1AT"] == DBNull.Value ? "" : dt.Rows[i]["DEBfax"].ToString();
                //        item.DEBemail = dt.Rows[i]["DEBemail"] == DBNull.Value ? "" : dt.Rows[i]["DEBemail"].ToString();
                //        item.DEBtarget = dt.Rows[i]["DEBtarget"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[i]["DEBtarget"].ToString());
                //        item.DEBmemo = dt.Rows[i]["DEBmemo"] == DBNull.Value ? "" : dt.Rows[i]["DEBmemo"].ToString();
                //        item.DEBac = dt.Rows[i]["DEBac"] == DBNull.Value ? "" : dt.Rows[i]["DEBac"].ToString();
                //        item.DEBlock = dt.Rows[i]["DEBlock"] == DBNull.Value ? "" : dt.Rows[i]["DEBlock"].ToString();
                //        item.DEBoName = dt.Rows[i]["DEBoName"] == DBNull.Value ? "" : dt.Rows[i]["DEBoName"].ToString();
                //        item.DEBprice = dt.Rows[i]["DEBprice"] == DBNull.Value ? "" : dt.Rows[i]["DEBprice"].ToString();
                //        item.DEBbillAD = dt.Rows[i]["DEBbillAD"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["DEBbillAD"].ToString());
                //        item.DEBsortNT = dt.Rows[i]["DEBsortNT"] == DBNull.Value ? "" : dt.Rows[i]["DEBsortNT"].ToString();
                //        item.DEBsortNE = dt.Rows[i]["DEBsortNE"] == DBNull.Value ? "" : dt.Rows[i]["DEBsortNE"].ToString();
                //      //  item.DEBeditDT = dt.Rows[i]["DEBeditDT"] == DBNull.Value ? null :  Convert.ToDateTime(dt.Rows[i]["DEBeditDT"].ToString());
                //        item.DEBsalesP = dt.Rows[i]["DEBsalesP"] == DBNull.Value ? "" : dt.Rows[i]["DEBsalesP"].ToString();
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

        public void GetAllCustomer(out List<DEB> ls)
        {
            string strSQL = string.Empty;
            ls = new List<DEB>();
            try
            {
                using (var dbPackagingDB = new SqlConnection(ConfigurationManager.ConnectionStrings["PackagingDB"].ConnectionString))
                {
                    strSQL = @"SELECT ROW_NUMBER() OVER(order by DEBcode) as DEBrow,* FROM [dbo].[DEB] order by DEBcode;";
                    ls = dbPackagingDB.Query<DEB>(strSQL).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
        }

        public void GetAllCustomerGroup(out List<DEG> ls)
        {
            string strSQL = string.Empty;
            ls = new List<DEG>();
            try
            {
                using (var dbPackagingDB = new SqlConnection(ConfigurationManager.ConnectionStrings["PackagingDB"].ConnectionString))
                {
                    strSQL = @"SELECT * FROM [dbo].[DEG] order by DEGcode;";
                    ls = dbPackagingDB.Query<DEG>(strSQL).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("เกิดข้อผิดพลาด : " + ex.Message);
            }
        }

        public void InsertDEB(DEB item)
        {

            if (!Utility.IsDate(item.DEBdate))
            {
                item.DEBdate = null;
            }
            //if (!Utility.IsDate(item.DEBbgrday))
            //{
            //    item.DEBbgrday = null;
            //}

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                        string strSQL = @" INSERT INTO [dbo].[DEB]
                                   ([DEBcode]
                                   ,[DEBgroup]
                                   ,[DEBnameT]
                                   ,[DEBnameE]
                                   ,[DEBcontactT]
                                   ,[DEBcontactE]
                                   ,[DEBadd1AT]
                                   ,[DEBadd2AT]
                                   ,[DEBadd3AT]
                                   ,[DEBadd1AE]
                                   ,[DEBadd2AE]
                                   ,[DEBadd3AE]
                                   ,[DEBtel]
                                   ,[DEBtaxnos]
                                   ,[DEBzone]
                                   ,[DEBgrade]
                                   ,[DEBlimit]
                                   ,[DEBtaxclass]
                                   ,[DEBgoodsDef]
                                   ,[DEBcreditTerm]
                                   ,[DEBpaytype]
                                   ,[DEBpayday]
                                   ,[DEBpayOn1]
                                   ,[DEBpayOn2]
                                   ,[DEBpayOn3]
                                   ,[DEBpayOn4]
                                   ,[DEBpayOn5]
                                   ,[DEBpayN1]
                                   ,[DEBpayN2]
                                   ,[DEBbgrtype]
                                   ,[DEBbgrday]
                                   ,[DEBbgrOn1]
                                   ,[DEBbgrOn2]
                                   ,[DEBbgrOn3]
                                   ,[DEBbgrOn4]
                                   ,[DEBbgrOn5]
                                   ,[DEBdate]
                                   ,[DEBhide]
                                   ,[DEBfax]
                                   ,[DEBemail]
                                   ,[DEBtarget]
                                   ,[DEBmemo]
                                   ,[DEBac]
                                   ,[DEBlock]
                                   ,[DEBoName]
                                   ,[DEBprice]
                                   ,[DEBbillAD]
                                   ,[DEBsortNT]
                                   ,[DEBsortNE]
                                   ,[DEBeditDT]
                                   ,[DEBsalesP])VALUES( ";
                        strSQL += Utility.ReplaceString(item.DEBcode)
                           + "," + Utility.ReplaceString(item.DEBgroup)
                           + "," + Utility.ReplaceString(item.DEBnameT)
                           + "," + Utility.ReplaceString(item.DEBnameE)
                           + "," + Utility.ReplaceString(item.DEBcontactT)
                           + "," + Utility.ReplaceString(item.DEBcontactE)
                           + "," + Utility.ReplaceString(item.DEBadd1AT)
                           + "," + Utility.ReplaceString(item.DEBadd2AT)
                           + "," + Utility.ReplaceString(item.DEBadd3AT)
                           + "," + Utility.ReplaceString(item.DEBadd1AE)
                           + "," + Utility.ReplaceString(item.DEBadd2AE)
                           + "," + Utility.ReplaceString(item.DEBadd3AE)
                           + "," + Utility.ReplaceString(item.DEBtel)
                           + "," + Utility.ReplaceString(item.DEBtaxnos)
                           + "," + Utility.ReplaceString(item.DEBzone)
                           + "," + Utility.ReplaceString(item.DEBgrade)
                           + "," + item.DEBlimit
                           + "," + item.DEBtaxclass
                           + "," + item.DEBgoodsDef
                           + "," + item.DEBcreditTerm
                           + "," + item.DEBpaytype
                           + "," + item.DEBpayday
                           + "," + item.DEBpayOn1
                           + "," + item.DEBpayOn2
                           + "," + item.DEBpayOn3
                           + "," + item.DEBpayOn4
                           + "," + item.DEBpayOn5
                           + "," + item.DEBpayN1
                           + "," + item.DEBpayN2
                           + "," + item.DEBbgrtype
                           + "," + 0//Utility.FormateDate(item.DEBbgrday)
                           + "," + item.DEBbgrOn1
                           + "," + item.DEBbgrOn2
                           + "," + item.DEBbgrOn3
                           + "," + item.DEBbgrOn4
                           + "," + item.DEBbgrOn5
                           + "," + Utility.FormateDate(item.DEBdate)
                           + "," + item.DEBhide
                           + "," + Utility.ReplaceString(item.DEBfax)
                           + "," + Utility.ReplaceString(item.DEBemail)
                           + "," + item.DEBtarget
                           + "," + Utility.ReplaceString(item.DEBmemo)
                           + "," + Utility.ReplaceString(item.DEBac)
                           + "," + (item.DEBlock=="true" ? 1 :0)
                           + "," + Utility.ReplaceString(item.DEBoName)
                           + "," + Utility.ReplaceString(item.DEBprice)
                           + "," + item.DEBbillAD
                           + "," + Utility.ReplaceString(item.DEBsortNT)
                           + "," + Utility.ReplaceString(item.DEBsortNE)
                           + "," + Utility.FormateDate(DateTime.Now)
                           + "," + Utility.ReplaceString(item.DEBsalesP)
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

        public void UpdateDEB(DEB item)
        {
            if (!Utility.IsDate(item.DEBdate))
            {
                item.DEBdate = null;
            }

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @" Update [dbo].[DEB]
                                   Set [DEBcode] ={1}
                                   ,[DEBgroup]={2}
                                   ,[DEBnameT]={3}
                                   ,[DEBnameE]={4}
                                   ,[DEBcontactT]={5}
                                   ,[DEBcontactE]={6}
                                   ,[DEBadd1AT]={7}
                                   ,[DEBadd2AT]={8}
                                   ,[DEBadd3AT]={9}
                                   ,[DEBadd1AE]={10}
                                   ,[DEBadd2AE]={11}
                                   ,[DEBadd3AE]={12}
                                   ,[DEBtel]={13}
                                   ,[DEBtaxnos]={14}
                                   ,[DEBzone]={15}
                                   ,[DEBgrade]={16}
                                   ,[DEBlimit]={17}
                                   ,[DEBtaxclass]={18}
                                   ,[DEBgoodsDef]={19}
                                   ,[DEBcreditTerm]={20}
                                   ,[DEBpaytype]={21}
                                   ,[DEBpayday]={22}
                                   ,[DEBpayOn1]={23}
                                   ,[DEBpayOn2]={24}
                                   ,[DEBpayOn3]={25}
                                   ,[DEBpayOn4]={26}
                                   ,[DEBpayOn5]={27}
                                   ,[DEBpayN1]={28}
                                   ,[DEBpayN2]={29}
                                   ,[DEBbgrtype]={30}
                                   ,[DEBbgrday]={31}
                                   ,[DEBbgrOn1]={32}
                                   ,[DEBbgrOn2]={33}
                                   ,[DEBbgrOn3]={34}
                                   ,[DEBbgrOn4]={35}
                                   ,[DEBbgrOn5]={36}
                                   ,[DEBdate]={37}
                                   ,[DEBhide]={38}
                                   ,[DEBfax]={39}
                                   ,[DEBemail]={40}
                                   ,[DEBtarget]={41}
                                   ,[DEBmemo]={42}
                                   ,[DEBac]={43}
                                   ,[DEBlock]={44}
                                   ,[DEBoName]={45}
                                   ,[DEBprice]={46}
                                   ,[DEBbillAD]={47}
                                   ,[DEBsortNT]={48}
                                   ,[DEBsortNE]={49}
                                   ,[DEBeditDT]={50}
                                   ,[DEBsalesP]={51} 
                                where  DEBid={0} ";

                strSQL = string.Format(strSQL,
                     item.DEBid
                   , Utility.ReplaceString(item.DEBcode)
                   , Utility.ReplaceString(item.DEBgroup)
                   , Utility.ReplaceString(item.DEBnameT)
                   , Utility.ReplaceString(item.DEBnameE)
                   , Utility.ReplaceString(item.DEBcontactT)
                   , Utility.ReplaceString(item.DEBcontactE)
                   , Utility.ReplaceString(item.DEBadd1AT)
                   , Utility.ReplaceString(item.DEBadd2AT)
                   , Utility.ReplaceString(item.DEBadd3AT)
                   , Utility.ReplaceString(item.DEBadd1AE)
                   , Utility.ReplaceString(item.DEBadd2AE)
                   , Utility.ReplaceString(item.DEBadd3AE)
                   , Utility.ReplaceString(item.DEBtel)
                   , Utility.ReplaceString(item.DEBtaxnos)
                   , Utility.ReplaceString(item.DEBzone)
                   , Utility.ReplaceString(item.DEBgrade)
                   , item.DEBlimit
                   , item.DEBtaxclass
                   , item.DEBgoodsDef
                   , item.DEBcreditTerm
                   , item.DEBpaytype
                   , item.DEBpayday
                   , item.DEBpayOn1
                   , item.DEBpayOn2
                   , item.DEBpayOn3
                   , item.DEBpayOn4
                   , item.DEBpayOn5
                   , item.DEBpayN1
                   , item.DEBpayN2
                   , item.DEBbgrtype
                   , 0//Utility.FormateDate(item.DEBbgrday)
                   , item.DEBbgrOn1
                   , item.DEBbgrOn2
                   , item.DEBbgrOn3
                   , item.DEBbgrOn4
                   , item.DEBbgrOn5
                   , Utility.FormateDate(item.DEBdate)
                   , item.DEBhide
                   , Utility.ReplaceString(item.DEBfax)
                   , Utility.ReplaceString(item.DEBemail)
                   , item.DEBtarget
                   , Utility.ReplaceString(item.DEBmemo)
                   , Utility.ReplaceString(item.DEBac)
                   , (item.DEBlock == "true" ? 1 : 0)
                   , Utility.ReplaceString(item.DEBoName)
                   , Utility.ReplaceString(item.DEBprice)
                   , item.DEBbillAD
                   , Utility.ReplaceString(item.DEBsortNT)
                   , Utility.ReplaceString(item.DEBsortNE)
                   , Utility.FormateDate(DateTime.Now)
                   , Utility.ReplaceString(item.DEBsalesP)
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

        public void DeleteDEB(DEB stg)
        {

            SqlConnection objConn = DBHelper.ConnectDb(ref msgErr);
            try
            {
                string strSQL = @"Delete  From [dbo].[DEB]
                                    where DEBid={0}";

                strSQL = string.Format(strSQL
                    , stg.DEBid);

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