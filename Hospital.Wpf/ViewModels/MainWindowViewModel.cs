using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Wpf.Controls;

namespace Hospital.Wpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowModel
    {
        private readonly IRepository _repository;

        public List<Department> Departments { get; set; }

        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                _selectedDepartment = value;
                Services = SelectedDepartment.Services.ToList();
                RaisePropertyChanged(nameof(SelectedDepartment));
            }
        }

        private Service _selectedService;
        private List<Resource> _resources;
        private Department _selectedDepartment;
        private List<Service> _services;

        public List<Resource> Resources
        {
            get => _resources;
            set { _resources = value; RaisePropertyChanged(nameof(Resources)); }
        }

        public List<Service> Services
        {
            get => _services;
            set { _services = value; RaisePropertyChanged(nameof(Services)); }
        }

        public ICommand ValidateCommand { get; set; }  

        public Service SelectedService
        {
            get => _selectedService;
            set { _selectedService = value; RaisePropertyChanged(nameof(SelectedService)); }
        }

        public MainWindowViewModel(IRepository repository)
        {
            _repository = repository;
            ValidateCommand = new RelayCommand<PlaningControl>(Validate, (c) => SelectedService != null);
            
            Departments = repository.GetDepartments().ToList();
        }

        private void Validate(PlaningControl planingControl)
        {
            Resources = SelectedService.Employees.Select(e => new Resource(e)).ToList();
            planingControl.ExecuteCommand.Execute(SelectedService);
        }
    }

    public interface IMainWindowModel
    {

    }
}
