using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTTK.Models;
using System.Data;
using System.Data.SqlClient;

namespace PTTK.Controllers
{

    public class PhuKienDienThoai
    {
        public DataTable dt;
        public DataTable pk;
        public PhuKienDienThoai()
        {

        }

        public PhuKienDienThoai(DataTable pk, DataTable dt)
        {
            this.pk = pk;
            this.dt = dt;
        }
    }
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SanPhamModel model = new SanPhamModel();
            DataTable dt = model.getAllDienThoai();
            DataTable pk = model.getAllPhuKien();
            PhuKienDienThoai obj = new PhuKienDienThoai(pk, dt);
            return View("Index", obj );
        }

        public ActionResult Detail(int id)
        {
            SanPhamModel model = new SanPhamModel();
            DataTable dt = model.GetSanPham(id);
            return View("Detail", dt);
        }
    }
}