using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
//using System.Xml.Linq;
using WebQLKS.Models;

namespace WebQLKS.Controllers
{
    public class LoginAcountController : Controller
    {
        DAQLKSEntities db = new DAQLKSEntities();
        // GET: Login

        public ActionResult LoginAcountKH()
        {

            return View();
        }
        [HttpPost]
        public ActionResult LoginAcountKH(string TaiKhoan, string MatKhau)
        {
            tbl_KhachHang khachHang = new tbl_KhachHang()
            {
                TaiKhoan = TaiKhoan,
                MatKhau = MatKhau
            };
            var checkkh = db.tbl_KhachHang.Where(s => s.TaiKhoan == khachHang.TaiKhoan && s.MatKhau == khachHang.MatKhau).FirstOrDefault();

            if (checkkh == null)
            {
                TempData["SaiThongTin"] = "Sai tài khoản hoặc mật khẩu.";
                ViewBag.ErroInfo = "Sai tai khoan";
                return View("LoginAcountKH");
            }
            else
            {
                TempData["LoginSuccess"] = "Đăng nhập thành công!";
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["KH"] = checkkh.MaKH;
                Session["nameKH"] = checkkh.HoTen;
                ViewBag.SessionValue = Session["KH"];
                if (Session["PreviousUrl"] != null && !string.IsNullOrEmpty(Session["PreviousUrl"].ToString()))
                {
                    string previousUrl = Session["PreviousUrl"].ToString();
                    string maDichVu = Session["MaDichVu"] != null ? Session["MaDichVu"].ToString() : null;
                    Session.Remove("PreviousUrl"); // Xóa session sau khi sử dụng

                    Response.Redirect(previousUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
        }//sprint 1

        private string MaKhachHang()
        {
            var CheckMa = db.tbl_KhachHang.OrderByDescending(p => p.MaKH).FirstOrDefault();
            if (CheckMa != null)
            {
                int MKH = int.Parse(CheckMa.MaKH.Substring(2));
                int nextMKH = MKH + 1;
                return "KH" + nextMKH.ToString();
            }
            return "KH1";
        }
        [HttpGet]
        public ActionResult RegisterKH()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult RegisterKH(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Kiểm tra xem tài khoản đã tồn tại chưa
                var existingAccount = db.tbl_KhachHang.FirstOrDefault(s => s.TaiKhoan == model.TaiKhoan);
                if (existingAccount != null)
                {
                    // Thêm thông báo lỗi nếu tài khoản đã tồn tại
                    ModelState.AddModelError("TaiKhoan", "Tài khoản đã được đăng ký. Vui lòng chọn tài khoản khác.");
                    return View(model); // Trả lại view và giữ lại các giá trị đã nhập
                }
                string loai = model.QuocTich.ToLower();
                string makhachH = MaKhachHang();
                int maLoaiKH;
                String phoneCheck = "+84" + model.SDT.ToString().Trim();


                if (loai == "việt nam")
                {
                     maLoaiKH = 002;
                    
                }
                else
                {
                     maLoaiKH = 001;
                    
                }
                tbl_KhachHang khachhang = new tbl_KhachHang()
                {
                    MaKH = makhachH,
                    HoTen = model.HoTen,
                    TaiKhoan = model.TaiKhoan,
                    MatKhau = model.MatKhau,
                    Email = model.Email,
                    SDT = model.SDT,
                    NgaySinh = model.NgaySinh,
                    CCCD = model.CCCD,
                    DiaChi = model.DiaChi,
                    QuocTich = model.QuocTich,
                    MaLoaiKH = maLoaiKH

                };
                var checkTK = db.tbl_KhachHang.Where(s => s.TaiKhoan == khachhang.TaiKhoan).FirstOrDefault();
                if (checkGmail(model.Email) != true)
                {
                    TempData["ErrorRegister"] = "Sai định dạng gmail";
                    return RedirectToAction("RegisterKH");
                }
                if (checkPhoneNumber(phoneCheck) != true)
                {
                    TempData["ErrorRegister"] = "Sai định dạng số điện thoại";
                    return RedirectToAction("RegisterKH");
                }
                if (checkCCCD(model.CCCD) != true)
                {
                    TempData["ErrorRegister"] = "Sai định dạng căn cước công dân";
                    return RedirectToAction("RegisterKH");
                }
                if (model.MatKhau.ToString() != model.ConfirmPass.ToString())
                {
                    TempData["ErrorRegister"] = "Mật khẩu không trùng khớp";
                    return RedirectToAction("RegisterKH");
                }
                else  if (checkTK == null)
                {
                    TempData["RegisterSuccess"] = "Đăng Ký thành công!";
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.tbl_KhachHang.Add(khachhang);
                    db.SaveChanges();
                    return RedirectToAction("LoginAcountKH");
                }
                else
                {
                    TempData["ErrorRegister"] = "Tài khoản đã có người đăng ký! Vui lòng thử lại";
                    return RedirectToAction("RegisterKH");
                }

            }
            return View();
        }//sprint 1

        public bool checkCCCD(String cccd)
        {
            String regex = "^\\d{12}$";
            if (Regex.IsMatch(cccd, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkPhoneNumber(String phoneNumber)
        {
            String regex = @"^\+84\d{9,10}$";
            if (Regex.IsMatch(phoneNumber, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkGmail(String gmail)
        {
            String regex = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            if (Regex.IsMatch(gmail, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}