using System.Collections.Generic;
using Hospital.Core.Models;
using Hospital.Core.Repository;

namespace Hospital.Data.Repositories
{
    public class MemoryRepository : IRepository
    {
        public IList<Department> GetDepartments()
        {
            var employees = GetEmployees();
            var services = GetServices();
            return  new List<Department>()
            {
                new Department(){Id = 1, Name = "Gynéco-obstétrique", Manager = employees[0], Services = new List<Service>(){services[0]}},
                new Department(){Id = 1, Name = "Médicaux techniques", Manager = employees[0], Services = new List<Service>(){services[1]}}
            };
        }

        public IList<Employee> GetEmployees()
        {
            var manager = new Employee { Id = 1, Name = "Youssef Ruwayd Nahas", Job = "Médecin Spécialiste" , PhoneNumber = "75 684 678" };

            var employee = new Employee { Id = 2, Name = "Kutaiba Nabhan Abadi", Job = "Médecin généraliste", PhoneNumber = "77 158 551", IsAbsent = true};
            var employee1 = new Employee { Id = 3, Name = "Hazar Simah Fakhoury", Job = "Sage-femme" , PhoneNumber = "73 877 687" };
            var employee2 = new Employee { Id = 4, Name = "Nur al Din 'Asim Abboud", Job = "Technicien de surface" , PhoneNumber = "71 863 016" };
            var employee3 = new Employee { Id = 5, Name = "Ayat Johara Toma", Job = "Sage-femme" , PhoneNumber = "75 781 813" };
            var employee4 = new Employee { Id = 7, Name = "Thawab Nur al Huda Essa", Job = "Sage-femme", PhoneNumber = "75 655 982" };
            var employee5 = new Employee { Id = 8, Name = "Abdul-Muta'al Amjad Bazzi", Job = "Agent d’hygiène", PhoneNumber = "77 629 291" };

            return new List<Employee>()
            {
                manager,employee, employee1, employee2, employee3, employee4, employee5
            };

        }

        public IList<Service> GetServices()
        {
            var employees = GetEmployees();
            var service = new Service { Id = 1, Name = "Consultation Externe de Gynécologie", Manager = employees[0], Employees = new List<Employee> { employees[1], employees[2], employees[3], employees[4] } };
            var service2 = new Service() { Id = 2, Name = "Bloc de Chirurgie Gynécologique", Manager = employees[0], Employees = new List<Employee> { employees[5], employees[6] } };
            
            return new List<Service>()
            {
                service, service2
            };
        }
    }
}
