using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Services;
using System.Text.Json;
using PhoneRepository;
using PhoneRepository.Models;

namespace ASMX
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        PhonesRepository repository;
        public WebService1()
        {
            repository = new PhonesRepository();
        }

        [WebMethod]
        public List<Contact> GetDist()
        {
            return repository.getAll();
        }

        [WebMethod]
        public string AddDict(Contact contact)
        {
            repository.add(contact);
            return "Success added";
        }

        [WebMethod]
        public string UpdDict(Contact contact)
        {
            repository.update(contact);
            return "Success updated";
        }

        [WebMethod]
        public string DelDict(Contact contact)
        {
            repository.delete(contact.Id);
            return "Success deleted";
        }
    }
}
