using System.Windows.Controls;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour PlanningView.xaml
    /// </summary>
    public partial class PlanningView
    {
        [Dependency]
        public PlanningViewModel ViewModel
        {
            set => DataContext = value;
        }

        public PlanningView()
        {
            InitializeComponent();
        }
    }
}
