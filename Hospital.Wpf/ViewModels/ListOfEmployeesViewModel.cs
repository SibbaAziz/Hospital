using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Wpf.Helpers;

namespace Hospital.Wpf.ViewModels
{
    public class ListOfEmployeesViewModel : ViewModelBase
    {
        private readonly IRepository _repository;
        private List<Employee> _employees;
        public ICommand EditCommand { get; set; }

        public List<Employee> Employees
        {
            get => _employees;
            set { _employees = value; RaisePropertyChanged(nameof(Employees));}
        }

        public ICommand RefreshCommand { get; set; }

        public ListOfEmployeesViewModel(IRepository repository)
        {
            _repository = repository;
            EditCommand = new RelayCommand<Employee>(Edit);
            RefreshCommand = new RelayCommand(Refresh);
            Employees = repository.GetEmployees().ToList();
        }

        private void Edit(Employee employee)
        {
            Mediator.Instance.NotifyColleagues(ViewModelMessages.OpenEmployeeEdit, employee);
        }

        private void Refresh()
        {
            Employees = _repository.GetEmployees().ToList();
        }
    }
}
