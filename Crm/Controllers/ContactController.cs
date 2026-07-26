using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crm.Entities;

namespace Crm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController(CrmContext crmContext) : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<Contact> Get()
        {
            return crmContext.Contacts;
        }

        [HttpGet("{id}")]
        public Contact? Get(int id)
        {
            return crmContext.Contacts.FirstOrDefault(c =>  c.Id == id); //?? new Contact{Email = "not found"};
        }

        [HttpPost("")]
        public void Add(Contact contact)
        {
            crmContext.Contacts.Add(contact);
            crmContext.SaveChanges();
        }
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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