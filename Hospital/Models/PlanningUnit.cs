using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public class PlanningUnit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Service Service { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
