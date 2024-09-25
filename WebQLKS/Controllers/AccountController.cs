using Newtonsoft.Json.Linq;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Xml.Linq;
using WebQLKS.Models;

namespace WebQLKS.Controllers
{
    public class AccountController : Controller
    {
        DAQLKSEntities db = new DAQLKSEntities();
        // GET: Account
        public ActionResult historyService()
        {
            if (Session["KH"] == null)
            {
                TempData["SessionKhNull"] = "Phiên đăng nhập đã hết hạn. Hãy đăng nhập lại để tiếp tục";
                return RedirectToAction("LoginAcountKH", "LoginAcount");
            }
            var maKH = Session["KH"].ToString();
            var service = db.tbl_DichVuDaDat.Where(s => s.MaKH == maKH).ToList().AsEnumerable().Reverse().ToList();
            if (service == null)
            {
                ViewBag.Notification = "Quý khách chưa sử dụng dịch vụ nào";
                return RedirectToAction("historyService", "Account");
            }
            return View(service);
        }//sprint 1
        public ActionResult historyOrdRoom()
        {
            if (Session["KH"] == null)
            {
                TempData["SessionKhNull"] = "Phiên đăng nhập đã hết hạn. Hãy đăng nhập lại để tiếp tục";
                return RedirectToAction("LoginAcountKH", "LoginAcount");
            }
            var maKH = Session["KH"].ToString();
            var HD = db.tbl_PhieuThuePhong.Where(hd => hd.MaKH == maKH).ToList().AsEnumerable().Reverse().ToList();
            if (HD == null)
            {
                ViewBag.Notification = "Quý khách chưa đặt phòng nào";
                return RedirectToAction("historyOrdRoom", "Account");
            }
            return View(HD);
        }//sprint 1
        public ActionResult Logout()
        {
            if (Session["KH"] == null)
            {
                TempData["SessionKhNull"] = "Phiên đăng nhập đã hết hạn. Hãy đăng nhập lại để tiếp tục";
                return RedirectToAction("LoginAcountKH", "LoginAcount");
            }
            Session["KH"] = null;
            return RedirectToAction("Index", "Home");
        }
        //sprint 1


    }
}