using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Hospital.Core.Helpers;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Data.Data;

namespace Hospital.Data.Repositories
{
    public class SqlServerRepository : IRepository
    {
        public IList<Department> GetDepartments()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Departments.Include("Services").Include("Employees").ToList();
            }
        }

        public IList<Employee> GetEmployees()
        {
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Employee>));

            // Declare an object variable of the type to be deserialized.
            List<Employee> result;

            using (Stream reader = new FileStream("Data/data.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                result = (List<Employee>)serializer.Deserialize(reader);
            }

            return result;

        }

        public IList<Service> GetServices()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Services.Include("Employees").ToList();
            }
        }

        public IList<PlanningUnit> GetPlanningUnit(int serviceId, DateRange dateRange)
        {
            throw new System.NotImplementedException();
        }

        public bool SavePlanning(int serviceId, IEnumerable<PlanningUnit> planningUnits)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveEmployee(int serviceId, Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public IList<string> GetJobs()
        {
            throw new System.NotImplementedException();
        }
    }
}
