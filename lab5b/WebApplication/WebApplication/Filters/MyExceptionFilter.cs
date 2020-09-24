using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Filters
{
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        { 
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Write("<div class=\"container\"><h3>(InvalidOperationException)</h3></div>");
                filterContext.HttpContext.Response.Write($"<p>EXCEPTION filter: {filterContext.Exception.Message}</p>");

        }
    }
}