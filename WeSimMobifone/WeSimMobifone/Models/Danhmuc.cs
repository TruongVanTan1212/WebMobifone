using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("DANHMUC")]
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Thuebao = new HashSet<Thuebao>();
        }

        [Key]
        [Column("MaDM")]
        public int MaDm { get; set; }
        [Required]
        [Column("TenDM")]
        [StringLength(100)]
        public string TenDm { get; set; }

        [InverseProperty("MaDmNavigation")]
        public virtual ICollection<Thuebao> Thuebao { get; set; }
    }
}
