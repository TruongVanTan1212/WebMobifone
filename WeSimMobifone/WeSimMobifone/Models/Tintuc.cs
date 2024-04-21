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
        [Required(ErrorMessage = "vui lòng nhập tiêu đề tin tức")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Required(ErrorMessage = "vui lòng nhập tóm tắt tin")]
        [Display(Name = "Tóm tắt")]
        public string TomTat { get; set; }
        [Required(ErrorMessage = "vui lòng nhập nội dung tin")]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [StringLength(255)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Ngày đăng")]
        public DateTime? NgayDang { get; set; }
        public int Hot { get; set; }
    }
}
