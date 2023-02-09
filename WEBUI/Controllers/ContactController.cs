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
    public class ContactController:Controller
    {
        IssueRepository _iRep;
        MessageRepository _mRep;

        public ContactController()
        {
            _iRep = new IssueRepository();
            _mRep = new MessageRepository();
        }
        public ActionResult AddTechIssue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTechIssue(Issue issue)
        {
            _iRep.Add(issue);
            string supportEmail = "We Have Recived your request, we will revert shortly as soon as possible";
            //todo 
            EmailService.Send(issue.Email, body: supportEmail, subject: "TeknoRama Support Team");
            return RedirectToAction("Contact", "Home");
                        
        }
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            message.MessageType = Project.ENTITIES.Enums.MessageType.Advise;
            _mRep.Add(message);

            string supportEmail = "We Have Recived your request, we will revert shortly as soon as possible";
            EmailService.Send(message.Email, body: supportEmail, subject: "TeknoRama Support Team");
            return RedirectToAction("Contact", "Home");
        }
    }
}