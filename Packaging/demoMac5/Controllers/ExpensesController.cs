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
    public class ExpensesController : Controller
    {
        
        #region EXPENSES_HEADER 
        // \Expenses/GetEXPENSES_HEADER/0
        public JsonResult GetEXPENSES_HEADER(int id)
        {

            try
            {
                ExpensesHeaderData item = new ExpensesHeaderData();
                List<EXPENSES_HEADER> ls = new List<EXPENSES_HEADER>();
                item.GetExpensesHeader(out ls, id);

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


        // \Expenses/InsertEXPENSES_HEADER
        [HttpPost]
        public JsonResult InsertEXPENSES_HEADER(EXPENSES_HEADER item)
        {

            try
            {
                item.Expenses_DateStart = DateTime.ParseExact(item.Expenses_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Expenses_DateEnd = DateTime.ParseExact(item.Expenses_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ExpensesHeaderData data = new ExpensesHeaderData();
                data.InsertExpensesHeader(item);

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
        // \Expenses/UpdateEXPENSES_HEADER
        [HttpPost]
        public JsonResult UpdateEXPENSES_HEADER(EXPENSES_HEADER item)
        {

            try
            {
                item.Expenses_DateStart = DateTime.ParseExact(item.Expenses_DateStart_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                item.Expenses_DateEnd = DateTime.ParseExact(item.Expenses_DateEnd_Input, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                ExpensesHeaderData data = new ExpensesHeaderData();
                data.UpdateExpensesHeader(item);

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

        // \Expenses/DeleteEXPENSES_HEADER
        [HttpPost]
        public JsonResult DeleteEXPENSES_HEADER(EXPENSES_HEADER item)
        {

            try
            {
                ExpensesHeaderData data = new ExpensesHeaderData();
                data.DeleteExpensesHeader(item);

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

        #endregion EXPENSES_HEADER

        #region EXPENSES_DETAIL 
        // \Expenses/GetEXPENSES_DETAIL/0
        public JsonResult GetEXPENSES_DETAIL(int id)
        {

            try
            {
                ExpensesDetailData item = new ExpensesDetailData();
                List<EXPENSES_DETAIL> ls = new List<EXPENSES_DETAIL>();
                item.GetExpensesDetail(out ls, id);

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


        // \Expenses/InsertEXPENSES_DETAIL
        [HttpPost]
        public JsonResult InsertEXPENSES_DETAIL(EXPENSES_DETAIL item)
        {

            try
            {
                ExpensesDetailData data = new ExpensesDetailData();
                data.InsertExpensesDetail(item);

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
        // \Expenses/UpdateEXPENSES_DETAIL
        [HttpPost]
        public JsonResult UpdateEXPENSES_DETAIL(EXPENSES_DETAIL item)
        {

            try
            {
                
                ExpensesDetailData data = new ExpensesDetailData();
                data.UpdateExpensesDetail(item);

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

        // \Expenses/DeleteEXPENSES_DETAIL
        [HttpPost]
        public JsonResult DeleteEXPENSES_DETAIL(EXPENSES_DETAIL item)
        {

            try
            {
                ExpensesDetailData data = new ExpensesDetailData();
                data.DeleteExpensesDetail(item);

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

        #endregion EXPENSES_DETAIL

    }
}