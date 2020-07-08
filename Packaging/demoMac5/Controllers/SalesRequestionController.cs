using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class SalesRequestionController : Controller
    {

        // POST:\SalesRequestion/PostLoadClipBoard
        public JsonResult PostLoadClipBoard(List<int> a)
        {
            try
            {
                SalesRequestionData item = new SalesRequestionData();
                item.LoadClipBoard(a);

                return Json(new
                {
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
        // GET:\SalesRequestion/GetClipBoard
        public JsonResult GetClipBoard()
        {
            try
            {
                List<ClipBoard> ls = new List<ClipBoard>();
                SalesRequestionData item = new SalesRequestionData();
                item.GetClipBoard(out ls);

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


        // GET:\SalesRequestion/GetSalesRequestion/0
        public JsonResult GetSalesRequestion(int id)
        {
            try
            {
                List<SalesRequestion> ls = new List<SalesRequestion>();
                SalesRequestionData item = new SalesRequestionData();
                item.GetSalesRequestion(out ls, id);

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

    }
}