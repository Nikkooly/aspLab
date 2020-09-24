using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Models
{
    public class Repository :IDictionary
    {
        public IContacts contacts;
        public Repository(IContacts _contacts)
        {
            contacts = _contacts;
        }
        public List<PhoneBook> GetData()
        {
            return contacts.PhoneBook.OrderBy(x => x.Name).ToList();
        }
        public PhoneBook GetDataById(Guid id)
        {
            return contacts.PhoneBook.FirstOrDefault(x => x.Id == id);
        }
        public void Add(string name, string phones)
        {
            var phone = new PhoneBook() { Id = Guid.NewGuid(), Name = name, Phone = phones};
            contacts.PhoneBook.Add(phone);
            contacts.SaveDbChanges();
        }

        public void Update(Guid id, string name, string phones)
        {
            var phone = contacts.PhoneBook.FirstOrDefault(x => x.Id == id);
            phone.Name = name;
            phone.Phone =phones;
            contacts.PhoneBook.Update(phone);
            contacts.SaveDbChanges();
        }

        public void Delete(Guid id)
        {
            var phones = GetDataById(id);
            contacts.PhoneBook.Remove(phones);
            contacts.SaveDbChanges();
        }

    }
}
