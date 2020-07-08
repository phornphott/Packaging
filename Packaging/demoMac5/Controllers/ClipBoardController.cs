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
    public class ClipBoardController : Controller
    {
        #region --- ClipBoard ----

        // \ClipBoard/GetClipBoard/id
        public JsonResult GetClipBoard(int id)
        {

            try
            {
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard> ls = new List<ClipBoard>();
                stg.GetClipBoard(out ls, id);

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

        public JsonResult GetLastClipBoard(int id)
        {

            try
            {
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard> ls = new List<ClipBoard>();
                stg.GetLastClipBoard(out ls, id);

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

        //\ClipBoard/InsertClipBoard
        [HttpPost]
        public JsonResult InsertClipBoard(ClipBoard item)
        {

            try
            {
                ClipBoardData stg = new ClipBoardData();
                stg.InsertClipboard(item);

                return Json(new
                {
                    data = "เพิ่มกระดาษทดสำเร็จ !!!",
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

        //\ClipBoard/UpdateClipBoard
        [HttpPost]
        public JsonResult UpdateClipBoard(ClipBoard item)
        {

            try
            {
                ClipBoardData stg = new ClipBoardData();
                stg.UpdateClipboard(item);

                return Json(new
                {
                    data = "บันทึกกระดาษทดเรียบร้อยแล้ว !!!",
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


        // \ClipBoard/GetClipBoard/id
        public JsonResult RecalculateClipBoard(ClipBoard item)
        {

            try
            {
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard> ls = new List<ClipBoard>();
                stg.RecalculateClipBoard(out ls, item.Clipboard_Date, item.Delivery_Id);

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
        #endregion

        #region --- Get Code Clipboard ---
        public JsonResult GetAllCodeHandle(ClipBoard item)
        {
            ObjClipBoard objClip = new ObjClipBoard();
            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard_Handle> ls = new List<ClipBoard_Handle>();
                List<ClipBoard_Tag> lsTag = new List<ClipBoard_Tag>();
                List<ClipBoard_Sewing> lsSewing = new List<ClipBoard_Sewing>();
                List<ClipBoard_Eyelet> lsEyelet = new List<ClipBoard_Eyelet>();
                List<ClipBoard_Bell> lsBell = new List<ClipBoard_Bell>();
                List<ClipBoard_Bagin2> lsBagin2 = new List<ClipBoard_Bagin2>();
                stg.GetCodeHandleClipBoard(out ls, item.Clipboard_Date);
                stg.GetCodeTagClipBoard(out lsTag, item.Clipboard_Date);
                stg.GetCodeSewingClipBoard(out lsSewing, item.Clipboard_Date);
                stg.GetCodeEyeletClipBoard(out lsEyelet, item.Clipboard_Date);
                stg.GetCodeBellClipBoard(out lsBell, item.Clipboard_Date);
                stg.GetCodeBagin2ClipBoard(out lsBagin2, item.Clipboard_Date);

                objClip.ListBagin2 = lsBagin2;
                objClip.ListBell = lsBell;
                objClip.ListEyelet = lsEyelet;
                objClip.ListHandle = ls;
                objClip.ListSewing = lsSewing;
                objClip.ListTag = lsTag;

                return Json(new
                {
                    data = objClip,
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

        // \ClipBoard/GetCodeHandleClipBoard/Gdate
        // หูหิ้ว
        public JsonResult GetCodeHandleClipBoard(ClipBoard item)
        {

            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard_Handle> ls = new List<ClipBoard_Handle>();
                stg.GetCodeHandleClipBoard(out ls, item.Clipboard_Date);

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
        // \ClipBoard/GetCodeTagClipBoard/Gdate
        // Tag
        public JsonResult GetCodeTagClipBoard(ClipBoard item)
        {

            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard_Tag> ls = new List<ClipBoard_Tag>();
                stg.GetCodeTagClipBoard(out ls, item.Clipboard_Date);

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
        // \ClipBoard/GetCodeTagClipBoard/Gdate
        // งานเย็บ
        public JsonResult GetCodeSewingClipBoard(ClipBoard item)
        {

            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard_Sewing> ls = new List<ClipBoard_Sewing>();
                stg.GetCodeSewingClipBoard(out ls, item.Clipboard_Date);

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

        // \ClipBoard/GetCodeTagClipBoard/Gdate
        // เจาะตาไก่
        public JsonResult GetCodeEyeletClipBoard(ClipBoard item)
        {

            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard_Eyelet> ls = new List<ClipBoard_Eyelet>();
                stg.GetCodeEyeletClipBoard(out ls, item.Clipboard_Date);

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

        // \ClipBoard/GetCodeBellClipBoard/Gdate
        // อัลเบลล์
        public JsonResult GetCodeBellClipBoard(ClipBoard item)
        {

            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard_Bell> ls = new List<ClipBoard_Bell>();
                stg.GetCodeBellClipBoard(out ls, item.Clipboard_Date);

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

        // \ClipBoard/GetCodeBagin2ClipBoard/Gdate
        // สวมถุงใน
        public JsonResult GetCodeBagin2ClipBoard(ClipBoard item)
        {

            try
            {
                item.Clipboard_Date = DateTime.ParseExact(item.Clipboard_Date_Str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClipBoardData stg = new ClipBoardData();
                List<ClipBoard_Bagin2> ls = new List<ClipBoard_Bagin2>();
                stg.GetCodeBagin2ClipBoard(out ls, item.Clipboard_Date);

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
        #endregion
    }
}