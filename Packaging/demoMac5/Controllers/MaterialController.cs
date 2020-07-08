using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class MaterialController : Controller
    {
        
        #region ========== MPlastic ============
        // \Material/GetMPlastic/id
        public JsonResult GetMPlastic(int id)
        {

            try
            {
                MaterialData item = new MaterialData();
                List<MPlastic> ls = new List<MPlastic>();
                item.GetMPlastic(out ls, id);

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
        // \Material/InsertMPlastic
        [HttpPost]
        public JsonResult InsertMPlastic(MPlastic item)
        {

            try
            {

                if (Session["iuserid"] != null) {
                    item.Plastic_CreateUser = Convert.ToInt32( Session["iuserid"]);
                }

                bool iExist = Library.CheckExistCode("M_PLASTIC", item.Plastic_Id, item.Plastic_Code);

                if (iExist)
                {
                    throw new Exception("รหัสเม็ดพลาสติกซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                MaterialData data = new MaterialData();
                //int i = Utility.GetCheckUniqe(
                //      " [dbo].[M_PLASTIC] ",
                //      " Plastic_Code ",
                //      " and Plastic_Code=" + Utility.ReplaceString(item.Plastic_Code));

                //if (i == 0)
                //{


                    data.InsertMPlastic(item);
                    return Json(new
                    {
                        data = "เพิ่มข้อมูลสำเร็จ !!!",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    throw new Exception(" รหัสเม็ดพลาสติก " + item.Plastic_Code + "  ซ้ำ !!!");
                  
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
        // \Material/UpdateMPlastic
        [HttpPost]
        public JsonResult UpdateMPlastic(MPlastic item)
        {

            try
            {
                MaterialData data = new MaterialData();              
                bool iExist = Library.CheckExistCode("M_PLASTIC", item.Plastic_Id, item.Plastic_Code);

                if (iExist)
                {
                    throw new Exception("รหัสเม็ดพลาสติกซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                data.UpdateMPlastic(item);
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

        // \Material/DeleteMPlastic
        [HttpPost]
        public JsonResult DeleteMPlastic(MPlastic item)
        {

            try
            {
                MaterialData data = new MaterialData();
                data.DeleteMPlastic(item);

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

        #endregion ========== MPlastic ============



        #region MPrint 
        // \Material/GetMPrint
        public JsonResult GetMPrint( int id)
        {

            try
            {
                MaterialData item = new MaterialData();
                List<MPrint> ls = new List<MPrint>();
                item.GetMPrint(out ls, id);

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


        // \Material/InsertMPrint
        [HttpPost]
        public JsonResult InsertMPrint(MPrint item)
        {

            try
            {

                MaterialData data = new MaterialData();
                //int i = Utility.GetCheckUniqe(
                //      " [dbo].[M_PRINT] ",
                //      " Print_Code ",
                //      " and Print_Code=" + Utility.ReplaceString(item.Print_Code));

                //if (i == 0)
                //{

                bool iExist = Library.CheckExistCode("M_PRINT", item.Print_Id, item.Print_Code);

                if (iExist)
                {
                    throw new Exception("รหัสงานพิมพ์ซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }


                data.InsertMPrint(item);
                    return Json(new
                    {
                        data = "เพิ่มข้อมูลสำเร็จ !!!",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
                //}
                //  else
                //{
                //    throw new Exception(" รหัสงานพิมพ์ " + item.Print_Code + "  ซ้ำ !!!");

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
        // \Material/UpdateMPrint
        [HttpPost]
        public JsonResult UpdateMPrint(MPrint item)
        {

            try
            {
                MaterialData data = new MaterialData();

                bool iExist = Library.CheckExistCode("M_PRINT", item.Print_Id, item.Print_Code);

                if (iExist)
                {
                    throw new Exception("รหัสงานพิมพ์ซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }


                data.UpdateMPrint(item);
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

        // \Material/DeleteMPrint
        [HttpPost]
        public JsonResult DeleteMPrint(MPrint item)
        {

            try
            {
                MaterialData data = new MaterialData();
                data.DeleteMPrint(item);

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

        #endregion MPrint




        #region MEquipment 
        // \Material/GetMEquipment
        public JsonResult GetMEquipment(int id)
        {

            try
            {
                MaterialData item = new MaterialData();
                List<MEquipment> ls = new List<MEquipment>();
                item.GetMEquipment(out ls, id);

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


        // \Material/InsertMEquipment
        [HttpPost]
        public JsonResult InsertMEquipment(MEquipment item)
        {

            try
            {
                MaterialData data = new MaterialData();
                bool iExist = Library.CheckExistCode("M_EQUIPMENT", item.Equipment_Id, item.Equipment_Code);

                if (iExist)
                {
                    throw new Exception("รหัสอุปกรณ์ซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }
                //int i =  Utility.GetCheckUniqe(
                //      " [dbo].[M_EQUIPMENT] ",
                //      " Equipment_Code ",
                //      " and Equipment_Code=" + Utility.ReplaceString(item.Equipment_Code));

                //  if (i == 0)
                //  {

                data.InsertMEquipment(item);
                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
                    success = true
                }, JsonRequestBehavior.AllowGet);
                //}
                //else {
                //    throw new Exception(" รหัสอุปกรณ์  " + item.Equipment_Code + "  ซ้ำ !!!");
                    
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
        // \Material/UpdateMMEquipment
        [HttpPost]
        public JsonResult UpdateMEquipment(MEquipment item)
        {

            try
            {
                MaterialData data = new MaterialData();

                bool iExist = Library.CheckExistCode("M_EQUIPMENT", item.Equipment_Id, item.Equipment_Code);

                if (iExist)
                {
                    throw new Exception("รหัสอุปกรณ์ซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }
                data.UpdateMEquipment(item);

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

        // \Material/DeleteMEquipment
        [HttpPost]
        public JsonResult DeleteMEquipment(MEquipment item)
        {

            try
            {
                MaterialData data = new MaterialData();
                data.DeleteMEquipment(item);

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

        #endregion MEquipment


    }
}