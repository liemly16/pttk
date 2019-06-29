using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTTK.Models;
using System.Data;


namespace PTTK.Controllers
{
    public class KhuyenMaiController : Controller
    {
        // GET: KhuyenMai
        public ActionResult Index()
        {
            KhuyenMaiModel model = new KhuyenMaiModel();
            DataTable dt = model.getAllKhuyenMai();
            return View("Index", dt);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult InsertRecord(FormCollection form, string action)
        {
            if (action == "Submit")
            {
                KhuyenMaiModel model = new KhuyenMaiModel();
                   
                string loai = form["loai"];
                string ten = form["ten"];
                string thoiGianBatDau = form["thoiGianBatDau"];
                string thoiGianKetThuc = form["thoiGianKetThuc"];
                int giaTri = Convert.ToInt32(form["giaTri"]);
                int tongTienThapNhat = Convert.ToInt32(form["tongTienThapNhat"]);

                int status = model.Insert(ten, loai, thoiGianBatDau, thoiGianKetThuc, giaTri, tongTienThapNhat);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int ma)
        {
            KhuyenMaiModel model = new KhuyenMaiModel();
            DataTable dt = model.getKhuyenMai(ma);
            return View("Edit", dt);
        }

        public ActionResult UpdateRecord(FormCollection form, string action)
        {
            if (action == "Submit")
            {
                KhuyenMaiModel model = new KhuyenMaiModel();

                int ma = Convert.ToInt32(form["ma"]);
                string loai = form["loai"];
                string ten = form["ten"];
                string thoiGianBatDau = form["thoiGianBatDau"];
                string thoiGianKetThuc = form["thoiGianKetThuc"];
                int giaTri = Convert.ToInt32(form["giaTri"]);
                int tongTienThapNhat = Convert.ToInt32(form["tongTienThapNhat"]);
                int status = model.Update(ma, ten, loai, thoiGianBatDau, thoiGianKetThuc, giaTri, tongTienThapNhat);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
        }
    }

        public ActionResult Delete(int ma)
        {
            KhuyenMaiModel model = new KhuyenMaiModel();
            model.Delete(ma);
            return RedirectToAction("Index");
        }

    }
}