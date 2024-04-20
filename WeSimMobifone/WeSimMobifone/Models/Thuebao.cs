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
            Qlthuebao = new HashSet<Qlthuebao>();
        }

        [Key]
        [Column("MaTB")]
        [Display(Name = "Mã thuê bao")]
        public int MaTb { get; set; }
        [Required(ErrorMessage = "vui lòng nhập số thuê bao")]
        [Display(Name = "Số thuê bao")]
        [StringLength(10)]
        public string SoThueBao { get; set; }
        [Display(Name = "Phí hoà mạng")]
        public int PhiHoaMang { get; set; }
        [Column("MaDM")]
        [Display(Name = "Danh mục thuê bao")]
        public int MaDm { get; set; }
        [Column("MaLTB")]
        [Display(Name = "Loại thuê bao")]
        public int MaLtb { get; set; }
        [Display(Name = "Loại số")]
        [StringLength(50)]
        public string LoaiSo { get; set; }
        [Column("DiaDiemHM")]
        [Display(Name = "Địa điểm hoà mạng")]
        [StringLength(100)]
        public string DiaDiemHm { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public int Daxoa { get; set; }

        [ForeignKey(nameof(MaDm))]
        [InverseProperty(nameof(Danhmuc.Thuebao))]
        public virtual Danhmuc MaDmNavigation { get; set; }
        [ForeignKey(nameof(MaLtb))]
        [InverseProperty(nameof(Loaitb.Thuebao))]
        public virtual Loaitb MaLtbNavigation { get; set; }
        [InverseProperty("MaTbNavigation")]
        public virtual ICollection<Hoadon> Hoadon { get; set; }

        [InverseProperty("MaTbNavigation")]
        public virtual ICollection<Qlthuebao> Qlthuebao { get; set; }
    }
}
