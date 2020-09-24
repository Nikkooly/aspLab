using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PhoneRepository;
using PhoneRepository.Models;

namespace WcfService1
{
    
    public class Service1 : IService1
    {
        private PhonesRepository repository;
        public Service1()
        {
            repository = new PhonesRepository();
        }

        public List<Contact> GetDist()
        {
            return repository.getAll();
        }

        public string AddDict(Contact contact)
        {
            repository.add(contact);
            return "Success added";
        }

        public string UpdDict(Contact contact)
        {
            repository.update(contact);
            return "Success updated";
        }

        public string DelDict(Contact contact)
        {
            repository.delete(contact.Id);
            return "Success deleted";
        }
    }
}
