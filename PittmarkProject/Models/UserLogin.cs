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
        public string UserName { get; set; }
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }
        public bool SavePassWork { get; set; }
    }
}