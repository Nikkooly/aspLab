namespace PhoneRepository.Models
{
    using System.Data.Entity;

    public class ContactContext : DbContext
    {
        public ContactContext()
            : base("name=ContactContext")
        {
        }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}