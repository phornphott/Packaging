using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class UserController : Controller
    {
       

        #region --- User ----

        // \User/GetUSR/id
        public JsonResult GetUSR(int id)
        {

            try
            {
                UserData stg = new UserData();
                List<USR> ls = new List<USR>();
                stg.GetUSR(out ls, id);

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
        //\User/InsertUSR
        [HttpPost]
        public JsonResult InsertUSR(USR item)
        {

            try
            {
                UserData stg = new UserData();
                stg.InsertUSR(item);

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
        //\User/UpdateUSR
        [HttpPost]
        public JsonResult UpdateUSR(USR item)
        {

            try
            {
                UserData stg = new UserData();
                stg.UpdateUSR(item);

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

        //\User/DeleteUSR
        [HttpPost]
        public JsonResult DeleteUSR(USR item)
        {

            try
            {
                UserData stg = new UserData();
                stg.DeleteUSR(item);

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
        #endregion --- User ----


        #region  ---- Permission  ----

        // \User/GetUSM/id
        public JsonResult GetUSM(int id)
        {

            try
            {
                UserData stg = new UserData();
                List<USM> ls = new List<USM>();
                stg.GetUSM(out ls, id);

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
        //\User/InsertUSM
        [HttpPost]
        public JsonResult InsertUSM(USM item)
        {

            try
            {
                UserData stg = new UserData();
                stg.InsertUSM(item);

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
        //\User/UpdateUSM
        [HttpPost]
        public JsonResult UpdateUSM(USM item)
        {

            try
            {
                UserData stg = new UserData();
                stg.UpdateUSM(item);

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

        #endregion   ---- Permission  ----
    }
}