using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Entities;
using Crm.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayrollController(IPayrollRepository payrollRepository) : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<Payroll> Get()
        {
            return payrollRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Payroll? Get(int id)
        {
            return payrollRepository.GetById(id);
        }

        [HttpPost("")]
        public void Add(Payroll payroll)
        {
            payrollRepository.Add(payroll);
        }

        [HttpPut("{id}")]
        public void Update(int id, Payroll payroll)
        {
            payrollRepository.Update(id, payroll);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            payrollRepository.Delete(id);
        }
    }
}