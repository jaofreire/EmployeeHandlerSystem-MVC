using Microsoft.EntityFrameworkCore;

namespace EmployeeHandlerSystem.Data
{
    public class EmployeeHandlerDbContext : DbContext
    {
        public EmployeeHandlerDbContext(DbContextOptions<EmployeeHandlerDbContext> options) : base(options)
        {
        }
    }
}
