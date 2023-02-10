using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace WEBUI.Controllers
{
    public class LoginController:Controller
    {
        AppUserRepository _aRep;
        public LoginController()
        {
            _aRep = new AppUserRepository();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            AppUser user = _aRep.FirstOrDefault(x => x.UserName == appUser.UserName);

            if(user==null)
            {
                ViewBag.NoAssignedUser = "User cannot be found";
                return View();
            }
            //todo crypto class need to be corrected
            bool isValidPassword = Crypto.VerifyPassword(appUser.Password, user.Password);

            if (isValidPassword && user.Role==Project.ENTITIES.Enums.UserRole.Admin)
            {
                Session["admin"] = user;
                return RedirectToAction("AppUserList", "AppUser", new { Area = "Administration" });
            }
            else if(isValidPassword && user.Role==Project.ENTITIES.Enums.UserRole.BranchManager)
            {
                Session["manager"] = user;
                return RedirectToAction("AppUserList", "AppUser", new { Area = "Administration" });
            }

            else if(isValidPassword && user.Role==Project.ENTITIES.Enums.UserRole.SalesPerson)

            {
                Session["sale"] = user;
                return RedirectToAction("ProductList", "Product", new { Area = "Administration" });
            }
            else if(isValidPassword && user.Role==Project.ENTITIES.Enums.UserRole.StockPerson)
            {
                Session["ware"] = user;
                return RedirectToAction("ProductList", "Product", new { Area = "Administration" });
            }
            else if(isValidPassword && user.Role==Project.ENTITIES.Enums.UserRole.AccountingPerson)
            {
                Session["accounter"] = user;
                return RedirectToAction("ExpenseList", "Expense", new { Area = "Administration" });
            }
            else if(isValidPassword &&user.Role==Project.ENTITIES.Enums.UserRole.TechnicService)
            {
                Session["tech"] = user;
                return RedirectToAction("issueList", "Issue", new { Area = "Administration" });
            }
            else if(isValidPassword &&user.Role== Project.ENTITIES.Enums.UserRole.MobileSalePerson)
            {
                Session["mobileSale"] = user;
                return RedirectToAction("ShoppingList", "Shopping");
            }
            else if(isValidPassword &&user.Role==Project.ENTITIES.Enums.UserRole.Member)
            {
                if(!user.Active)
                {
                    return ActiveChecking();
                }
                Session["member"] = user;
                return RedirectToAction("ShoppingList", "Shopping");
            }
            ViewBag.NoAssignedUser = "User cannot be found";
            return View();
        }

        public ActionResult ActiveChecking()
        {
            ViewBag.NotActive = "Your account is not active, Please double check the Activation Email";
            return View("Login");
        }
    }
}