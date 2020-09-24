using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Models
{
    public interface IContacts
    {
        DbSet<PhoneBook> PhoneBook { get; set; }

        int SaveDbChanges();
    }
}
