using EmployeeHandlerSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHandlerSystem.Infraestructure.Data
{
    public class EmployeeHandlerDbContext : DbContext
    {
        public EmployeeHandlerDbContext(DbContextOptions<EmployeeHandlerDbContext> options) : base(options)
        {
        }

       
    }
}
