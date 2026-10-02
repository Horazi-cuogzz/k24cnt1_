using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PQCLession12.Models
{
    [Table("PqcCategory")]
    public class PqcCategory
    {
        [Key]
        [Display(Name = "Mã danh mục")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên danh mục")]
        public string PqcName { get; set; } = string.Empty;

        [Column(TypeName = "tinyint")]
        [Display(Name = "Trạng thái")]
        public byte PqcStatus { get; set; } = 1;

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PqcCreatedDate { get; set; } = DateTime.Now;

        // Danh sách sản phẩm theo danh mục (1 - N)
        public virtual ICollection<PqcProduct> PqcProducts { get; set; } = new List<PqcProduct>();
    }
}
