using Pittmark.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PittmarkProject.Areas.Admin.Models
{
    public class DisplayProductViewModel : IValidatableObject
    {
        public int id { get; set; }
        public string Name { get; set; }
        [MaxLength(length: 200000)]
        public string Image { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckUserInput.IsDangerousString(Name) )
            {
                yield return new ValidationResult("Input invalid");
            }
        }
    }
}