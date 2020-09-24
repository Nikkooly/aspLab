﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using lab4.Models;

namespace lab4.Context
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("PhoneCatalog")
        { }

        public DbSet<PhoneBook> Contacts { get; set; }
    }
}