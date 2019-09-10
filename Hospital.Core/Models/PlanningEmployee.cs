namespace Hospital.Core.Models
{
    public class PlanningEmployee
    {
        public Employee Employee { get; set; }

        public bool IsAbsent { get; set; }
        public string Comment { get; set; }

        public PlanningEmployee()
        {
            
        }
        public PlanningEmployee(Employee employee)
        {
            Employee = employee;
        }

        public Employee GetEmployee()
        {
            return Employee;
        }
    }
}
