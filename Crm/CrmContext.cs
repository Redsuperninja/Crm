using Microsoft.EntityFrameworkCore;
using Crm.Entities;

namespace Crm;

public class CrmContext : DbContext
{
    public CrmContext(DbContextOptions<CrmContext> options) : base(options)
    {
    }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}