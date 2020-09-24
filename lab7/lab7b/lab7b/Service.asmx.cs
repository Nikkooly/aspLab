using PhoneRepository;
using PhoneRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace lab7b
{
    /// <summary>
    /// Сводное описание для Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        PhonesRepository repository;
        public Service()
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
