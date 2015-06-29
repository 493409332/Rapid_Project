using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Complex.Common.Utility.Attribute
{

    public class LoginInterceptFilter: IActionFilter
    {
        #region IActionFilter 成员

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
             
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            var Request = filterContext.HttpContext.Request; 
            var Session = filterContext.HttpContext.Session;
            var Cookies = filterContext.HttpContext.Request.Cookies;

            var Url=Request.Url.AbsolutePath;
            if ( !Url.StartsWith("/Admin/AdminLogin") )
            {
                if ( Cookies["user"] != null && Session["userinfo"]==null)
                {
#warning 需要对session完善
                }
                if ( Session["userinfo"] == null && Cookies["user"] == null )
                {
                    filterContext.Result = new RedirectResult("/Admin/AdminLogin", false);
                }
            }

           
            //if (Session["userinfo"] != null) 
         //filterContext.HttpContext.Request.Url
        }

        #endregion
    }
}
