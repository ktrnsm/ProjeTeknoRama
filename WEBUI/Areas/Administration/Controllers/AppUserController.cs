using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBUI.Areas.Administration.Controllers
{
   
    public class AppUserController:Controller
    {
        AppUserRepository _aRep;

        public AppUserController()
        {
            _aRep = new AppUserRepository();
        }

        

    }
}