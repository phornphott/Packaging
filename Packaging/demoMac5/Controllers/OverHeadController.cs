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
    public class OverHeadController : Controller
    {
        
        #region OVERHEAD_HEADER 
        // \Overhead/GetOVERHEAD_HEADER/0
        public JsonResult GetOVERHEAD_HEADER(int id)
        {

            try
            {
                OverHeadHeaderData item = new OverHeadHeaderData();
                List<OVERHEAD_HEADER> ls = new List<OVERHEAD_HEADER>();
                item.GetOverheadHeader(out ls, id);

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


        // \Overhead/InsertOVERHEAD_HEADER
        [HttpPost]
        public JsonResult InsertOVERHEAD_HEADER(OVERHEAD_HEADER item)
        {

            try
            {
                item.Overhead_DateStart = DateTime.ParseExact(item.Overhead_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Overhead_DateEnd = DateTime.ParseExact(item.Overhead_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                OverHeadHeaderData data = new OverHeadHeaderData();
                data.InsertOverheadHeader(item);

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
        // \Overhead/UpdateOVERHEAD_HEADER
        [HttpPost]
        public JsonResult UpdateOVERHEAD_HEADER(OVERHEAD_HEADER item)
        {

            try
            {
                item.Overhead_DateStart = DateTime.ParseExact(item.Overhead_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Overhead_DateEnd = DateTime.ParseExact(item.Overhead_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                OverHeadHeaderData data = new OverHeadHeaderData();
                data.UpdateOverheadHeader(item);

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

        // \Overhead/DeleteOVERHEAD_HEADER
        [HttpPost]
        public JsonResult DeleteOVERHEAD_HEADER(OVERHEAD_HEADER item)
        {

            try
            {
                OverHeadHeaderData data = new OverHeadHeaderData();
                data.DeleteOverheadHeader(item);

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

        #endregion OVERHEAD_HEADER


        #region OVERHEAD_DETAIL 
        // \Overhead/OVERHEAD_DETAIL/0
        public JsonResult GetOVERHEAD_DETAIL(int id)
        {

            try
            {
                OverheadDetailData item = new OverheadDetailData();
                List<OVERHEAD_DETAIL> ls = new List<OVERHEAD_DETAIL>();
                item.GetOverheadDetail(out ls, id);

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


        // \Overhead/InsertOVERHEAD_DETAIL
        [HttpPost]
        public JsonResult InsertOVERHEAD_DETAIL(OVERHEAD_DETAIL item)
        {

            try
            {
                OverheadDetailData data = new OverheadDetailData();
                data.InsertOverheadDetail(item);

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
        // \Overhead/UpdateOVERHEAD_DETAIL
        [HttpPost]
        public JsonResult UpdateOVERHEAD_DETAIL(OVERHEAD_DETAIL item)
        {

            try
            {
                OverheadDetailData data = new OverheadDetailData();
                data.UpdateOverheadDetail(item);

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

        // \Overhead/DeleteOVERHEAD_DETAIL
        [HttpPost]
        public JsonResult DeleteOVERHEAD_DETAIL(OVERHEAD_DETAIL item)
        {

            try
            {
                OverheadDetailData data = new OverheadDetailData();
                data.DeleteOverheadDetail(item);

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

        #endregion OVERHEAD_DETAIL
    }
}