using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Hospital.Core.Helpers;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Migrations;

namespace Hospital.Data.Repositories
{
    public static class Context
    {
        public static List<Service> Services = new List<Service>();
    }

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
            List<Service> services;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Service>));

            // Declare an object variable of the type to be deserialized.

            using (Stream reader = new FileStream("Data/services.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                services = (List<Service>)serializer.Deserialize(reader);
            }

            return services.SelectMany(s => s.Employees).ToList();

        }

        public bool SaveEmployee(int serviceId, Employee employee)
        {
            List<Service> services;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Service>));

            // Declare an object variable of the type to be deserialized.

            using (Stream reader = new FileStream("Data/services.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                services = (List<Service>)serializer.Deserialize(reader);
            }

            var service = services.FirstOrDefault(s => s.Id == serviceId);

            if (service == null)
            {
                service = GetServices().FirstOrDefault(s => s.Id == serviceId);
                services.Add(service);
            }

            var exit = service.Employees.FirstOrDefault(e => e.Id == employee.Id);

            if(exit == null)
            {
                service.Employees.Add(employee);
            }
            else
            {
                exit.Email = employee.Email;
                exit.Job = employee.Job;
                exit.Name = employee.Name;
                exit.PhoneNumber = employee.PhoneNumber;
            }
            
            // Create an XmlTextWriter using a FileStream.
            
            using (Stream fs = new FileStream("Data/services.xml", FileMode.Create))
            {
                using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
                {
                    serializer.Serialize(writer, services);
                }
            }
            return true;
        }

        public IList<string> GetJobs()
        {
            List<string> jobs;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<string>));

            // Declare an object variable of the type to be deserialized.

            using (Stream reader = new FileStream("Data/jobs.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                jobs = (List<string>)serializer.Deserialize(reader);
            }

            return jobs;
        }

        public IList<Service> GetServices()
        {
            List<Service> services;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Service>));

            // Declare an object variable of the type to be deserialized.

            using (Stream reader = new FileStream("Data/services.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                services = (List<Service>)serializer.Deserialize(reader);
            }

            return services;            
        }

        public IList<PlanningUnit> GetPlanningUnit(int serviceId, DateRange dateRange)
        {
            List<Service> services;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Service>));

            // Declare an object variable of the type to be deserialized.

            using (Stream reader = new FileStream("Data/data.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                services = (List<Service>)serializer.Deserialize(reader);
            }
            var service = services.FirstOrDefault(s => s.Id == serviceId);
            return service?.PlanningUnits?.Where(p => dateRange.GetStart() <= p.Date && p.Date <= dateRange.GetEnd()).ToList();
        }

        public bool SavePlanning(int serviceId, IEnumerable<PlanningUnit> planningUnits)
        {
            List<Service> services;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
                new XmlSerializer(typeof(List<Service>));

            // Declare an object variable of the type to be deserialized.

            using (Stream reader = new FileStream("Data/services.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                services = (List<Service>)serializer.Deserialize(reader);
            }

            var service = services.FirstOrDefault(s => s.Id == serviceId);

            if (service == null)
            {
                service = GetServices().FirstOrDefault(s => s.Id == serviceId);
                services.Add(service);
            }

            service.PlanningUnits = planningUnits.ToList();

            // Create an XmlTextWriter using a FileStream.
            Stream fs = new FileStream("Data/data.xml", FileMode.Create);
            XmlWriter writer =
                new XmlTextWriter(fs, Encoding.Unicode);
            // Serialize using the XmlTextWriter.
            serializer.Serialize(writer, services);
            writer.Close();
            return true;
        }
    }
}
