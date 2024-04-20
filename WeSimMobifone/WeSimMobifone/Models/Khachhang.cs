using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("KHACHHANG")]
    public partial class Khachhang
    {
        public Khachhang()
        {
            Diachi = new HashSet<Diachi>();
            Hoadon = new HashSet<Hoadon>();
            Qlthuebao = new HashSet<Qlthuebao>();
        }

        [Key]
        [Column("MaKH")]
        [Display(Name = "Mã khách hàng")]
        public int MaKh { get; set; }
        [Display(Name = "Tên khách hàng")]
        [StringLength(100)]
        public string Ten { get; set; }
        [Display(Name = "Điện thoại")]
        [StringLength(10)]
        public string DienThoai { get; set; }
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(255)]
        public string MatKhau { get; set; }
        [Column("CCCD")]
        [Display(Name = "Căn cước công dân")]
        [StringLength(12)]
        public string Cccd { get; set; }
        [Display(Name = "Ảnh căn cước mặt trước")]
        [StringLength(255)]
        public string HinhT { get; set; }
        [Display(Name = "Ảnh căn cước mặt sau")]
        [StringLength(255)]
        public string HinhS { get; set; }
        [Display(Name = "Số lượng thuê bao")]
        [Column("SLThueB")]
        public int SlthueB { get; set; }
        public int Daxoa { get; set; }

        [InverseProperty("MaKhNavigation")]
        public virtual ICollection<Diachi> Diachi { get; set; }

        [InverseProperty("MaKhNavigation")]
        public virtual ICollection<Hoadon> Hoadon { get; set; }

        [InverseProperty("MaKhNavigation")]
        public virtual ICollection<Qlthuebao> Qlthuebao { get; set; }
    }
}
