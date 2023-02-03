using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.AuthenticationClasses;
using WEBUI.VMClasses;

namespace WEBUI.Areas.Administration.Controllers
{
    [ManagerAuthentication]
    public class MessageController : Controller
    {
        MessageRepository _mRep;

        public MessageController()
        {
            _mRep = new MessageRepository();
        }


        public ActionResult MessageList(int? id)
        {
            MessageVM mvm = id == null ? new MessageVM
            {
                Messages = _mRep.GetActives()
            } : new MessageVM { Messages = _mRep.Where(x => x.ID==id) };
            return View(mvm);
        }
    }
}