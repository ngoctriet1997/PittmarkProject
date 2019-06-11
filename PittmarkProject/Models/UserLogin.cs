using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PittmarkProject.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Yêu cầu nhập tài khoản")]
        [MaxLength(length: 50, ErrorMessage = "Tài khoản quá dài chỉ giới hạn 50 ký tự")]
        [MinLength(length: 8, ErrorMessage = "Tài khoản quá ngắn phải tối thiểu 8 ký tự")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        [MaxLength(length:50,ErrorMessage ="Mật khẩu quá dài chỉ giới hạn 50 ký tự")]
        [MinLength(length:8,ErrorMessage ="Mật khẩu quá ngắn phải tối thiểu 8 ký tự")]
        public string Password { get; set; }
        public bool SavePassWork { get; set; }
    }
}