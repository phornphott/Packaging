using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class CostController : Controller
    {
        
        #region COST_HEADER 
        // \Cost/GetCOST_HEADER/0
        public JsonResult GetCOST_HEADER(int id)
        {

            try
            {
                CostHeaderData item = new CostHeaderData();
                List<COST_HEADER> ls = new List<COST_HEADER>();
                item.GetCostHeader(out ls, id);

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


        // \Cost/InsertCOST_HEADER
        [HttpPost]
        public JsonResult InsertCOST_HEADER(COST_HEADER item)
        {

            try
            {
                item.Cost_DateStart = DateTime.ParseExact(item.Cost_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Cost_DateEnd = DateTime.ParseExact(item.Cost_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                CostHeaderData data = new CostHeaderData();
                data.InsertCostHeader(item);

                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
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
        // \Cost/UpdateCOST_HEADER
        [HttpPost]
        public JsonResult UpdateCOST_HEADER(COST_HEADER item)
        {

            try
            {
                item.Cost_DateStart = DateTime.ParseExact(item.Cost_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Cost_DateEnd = DateTime.ParseExact(item.Cost_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                CostHeaderData data = new CostHeaderData();
                data.UpdateCostHeader(item);

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

        // \Cost/DeleteCOST_HEADER
        [HttpPost]
        public JsonResult DeleteCOST_HEADER(COST_HEADER item)
        {

            try
            {
                CostHeaderData data = new CostHeaderData();
                data.DeleteCostHeader(item);

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

        #endregion COST_HEADER

        #region COST_PLASTIC 
        // \Cost/GetCOST_PLASTIC/0
        public JsonResult GetCOST_PLASTIC(int id)
        {

            try
            {
                CostPlasticData item = new CostPlasticData();
                List<COST_PLASTIC> ls = new List<COST_PLASTIC>();
                item.GetCostPlastic(out ls, id);

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


        // \Cost/InsertCOST_PLASTIC
        [HttpPost]
        public JsonResult InsertCOSTHEADER(COST_PLASTIC item)
        {

            try
            {
                CostPlasticData data = new CostPlasticData();
                data.InsertCostPlastic(item);

                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
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
        // \Cost/UpdateCOST_PLASTIC
        [HttpPost]
        public JsonResult UpdateCOST_PLASTIC(COST_PLASTIC item)
        {

            try
            {
                CostPlasticData data = new CostPlasticData();
                data.UpdateCostPlastic(item);

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

        // \Cost/DeleteCOST_PLASTIC
        [HttpPost]
        public JsonResult DeleteCOST_PLASTIC(COST_PLASTIC item)
        {

            try
            {
                CostPlasticData data = new CostPlasticData();
                data.DeleteCostPlastic(item);

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

        #endregion COST_PLASTIC



        #region COST_PRINT_ADD1 
        // \Cost/GetCOST_PRINT_ADD1/0
        public JsonResult GetCOST_PRINT_ADD1(int id)
        {

            try
            {
                CostPrintAdd1Data item = new CostPrintAdd1Data();
                List<COST_PRINT_ADD1> ls = new List<COST_PRINT_ADD1>();
                item.GetCostPrintAdd1(out ls, id);

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


        // \Cost/InsertCOST_PRINT_ADD1
        [HttpPost]
        public JsonResult InsertCOST_PRINT_ADD1(COST_PRINT_ADD1 item)
        {

            try
            {
                CostPrintAdd1Data data = new CostPrintAdd1Data();
                data.InsertCostPrintAdd1(item);

                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
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
        // \Cost/UpdateCOST_PRINT_ADD1
        [HttpPost]
        public JsonResult UpdateCOST_PRINT_ADD1(COST_PRINT_ADD1 item)
        {

            try
            {
                CostPrintAdd1Data data = new CostPrintAdd1Data();
                data.UpdateCostPrintAdd1(item);

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

        // \Cost/DeleteCOST_PRINT_ADD1
        [HttpPost]
        public JsonResult DeleteCOST_PRINT_ADD1(COST_PRINT_ADD1 item)
        {

            try
            {
                CostPrintAdd1Data data = new CostPrintAdd1Data();
                data.DeleteCostPrintAdd1(item);

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

        #endregion COST_PRINT_ADD1

        #region COST_PRINT_ADD2 
        // \Cost/GetCOST_PRINT_ADD2/0
        public JsonResult GetCOST_PRINT_ADD2(int id)
        {

            try
            {
                CostPrintAdd2Data item = new CostPrintAdd2Data();
                List<COST_PRINT_ADD2> ls = new List<COST_PRINT_ADD2>();
                item.GetCostPrintAdd2(out ls, id);

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


        // \Cost/InsertCOST_PRINT_ADD2
        [HttpPost]
        public JsonResult InsertCOST_PRINT_ADD2(COST_PRINT_ADD2 item)
        {

            try
            {
                CostPrintAdd2Data data = new CostPrintAdd2Data();
                data.InsertCostPrintAdd2(item);

                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
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
        // \Cost/UpdateCOST_PRINT_ADD2
        [HttpPost]
        public JsonResult UpdateCOST_PRINT_ADD2(COST_PRINT_ADD2 item)
        {

            try
            {
                CostPrintAdd2Data data = new CostPrintAdd2Data();
                data.UpdateCostPrintAdd2(item);

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

        // \Cost/DeleteCOST_PRINT_ADD2
        [HttpPost]
        public JsonResult DeleteCOST_PRINT_ADD2(COST_PRINT_ADD2 item)
        {

            try
            {
                CostPrintAdd2Data data = new CostPrintAdd2Data();
                data.DeleteCostPrintAdd2(item);

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

        #endregion COST_PRINT_ADD2

        #region COST_EQUIPMENT 
        // \Cost/GetCOST_EQUIPMENT/0
        public JsonResult GetCOST_EQUIPMENT(int id)
        {

            try
            {
                CostEquipmentData item = new CostEquipmentData();
                List<COST_EQUIPMENT> ls = new List<COST_EQUIPMENT>();
                item.GetCostEquipment(out ls, id);

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


        // \Cost/InsertCOST_EQUIPMENT
        [HttpPost]
        public JsonResult InsertCOST_EQUIPMENT(COST_EQUIPMENT item)
        {

            try
            {
                CostEquipmentData data = new CostEquipmentData();
                data.InsertCostEquipment(item);

                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
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
        // \Cost/UpdateCOST_EQUIPMENT
        [HttpPost]
        public JsonResult UpdateCOST_EQUIPMENT(COST_EQUIPMENT item)
        {

            try
            {
                CostEquipmentData data = new CostEquipmentData();
                data.UpdateCostEquipment(item);

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

        // \Cost/DeleteCOST_EQUIPMENT
        [HttpPost]
        public JsonResult DeleteCOST_EQUIPMENT(COST_EQUIPMENT item)
        {

            try
            {
                CostEquipmentData data = new CostEquipmentData();
                data.DeleteCostEquipment(item);

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

        #endregion COST_EQUIPMENT

        #region COST_PRINT 
        // \Cost/GetCOST_PRINT/0
        public JsonResult GetCOST_PRINT(int id)
        {

            try
            {
                CostPrintData item = new CostPrintData();
                List<COST_PRINT> ls = new List<COST_PRINT>();
                item.GetCostPrint(out ls, id);

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


        // \Cost/InsertCOST_PRINT
        [HttpPost]
        public JsonResult InsertCOST_PRINT(COST_PRINT item)
        {

            try
            {
                CostPrintData data = new CostPrintData();
                data.InsertCostPrint(item);

                return Json(new
                {
                    data = "เพิ่มข้อมูลสำเร็จ !!!",
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
        // \Cost/UpdateCOST_PRINT
        [HttpPost]
        public JsonResult UpdateCOST_PRINT(COST_PRINT item)
        {

            try
            {
                CostPrintData data = new CostPrintData();
                data.UpdateCostPrint(item);

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

        // \Cost/DeleteCOST_PRINT
        [HttpPost]
        public JsonResult DeleteCOST_PRINT(COST_PRINT item)
        {

            try
            {
                CostPrintData data = new CostPrintData();
                data.DeleteCostPrint(item);

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

        #endregion COST_PRINT
    }
}