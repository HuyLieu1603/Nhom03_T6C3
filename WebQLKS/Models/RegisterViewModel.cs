using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLKS.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Họ tên không được bỏ trống")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Tài khoản không được bỏ trống")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Email không được bỏ trống")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải có 10 chữ số và bắt đầu bằng 0")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Căn cước công dân không được bỏ trống")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Căn cước công dân phải có 12 chữ số")]
        public string CCCD { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được bỏ trống")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Xác nhận mật khẩu không được bỏ trống")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp")]
        public string ConfirmPass { get; set; }

        [Required(ErrorMessage = "Quốc tịch không được bỏ trống")]
        public string QuocTich { get; set; }
    }
}