using mvcBuiko;
using mvcBuiko.Helpers;
using PhoneRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace PhoneRepository
{
    public class PhonesRepository : IPhoneDictionary, IDisposable
    {
        string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        ContactContext context;
        JsonHelper jsonHelper;
        public PhonesRepository()
        {
            context = new ContactContext();
            jsonHelper = new JsonHelper(path + "contacts.json");
        }
        public void add(Contact contact)
        {
            context.Contacts.Add(contact);
            saveChanges();
        }

        public void delete(int? id)
        {
            Contact contact = context.Contacts.Find(id);
            context.Contacts.Remove(contact);
            saveChanges();
        }

        public List<Contact> getAll()
        {
            return context.Contacts.ToList();
        }

        public Contact getById(int? id)
        {
            return context.Contacts.Find(id);
        }

        public void update(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;
            saveChanges();
        }

        private void saveChanges()
        {
            context.SaveChanges();
            //jsonHelper.updateFile(getAll());
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
