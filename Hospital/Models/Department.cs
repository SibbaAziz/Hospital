using System.Collections.Generic;
using Hospital.Controls;

namespace Hospital.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Manager { get; set; }
        public IList<Service> Services { get; set; }
    }
}
