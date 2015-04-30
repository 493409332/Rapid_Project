using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Areas.Filter
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        #region IActionFilter 成员

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (true)//filterContext.HttpContext.Request.Url )
            {
                filterContext.HttpContext.Items.Add("123","321");
            }
        }


        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

      

        #endregion
    }
}