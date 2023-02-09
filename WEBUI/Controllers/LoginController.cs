using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBUI.Controllers
{
    public class LoginController:Controller
    {
        AppUserRepository _aRep;
        public LoginController()
        {
            _aRep = new AppUserRepository();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            AppUser user = _aRep.FirstOrDefault(x => x.UserName == appUser.UserName);

            if(user==null)
            {
                ViewBag.NoAssignedUser = "User cannot be found";
                return View();
            }
            
            string decrypted = Crypto.HashPassword.

        }

    }
}