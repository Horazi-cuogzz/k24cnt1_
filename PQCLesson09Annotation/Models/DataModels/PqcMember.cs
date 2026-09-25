using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PQCLesson09Annotation.Models.DataModels
{
    public class PqcMember
    {
        [DisplayName("Mã TV")]
        public int PqcMemberId { get; set; }

        [DisplayName("Tên đăng nhập")]
        public string PqcUserName { get; set; } = string.Empty;

        [DisplayName("Mật khẩu")]
        public string PqcPassword { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string PqcEmail { get; set; } = string.Empty;

        [DisplayName("Số điện thoại")]
        public string PqcPhoneNumber { get; set; } = string.Empty;

        [DisplayName("Họ và tên")]
        public string PqcFullName { get; set; } = string.Empty;

        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime PqcBirthday { get; set; }
    }
}
