using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Entities
{
    public class Payroll
    {
        public int Id { get; set; }
        public required string EmployeeFirstName { get; set; }
        public required string EmployeeLastName { get; set; }
        public decimal Salary { get; set; }
    }
}