using demoMac5.Models;
using demoMac5.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoMac5.Controllers
{
    public class WageController : Controller
    {
        
        #region :: Province ::
        // \Wage/GetProvince/id
        public JsonResult GetProvince(int id)
        {

            try
            {
                ProvinceData stg = new ProvinceData();
                List<Province> ls = new List<Province>();
                stg.GetProvince(out ls, id);

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


        // \Wage/Insert_Province
        [HttpPost]
        public JsonResult Insert_Province(Province item)
        {

            try
            {
                ProvinceData stg = new ProvinceData();
                stg.Insert_Province(item);

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
        // \Wage/Update_MSew
        [HttpPost]
        public JsonResult Update_Province(Province item)
        {

            try
            {
                ProvinceData stg = new ProvinceData();
                stg.Update_Province(item);

                return Json(new
                {
                    data = "บันทึกข้อมูลสำเร็จ !!!",
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


        // \Wage/Delete_Province
        [HttpPost]
        public JsonResult Delete_Province(Province item)
        {

            try
            {
                ProvinceData stg = new ProvinceData();
                stg.Delete_Province(item);

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
        #endregion :: Province ::

        #region :: MSew ::

        // \Wage/GetMSew
        public JsonResult GetMSew(int id)
        {

            try
            {
                MSewData stg = new MSewData();
                List<MSew> ls = new List<MSew>();
                stg.GetMSew(out ls, id);

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

        // \Wage/Insert_MSew
        [HttpPost]
        public JsonResult Insert_MSew(MSew item)
        {

            try
            {
                MSewData stg = new MSewData();

                bool iExist = Library.CheckExistCode("M_SEW", item.Sew_Id, item.Sew_Code);

                if (iExist)
                {
                    throw new Exception("รหัสงานเย็บซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stg.InsertMSew(item);

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
        // \Wage/Update_MSew
        [HttpPost]
        public JsonResult Update_MSew(MSew item)
        {
            try
            {
                MSewData stg = new MSewData();

                bool iExist = Library.CheckExistCode("M_SEW", item.Sew_Id, item.Sew_Code);

                if (iExist)
                {
                    throw new Exception("รหัสงานเย็บซ้ำ" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }
                stg.UpdateMSew(item);

                return Json(new
                {
                    data = "บันทึกข้อมูลสำเร็จ !!!",
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


        // \Wage/Delete_MSew
        [HttpPost]
        public JsonResult Delete_MSew(MSew item)
        {

            try
            {
                MSewData stg = new MSewData();
                stg.DeleteMSew(item);

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
        #endregion  :: MSew ::

        #region :: MExpense ::

        // \Wage/GetMExpense
        public JsonResult GetMExpense(int id)
        {

            try
            {
                MExpenseData stg = new MExpenseData();
                List<MExpense> ls = new List<MExpense>();
                stg.GetMExpense(out ls, id);

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

        // \Wage/Insert_MExpense
        [HttpPost]
        public JsonResult Insert_MExpense(MExpense item)
        {

            try
            {
                MExpenseData stg = new MExpenseData();

                bool iExist = Library.CheckExistCode("M_EXPENSE", item.Expense_Id, item.Expense_Code);

                if (iExist)
                {
                    throw new Exception("รหัสค่าใช้จ่ายและบริหาร" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }
                stg.InsertMExpense(item);

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
        // \Wage/Update_MExpense
        [HttpPost]
        public JsonResult Update_MExpense(MExpense item)
        {

            try
            {
                MExpenseData stg = new MExpenseData();
                bool iExist = Library.CheckExistCode("M_EXPENSE", item.Expense_Id, item.Expense_Code);

                if (iExist)
                {
                    throw new Exception("รหัสค่าใช้จ่ายและบริหาร" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stg.UpdateMExpense(item);

                return Json(new
                {
                    data = "บันทึกข้อมูลสำเร็จ !!!",
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


        // \Wage/Delete_MExpense
        [HttpPost]
        public JsonResult Delete_MExpense(MExpense item)
        {

            try
            {
                MExpenseData stg = new MExpenseData();
                stg.DeleteMExpense(item);

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
        #endregion  :: MExpense ::

        #region :: MDepartment ::

        // \Wage/GetMDepartment
        public JsonResult GetMDepartment(int id)
        {

            try
            {
                MDepartmentData stg = new MDepartmentData();
                List<MDepartment> ls = new List<MDepartment>();
                stg.GetMDepartment(out ls, id);

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

        // \Wage/Insert_MSew
        [HttpPost]
        public JsonResult Insert_MDepartment(MDepartment item)
        {

            try
            {
                MDepartmentData stg = new MDepartmentData();
          
                int i = Utility.GetCheckUniqe(
                " [dbo].[M_DEPARTMENT] ",
                " Department_Code ",
                " and Department_Code=" + Utility.ReplaceString(item.Department_Code));

                if (i == 0)
                {
                    stg.InsertMDepartment(item);
                    return Json(new
                    {
                        data = "เพิ่มข้อมูลสำเร็จ !!!",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception(" รหัสแผนก" + item.Department_Code + "  ซ้ำ !!!");

                }

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
        // \Wage/Update_MDepartment
        [HttpPost]
        public JsonResult Update_MDepartment(MDepartment item)
        {

            try
            {
                MDepartmentData stg = new MDepartmentData();
                stg.UpdateMDepartment(item);

                return Json(new
                {
                    data = "บันทึกข้อมูลสำเร็จ !!!",
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


        // \Wage/Delete_MDepartment
        [HttpPost]
        public JsonResult Delete_MDepartment(MDepartment item)
        {

            try
            {
                MDepartmentData stg = new MDepartmentData();
                stg.DeleteMDepartment(item);

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
        #endregion  :: MDepartment ::

        #region :: MOverhead ::

        // \Wage/GetMOverhead
        public JsonResult GetMOverhead(int id)
        {

            try
            {
                MOverheadData stg = new MOverheadData();
                List<MOverhead> ls = new List<MOverhead>();
                stg.GetMOverhead(out ls, id);

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

        // \Wage/Insert_MOverhead
        [HttpPost]
        public JsonResult Insert_MOverhead(MOverhead item)
        {

            try
            {
                MOverheadData stg = new MOverheadData();

                bool iExist = Library.CheckExistCode("M_OVERHEAD", item.Overhead_Id, item.Overhead_Code);

                if (iExist)
                {
                    throw new Exception("รหัสโสหุ้ยการผลิต" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }
                stg.InsertMOverhead(item);

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
        // \Wage/Update_MOverhead
        [HttpPost]
        public JsonResult Update_MOverhead(MOverhead item)
        {

            try
            {
                MOverheadData stg = new MOverheadData();
                bool iExist = Library.CheckExistCode("M_OVERHEAD", item.Overhead_Id, item.Overhead_Code);

                if (iExist)
                {
                    throw new Exception("รหัสโสหุ้ยการผลิต" + Environment.NewLine + "มีรหัสนี้ในฐานข้อมูลแล้ว");
                }

                stg.UpdateMOverhead(item);

                return Json(new
                {
                    data = "บันทึกข้อมูลสำเร็จ !!!",
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


        // \Wage/Delete_MOverhead
        [HttpPost]
        public JsonResult Delete_MOverhead(MOverhead item)
        {

            try
            {
                MOverheadData stg = new MOverheadData();
                stg.DeleteMOverhead(item);

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
        #endregion  :: MOverhead ::
    }
}