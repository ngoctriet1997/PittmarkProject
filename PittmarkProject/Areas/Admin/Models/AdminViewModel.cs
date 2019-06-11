using Pittmark.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PittmarkProject.Areas.Admin.Models
{
    public class AdminViewModel : IValidatableObject
    {
        public string Name { get; set; }    
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [MaxLength(length: 50, ErrorMessage = "Mật khẩu quá dài chỉ giới hạn 50 ký tự")]
        [MinLength(length: 8, ErrorMessage = "Mật khẩu quá ngắn phải tối thiểu 8 ký tự")]
        public string NewPassword { get; set; }
        public string EnterNewPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(CheckUserInput.IsDangerousString(OldPassword) || CheckUserInput.IsDangerousString(NewPassword) || CheckUserInput.IsDangerousString(EnterNewPassword))
            {
                yield return new ValidationResult("Input invalid");
            }
        }
    }
}