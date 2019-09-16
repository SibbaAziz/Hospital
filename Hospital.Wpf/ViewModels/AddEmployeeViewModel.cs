using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Caching;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Wpf.Helpers;

namespace Hospital.Wpf.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private readonly IRepository _repository;
        private string _name;
        private string _email;
        private string _phoneNumber;
        private string _mobileNumber;
        private string _selectedJob;
        private Service _selectedService;

        public List<Service> Services { get; set; }
        public Service SelectedService
        {
            get => _selectedService;
            set
            {
                _selectedService = value;
                RaisePropertyChanged(nameof(SelectedService));
            }
        }
        private Employee _employee;

        public List<string> Jobs { get; set; }
        public string SelectedJob
        {
            get => _selectedJob;
            set
            {
                _selectedJob = value; RaisePropertyChanged(nameof(SelectedJob));
            }
        }

        public ICommand SaveCommand { get; set; }

        public bool CanSave => !string.IsNullOrEmpty(Name);

        public string Name
        {
            get => _name;
            set { _name = value; RaisePropertyChanged(nameof(Name));}
        }
                
        public string Email
        {
            get => _email;
            set { _email = value; RaisePropertyChanged(nameof(Email));}
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; RaisePropertyChanged(nameof(PhoneNumber));}
        }

        public string MobileNumber
        {
            get => _mobileNumber;
            set { _mobileNumber = value; RaisePropertyChanged(nameof(MobileNumber));}
        }

        public AddEmployeeViewModel(IRepository repository)
        {
            _repository = repository;
            SaveCommand = new RelayCommand(Save, () => CanSave);
            Services = CacheContext.GetServices().ToList();
            Jobs = CacheContext.GetJobs().ToList();
            Mediator.Instance.Register((e) => 
            {
                _employee = (Employee)e;
                Name = _employee.Name;
                Email = _employee.Email;
                SelectedJob = _employee.Job;
                PhoneNumber = _employee.PhoneNumber;
                SelectedJob = Jobs.FirstOrDefault(j => j == _employee.Job);
                SelectedService = Services.FirstOrDefault(s => s.Employees.Contains(_employee));
            }, ViewModelMessages.AskToEditEmployee);
        }

        private void Save()
        {
              var  employee = new Employee
                {
                    Id = _employee?.Id == default ? new Random().Next(0, int.MaxValue) : _employee.Id,
                    Name = $"{Name}",
                    Email = Email,
                    Job = SelectedJob,
                    PhoneNumber = PhoneNumber
                };
            

            _repository.SaveEmployee(SelectedService.Id, employee);
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            MobileNumber = string.Empty;
        }
    }
}
