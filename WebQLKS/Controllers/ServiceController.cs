using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLKS.Models;

namespace WebQLKS.Controllers
{
    public class ServiceController : Controller
    {
        DAQLKSEntities db = new DAQLKSEntities();
        // GET: Service
        public ActionResult Index()
        {
            var DV = db.tbl_LoaiDichVu.ToList();
            return View(DV);
        }//sprint 1
        public ActionResult chiTietLoaiDV(string maLoaiDV)
        {
            var ct = db.tbl_DichVu.Where(dv => dv.MaLoaiDV == maLoaiDV).ToList();
            return View(ct);
        }//sprint 1
        public ActionResult detailService(string maDV)
        {
            Session["PreviousUrl"] = Request.Url.AbsoluteUri;
            Session["Previous"] = Request.Url.AbsoluteUri;
            var ctDV = db.tbl_DichVu.Where(r => r.MaDV == maDV).FirstOrDefault();
            return View(ctDV);
        }//sprint 1
    }
}