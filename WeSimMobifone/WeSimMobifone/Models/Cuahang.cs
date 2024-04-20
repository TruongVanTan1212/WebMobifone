using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeSimMobifone.Models
{
    [Table("CUAHANG")]
    public partial class Cuahang
    {
        [Key]
        [Column("MaCH")]
        public int MaCh { get; set; }
        [Required(ErrorMessage = "vui lòng nhập tên cửa hàng")]
        [Display(Name = "Tên cửa hàng")]
        [StringLength(100)]
        public string Ten { get; set; }
        [Display(Name = "Điện thoại")]
        [StringLength(20)]
        public string DienThoai { get; set; }
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(100)]
        public string DiaChi { get; set; }
    }
}
