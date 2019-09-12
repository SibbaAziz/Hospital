using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Caching;
using Hospital.Core.Models;
using Hospital.Core.Repository;

namespace Hospital.Wpf.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private readonly IRepository _repository;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _mobileNumber;
        public List<Service> Services { get; set; }
        public Service SelectedService { get; set; }

        public List<string> Jobs { get; set; }
        public string SelectedJob { get; set; }

        public ICommand SaveCommand { get; set; }

        public bool CanSave => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; RaisePropertyChanged(nameof(FirstName));}
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; RaisePropertyChanged(nameof(LastName));}
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
        }

        private void Save()
        {
            var employee = new Employee
            {
                Id = new Random().Next(0, int.MaxValue),
                Name = $"{LastName} {FirstName}",
                Email = Email,
                Job = SelectedJob,
                PhoneNumber = PhoneNumber
            };

            _repository.SaveEmployee(SelectedService.Id, employee);
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            MobileNumber = string.Empty;
        }
    }
}
