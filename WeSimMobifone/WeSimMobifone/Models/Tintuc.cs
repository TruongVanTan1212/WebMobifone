using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("TINTUC")]
    public partial class Tintuc
    {
        [Key]
        public int MaTin { get; set; }
        public string TieuDe { get; set; }
        public string TomTat { get; set; }
        public string NoiDung { get; set; }
        [StringLength(255)]
        public string HinhAnh { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayDang { get; set; }
    }
}
