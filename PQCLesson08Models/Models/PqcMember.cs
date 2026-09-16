using System.ComponentModel;

namespace PQCLesson08Models.Models
{
    public class PqcMember
    {
        [DisplayName("Mã thành viên")]
        public string PqcMemberId { get; set; } = string.Empty;

        [DisplayName("Tên tài khoản")]
        public string PqcUserName { get; set; } = string.Empty;

        [DisplayName("Mật khẩu")]
        public string PqcPassword { get; set; } = string.Empty;

        [DisplayName("Họ và tên")]
        public string PqcFullName { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string PqcEmail { get; set; } = string.Empty;
    }
}
