using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("THUEBAO")]
    public partial class Thuebao
    {
        public Thuebao()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        [Key]
        [Column("MaTB")]
        public int MaTb { get; set; }
        [Required]
        [StringLength(10)]
        public string SoThueBao { get; set; }
        public int PhiHoaMang { get; set; }
        [Column("MaDM")]
        public int MaDm { get; set; }
        [Column("MaLTB")]
        public int MaLtb { get; set; }
        [StringLength(50)]
        public string LoaiSo { get; set; }
        [Column("DiaDiemHM")]
        [StringLength(100)]
        public string DiaDiemHm { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaDm))]
        [InverseProperty(nameof(Danhmuc.Thuebao))]
        public virtual Danhmuc MaDmNavigation { get; set; }
        [ForeignKey(nameof(MaLtb))]
        [InverseProperty(nameof(Loaitb.Thuebao))]
        public virtual Loaitb MaLtbNavigation { get; set; }
        [InverseProperty("MaTbNavigation")]
        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
