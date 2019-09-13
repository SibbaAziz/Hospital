using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Wpf.Helpers;
using Hospital.Wpf.IoC;
using Hospital.Wpf.Views;

namespace Hospital.Wpf.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        private Control _content;
        private Control ListOfEmployees => InjectContainer.ResolveView<ListOfEmployeesView>();
        private Control AddView => InjectContainer.ResolveView<AddEmployeeView>();

        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }

        public Control Content
        {
            get => _content;
            set { _content = value;  RaisePropertyChanged(nameof(Content));}
        }

        public EmployeesViewModel()
        {
            AddCommand = new RelayCommand(Add);
            ShowCommand = new RelayCommand(Show);
            Content = ListOfEmployees;
            Mediator.Instance.Register((a) => 
            {
                Content = AddView;
                Mediator.Instance.NotifyColleagues(ViewModelMessages.AskToEditEmployee, a);
            }, ViewModelMessages.OpenEmployeeEdit);
        }

        private void Show()
        {
            Content = ListOfEmployees;
        }

        private void Add()
        {
            Content = AddView;
        }
    }
}
