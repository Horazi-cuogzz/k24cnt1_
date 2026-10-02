using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PQCLession12.Models
{
    [Table("PqcProduct")]
    public class PqcProduct
    {
        [Key]
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm giới hạn 150 ký tự")]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Tên sản phẩm")]
        public string PqcName { get; set; } = string.Empty;

        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Hình ảnh")]
        public string? PqcImage { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Đơn giá")]
        [DisplayFormat(DataFormatString = "{0:#,##0} VNĐ")]
        public float PqcPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Giá khuyến mãi")]
        [DisplayFormat(DataFormatString = "{0:#,##0} VNĐ")]
        public float PqcSalePrice { get; set; }

        [Column(TypeName = "tinyint")]
        [Display(Name = "Trạng thái")]
        public byte PqcStatus { get; set; } = 1;

        [StringLength(1000, ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string? PqcDescriptions { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        [Display(Name = "Danh mục")]
        public int PqcCategoryId { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PqcCreatedDate { get; set; } = DateTime.Now;

        // Khóa ngoại tới bảng PqcCategory
        [ForeignKey("PqcCategoryId")]
        [Display(Name = "Danh mục")]
        public virtual PqcCategory? PqcCategory { get; set; }
    }
}
