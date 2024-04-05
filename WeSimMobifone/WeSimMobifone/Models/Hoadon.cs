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
        public int MaHd { get; set; }
        [Column("MaTB")]
        public int MaTb { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngay { get; set; }
        public int? TongTien { get; set; }
        [Column("MaKH")]
        public int MaKh { get; set; }
        [Column("MaDc")]
        public int MaDc { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaKh))]
        [InverseProperty(nameof(Khachhang.Hoadon))]
        public virtual Khachhang MaKhNavigation { get; set; }
        [ForeignKey(nameof(MaTb))]
        [InverseProperty(nameof(Thuebao.Hoadon))]
        public virtual Thuebao MaTbNavigation { get; set; }

    }
}
