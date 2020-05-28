using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Filters;

namespace WebApplication.Controllers
{
    public class AResearchController : Controller
    {
        // GET: AResearch
        public ActionResult Index()
        {
            return View();
        }

        [MyActionFilter]
        public ActionResult AA(int? id)
        {
            Response.Write("<div class=\"container\"><h2>Action AA: (id = " + id.Value + ")</h2></div>");
            return View("Index");
        }

        [MyResultFilter]
        public ActionResult AR()
        {
            Response.Write("<div class=\"container\"><h2>Action AR</h2></div>");
            return View("Index");
        }

        [MyExceptionFilter]
        public ActionResult AE()
        {
            throw new Exception("Help i wan't to sleep");
        }
    }
}