using System;
using System.Collections.Generic;
using Hospital.Core.Helpers;

namespace Hospital.Core.Models
{
    public class PlanningUnit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Employee> Employees { get; set; }
        public DayNight DayNight { get; set; }
    }
}
