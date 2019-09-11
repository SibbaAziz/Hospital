using System.Collections.Generic;
using System.Linq;
using Hospital.Core.Models;
using Hospital.Core.Repository;

namespace Hospital.Wpf.ViewModels
{
    public class ListOfEmployeesViewModel
    {
        public List<Employee> Employees { get; set; }

        public ListOfEmployeesViewModel(IRepository repository)
        {
            Employees = repository.GetEmployees().ToList();
        }
    }
}
