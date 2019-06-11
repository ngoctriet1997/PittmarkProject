using Pittmark.Dao;
using PittmarkProject.Areas.Admin.Models;
using PittmarkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PittmarkProject.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private DaoClientScreen _daoClientScreen;
        private DaoManageBill _daoManageBill;
        
        public HomeController()
        {
            _daoClientScreen = new DaoClientScreen();
            _daoManageBill = new DaoManageBill();
        }
        // GET: Admin/Home
        public ActionResult ManageProduct()
        {
            return View();
        }
        public ActionResult ManageDisplayProduct()
        {
            return View();
        }
        public ActionResult ManageBill()
        {
            
            return View();
        }
        public ActionResult ManageProfile()
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

            return View(profileViewModel);
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult SlideBar()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult GetUserLogin()
        {
            UserLogin userLogin = (UserLogin)Session[Pittmark.Common.Constraints.User_Login];
            return  Json(Newtonsoft.Json.JsonConvert.SerializeObject(userLogin),JsonRequestBehavior.DenyGet);
            
        }
        public ViewResult PersonalInformation()
        {
            var userLogin = (UserLogin)Session[Pittmark.Common.Constraints.User_Login];
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.UserName = userLogin.UserName;
            adminViewModel.Name = userLogin.UserName;
            return View(adminViewModel);
        }
        public ViewResult ChangePassword(AdminViewModel adminViewModel)
        {
            try
            {
                DaoLogin daoLogin = new DaoLogin();
                if (daoLogin.CheckLogin(adminViewModel.UserName, adminViewModel.OldPassword))
                {
                    if (adminViewModel.NewPassword == adminViewModel.EnterNewPassword && !string.IsNullOrEmpty(adminViewModel.EnterNewPassword))
                    {
                        DaoAdminInformation daoAdmin = new DaoAdminInformation();
                        if (daoAdmin.ChangePassword(adminViewModel.UserName, adminViewModel.NewPassword))
                        {

                            return View("PersonalInformation");
                        }
                        ModelState.AddModelError("", "Thay đổi không thành công");
                        return View("PersonalInformation");
                    }
                    ModelState.AddModelError("", "Mật khẩu không trùng nhau");
                    return View("PersonalInformation");
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                    return View("PersonalInformation");
                }
            }
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, this.GetType().Name, e.Message);
                return null;
            }
        }
        public ActionResult LogOut()
        {
            try
            {
                Session[Pittmark.Common.Constraints.User_Login] = null;
                HttpCookie userInfo = new HttpCookie(Pittmark.Common.Constraints.User_Login);
                userInfo["username"] = "";
                userInfo["password"] = "";
                Response.Cookies.Add(userInfo);
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, this.GetType().Name, e.Message);
                return null;
            }
        }
    }
}