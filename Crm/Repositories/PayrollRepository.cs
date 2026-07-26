using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Entities;

namespace Crm.Repositories
{
    public interface IPayrollRepository
    {
        void Add(Payroll payroll);
        void Delete(int id);
        IEnumerable<Payroll> GetAll();
        Payroll? GetById(int id);
        void Update(int id, Payroll payroll);
    }

    public class PayrollRepository(CrmContext crmPayroll) : IPayrollRepository
    {
        public IEnumerable<Payroll> GetAll()
        {
            return crmPayroll.Payrolls;
        }
        public Payroll? GetById(int id)
        {
            return crmPayroll.Payrolls.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Payroll payroll)
        {
            crmPayroll.Payrolls.Add(payroll);
            crmPayroll.SaveChanges();
        }
        public void Update(int id, Payroll payroll)
        {
            var existingPayroll = crmPayroll.Payrolls.FirstOrDefault(p => p.Id == id);
            if (existingPayroll != null)
            {
                existingPayroll.EmployeeFirstName = payroll.EmployeeFirstName;
                existingPayroll.EmployeeLastName = payroll.EmployeeLastName;
                existingPayroll.Salary = payroll.Salary;
                crmPayroll.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var payroll = crmPayroll.Payrolls.FirstOrDefault(p => p.Id == id);
            if (payroll != null)
            {
                crmPayroll.Payrolls.Remove(payroll);
                crmPayroll.SaveChanges();
            }
        }
    }
}