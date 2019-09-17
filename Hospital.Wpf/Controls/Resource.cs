using GalaSoft.MvvmLight;
using Hospital.Core.Models;

namespace Hospital.Wpf.Controls
{
    public class Resource : ViewModelBase
    {
        public Resource(PlanningEmployee planningEmployee)
        {
            var employee = planningEmployee.GetEmployee();
            Id = employee.Id;
            Name = employee.Name;
            Job = employee.Job;
            PhoneNumber = employee.PhoneNumber;
            Email = employee.Email;
            IsEditMode = false;
            IsPresent = !planningEmployee.IsAbsent;
            Comment = planningEmployee.Comment;
        }

        public string Email
        {
            get => _email;
            set { _email = value; RaisePropertyChanged(nameof(Email)); }
        }

        public Resource(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Job = employee.Job;
            PhoneNumber = employee.PhoneNumber;
            Email = employee.Email;
            IsEditMode = false;
            IsPresent = true;
        }

        public string Comment
        {
            get => _comment;
            set { _comment = value; RaisePropertyChanged(nameof(Comment));}
        }

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        private bool _isEditMode;
        private string _name;
        private string _job;
        private int _id;
        private bool _isPresent;
        private string _email;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Job
        {
            get => _job;
            set
            {
                _job = value;
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

        private string _phoneNumber;
        private string _comment;

        public string PhoneNumber

        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
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
        }

        public PlanningEmployee ToEmployee()
        {
            var employee = new Employee()
                {Id = Id, Name = Name, Job = Job, PhoneNumber = PhoneNumber, Email = Email};
            return new PlanningEmployee(employee){IsAbsent = !IsPresent, Comment = Comment};
        }
    }
}
