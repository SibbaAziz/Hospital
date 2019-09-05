using System.ComponentModel;
using System.Windows.Controls;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour PlanningView.xaml
    /// </summary>
    public partial class PlanningView : UserControl
    {
        [Dependency]
        public IPlanningViewModel ViewModel
        {
            set => DataContext = value;
        }

        public PlanningView()
        {
            InitializeComponent();
        }
    }
}
