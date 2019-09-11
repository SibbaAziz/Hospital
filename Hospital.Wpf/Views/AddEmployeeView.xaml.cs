using System.Windows.Controls;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour AddEmployeeView.xaml
    /// </summary>
    public partial class AddEmployeeView : UserControl
    {
        [Dependency]
        public AddEmployeeViewModel ViewModel
        {
            set => DataContext = value;
        }
        public AddEmployeeView()
        {
            InitializeComponent();
        }
    }
}
