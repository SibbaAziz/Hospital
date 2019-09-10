using System.Windows.Controls;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour Employees.xaml
    /// </summary>
    public partial class Employees : UserControl
    {
        [Dependency]
        public EmployeesViewModel ViewModel
        {
            set => DataContext = value;
        }

        public Employees()
        {
            InitializeComponent();
        }
    }
}
