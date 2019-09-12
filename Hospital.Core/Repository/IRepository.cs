using System;
using System.Collections.Generic;
using Hospital.Core.Helpers;
using Hospital.Core.Models;

namespace Hospital.Core.Repository
{
    public interface IRepository
    {
        IList<Department> GetDepartments();
        IList<Employee> GetEmployees();
        IList<Service> GetServices();
        IList<PlanningUnit> GetPlanningUnit(int serviceId, DateRange dateRange);
        bool SavePlanning(int serviceId, IEnumerable<PlanningUnit> planningUnits);
        bool SaveEmployee(int serviceId, Employee employee);
        IList<string> GetJobs();
    }
}
