using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class PurchaseOrderController : Controller
    {
        
        // GET:\PurchaseOrder/GetSalesRequestion
        public JsonResult GetSalesRequestion()
        {
            try
            {
                List<SalesRequestion> ls = new List<SalesRequestion>();
                 PurchaseOrderData item = new PurchaseOrderData();
                item.GetSalesRequest(out ls);

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


        // GET:\PurchaseOrder/GetPurchaseOrder/0
        public JsonResult GetPurchaseOrder(int id)
        {
            try
            {
                List<PurchaseOrder> ls = new List<PurchaseOrder>();
                PurchaseOrderData item = new PurchaseOrderData();
                item.GetPurchaseOrder(out ls, id);

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


        // POST:\PurchaseOrder/PostLoadSalesRequestion
        public JsonResult PostLoadSalesRequestion(List<int> a)
        {
            try
            {
                PurchaseOrderData item = new PurchaseOrderData();
                item.LoadPurchaseOrder(a);

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

    }
}