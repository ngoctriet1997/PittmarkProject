using Pittmark.Dao;
using PittmarkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PittmarkProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            DaoLogin daoLogin = new DaoLogin();
            UserLogin userLogin = new UserLogin();
            if (Request.Cookies[Pittmark.Common.Constraints.User_Login] != null )
            {
                string originUserName = Request.Cookies[Pittmark.Common.Constraints.User_Login].Value.Split('&')[0].Split('=')[1];
                string originPassword = Request.Cookies[Pittmark.Common.Constraints.User_Login].Value.Split('&')[1].Split('=')[1];
                if (daoLogin.CheckLogin(originUserName, originPassword))
                {
                    userLogin.UserName = originUserName;
                    userLogin.Password = originPassword;
                       Session[Pittmark.Common.Constraints.User_Login] = userLogin;
                    Session.Timeout = 10000;
                    return RedirectToAction("ManageProfile", "Home");
                }

            }
            if (Session[Pittmark.Common.Constraints.User_Login] != null)
            {
                 userLogin = (UserLogin)Session[Pittmark.Common.Constraints.User_Login];
                if (daoLogin.CheckLogin(userLogin.UserName, userLogin.Password))
                {
                    return RedirectToAction("ManageProfile", "Home");
                }
            }
            return View();
        }
        //
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                DaoLogin daoLogin = new DaoLogin();
                if (daoLogin.CheckLogin(userLogin.UserName, userLogin.Password))
                {
                    Session[Pittmark.Common.Constraints.User_Login] = userLogin;
                    Session.Timeout = 10000;
                    if (userLogin.SavePassWork)
                    {
                        HttpCookie userInfo = new HttpCookie(Pittmark.Common.Constraints.User_Login);
                        userInfo["username"] = userLogin.UserName;
                        userInfo["password"] = userLogin.Password;
                        Response.Cookies.Add(userInfo);
                    }

                    return RedirectToAction("ManageProfile", "Home");
                }
                ModelState.AddModelError("", "Tài khoản và mật khẩu không hợp lệ");

            }

            return View("Index");
        }
    }
}