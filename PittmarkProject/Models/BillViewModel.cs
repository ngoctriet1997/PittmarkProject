using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PittmarkProject.Models
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public string Descript { get; set; }
        public int? IdProduct { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public double Price { get; set; }
        public DateTime? OrderDate { get; set; }

        public string NumberPhone { get; set; }
        public string Address { get; set; }
    }
}