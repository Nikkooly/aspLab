using lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8
{
    public class DefaultContacts
    {
        public static void Initialize(TelephoneBookContext context)
        {
            if (!context.PhoneBook.Any())
            {
                context.PhoneBook.AddRange(
                    new PhoneBook
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kolya Yarmolik",
                        Phone = "+37502556265"
                    },
                     new PhoneBook
                     {
                         Id = Guid.NewGuid(),
                         Name = "Kolya Yarmolik 2",
                         Phone = "+37502556265"
                     },
                    new PhoneBook
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kolya Yarmolik 3",
                        Phone = "+37502556265"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
