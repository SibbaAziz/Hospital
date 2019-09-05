using System.Collections.Generic;
using Hospital.Models;

namespace Hospital.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hospital.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hospital.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var manager = new Employee() {Id = 1, Name = "Aziz", Job = "LMLM"};
            context.Employees.AddOrUpdate(manager);

            var service = new Service(){ Id = 1, Name = "Consultation Externe de Gynécologie", Manager = manager };
            var service2 = new Service() { Id = 2, Name = "Bloc de Chirurgie Gynécologique", Manager = manager };
            context.Services.AddOrUpdate(service);
            context.Services.AddOrUpdate(service2);

            context.Departments.AddOrUpdate(new Department(){Id = 1, Name = "Gynéco-obstétrique", Manager = manager, Services = new List<Service>(){service, service2}});
        }
    }
}
