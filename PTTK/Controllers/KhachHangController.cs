using PTTK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTTK.Controllers
{
    public class KhachHang
    {
        public DataTable KhachHangData { get; set; }

        public KhachHang()
        {

        }
        public KhachHang(DataTable dataTable)
        {
            this.KhachHangData = dataTable;
        }

    }
    public class KhachHangController : Controller
    {
        public ActionResult Delete(int ma)
        {
            
                KhachHangModel model = new KhachHangModel();
                model.deleteKhachHang(ma);
                return RedirectToAction("Index");
            
        }
        public ActionResult Insert()  
        {  
            return View("Create");  
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult UpdateRecord(FormCollection frmEdit, string action)
        {
            if (action == "Submit")
            {
                KhachHangModel model = new KhachHangModel();
                string ten = frmEdit["txtTen"];
                string loai = frmEdit["txtLoai"];
                string sdt = frmEdit["txtSDT"];
                string diaChi = frmEdit["txtDiaChi"];
                string nguoiDaiDien = frmEdit["txtNguoiDaiDien"];
                string sdtCongTy = frmEdit["txtSoDienThoaiCongTy"];
                int id = Convert.ToInt32(frmEdit["hdID"]);

                int status = model.updateKhachHang(ten, loai, sdt, diaChi, nguoiDaiDien, sdtCongTy,id);
                
                return RedirectToAction("Index");
                
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int ma)
        {
            KhachHangModel model= new KhachHangModel();
            DataTable dt = model.getKhachHang(ma);
            return View("Edit", dt);
        }
        // GET: all KhachHangs
        public ActionResult Index()
        {
            KhachHangModel khachHangModel = new KhachHangModel();
            DataTable kh = khachHangModel.getAllKhachHang();
            
            return View("Index",kh);
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                KhachHangModel model = new KhachHangModel();
                string ten = frm["txtTen"];
                string loai = frm["txtLoai"];
                string sdt = frm["txtSDT"];
                string diaChi = frm["txtDiaChi"];
                string nguoiDaiDien = frm["txtNguoiDaiDien"];
                string sdtCongTy = frm["txtSDTCongTy"];

                int status = model.insertKhachHang(ten, loai, sdt, diaChi, nguoiDaiDien, sdtCongTy);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
    
}