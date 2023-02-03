using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.ENTITIES.Models;
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
        
        [HttpPost]
        public ActionResult AddExpense(Expense expense)
        {
            _eRep.Add(expense);
            return RedirectToAction("ExpenseList");
        }
        public ActionResult UpdateExpense(int id)
        {
            ExpenseVM evm = new ExpenseVM
            {
                Expense=_eRep.Find(id)
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult UpdateExpense(Expense expense)
        {
            ;_eRep.Update(expense);
            return RedirectToAction("ExpenseList");
        }
        public ActionResult DeleteExpense(int id)
        {
            _eRep.Delete(_eRep.Find(id));
            return RedirectToAction("ExpenseList");
        }

        
    }
}