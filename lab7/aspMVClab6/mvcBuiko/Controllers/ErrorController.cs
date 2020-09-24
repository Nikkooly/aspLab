using mvcBuiko.Models.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcBuiko.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            errorViewModel.Method = Request.HttpMethod;
            errorViewModel.Url = Request.Url.ToString();
            return View(errorViewModel);
        }
    }
}