using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PittmarkProject.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string EnterNewPassword { get; set; }
    }
}