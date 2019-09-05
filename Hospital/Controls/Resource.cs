using GalaSoft.MvvmLight;
using Hospital.Models;

namespace Hospital.Controls
{
    public class Resource : ViewModelBase
    {
        public Employee Employee { get; set; }
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                Employee.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        private bool _isEditMode;
        private string _name;
        private string _job;
        private int _id;
        private bool _isPresent;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Employee.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Job
        {
            get => _job;
            set
            {
                _job = value;
                Employee.Job = value;
                RaisePropertyChanged(nameof(Job));
            }
        }


        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = value;
                RaisePropertyChanged(nameof(IsEditMode));
            }
        }

        public bool IsPresent
        {
            get => _isPresent;
            set { _isPresent = value; RaisePropertyChanged(nameof(IsPresent));}
        }

        public override string ToString()
        {
            return $"{Name} - {Job}";
        }

        public Resource()
        {
            IsEditMode = true;
            Employee = new Employee();
        }
    }
}
