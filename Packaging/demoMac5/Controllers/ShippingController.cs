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
    public class ShippingController : Controller
    {
        
        #region SHIPPING_HEADER 
        // \Shipping/GetSHIPPING_HEADER/0
        public JsonResult GetSHIPPING_HEADER(int id)
        {

            try
            {
                ShippingHeaderData item = new ShippingHeaderData();
                List<SHIPPING_HEADER> ls = new List<SHIPPING_HEADER>();
                item.GetShippingHeader(out ls, id);

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


        // \Shipping/InsertSHIPPING_HEADER
        [HttpPost]
        public JsonResult InsertSHIPPING_HEADER(SHIPPING_HEADER item)
        {

            try
            {
                item.Shipping_DateStart = DateTime.ParseExact(item.Shipping_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Shipping_DateEnd = DateTime.ParseExact(item.Shipping_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ShippingHeaderData data = new ShippingHeaderData();
                data.InsertShippingHeader(item);

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
        // \Shipping/UpdateSHIPPING_HEADER
        [HttpPost]
        public JsonResult UpdateSHIPPING_HEADER(SHIPPING_HEADER item)
        {

            try
            {
                item.Shipping_DateStart = DateTime.ParseExact(item.Shipping_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Shipping_DateEnd = DateTime.ParseExact(item.Shipping_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ShippingHeaderData data = new ShippingHeaderData();
                data.UpdateShippingHeader(item);

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

        // \Shipping/DeleteSHIPPING_HEADER
        [HttpPost]
        public JsonResult DeleteSHIPPING_HEADER(SHIPPING_HEADER item)
        {

            try
            {
                ShippingHeaderData data = new ShippingHeaderData();
                data.DeleteShippingHeader(item);

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

        #endregion SHIPPING_HEADER



        #region SHIPPING_DETAIL 
        // \Shipping/GetSHIPPING_DETAIL/0
        public JsonResult GetSHIPPING_DETAIL(int id)
        {

            try
            {
                ShippingDetailData item = new ShippingDetailData();
                List<SHIPPING_DETAIL> ls = new List<SHIPPING_DETAIL>();
                item.GetShippingDetail(out ls, id);

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


        // \Shipping/InsertSHIPPING_DETAIL
        [HttpPost]
        public JsonResult InsertSHIPPING_DETAIL(SHIPPING_DETAIL item)
        {

            try
            {

                ShippingDetailData data = new ShippingDetailData();
                data.InsertShippingDetail(item);

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
        // \Shipping/UpdateSHIPPING_DETAIL
        [HttpPost]
        public JsonResult UpdateSHIPPING_DETAIL(SHIPPING_DETAIL item)
        {

            try
            {
                ShippingDetailData data = new ShippingDetailData();
                data.UpdateShippingDetail(item);

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

        // \Shipping/DeleteSHIPPING_DETAIL
        [HttpPost]
        public JsonResult DeleteSHIPPING_DETAIL(SHIPPING_DETAIL item)
        {

            try
            {
                ShippingDetailData data = new ShippingDetailData();
                data.DeleteShippingDetail(item);

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

        #endregion SHIPPING_DETAIL
    }
}