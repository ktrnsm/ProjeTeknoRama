using PagedList;
using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            Cart cart = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;
            Product productToAdd = _proRep.Find(id);

            CartItem cartItem = new CartItem
            {
                id = productToAdd.ID,
                Price = productToAdd.UnitPrice,
                ImagePath = productToAdd.ImangePatch
            };

        }
    }
}