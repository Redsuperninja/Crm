using Crm.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
namespace Crm;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.
        builder.Services.AddDbContext<CrmContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddControllers();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
