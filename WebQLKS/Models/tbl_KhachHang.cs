﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_KhachHang()
        {
            this.tbl_DichVuDaDat = new HashSet<tbl_DichVuDaDat>();
            this.tbl_HoaDon = new HashSet<tbl_HoaDon>();
            this.tbl_PhieuThuePhong = new HashSet<tbl_PhieuThuePhong>();
        }

        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        [NotMapped]
        [Compare("MatKhau")]
        [DisplayName("Nh?p l?i m?t kh?u")]
        public string ConfirmPass { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> MaLoaiKH { get; set; }
        public string QuocTich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DichVuDaDat> tbl_DichVuDaDat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HoaDon> tbl_HoaDon { get; set; }
        public virtual tbl_LoaiKhach tbl_LoaiKhach { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PhieuThuePhong> tbl_PhieuThuePhong { get; set; }
    }
}