using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Entities;

namespace Crm.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Delete(int id);
        IEnumerable<Contact> GetAll();
        Contact? GetById(int id);
        void Update(int id, Contact contact);
    }

    public class ContactRepository(CrmContext crmContext) : IContactRepository
    {
        public IEnumerable<Contact> GetAll()
        {
            return crmContext.Contacts;
        }

        public Contact? GetById(int id)
        {
            return crmContext.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Contact contact)
        {
            crmContext.Contacts.Add(contact);
            crmContext.SaveChanges();
        }

        public void Update(int id, Contact contact)
        {
            var existingContact = crmContext.Contacts.FirstOrDefault(c => c.Id == id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                crmContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var contact = crmContext.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                crmContext.Contacts.Remove(contact);
                crmContext.SaveChanges();
            }
        }
    }
}