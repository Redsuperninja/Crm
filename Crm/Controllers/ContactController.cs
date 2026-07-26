using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crm.Entities;
using Crm.Repositories;

namespace Crm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController(IContactRepository contactRepository) : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<Contact> Get()
        {
            return contactRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Contact? Get(int id)
        {
            return contactRepository.GetById(id);
        }

        [HttpPost("")]
        public void Add(Contact contact)
        {
            contactRepository.Add(contact);
        }
        [HttpPut("{id}")]
        public void Update(int id, Contact contact)
        {
            contactRepository.Update(id, contact);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            contactRepository.Delete(id);
        }
    }
}