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
    public class OrderController:Controller
    {
        OrderRepository _oRep;
        AppUserRepository _aRep;
        ShipperRepository _sRep;

        public OrderController()
        {
            _oRep = new OrderRepository();
            _aRep = new AppUserRepository();
            _sRep = new ShipperRepository();
        }

        public ActionResult OrderList(int? id)
        {
            OrderVM ovm = id == null ? new OrderVM
            {
                Orders = _oRep.GetActives()
            } : new OrderVM { Orders = _oRep.Where(x => x.ID == id) };
            return View(ovm);

        }



    }
}