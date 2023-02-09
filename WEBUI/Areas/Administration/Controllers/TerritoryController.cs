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
    [ManagerAuthentication]
    public class TerritoryController:Controller
    {
        TerritoryRepository _tRep;

        public TerritoryController()
        {
            _tRep = new TerritoryRepository();
        }

        public ActionResult TerritoryList(int? id)
        {
            TerritoryVM tvm = id == null ? new TerritoryVM
            {
                Territories = _tRep.GetActives()
            } : new TerritoryVM
            {
                Territories = _tRep.Where(x => x.ID == id)
            };
            return View(tvm);
        }
        public ActionResult AddTerritory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTerritory(Territory territory)
        {
            _tRep.Add(territory);
            return RedirectToAction("TerritoryList");
        }
        public ActionResult UpdateTerritory(int id)

        {
            TerritoryVM tvm = new TerritoryVM
            {
                Territory = _tRep.Find(id)
            };
            return View(tvm);

        }
        [HttpPost]
        public ActionResult UpdateTerritory(Territory territory)
        {
            _tRep.Update(territory);
            return RedirectToAction("TerritoryList");
        }
        public ActionResult DeleteTerritory(int id)
        {
            _tRep.Delete(_tRep.Find(id));
            return RedirectToAction("TerritoryList");
        }


    }
}