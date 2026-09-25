using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PQCLesson09Annotation.Models.DataViewModels
{
    public class PqcMemberRegister
    {
        public int PqcMemberId { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 20 ký tự")]
        public string PqcUserName { get; set; } = string.Empty;

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
        public string PqcPassword { get; set; } = string.Empty;

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string PqcEmail { get; set; } = string.Empty;

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^0\d{9,10}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 0 và có 10-11 chữ số")]
        public string PqcPhoneNumber { get; set; } = string.Empty;

        [DisplayName("Họ và tên")]
        public string? PqcFullName { get; set; }

        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? PqcBirthday { get; set; }
    }
}
