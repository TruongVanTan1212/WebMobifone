using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("HUONGDAN")]
    public partial class Huongdan
    {
        [Key]
        [Column("MaHDan")]
        public int MaHdan { get; set; }
        [StringLength(255)]
        public string CauHoi { get; set; }
        public string TraLoi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayDang { get; set; }
    }
}
