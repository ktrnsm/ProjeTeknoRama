using Project.BLL.DesignPatterns.GenericRepository.ConcRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.AuthenticationClasses;
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

    }
}