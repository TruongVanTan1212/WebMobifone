using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeSimMobifone.Models
{
    [Table("QLTHUEBAO")]
    public partial class Qlthuebao
    {
     
        [Key]
        [Column("MaQL")]
        public int MaQl { get; set; }
        [Column("MaTB")]
        public int MaTb { get; set; }
        [Column("MaKH")]
        public int MaKh { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? NgayKichHoat { get; set; }
        public int TrangThai { get; set; }
        public int Daxoa { get; set; }

        [ForeignKey(nameof(MaKh))]
        [InverseProperty(nameof(Khachhang.Qlthuebao))]
        public virtual Khachhang MaKhNavigation { get; set; }

        [ForeignKey(nameof(MaTb))]
        [InverseProperty(nameof(Thuebao.Qlthuebao))]
        public virtual Thuebao MaTbNavigation { get; set; }
    }
}
