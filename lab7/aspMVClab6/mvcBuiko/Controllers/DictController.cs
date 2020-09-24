using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using PhoneRepository;
using System.Web.Hosting;
using PhoneRepository.Models;

namespace mvcBuiko.Controllers
{
    public class DictController : Controller
    {
        IPhoneDictionary repository;
        public DictController(IPhoneDictionary repos)
        {
            repository = repos;
        }
        // GET: Dict
        public ActionResult Index()
        {
            return View(repository.getAll());
        }

        // GET: Dict/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = repository.getById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Dict/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Dict/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult AddSave([Bind(Include = "Phone,Surname")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                repository.add(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }
   
        // GET: Dict/Edit/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = repository.getById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Dict/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSave([Bind(Include = "Id, Phone,Surname")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                repository.update(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Dict/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = repository.getById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Dict/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSave(int id)
        {
            repository.delete(id);
            return RedirectToAction("Index");
        }
    }
}
