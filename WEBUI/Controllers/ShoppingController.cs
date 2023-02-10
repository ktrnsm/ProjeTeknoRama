using PagedList;
using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.AuthenticationClasses;
using WEBUI.Models.ShoppingTools;
using WEBUI.VMClasses;

namespace WEBUI.Controllers
{
    public class ShoppingController:Controller
    {
        OrderRepository _orderRep;
        OrderDetailRepository _orderdetailRep;
        ProductRepository _proRep;
        CategoryRepository _catRep;


        public ShoppingController()
        {
            _proRep = new ProductRepository();
            _catRep = new CategoryRepository();
            _orderdetailRep = new OrderDetailRepository();
            _orderRep = new OrderRepository();
        }
        public ActionResult ShoppingList(int? page, int? categoryID)
        {
            PaginationVM pavm = new PaginationVM
            {
                PagedProducts = categoryID == null ? _proRep.GetActives().ToPagedList(page ?? 1, 9) : _proRep.Where(x => x.CategoryID ==categoryID).ToPagedList(page ?? 1,9),
                Categories=_catRep.GetActives()
            };
            if (categoryID != null) TempData["catID"] = categoryID;
            return View(pavm);
        }

        public ActionResult AddToCart(int id)
        {
            Card card = Session["scart"] == null ? new Card() : Session["scart"] as Card;
            Product productToAdd = _proRep.Find(id);

            CardItem cardItem = new CardItem
            {
                ID = productToAdd.ID,
                Name=productToAdd.ProductName,
                Price = productToAdd.UnitPrice,
                ImagePath = productToAdd.ImangePatch
            };
            card.AddToCard(cardItem);

            Session["count"] = card.ProductCount();
            Session["scart"] = card;

            return RedirectToAction("ShoppingList");

        }

        public ActionResult CardPage()
        {
            if (Session["scart"] != null)
            {
                CardPageVM cpvm = new CardPageVM();
                Card card = Session["scart"] as Card;
                cpvm.Card = card;
                return View(cpvm);

            }
            TempData["CardIsEmpty"] = "There is no Product in your Basket";
            return RedirectToAction("ShoppingList");
                }

        public ActionResult DeleteFromCard(int id)
        {
            if (Session["scart"]!=null)
            {
                Card card = Session["scart"] as Card;
                card.RemoveFromCard(id);
                Session["coount"] = card.ProductCount();

                if(card.MyBasket.Count==0)
                {
                    Session.Remove("scart");
                    TempData["CardIsEmpty"] = "There is no Product in your Basket";
                    return RedirectToAction("ShoppingList");
                }
                return RedirectToAction("CardPage");
            }
            return RedirectToAction("ShoppingList");

        }
        [HttpPost]
        public ActionResult ConfirmOrder(OrderVM ovm)
        {
            bool result;
            Card card = Session["scart"] as Card;
            ovm.Order.TotalPrice = ovm.PaymentDTO.ShoppingPrice = card.TotalCost;
        }

        [MemberAuthentication]
        public ActionResult OrderList()
        {
            return View();
        }

    }
}