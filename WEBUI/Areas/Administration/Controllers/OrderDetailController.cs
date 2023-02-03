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
    public class OrderDetailController:Controller
    {

        OrderDetailRepository _odRep;
        public OrderDetailController()
        {
            _odRep = new OrderDetailRepository();
        }


        public ActionResult OrderDetailList()
        {
            OrderDetailVM odvm = new OrderDetailVM
            {
                OrderDetails = _odRep.GetActives()
            };
            return View(odvm);
        }

    }
}