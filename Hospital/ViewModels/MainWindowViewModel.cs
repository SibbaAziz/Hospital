using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Controls;
using Hospital.Models;
using Hospital.Repository;
using Unity;

namespace Hospital.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowModel
    {
        private Service _selectedService;
        public List<Resource> Resources { get; set; }
        public List<Service> Services { get; set; }

        public ICommand ValidateCommand { get; set; }  

        public Service SelectedService
        {
            get => _selectedService;
            set { _selectedService = value; RaisePropertyChanged(nameof(SelectedService)); }
        }

        public MainWindowViewModel(IRepository repository)
        {
            ValidateCommand = new RelayCommand<PlaningControl>(Validate, (c) => SelectedService != null);
            Resources = repository.GetResources().ToList();
            Services = repository.GetServices().ToList();
        }

        private void Validate(PlaningControl planingControl)
        {
            planingControl.ExecuteCommand.Execute(SelectedService);
        }
    }

    public interface IMainWindowModel
    {

    }
}
