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
    public class EmployeeTerritoryController:Controller
    {
        EmployeeRepository _eRep;
        TerritoryRepository _tRep;
        EmployeeTerritoryRepository _etRep;

        public EmployeeTerritoryController()
        {
            _etRep = new EmployeeTerritoryRepository();
            _eRep = new EmployeeRepository();
            _tRep = new TerritoryRepository();
        }

        public ActionResult EmployeeTerritoryList()
        {
            EmployeeTerritoryVM etvm = new EmployeeTerritoryVM
            {
                EmployeeTerritories = _etRep.GetActives()
            };

            return View(etvm);
        }

        [HttpPost]
        public ActionResult AddEmployeeTerritory(EmployeeTerritory employeeTerritory)
        {
            _etRep.Add(employeeTerritory);
            return RedirectToAction("EmployeeTerritoryList");
        }

         

    }
}