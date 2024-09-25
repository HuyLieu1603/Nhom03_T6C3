using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebQLKS.Models;
using System.Transactions;
using System.Threading.Tasks;
using System.Threading;

namespace WebQLKS.Controllers
{
    public class RoomController : Controller
    {
        DAQLKSEntities database = new DAQLKSEntities();
        // GET: Room
        public ActionResult CategoryRoom()
        {
            var room = database.tbl_LoaiPhong.ToList();
            var tienIchDict = new Dictionary<string, List<string>>();
            foreach (var item in room)
            {
                var maLoaiPhong = item.MaLoaiPhong;
                var lstTienIch = database.tbl_ChiTietPhong.Where(ct => ct.MaLoaiPhong == maLoaiPhong).Select(ct => ct.TienIch).Distinct().ToList();
                tienIchDict[maLoaiPhong] = lstTienIch;
            }
            ViewBag.TienIch = tienIchDict;
            return View(room);
        }//sprint 1
        //Load Phòng Theo Loại Phòng
        public ActionResult DetailRoom(string MaLoaiPhong)
        {
            Session["MaLoaiPhong"] = MaLoaiPhong;
            ViewBag.imgLoaiPhong = database.tbl_Phong.Where(ha => ha.MaLoaiPhong == MaLoaiPhong).ToList();
            if ((MaLoaiPhong.ToString().Trim() == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ten = database.tbl_LoaiPhong.Where(r => r.MaLoaiPhong == MaLoaiPhong).Select(r => r.TenLoaiPhong).FirstOrDefault();
            var donGia = database.tbl_LoaiPhong.Where(dg => dg.MaLoaiPhong == MaLoaiPhong).Select(dg => dg.DonGia).FirstOrDefault();
            var moTa = database.tbl_LoaiPhong.Where(lp => lp.MaLoaiPhong == MaLoaiPhong).Select(lp => lp.MoTa).FirstOrDefault();
            if (moTa == null)
            {
                return HttpNotFound("Không tìm thấy thông tin phòng");
            }
            var tienIch = database.tbl_ChiTietPhong.Where(ct => ct.MaLoaiPhong == MaLoaiPhong).Select(ct => ct.TienIch).Distinct().ToList();
            var viewModel = new RoomDetailViewModel
            {
                maPhong = MaLoaiPhong,
                tenPhong = ten,
                donGia = donGia,
                MoTa = moTa,
                TienIch = tienIch
            };
            return View(viewModel);
        }//sprint 1



    }
}