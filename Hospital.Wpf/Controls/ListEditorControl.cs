using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Core.Helpers;

namespace Hospital.Wpf.Controls
{
    public class ListEditorControl : Control
    {
        static ListEditorControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListEditorControl), new FrameworkPropertyMetadata(typeof(ListEditorControl)));
        }

        public ListEditorControl()
        {
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand<Resource>(Remove);
            RemoveAllCommand = new RelayCommand(RemoveAll);
            ValidateCommand = new RelayCommand<Resource>(Validate);
            EditCommand = new RelayCommand<Resource>(Edit);
            ObservableResources = new ObservableCollection<Resource>();
        }

        private Resource _tobeEdited;
        private void Edit(Resource resource)
        {
            resource.IsEditMode = true;
            _tobeEdited = resource;
        }

        public DayNight DayNight { get; set; }

        public DateTime Date { get; set; }

        private void Validate(Resource resource)
        {
            if(resource == null)
                return;
            resource.IsEditMode = false;
            var edit = _tobeEdited == null ? ObservableResources.FirstOrDefault(r => r.Id == 0) : ObservableResources.FirstOrDefault(r => r.Id == _tobeEdited.Id);

            if (edit != null)
            {
                edit.Id = resource.Id;
                edit.Job = resource.Job;
                edit.Name = resource.Name;
                edit.IsEditMode = resource.IsEditMode;
                edit.PhoneNumber = resource.PhoneNumber;
                edit.IsPresent = resource.IsPresent;
            }

            _tobeEdited = null;
        }

        private void RemoveAll()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Voulez-vous tout supprimer ?", "Confimez la suppression", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            { 
                ObservableResources.Clear();
            }
        }

        public ObservableCollection<Resource> ObservableResources { get; set; }

        private void Remove(Resource resource)
        {
            ObservableResources.Remove(resource);
        }

        public IList<Resource> ResourceItems
        {
            get { return (IList<Resource>)GetValue(ResourceItemsProperty); }
            set { SetValue(ResourceItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResourceItemsProperty =
            DependencyProperty.Register("ResourceItems", typeof(IList<Resource>), typeof(ListEditorControl), new PropertyMetadata(null));



        private void Add()
        {
            ObservableResources.Add(new Resource());
        }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand RemoveAllCommand { get; set; }
        public ICommand ValidateCommand { get; set; }
        public ICommand EditCommand { get; set; }
    }
}
