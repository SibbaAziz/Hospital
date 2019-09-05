using System.Data.Entity;
using Hospital.Core.Models;

namespace Hospital.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PlanningUnit> PlanningUnits { get; set; }
    }
}
