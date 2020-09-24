using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab8.Models;

namespace lab8.Controllers
{
    public class HomeController : Controller
    {
        public IDictionary dictionary;
        TelephoneBookContext db;
        public HomeController(IDictionary context)
        {
            dictionary = context;
        }
        public IActionResult Index()
        {
            ViewBag.PhoneBook = dictionary.GetData();
            return View();
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            ViewBag.Id =id;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSave(Guid id)
        {
            dictionary.Delete(id);
            ViewBag.PhoneBook = dictionary.GetData();
            return View("Index");
        }
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            ViewBag.Id = id;
            ViewBag.PhoneBook = dictionary.GetData();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(Guid id, string name, string phones)
        {
            dictionary.Update(id, name, phones);
            ViewBag.PhoneBook = dictionary.GetData();
            return View("Index");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(string name, string phones)
        {
             dictionary.Add(name, phones);
            ViewBag.PhoneBook = dictionary.GetData();
             return View("Index");
        }
    }
}
