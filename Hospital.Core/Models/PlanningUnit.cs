using System;
using System.Collections.Generic;

namespace Hospital.Core.Models
{
    public class PlanningUnit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
