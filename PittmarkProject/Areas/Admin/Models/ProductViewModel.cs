using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PittmarkProject.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; }
        public decimal? Price { get; set; }

    }
}