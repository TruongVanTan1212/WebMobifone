using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("LOAITB")]
    public partial class Loaitb
    {
        public Loaitb()
        {
            Thuebao = new HashSet<Thuebao>();
        }

        [Key]
        [Column("MaLTB")]
        public int MaLtb { get; set; }
        [Required]
        [StringLength(100)]
        public string TenL { get; set; }

        [InverseProperty("MaLtbNavigation")]
        public virtual ICollection<Thuebao> Thuebao { get; set; }
    }
}
