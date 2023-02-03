using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBUI.AuthenticationClasses
{
    public class MemberAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["member"] !=null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Shopping/ShopiingList");
            return false;
        }
    }
}