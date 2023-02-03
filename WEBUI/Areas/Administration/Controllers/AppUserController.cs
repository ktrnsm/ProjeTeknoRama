using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.AuthenticationClasses;
using WEBUI.VMClasses;

namespace WEBUI.Areas.Administration.Controllers
{
    [AdminAuthentication]
    public class AppUserController:Controller
    {
        AppUserRepository _aRep;

        public AppUserController()
        {
            _aRep = new AppUserRepository();
        }

        public ActionResult AppUserList(int? id)
        {
            AppUserVM svm = id == null ? new AppUserVM
            {
                AppUsers = _aRep.GetActives()
            } : new AppUserVM { AppUsers = _aRep.Where(x => x.ID == id) };
            return View(svm);
        }
        [HttpPost]
        public ActionResult AddAppUser(AppUser appuser)
        {
            appuser.Active = true;
            _aRep.Add(appuser);
            return RedirectToAction("AppUserList");
        }

        public ActionResult UpdateAppUser(int id)
        {
            AppUserVM svm = new AppUserVM
            {
                AppUser = _aRep.Find(id)
            };
            return View(svm);
        }
        [HttpPost]
        public ActionResult UpdateAppUser(AppUser appuser)
        {
            appuser.Active = true;
            _aRep.Update(appuser);
            return RedirectToAction("AppUserList");
        }

        public ActionResult DeleteAppUser(int id)
        {
            _aRep.Destroy(_aRep.Find(id));
            return RedirectToAction("AppUserList");
        }

        

    }
}