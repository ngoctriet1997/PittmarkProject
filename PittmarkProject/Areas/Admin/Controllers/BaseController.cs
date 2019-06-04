using Pittmark.Common;
using Pittmark.Dao;
using PittmarkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PittmarkProject.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            DaoLogin daoLogin = new DaoLogin();
            UserLogin userLogin = new UserLogin();
            if (Request.Cookies[Pittmark.Common.Constraints.User_Login] != null)
            {
                string originUserName = Request.Cookies[Pittmark.Common.Constraints.User_Login].Value.Split('&')[0].Split('=')[1];
                string originPassword = Request.Cookies[Pittmark.Common.Constraints.User_Login].Value.Split('&')[1].Split('=')[1];
                if (daoLogin.CheckLogin(originUserName, originPassword))
                {
                    userLogin.UserName = originUserName;
                    userLogin.Password = originPassword;
                    Session[Pittmark.Common.Constraints.User_Login] = userLogin;
                    Session.Timeout = 10000;                    
                    
                    return;
                }

            }
            if (Session[Pittmark.Common.Constraints.User_Login] != null)
            {
                userLogin = (UserLogin)Session[Pittmark.Common.Constraints.User_Login];
                if (daoLogin.CheckLogin(userLogin.UserName, userLogin.Password))
                {
                    
                    return ;
                }
            }
            filterContext.Result = RedirectToAction("Index", "Login", new { area = "Admin" });
          


         
        
        }
      
    }
}