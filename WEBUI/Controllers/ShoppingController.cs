using PagedList;
using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
               // cpvm.Card = card; //todo
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
                Session["count"] = card.ProductCount();

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
        
        public ActionResult ConfirmOrder()
        {
            AppUser currentUser;
            if (Session["member"]!=null)
            {
                currentUser = Session["member"] as AppUser;
            }
            else
            {
                TempData["huest"] = "Please assign to proceed your order";

                return RedirectToAction("RegisterNow", "Register");
            }
            return View();
        }
        //https://localhost:39785/api/Payment/RecievePayment

        [HttpPost]
        public async Task<ActionResult> ConfirmOrderAsync(OrderVM ovm)
        {

            bool result;
            Card card = Session["scart"] as Card;
            ovm.Order.TotalPrice = ovm.PaymentDTO.ShoppingPrice = card.TotalCost;

            // API 

           
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:39785/api/");

                HttpResponseMessage output;

                try
                {
                    output = await client.PostAsJsonAsync("Payment/ReceivePayment", ovm.PaymentDTO);
                }

                catch (Exception)
                {
                    TempData["connectionDeny"] = "Banka bağlantıyı reddetti";
                    return RedirectToAction("ShoppingList");
                }

                if (output.IsSuccessStatusCode) result = true;
                else result = false;

                if (result)
                {
                    if (Session["member"] != null)
                    {
                        AppUser user = Session["member"] as AppUser;
                        ovm.Order.AppUserID = user.ID;
                        ovm.Order.UserName = user.UserName;
                    }
                    else
                    {
                        ovm.Order.AppUserID = null;
                        ovm.Order.UserName = TempData["anonim"].ToString();
                    }

                    _orderRep.Add(ovm.Order);

                    foreach (CardItem item in card.MyBasket)
                    {
                        OrderDetail od = new OrderDetail();
                        od.OrderID = ovm.Order.ID;
                        od.ProductID = item.ID;
                        od.UnitPrice = item.Price;
                        od.TotalPrice = item.SubTotal;
                        od.Quantity = item.Amount;
                        _orderdetailRep.Add(od);

                        //Stok düşme
                        Product decreaseStock = _proRep.Find(item.ID);
                        decreaseStock.UnitInStock -= item.Amount;
                        _proRep.Update(decreaseStock);
                    }

                    TempData["payment"] = "We have recieved your order";
                    EmailService.Send(ovm.Order.Email, body: $"Your order is proceeded, TotalCost is: ${ovm.Order.TotalPrice}", subject: "Order Succeeded");
                    Session["scart"] = null;
                    Session["count"] = null;
                    return RedirectToAction("ShoppingList");
                }

                else
                {
                    TempData["paymentIssue"] = "There has been a problem of recieveing payment please try again";
                    return RedirectToAction("ShoppingList");
                }
            }

          

        }
        [MemberAuthentication]
        public ActionResult OrderList()
        {
            return View();
        }

    }
}