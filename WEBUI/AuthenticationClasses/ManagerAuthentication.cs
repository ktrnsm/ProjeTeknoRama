using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBUI.AuthenticationClasses
{
    public class ManagerAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["manager"]!=null|| httpContext.Session["accounter"]!=null || httpContext.Session["ware"] !=null || httpContext.Session["sale"]!=null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Shopping/ShoppingList");
            return false;
        }
    }
}