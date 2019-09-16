namespace Hospital.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override bool Equals(object obj)
        {
            var employee = obj as Employee;
            if (employee == null)
                return false;
            return Id == employee.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
