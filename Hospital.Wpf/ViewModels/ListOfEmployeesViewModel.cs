using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Core.Models;
using Hospital.Core.Repository;

namespace Hospital.Wpf.ViewModels
{
    public class ListOfEmployeesViewModel : ViewModelBase
    {
        private readonly IRepository _repository;
        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get => _employees;
            set { _employees = value; RaisePropertyChanged(nameof(Employees));}
        }

        public ICommand RefreshCommand { get; set; }

        public ListOfEmployeesViewModel(IRepository repository)
        {
            _repository = repository;
            RefreshCommand = new RelayCommand(Refresh);
            Employees = repository.GetEmployees().ToList();
        }

        private void Refresh()
        {
            Employees = _repository.GetEmployees().ToList();
        }
    }
}
