using PhoneRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneRepository
{
    public interface IPhoneDictionary
    {
        void add(Contact contact);
        void update(Contact contact);
        void delete(int? id);
        List<Contact> getAll();
        Contact getById(int? id);
    }
}
