using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.AuthenticationClasses;
using WEBUI.Models.Currency;
using WEBUI.VMClasses;

namespace WEBUI.Areas.Administration.Controllers
{
    [ManagerAuthentication, WareAuthentication, SalesAuthentication]
    public class ProductController:Controller
    {

        ProductRepository _pRep;
        CategoryRepository _cRep;
        SupplierRepository _sRep;

        public ProductController()
        {
            _pRep = new ProductRepository();
            _cRep = new CategoryRepository();
            _sRep = new SupplierRepository();
        }

        public ActionResult ProductDetail(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Products = _pRep.Where(x=>x.ID==id)
            };
            return View(pvm);
        }

        public ActionResult ProductList(int? id)
        {
            ProductVM pvm = new ProductVM
            {
                Products = id==null? _pRep.GetActives():_pRep.Where(x=>x.CategoryID==id)
            };

            Currency c = new Currency();
            ViewBag.EuroSll = c.EuroSll;
            ViewBag.EuroBy = c.EuroBy;
            ViewBag.DolarSll = c.DolarSll;
            ViewBag.DolarBy = c.DolarBy;
            return View(pvm);
        }

        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
            Product= new Product(),
            Categories=_cRep.GetActives(),
            Suppliers=_sRep.GetActives()
            // there is a problem here
            };
            return View(pvm);
        }


    }
}