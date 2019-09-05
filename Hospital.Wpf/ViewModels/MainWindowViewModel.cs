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
        private Service _selectedService;
        private List<Resource> _resources;

        public List<Resource> Resources
        {
            get => _resources;
            set { _resources = value; RaisePropertyChanged(nameof(Resources)); }
        }

        public List<Service> Services { get; set; }

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
            
            Services = repository.GetServices().ToList();
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
