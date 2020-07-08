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
    public class SewingController : Controller
    {
        
        #region SEWING_HEADER 
        // \Sewing/GetSEWING_HEADER/0
        public JsonResult GetSEWING_HEADER(int id)
        {

            try
            {
                SweingHeaderData item = new SweingHeaderData();
                List<SEWING_HEADER> ls = new List<SEWING_HEADER>();
                item.GetSweingHeader(out ls, id);

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


        // \Sewing/InsertSEWING_HEADER
        [HttpPost]
        public JsonResult InsertSEWING_HEADER(SEWING_HEADER item)
        {

            try
            {
                item.Sewing_DateStart = DateTime.ParseExact(item.Sewing_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Sewing_DateEnd = DateTime.ParseExact(item.Sewing_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                SweingHeaderData data = new SweingHeaderData();
                data.InsertSweingHeader(item);

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
        // \Sewing/UpdateSEWING_HEADER
        [HttpPost]
        public JsonResult UpdateSEWING_HEADER(SEWING_HEADER item)
        {

            try
            {
                item.Sewing_DateStart = DateTime.ParseExact(item.Sewing_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Sewing_DateEnd = DateTime.ParseExact(item.Sewing_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                SweingHeaderData data = new SweingHeaderData();
                data.UpdateSweingHeader(item);

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

        // \Sewing/DeleteSEWING_HEADER
        [HttpPost]
        public JsonResult DeleteSEWING_HEADER(SEWING_HEADER item)
        {

            try
            {
                SweingHeaderData data = new SweingHeaderData();
                data.DeleteSweingHeader(item);

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

        #endregion SEWING_HEADER


        #region SEWING_DETAIL
        // \Sewing/GetSEWING_DETAIL/0
        public JsonResult GetSEWING_DETAIL(int id)
        {

            try
            {
                SweingDetailData item = new SweingDetailData();
                List<SEWING_DETAIL> ls = new List<SEWING_DETAIL>();
                item.GetSweingDetail(out ls, id);

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


        // \Sewing/InsertSEWING_DETAIL
        [HttpPost]
        public JsonResult InsertSEWING_DETAIL(SEWING_DETAIL item)
        {

            try
            {
                SweingDetailData data = new SweingDetailData();
                data.InsertSweingDetail(item);

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
        // \Sewing/UpdateSEWING_DETAIL
        [HttpPost]
        public JsonResult UpdateSEWING_DETAIL(SEWING_DETAIL item)
        {

            try
            {
                SweingDetailData data = new SweingDetailData();
                data.UpdateSweingDetail(item);

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

        // \Sewing/DeleteSEWING_DETAIL
        [HttpPost]
        public JsonResult DeleteSEWING_DETAIL(SEWING_DETAIL item)
        {

            try
            {
                SweingDetailData data = new SweingDetailData();
                data.DeleteSweingDetail(item);

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

        #endregion SEWING_DETAIL

        #region SEWING_OTHER
        // \Sewing/GetSEWING_OTHER/0
        public JsonResult GetSEWING_OTHER(int id)
        {

            try
            {
                SweingOtherData item = new SweingOtherData();
                List<SEWING_OTHER> ls = new List<SEWING_OTHER>();
                item.GetSewingOther(out ls, id);

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


        // \Sewing/InsertSEWING_OTHER
        [HttpPost]
        public JsonResult InsertSEWING_OTHER(SEWING_OTHER item)
        {

            try
            {

                SweingOtherData data = new  SweingOtherData();
                data.InsertSewingOther(item);

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
        // \Sewing/UpdateSEWING_OTHER
        [HttpPost]
        public JsonResult UpdateSEWING_OTHER(SEWING_OTHER item)
        {

            try
            {

                SweingOtherData data = new
                SweingOtherData();
                data.UpdateSewingOther(item);

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

        // \Sewing/DeleteSEWING_OTHER
        [HttpPost]
        public JsonResult DeleteSEWING_OTHER(SEWING_OTHER item)
        {

            try
            {
                SweingOtherData data = new SweingOtherData();
                data.DeleteSewingOther(item);

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

        #endregion SEWING_OTHER


    }
}