using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using Project.COMMON.Tools;
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
        SupplierRepository _suRep;

        public ProductController()
        {
            _pRep = new ProductRepository();
            _cRep = new CategoryRepository();
            _suRep = new SupplierRepository();
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
            //Suppliers= _suRep.GetActives()
            // todo  there is a problem here
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase picture)
        {
            product.ImangePatch = ImageUpload.UploadImage("/Pictures/", picture);
            _pRep.Add(product);
            return RedirectToAction("ProductList");

        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Categories = _cRep.GetActives(),
              //  Suppliers=_suRep.GetActives(),
                // todo mistake here
                Product = _pRep.Find(id)

            };
            return View(pvm);

        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product, HttpPostedFileBase picture)
        {
            if(picture == null)
            {
                Product tempProduct = _pRep.Find(product.ID);
                product.ImangePatch = tempProduct.ImangePatch;
                
            }

            else
            {
                product.ImangePatch = ImageUpload.UploadImage("/Pictures/", picture);
            }

            _pRep.Update(product);
            return RedirectToAction("ProductList");

        }

        public ActionResult DeleteProduct(int id)
        {
            _pRep.Delete(_pRep.Find(id));
            return RedirectToAction("ProductList");
        }


    }
}