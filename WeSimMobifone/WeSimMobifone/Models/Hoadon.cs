using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("HOADON")]
    public partial class Hoadon
    {
        [Key]
        [Column("MaHD")]
        [Display(Name = "Mã hoá đơn")]
        public int MaHd { get; set; }
        [Column("MaTB")]
        [Display(Name = "Mã thuê bao")]
        public int MaTb { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Ngày đặt hàng")]
        public DateTime? Ngay { get; set; }
        [Display(Name = "Tổng tiền")]
        public int TongTien { get; set; }
        [Column("MaKH")]
        [Display(Name = "Mã khách hàng")]
        public int MaKh { get; set; }
        [Column("MaDc")]
        public int MaDc { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public int Daxoa { get; set; }

        [ForeignKey(nameof(MaKh))]
        [InverseProperty(nameof(Khachhang.Hoadon))]
        public virtual Khachhang MaKhNavigation { get; set; }

        [ForeignKey(nameof(MaTb))]
        [InverseProperty(nameof(Thuebao.Hoadon))]
        public virtual Thuebao MaTbNavigation { get; set; }

        [ForeignKey(nameof(MaDc))]
        [InverseProperty(nameof(Diachi.Hoadon))]
        public virtual Diachi MaDcNavigation { get; set; }

    }
}
