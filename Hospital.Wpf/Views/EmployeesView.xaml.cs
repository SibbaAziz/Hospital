using System.Windows.Controls;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour Employees.xaml
    /// </summary>
    public partial class EmployeesView : UserControl
    {
        [Dependency]
        public EmployeesViewModel ViewModel
        {
            set => DataContext = value;
        }

        public EmployeesView()
        {
            InitializeComponent();
        }
    }
}
