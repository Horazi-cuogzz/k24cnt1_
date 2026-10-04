using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PQCLession14.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã bài viết")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên bài viết không được để trống")]
        [StringLength(100, ErrorMessage = "Tên bài viết tối đa 100 ký tự")]
        [Display(Name = "Tiêu đề bài viết")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100, ErrorMessage = "Đường dẫn ảnh tối đa 100 ký tự")]
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự")]
        [Display(Name = "Mô tả ngắn")]
        public string? Description { get; set; }
    }
}
