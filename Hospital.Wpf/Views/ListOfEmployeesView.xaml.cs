using System.Windows.Controls;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour ListOfEmployeesView.xaml
    /// </summary>
    public partial class ListOfEmployeesView : UserControl
    {
        [Dependency]
        public ListOfEmployeesViewModel ViewModel
        {
            set => DataContext = value;
        }
        public ListOfEmployeesView()
        {
            InitializeComponent();
        }
    }
}
