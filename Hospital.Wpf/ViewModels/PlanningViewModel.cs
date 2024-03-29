﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Caching;
using Hospital.Core.Exporters;
using Hospital.Core.Helpers;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Wpf.Controls;
using Unity;

namespace Hospital.Wpf.ViewModels
{
    public class PlanningViewModel : ViewModelBase
    {
        private readonly IRepository _repository;

        public ICommand ValidateCommand { get; set; }
        public ICommand ExportToExcelCommand { get; set; }

        [Dependency]
        public IDataExporter DataExporter { get; set; }

        public bool IsEdited
        {
            get => _isEdited;
            set { _isEdited = value; RaisePropertyChanged(nameof(IsEdited));}
        }

        

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
        private bool _isEdited;

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

        public ICommand CreateCommand { get; set; }

        public Service SelectedService
        {
            get => _selectedService;
            set { _selectedService = value; RaisePropertyChanged(nameof(SelectedService)); }
        }

        public PlanningViewModel(IRepository repository)
        {
            _repository = repository;
            CreateCommand = new RelayCommand<PlaningControl>(Create, (c) => SelectedService != null);
            ValidateCommand = new RelayCommand<PlaningControl>(Validate);
            Services = CacheContext.GetServices().ToList();
            ExportToExcelCommand = new RelayCommand<PlaningControl>(ExportToExcel);
        }
                
        private void Validate(PlaningControl planingControl)
        {
            var planning = planingControl.Validate();
            _repository.SavePlanning(SelectedService.Id, planning);
            planingControl.IsEdited = false;
        }

        private void Create(PlaningControl planingControl)
        {
            Resources = SelectedService.Employees.Select(e => new Resource(e)).ToList();

            SelectedService.PlanningUnits = _repository.GetPlanningUnit(SelectedService.Id,
                new DateRange(planingControl.StartDate, planingControl.EndDate))?.ToList();

            planingControl.ExecuteCommand.Execute(SelectedService);
        }

        private void ExportToExcel(PlaningControl planningControl)
        {
            var planning = planningControl.Validate();
            DataExporter.Export(planning);
        }
    }
}
