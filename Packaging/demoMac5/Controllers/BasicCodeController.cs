using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class BasicCodeController : Controller
    {
        
        #region --- STG ----

        // \BasicCode/GetSTG/id
        public JsonResult GetSTG(int id)
        {
            
            try
            {
                ProductData stg = new ProductData();
                List<STG> ls = new List<STG>();
                stg.GetSTG(out ls,id);

                return Json(new
                {
                    data = ls,
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //\BasicCode/InsertSTG
        [HttpPost]
        public JsonResult InsertSTG(STG item)
        {

            try
            {
                ProductData stg = new ProductData();
                bool iExist = Library.CheckExistCode("STG", item.STGid, item.STGcode);
                if (iExist)
                {
                    throw new Exception("รหัสกลุ่มสินค้าซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stg.InsertSTG(item);
                
                return Json(new
                {
                    data = "เพิ่มกลุ่มสินค้าสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        //\BasicCode/UpdateSTG
        [HttpPost]
        public JsonResult UpdateSTG(STG item)
        {

            try
            {
                ProductData stg = new ProductData();
                bool iExist = Library.CheckExistCode("STG", item.STGid, item.STGcode);

                if (iExist)
                {
                    throw new Exception("รหัสกลุ่มสินค้าซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stg.UpdateSTG(item);

                return Json(new
                {
                    data = "แก้ไขกลุ่มสินค้าสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //\BasicCode/DeleteSTG
        [HttpPost]
        public JsonResult DeleteSTG(STG item)
        {

            try
            {
                ProductData stg = new ProductData();
                stg.DeleteSTG(item);

                return Json(new
                {
                    data = "ลบกลุ่มสินค้าสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }





        #endregion  --- STG ----


        #region -- STK -- 

        // \BasicCode/GetSTK/id
        public JsonResult GetSTK(int id)
        {

            try
            {
                
                ProductData stg = new ProductData();
                List<STK> ls = new List<STK>();



                stg.GetSTK(out ls, id);

                return Json(new
                {
                    data = ls,
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        
        [HttpPost]
        public JsonResult InsertSTK(STK item)
        {

            try
            {

                
                ProductData data = new ProductData();

                bool iExist = Library.CheckExistCode("STK", item.STKid, item.STKcode);

                if (iExist)
                {
                    throw new Exception("รหัสสินค้าซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                //int i = Utility.GetCheckUniqe(
                //   " [dbo].[STK] ",
                //   " STKcode ",
                //   " and STKcode=" + Utility.ReplaceString(item.STKcode));

                //if (i == 0)
                //{

                    data.InsertSTK(item);
                    return Json(new
                    {
                        data = "เพิ่มข้อมูลสำเร็จ !!!",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    throw new Exception(" รหัสสินค้า " + item.STKcode + "  ซ้ำ !!!");

                //}
          
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult UpdateSTK(STK item)
        {

            try
            {

                ProductData stk = new ProductData();

                bool iExist = Library.CheckExistCode("STK", item.STKid, item.STKcode);

                if (iExist)
                {
                    throw new Exception("รหัสสินค้าซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stk.UpdateSTK(item);

                return Json(new
                {
                    data ="แก้ไขข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteSTK(STK item)
        {

            try
            {

                ProductData stg = new ProductData();
                stg.DeleteSTK(item);

                return Json(new
                {
                    data = "ลบข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion  -- STK --

        #region --- PER ----

        public JsonResult GetPER(int id) {

            ProcessResult pr = new ProcessResult();
            try
            {
                ProductData stg = new ProductData();


                List<PER> ls = new List<PER>();
                stg.GetPER(out ls, id);

                return Json(new
                {
                    data = ls,
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = pr,
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
           
        }

        [HttpPost]
        public JsonResult InsertPER(PER item)
        {

            try
            {
                string bdate = item.PERbdate_Text;
                int iDay = Convert.ToDateTime(item.PERbdate_Input).Day;
                int iMonth = Convert.ToDateTime(item.PERbdate_Input).Month;
                int iYear = Convert.ToDateTime(item.PERbdate_Input).Year;
                //  item.PEReditLK = DateTime.ParseExact(item.PEReditLK_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.PERbdate = DateTime.ParseExact(item.PERbdate_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.PERworkS = DateTime.ParseExact(item.PERworkS_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (Utility.IsDate(item.PERworkF_Input))
                {
                    item.PERworkF = DateTime.ParseExact(item.PERworkF_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    item.PERworkF = DateTime.MinValue;
                }

                ProductData data = new ProductData();

                int i = Utility.GetCheckUniqe(
                 " [dbo].[PER] ",
                 " PERcode ",
                 " and PERcode=" + Utility.ReplaceString(item.PERcode));

                if (i == 0)
                {


                    data.InsertPER(item);
                    return Json(new
                    {
                        data = "เพิ่มข้อมูลสำเร็จ !!!",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception(" รหัสพนักงาน " + item.PERcode + "  ซ้ำ !!!");

                }

                
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        //\BasicCode/UpdatePER
        [HttpPost]
        public JsonResult UpdatePER(PER item)
        {

            try
            {
                int iDay = Convert.ToDateTime(item.PERbdate_Input).Day;
                int iMonth = Convert.ToDateTime(item.PERbdate_Input).Month;
                int iYear = Convert.ToDateTime(item.PERbdate_Input).Year;

                //  item.PEReditLK = DateTime.ParseExact(item.PEReditLK_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.PERbdate = DateTime.ParseExact(item.PERbdate_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.PERworkS = DateTime.ParseExact(item.PERworkS_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.PERworkF = DateTime.ParseExact(item.PERworkF_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ProductData stg = new ProductData();

                bool iExist = Library.CheckExistCode("PER", item.PERid, item.PERcode);

                if (iExist)
                {
                    throw new Exception("รหัสพนักงานซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stg.UpdatePER(item);

                return Json(new
                {
                    data = "แก้ไขข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //\BasicCode/DeletePER
        [HttpPost]
        public JsonResult DeletePER(PER item)
        {

            try
            {
                ProductData stg = new ProductData();
                stg.DeletePER(item);

                return Json(new
                {
                    data = "ลบข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion  --- PER ----

        #region -- Job -- 
        public JsonResult GetJOB(int id)
        {

            try
            {
                ProductData stg = new ProductData();
                List<JOB> ls = new List<JOB>();
                stg.GetJob(out ls, id);

                return Json(new
                {
                    data = ls,
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //\BasicCode/InsertJOB
        [HttpPost]
        public JsonResult InsertJOB(JOB item)
        {

            try
            {
                ProductData data = new ProductData();
                //int i = Utility.GetCheckUniqe(
                //      " [dbo].[JOB] ",
                //      " JOBcode ",
                //      " and JOBcode=" + Utility.ReplaceString(item.JOBcode));

                //if (i == 0)
                //{
                bool iExist = Library.CheckExistCode("JOB", item.JOBid, item.JOBcode);

                if (iExist)
                {
                    throw new Exception("รหัสงานซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                data.InsertJob(item);

                if (item.JOBautostk_Chk)
                {
                    STK itemSTK = new STK();

                    itemSTK.STKcode = "05" + item.JOBcode.ToUpper();
                    itemSTK.STKdescT1 = item.JOBdescT;
                    itemSTK.STKdescE1 = item.JOBdescE;
                    if (itemSTK.STKdescT1 == null) itemSTK.STKdescT1 = "";
                    if (itemSTK.STKdescE1 == null) itemSTK.STKdescE1 = "";
                    itemSTK.STKsnsv = 1;
                    itemSTK.STKconv1 = 1;
                    itemSTK.STKmax = 0;
                    itemSTK.STKmin = 0;
                    itemSTK.STKqU1 = 1;
                    itemSTK.STKqE1 = 1;
                    itemSTK.STKqN1 = 1;
                    itemSTK.STKhide = 0;
                    itemSTK.STKlock = 0;
                    itemSTK.STKfx = 0;
                    itemSTK.STKvat = 7;
                    itemSTK.STKexpire = 0;
                    itemSTK.STKstatus = 0;
                    itemSTK.STKuname1 = "ใบ";
                    if (itemSTK.STKdescT1.Length >= 60)
                    {
                        itemSTK.STKsortNT = itemSTK.STKdescT1.Substring(0, 60);
                    }
                    else
                    {
                        itemSTK.STKsortNT = itemSTK.STKdescT1;
                    }
                    if (itemSTK.STKdescE1.Length >= 60)
                    {
                        itemSTK.STKsortNE = itemSTK.STKdescE1.Substring(0, 60);
                    }
                    else
                    {
                        itemSTK.STKsortNE = itemSTK.STKdescE1;
                    }
                    data.AutosertSTK(itemSTK);
                }

                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    throw new Exception(" รหัสงาน " + item.JOBcode + "  ซ้ำ !!!");

                //}

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        //\BasicCode/UpdateSTG
        [HttpPost]
        public JsonResult UpdateJOB(JOB item)
        {

            try
            {
                ProductData stg = new ProductData();

                bool iExist = Library.CheckExistCode("JOB", item.JOBid, item.JOBcode);

                if (iExist)
                {
                    throw new Exception("รหัสงานซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stg.UpdateJob(item);

                return Json(new
                {
                    data = "แก้ไขข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //\BasicCode/DeleteJOB
        [HttpPost]
        public JsonResult DeleteJOB(JOB item)
        {

            try
            {
                ProductData stg = new ProductData();
                stg.DeleteJob(item);

                return Json(new
                {
                    data = "ลบข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region --- DEG ----

        // \BasicCode/GetDEG/id
        public JsonResult GetDEG(int id)
        {

            try
            {
                ProductData stg = new ProductData();
                List<DEG> ls = new List<DEG>();
                stg.GetDEG(out ls, id);

                return Json(new
                {
                    data = ls,
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //\BasicCode/InsertDEG
        [HttpPost]
        public JsonResult InsertDEG(DEG item)
        {

            try
            {

                ProductData stg = new ProductData();
                int i = Utility.GetCheckUniqe(
                 " [dbo].[DEG] ",
                 " DEGcode ",
                 " and DEGcode=" + Utility.ReplaceString(item.DEGcode));

                if (i == 0)
                {
                
                    stg.InsertDEG(item);
                    return Json(new
                    {
                        data = "เพิ่มข้อมูลสำเร็จ !!!",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception(" รหัสกลุ่มลูกค้า : " + item.DEGcode.ToUpper() + "  ซ้ำ !!!");

                }
              

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }
        //\BasicCode/UpdateDEG
        [HttpPost]
        public JsonResult UpdateDEG(DEG item)
        {

            try
            {
                ProductData stg = new ProductData();
                stg.UpdateDEG(item);

                return Json(new
                {
                    data = "แก้ไขกลุ่มสินค้าสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //\BasicCode/DeleteDEG
        [HttpPost]
        public JsonResult DeleteDEG(DEG item)
        {

            try
            {
                ProductData stg = new ProductData();
                stg.DeleteDEG(item);

                return Json(new
                {
                    data = "ลบกลุ่มสินค้าสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }





        #endregion  --- STG ----

        #region -- DEB --

        // \BasicCode/GetDEB/id
        public JsonResult GetDEB(int id)
        {

            try
            {
                CustomerData stg = new CustomerData();
                List<DEB> ls = new List<DEB>();
                stg.GetDEB(out ls, id);

                var jsonResult = Json(new
                {
                    data = ls,
                    success = true
                }, JsonRequestBehavior.AllowGet);


                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }


        // \BasicCode/InsertDEB
        [HttpPost]
        public JsonResult InsertDEB(DEB item)
        {

            try
            {
               // item.DEBbgrday = DateTime.ParseExact(item.DEBbgrday_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //item.DEBdate = DateTime.ParseExact(item.DEBdate_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                

                int i = Utility.GetCheckUniqe(
                     " [dbo].[DEB] ",
                     " DEBcode ",
                     " and DEBcode=" + Utility.ReplaceString(item.DEBcode));

                if (i == 0)
                {
                    CustomerData stg = new CustomerData();
                    bool iExist = Library.CheckExistCode("DEB", item.DEBid, item.DEBcode);

                    if (iExist)
                    {
                        throw new Exception("รหัสกลุ่มสินค้าซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                    }
                    stg.InsertDEB(item);
                    return Json(new
                {
                    data = "เพิ่มลูกค้าสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception(" รหัสลูกค้า " + item.DEBcode + "  ซ้ำ !!!");

                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }


        // \BasicCode/UpdateDEB
        [HttpPost]
        public JsonResult UpdateDEB(DEB item)
        {

            try
            {
                // item.DEBbgrday = DateTime.ParseExact(item.DEBbgrday_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //item.DEBdate = DateTime.ParseExact(item.DEBdate_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                CustomerData stg = new CustomerData();
                    stg.UpdateDEB(item);
                    return Json(new
                    {
                        data = "แก้ไขลูกค้าสำเร็จ !!!",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
            
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult DeleteDEB(DEB item)
        {

            try
            {

                CustomerData stg = new CustomerData();
                stg.DeleteDEB(item);

                return Json(new
                {
                    data = "ลบข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message,
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion -- DEB --

    }
}