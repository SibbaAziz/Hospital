using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> Employees { get; set; }
        public IList<PlanningUnit> PlanningUnits { get; set; }
    }
}
