using Microsoft.Ajax.Utilities;
using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.VMClasses;

namespace WEBUI.Controllers
{
    public class RegisterController:Controller
    {
        AppUserRepository _apRep;
        UserProfileRepository _proRep;

        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _proRep = new UserProfileRepository();
        }

        public ActionResult RegisterNow()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult RegisterNow(AppUserVM apvm)
        {
            AppUser user = apvm.AppUser;
            UserProfile profile = apvm.UserProfile;
            user.Password = Crypto.HashPassword(user.Password);
            bool isPasswordMatch = Crypto.VerifyPassword(user.Password, user.ConfirmPassword);

            if (_apRep.Any(x=>x.UserName==user.UserName))
            {
                ViewBag.UserExists = "Please select another name, this one is already taken";
                return View();
            }
             if((_apRep.Any(x=>x.Email==user.Email)))
            {
                ViewBag.UserExists = "This email has been used, please tpye another email";
                return View();
            }
            if (!isPasswordMatch)
            {
                ViewBag.PasswordNotMatch = "Password and Confirm Password do not match";
                return View();
            }
            // add user and profile to the database if no errors are encountered
            _apRep.Add(user);
            _proRep.Add(profile);
            // todo ActivationCode Part is missing

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Activation(Guid id)
        {
            AppUser activation = _apRep.FirstOrDefault(x => x.ActivationCode == id);
            if(activation!=null)
            {
                activation.Active = true;
                _apRep.Update(activation);
                TempData["AccountIsActive"] = "Your Account has been activated";
                return RedirectToAction("Login", "Login");
            }
            TempData["AccountIsActive"] = "Account cannot be found";
            return RedirectToAction("Login", "Login");

        }
        public ActionResult RegistrationSuccessful()
        {
            return View();
        }
        

    }
}