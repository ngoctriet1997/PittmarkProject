using Pittmark.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PittmarkProject.Areas.Admin.Models
{
    public class ProductViewModel : IValidatableObject
    {
        public int id { get; set; }
        [MaxLength(length:256,ErrorMessage ="Độ dài chỉ giới hạn 256 ký tự")]
        public string Name { get; set; }
        [MaxLength(length: 256, ErrorMessage = "Độ dài chỉ giới hạn 256 ký tự")]
        public string Descript { get; set; }
       
        public decimal? Price { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckUserInput.IsDangerousString(Name) || CheckUserInput.IsDangerousString(Descript))
            {
                yield return new ValidationResult("Input invalid");
            }
        }
    }
}