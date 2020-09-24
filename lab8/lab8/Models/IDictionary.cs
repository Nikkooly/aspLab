using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Models
{
    public interface IDictionary
    {
        List<PhoneBook> GetData();
        PhoneBook GetDataById(Guid id);

        void Add(string name, string phones);

        void Update(Guid id, string name, string phones);

        void Delete(Guid id);
    }
}
