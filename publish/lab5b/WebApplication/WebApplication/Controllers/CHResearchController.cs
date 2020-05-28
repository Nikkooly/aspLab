using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CHResearchController : Controller
    {

        private static int counter = 0;
        private static int counter2 = 0;

        // GET: CHResearch
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [OutputCache (Duration = 5)]
        public ActionResult AD()
        {
            //Response.Write("<div class=\"container\"><h3>This text will be deleted in <strong>5 seconds</strong></h3></div>");
            Response.Write("<div class=\"container\"><h3>Counter <strong>"+ ++counter +"</strong></h3></div>");
            return View("Index");
        }

        [HttpPost]
        [OutputCache(Duration = 7)]
        public ActionResult AP(int x, int y)
        {
            //Response.Write("<div class=\"container\"><h3>This text will be deleted in <strong>7 seconds</strong></h3></div>");
            Response.Write("<div class=\"container\"><h3>Counter  <strong>" + ++counter2 +" Result " + (x+y+counter2)+ "</strong></h3></div>");
            return View("Index");
        }
    }
}