using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WEBUI.AuthenticationClasses;
using WEBUI.Models.Currency;
using WEBUI.VMClasses;

namespace WEBUI.Areas.Administration.Controllers
{
    [AccounterAuthentication]
    [ManagerAuthentication]
    public class ExpenseController : Controller
    {
        ExpensesRepository _eRep;

        public ExpenseController()
        {
            _eRep = new ExpensesRepository();
        }

        public ActionResult ExpenseList(int? id)
        {
            ExpenseVM evm = id == null ? new ExpenseVM
            {
                Expenses = _eRep.GetActives()
            } : new ExpenseVM { Expenses = _eRep.Where(x => x.ID == id) };

            Currency c = new Currency();
            ViewBag.EuroSll = c.EuroSll;
            ViewBag.EuroBy = c.EuroBy;
            ViewBag.DolarSll = c.DolarSll;
            ViewBag.DolarBy = c.DolarBy;

            return View(evm);

        }

        public ActionResult AddExpenses()
        {
        return View();
        }

        
    }
}