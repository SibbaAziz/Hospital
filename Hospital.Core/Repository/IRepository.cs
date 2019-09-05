using System.Collections.Generic;
using Hospital.Core.Models;

namespace Hospital.Core.Repository
{
    public interface IRepository
    {
        IList<Department> GetDepartments();
        IList<Employee> GetEmployees();
        IList<Service> GetServices();
    }
}
