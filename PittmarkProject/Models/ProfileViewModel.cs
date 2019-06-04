using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PittmarkProject.Models
{
    public class ProfileViewModel
    {
        public string ImgLogo { get; set; }
        public string ImgCover { get; set; }
        public List<string> EmailList { get; set; }
        public List<string> PhoneNumberList { get; set; }
        public List<string> AddressList { get; set; }
        public List<string> FaceBook { get; set; }

        public List<SanPham> ProductList { get; set; }

        public List<SanPhamTrungBay> DisplayProductList { get; set; }
    }
}