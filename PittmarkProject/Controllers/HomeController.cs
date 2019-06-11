using Pittmark.Dao;
using PittmarkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PittmarkProject.Controllers
{
    public class HomeController : Controller
    {
        private DaoClientScreen _daoClientScreen;
        public HomeController()
        {
         
            _daoClientScreen = new DaoClientScreen();
        }
        public ActionResult Index()
        {
            ProfileViewModel profileViewModel = new ProfileViewModel();

            var lstAddress = _daoClientScreen.GetAddresses();
            var lstEmail = _daoClientScreen.GetEmails();
            var lstFacebooks = _daoClientScreen.GetFacebooks();
            var lstPhoneNumbers = _daoClientScreen.GetPhoneNumbers();
            var profile = _daoClientScreen.GetProfiles();

            profileViewModel.AddressList = lstAddress.Select(x => x.Name).ToList();
            profileViewModel.EmailList = lstEmail.Select(x => x.Name).ToList();
            profileViewModel.FaceBook = lstFacebooks.Select(x => x.Name).ToList();
            profileViewModel.PhoneNumberList = lstPhoneNumbers.Select(x => x.Name).ToList();
            profileViewModel.ImgCover = profile.Img_cover;
            profileViewModel.ImgLogo = profile.Img_logo;
            profileViewModel.ProductList = _daoClientScreen.GetProducts().ToList();
            profileViewModel.DisplayProductList = _daoClientScreen.GetDisplayProducts().ToList();
            return View(profileViewModel);
        }
    }
}